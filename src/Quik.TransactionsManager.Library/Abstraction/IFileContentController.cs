#region Usings

using System;
using System.Collections.Generic;

#endregion

namespace Quik.TransactionsManager.Library.Abstraction
{
	public interface IFileContentController
	{
		Action<List<string>> NewTransactions { get; set; }

		void WriteTransactionResponse(string message);

		void StartReadingTransactions();

		void StopReadingTransactions();

		void StartWritingResponses();

		void StopWritingResponses();
	}
}
