namespace SandTiger
{
	public abstract class Singleton<T> where T : class, new()
	{
		private static T _instance = null;

		public static T Instance ()
		{
			return _instance ?? (_instance = new T());
		}
	}
}