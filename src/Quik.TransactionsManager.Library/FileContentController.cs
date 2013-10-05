#region Usings

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading;

using Quik.TransactionsManager.Library.Abstraction;

#endregion

namespace Quik.TransactionsManager.Library
{
	public class FileContentController : IFileContentController
	{
		private readonly string _responsesFile;
		private readonly string _transactionsFile;

		private readonly ConcurrentQueue<string> _responsesQueue;
		private readonly ConcurrentQueue<string> _transactionsQueue;

		private CancellationTokenSource _ctsReadingThread;
		private CancellationTokenSource _ctsWritingThread;

		private StreamWriter _responsesFileStream;
		private FileSystemWatcher _watcher;

		public FileContentController(string transactionsFile, string responsesFile)
		{
			if (string.IsNullOrEmpty(transactionsFile))
			{
				throw new ArgumentNullException(transactionsFile, "Error. Empty path to the file with transactions");
			}

			if (string.IsNullOrEmpty(responsesFile))
			{
				throw new ArgumentNullException(responsesFile, "Error. Empty path to the file with transaction's responses");
			}

			if (!File.Exists(transactionsFile))
			{
				throw new FileNotFoundException("File with transaction not found", transactionsFile);
			}

			_transactionsFile = transactionsFile;
			_transactionsQueue = new ConcurrentQueue<string>();

			_responsesFile = responsesFile;
			_responsesQueue = new ConcurrentQueue<string>();
		}

		// Event for the new transactions
		public Action<List<string>> NewTransactions { get; set; }

		public void WriteTransactionResponse(string message)
		{
			if (!string.IsNullOrEmpty(message))
			{
				_responsesQueue.Enqueue(message);
			}
		}

		public void StartReadingTransactions()
		{
			_watcher = new FileSystemWatcher
			{
				Path = Path.GetDirectoryName(_transactionsFile),
				Filter = Path.GetFileName(_transactionsFile),
				EnableRaisingEvents = true
			};

			_ctsReadingThread = new CancellationTokenSource();

			var readingThread = new Thread(StartReadingTransactionsAsync);
			readingThread.Start(_transactionsFile);
		}

		public void StopReadingTransactions()
		{
			_ctsReadingThread.Cancel();
			_watcher.EnableRaisingEvents = false;
		}

		public void StartWritingResponses()
		{
			_ctsWritingThread = new CancellationTokenSource();

			_responsesFileStream = new StreamWriter(_responsesFile, true);

			var writingThread = new Thread(StartWritingResponsesAsync);
			writingThread.Start();
		}

		public void StopWritingResponses()
		{
			_ctsWritingThread.Cancel();
			_responsesFileStream.Close();
		}

		private void StartReadingTransactionsAsync(object path)
		{
			using (var fs = new FileStream(path.ToString(), FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			{
				using (var sr = new StreamReader(fs))
				{
					// Read to the end of the file to prevent from processing existing entries, we should process only new data
					sr.ReadToEnd();

					while (!_ctsReadingThread.IsCancellationRequested)
					{
						// Wait till file changed
						_watcher.WaitForChanged(WatcherChangeTypes.Changed);

						while (!sr.EndOfStream)
						{
							var line = sr.ReadLine();
							if (!string.IsNullOrEmpty(line))
							{
								_transactionsQueue.Enqueue(line);
							}
						}

						OnChanged();
					}
				}
			}
		}

		private void StartWritingResponsesAsync()
		{
			while (!_ctsWritingThread.IsCancellationRequested)
			{
				if (!_responsesQueue.IsEmpty)
				{
					string message;
					if (_responsesQueue.TryDequeue(out message))
					{
						try
						{
							_responsesFileStream.WriteLine(message);
						}
						catch (IOException ex)
						{
							throw new IOException("Writing error", ex.InnerException);
						}
					}
				}
			}
		}

		private void OnChanged()
		{
			var transactions = new List<string>();
			while (!_transactionsQueue.IsEmpty)
			{
				string transaction;
				if (_transactionsQueue.TryDequeue(out transaction))
				{
					transactions.Add(transaction);
				}
			}

			NewTransactions.Invoke(transactions);
		}
	}
}
