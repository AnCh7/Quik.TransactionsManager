namespace Quik.TransactionsManager.Library.Abstraction
{
	public interface IQuikTransactionsAdapter
	{
		object ToEntity(string transaction);

		string ToString(object message);
	}
}
