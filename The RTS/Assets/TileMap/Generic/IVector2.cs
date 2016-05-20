using System;
using UnityEngine;

namespace SandTiger
{
	[Serializable] public class IVector2
	{
		/// <summary> X component of the vector. </summary>
		[SerializeField] public int x;
		/// <summary> Y component of the vector. </summary>
		[SerializeField] public int y;

		public int this [int index]
		{
			get { return index <= 0 ? x : y; }

			set
			{
				if (index <= 0) x = value;
				else y = value;
			}
		}

		/// <summary> Constructs a new vector with given x, y components. </summary>
		/// <param name="x"/><param name="y"/>
		public IVector2 (int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		/// <summary> Shorthand for writing IVector2 (0, 0). </summary>
		public static IVector2 zero
		{ get { return new IVector2 (0, 0); } }

		/// <summary> Shorthand for writing IVector2 (1, 1). </summary>
		public static IVector2 one
		{ get { return new IVector2 (1, 1); } }

		/// <summary> Shorthand for writing IVector2 (0, 1). </summary>
		public static IVector2 up
		{ get { return new IVector2 (0, 1); } }

		/// <summary> Shorthand for writing Vector2(0, -1). </summary>
		public static IVector2 down
		{ get { return new IVector2 (0, -1); } }

		/// <summary> Shorthand for writing IVector2 (-1, 0). </summary>
		public static IVector2 left
		{ get { return new IVector2 (-1, 0); } }

		/// <summary> Shorthand for writing IVector2I(1, 0). </summary>
		public static IVector2 right
		{ get { return new IVector2 (1, 0); } }

		public static implicit operator Vector2 (IVector2 v)
		{ 
			return new Vector2 (v.x, v.y);
		}

		public static implicit operator IVector2 (Vector2 v)
		{ 
			return new IVector2 ((int)v.x, (int)v.y);
		}

		public static IVector2 operator + (IVector2 a, IVector2 b)
		{
			return new IVector2 (a.x + b.x, a.y + b.y);
		}

		public static IVector2 operator -(IVector2 a, IVector2 b)
		{
			return new IVector2 (a.x - b.x, a.y - b.y);
		}
	
		public static IVector2 operator -(IVector2 a)
		{
			return new IVector2 (-a.x, -a.y);
		}

		public static IVector2 operator * (IVector2 a, int i)
		{
			return new IVector2 (a.x * i, a.y * i);
		}

		public static IVector2 operator * (int d, IVector2 a)
		{
			return new IVector2 (a.x * d, a.y * d);
		}

		public static IVector2 operator / (IVector2 a, int i)
		{
			return new IVector2 (a.x / i, a.y / i);
		}

		public override string ToString ()
		{
			return string.Format ("({0}, {1})", x, y);
		}

		public static implicit operator string (IVector2 v)
		{
			return v.ToString();
		}

		public bool Equals (IVector2 other)
		{
			if (ReferenceEquals (null, other)) return false;
			if (ReferenceEquals (this, other)) return true;
			return other.x == x && other.y == y;
		}

		public override bool Equals (object obj)
		{
			if (ReferenceEquals (null, obj)) return false;
			if (ReferenceEquals (this, obj)) return true;
			return obj.GetType() == typeof (IVector2) && Equals ((IVector2) obj);
		}

		public override int GetHashCode ()
		{
			unchecked { return (x * 397) ^ y; }
		}

		public static bool operator == (IVector2 left, IVector2 right)
		{
			return Equals (left, right);
		}

		public static bool operator != (IVector2 left, IVector2 right)
		{
			return !Equals (left, right);
		}

		/// <summary> Set x and y components of an existing IVector2. </summary>
		/// <param name="new_x"/><param name="new_y"/>
		public void Set (int new_x, int new_y)
		{
			x = new_x;
			y = new_y;
		}

		/// <summary> Multiplies two vectors component-wise. </summary>
		/// <param name="a"/><param name="b"/>
		public static IVector2 Scale (IVector2 a, IVector2 b)
		{
			return new IVector2 (a.x * b.x, a.y * b.y);
		}

		/// <summary> Multiplies every component of this vector by the same component of scale. </summary>
		/// <param name="scale"/>
		public void Scale (IVector2 scale)
		{
			x *= scale.x;
			y *= scale.y;
		}
	}
}