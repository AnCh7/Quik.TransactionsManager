#region Usings

using System;

using Quik.TransactionsManager.Library.Abstraction;
using Quik.TransactionsManager.Library.Models;

#endregion

namespace Quik.TransactionsManager.Library
{
	public class QuikTransactionsAdapter : IQuikTransactionsAdapter
	{
		private readonly string[] _fieldsDelimiter = {";"};

		private readonly string[] _pairDelimiter = {"="};

		// Convert quik transaction to entity. For example, to FIX message.
		// Override this method with needed functionality.
		public object ToEntity(string transaction)
		{
			var quikInbound = ConvertToQuikInbound(transaction);
			return ConvertToEntity(quikInbound);
		}

		// Convert entity message to quik response. For example, from FIX response.
		// Override this method with needed functionality.
		public string ToString(object message)
		{
			var quikOutbound = ConvertToQuikOutbound(message.ToString());
			return ConvertToStringResponse(quikOutbound);
		}

		private QuikInbound ConvertToQuikInbound(string transaction)
		{
			var order = new QuikInbound();
			var transactionSplitted = transaction.Trim().Split(_fieldsDelimiter, StringSplitOptions.RemoveEmptyEntries);

			var mappedFieldsAmount = 0;

			// Foreach all properties in the QuikInbound entity using reflection
			foreach (var s in transactionSplitted)
			{
				var pair = s.Trim().Split(_pairDelimiter, StringSplitOptions.RemoveEmptyEntries);
				if (pair.Length == 2)
				{
					var key = pair[0];
					var value = pair[1];
					var type = order.GetType();

					foreach (var pi in type.GetProperties())
					{
						if (pi.Name == key)
						{
							pi.SetValue(order, value);
							break;
						}
					}
				}

				mappedFieldsAmount++;
			}

			if (mappedFieldsAmount != transactionSplitted.Length)
			{
				throw new ArgumentException(
					string.Format("Amount of fields in the .tri file and amount of mapped parameters mismatch." +
								  "Quik transaction fields amount - {0}, QuikInbound fields amount - {1}",
								  transactionSplitted.Length,
								  mappedFieldsAmount));
			}

			return order;
		}

		private object ConvertToEntity(QuikInbound q)
		{
			return null;
		}

		private QuikOutbound ConvertToQuikOutbound(string message)
		{
			return new QuikOutbound();
		}

		private string ConvertToStringResponse(QuikOutbound quikOutbound)
		{
			var line = "TRANS_ID" + _pairDelimiter[0] + quikOutbound.TRANS_ID + _fieldsDelimiter[0] +
					   "STATUS" + _pairDelimiter[0] + quikOutbound.STATUS + _fieldsDelimiter[0] +
					   "TRANS_NAME" + _pairDelimiter[0] + quikOutbound.TRANS_NAME + _fieldsDelimiter[0] +
					   "DESCRIPTION" + _pairDelimiter[0] + quikOutbound.DESCRIPTION + _fieldsDelimiter[0] +
					   "ORDER_NUMBER" + _pairDelimiter[0] + quikOutbound.ORDER_NUMBER + _fieldsDelimiter[0];

			return line;
		}
	}
}
