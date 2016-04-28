using System;

namespace Utility
{
	public static class Utility
	{
		// Extends array to allow grabbig of data using a range.
		public static T[] SubArray<T>(this T[] data, int index, int length)
		{
			T[] result = new T[length];
			Array.Copy(data, index, result, 0, length);
			return result;
		}
	}
}