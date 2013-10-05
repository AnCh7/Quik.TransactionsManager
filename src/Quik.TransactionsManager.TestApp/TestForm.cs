#region Usings

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

using Quik.TransactionsManager.Library;

#endregion

namespace Quik.TransactionsManager.TestApp
{
	public partial class TestForm : Form
	{
		private FileContentController _contentController;

		public TestForm()
		{
			InitializeComponent();
		}

		private void btnChooseTRI_Click(object sender, EventArgs e)
		{
			var dialog = new OpenFileDialog();
			dialog.ShowDialog();
			tbTRIPath.Text = dialog.FileName;
		}

		private void btnChooseTRO_Click(object sender, EventArgs e)
		{
			var dialog = new OpenFileDialog();
			dialog.ShowDialog();
			tbTROPath.Text = dialog.FileName;
		}

		private void btnStartGen_Click(object sender, EventArgs e)
		{
			var writingThread = new Thread(StartMessagesGenerator);
			writingThread.Start(tbTRIPath.Text);
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			_contentController = new FileContentController(tbTRIPath.Text, tbTROPath.Text);
			_contentController.StartReadingTransactions();
			_contentController.NewTransactions = PrintTransactions;

			_contentController.StartWritingResponses();
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			_contentController.StopReadingTransactions();
			_contentController.StopWritingResponses();
		}

		private void PrintTransactions(List<string> trs)
		{
			foreach (var tr in trs)
			{
				var t = tr + Environment.NewLine;

				if (rtbLog.InvokeRequired)
				{
					rtbLog.BeginInvoke(new Action(() => PrintTransactions(trs)));
					return;
				}

				rtbLog.AppendText(t);
				rtbLog.ScrollToCaret();

				_contentController.WriteTransactionResponse(t);
			}
		}

		private void StartMessagesGenerator(object filename)
		{
			while (true)
			{
				var counter = 0;
				while (true)
				{
					using (var sr = new StreamWriter(filename.ToString(), true))
					{
						var m1 = counter + " " + DateTime.Now.ToLongTimeString();
						var m2 = counter + " " + DateTime.Now.ToLongTimeString();
						var m3 = counter + " " + DateTime.Now.ToLongTimeString();
						var m4 = counter + " " + DateTime.Now.ToLongTimeString();
						var m5 = counter + " " + DateTime.Now.ToLongTimeString();

						sr.WriteLineAsync(m1);
						sr.WriteLineAsync(m2);
						sr.WriteLineAsync(m3);
						sr.WriteLineAsync(m4);
						sr.WriteLineAsync(m5);

						counter++;

						Thread.Sleep(200);
					}
				}
			}
		}
	}
}
