namespace BlackTip
{
	public enum TileType
	{
		OUT_BOUNDS	= 0,	// @ T O	= out of bounds.
		GRASS		= 1,	// . G 		= passable terrain.
		SWAMP		= 2,	// S 		= swamp (passable from regular terrain).
		WATER		= 3,	// W 		= water (traversable, but not passable from terrain).
		TYPE_COUNT	= 4
	}
}