using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SandTiger
{
	[Serializable] public class Grid<T> : IEnumerable<T>
	{
		[SerializeField] private IVector2 _size = IVector2.zero;
		[SerializeField] private T[] _data		= null;
		[SerializeField] private T _default		= default (T);

		public void SetSize (IVector2 size, T defaultValue)
		{
			_default = defaultValue;

			if (_size == size) return;
			if (size.x < 1) throw new ArgumentException ("Size x is less than 1");
			if (size.y < 1) throw new ArgumentException ("Size y is less than 1");

			T[] oldData = _data;

			_data = Enumerable.Repeat (defaultValue, size.x * size.y).ToArray();

			if (oldData != null)
			{
				for (int ix = 0; ix < Mathf.Min (_size.x, size.x); ++ix)
				{
					for (int iy = 0; iy < Mathf.Min (_size.y, size.y); ++iy)
					{
						T oldValue = oldData[CoordToIndex (ix, iy)];

						_data[iy * size.x + ix] = oldValue;
					}
				}
			}

			_size = new IVector2 (size.x, size.y);
		}

		public int Count
		{ get { return _data.Count (t => !t.Equals (_default)); } }

		public void Clear ()
		{
			if (_data == null) return;

			for (int i = 0; i < _data.Length; ++i)
			{
				_data[i] = _default;
			}
		}

		public IVector2 Size
		{ get { return _size; } }

		public T this[int x, int y]
		{
			get
			{
				Validate (x, y);
				return _data[CoordToIndex(x, y)];
			}
			set
			{
				Validate (x, y);
				_data[CoordToIndex(x, y)] = value;
			}
		}

		public bool IsInBounds (int x, int y)
		{
			if (_data == null) throw new InvalidOperationException ("Size has not been set");
			return x >= 0 && y >= 0 && x < _size.x && y < _size.y;
		}

		public bool IsInBounds (IVector2 v)
		{
			return IsInBounds (v.x, v.y);
		}

		private int CoordToIndex (int x, int y)
		{
			return y * _size.x + x;
		}

		private void Validate (int x, int y)
		{
			if (_data == null)	throw new InvalidOperationException ("Size has not been set");
			if (x < 0)			throw new ArgumentException (string.Format ("X ({0}) is less than 0", x));
			if (x >= _size.x)	throw new ArgumentException (string.Format ("X ({0}) is greater than size x-1 ({1})", x, _size.x));
			if (y < 0)			throw new ArgumentException (string.Format ("Y ({0}) is less than 0", y));
			if (y >= _size.y)	throw new ArgumentException (string.Format ("Y ({0}) is greater than size y-1 ({1})", y, _size.y));
		}

		#region Implementation of IEnumerable

		public IEnumerator<T> GetEnumerator()
		{
			if (_data == null) return Enumerable.Empty<T>().GetEnumerator();
			return ((IEnumerable<T>) _data).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		#endregion
	}
}