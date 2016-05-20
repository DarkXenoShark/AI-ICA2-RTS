using System.Collections.Generic;
using System.Linq;

namespace SandTiger
{
	internal class Enumerator<T1, T2>
	{
		private readonly Dictionary <T1, T2> _enum = new Dictionary <T1, T2>();

		public T2 this[T1 key]
		{
			get { return _enum[key]; }
			set
			{
				_enum[key] = value;
			}
		}

		public void Add (T1 t1, T2 t2)
		{
			_enum.Add (t1, t2);
		}

		public bool Remove (T1 t1)
		{
			return _enum.Remove (t1);
		}

		public T2 GetValue (T1 t1)
		{
			return !_enum.ContainsKey (t1) ? default (T2) : _enum[t1];
		}

		// This probably doesn't work but why would you need this anyway!?!
		public T1 GetKey (T2 t2)
		{
			return !_enum.ContainsValue (t2) ? default (T1) : _enum.FirstOrDefault (x => x.Value.Equals (t2)).Key;
		}
	}
}
