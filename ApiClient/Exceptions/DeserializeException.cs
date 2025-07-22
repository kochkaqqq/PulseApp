namespace ApiClient.Exceptions
{
	public class DeserializeException : Exception
	{
		public DeserializeException(string entityName, string jsonValue) : base(entityName + "\n" + jsonValue) { }
	}
}
