using Microsoft.Xna.Framework;
using Terraria;

namespace Xenon;

public static class ClassExtensions
{
	public static Rectangle Expand(this Rectangle r, int xDist, int yDist)
	{
		r.X -= xDist;
		r.Y -= yDist;
		r.Width += xDist * 2;
		r.Height += yDist * 2;
		return r;
	}
	public static bool InPillarZone(this Player p)
	{
		if (!p.ZoneTowerStardust && !p.ZoneTowerVortex && !p.ZoneTowerSolar)
		{
			return p.ZoneTowerNebula;
		}

		return true;
	}
}
