using Terraria.IO;
using Terraria.ModLoader;
using Terraria;
using Terraria.WorldBuilding;
using Xenon.Content.Tiles.Corrosion;

namespace Xenon.Content.WorldGeneration.Passes;

internal class CorrosionVines : GenPass
{
    public CorrosionVines(string name, double loadWeight) : base(name, loadWeight)
    {
    }

    protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
    {
        for (int num586 = 0; num586 < Main.maxTilesX; num586++)
        {
            int num587 = 0;
            for (int num589 = 0; num589 < Main.maxTilesY; num589++)
            {
                if (num587 > 0 && !Main.tile[num586, num589].HasTile)
                {
                    Tile t = Main.tile[num586, num589];
                    t.HasTile = true;
                    t.TileType = (ushort)ModContent.TileType<Tiles.Corrosion.CorrosionVines>();
                    num587--;
                }
                else
                {
                    num587 = 0;
                }
                if (Main.tile[num586, num589].HasTile && Main.tile[num586, num589].TileType == (ushort)ModContent.TileType<CorrosionGrass>() && !Main.tile[num586, num589].BottomSlope && WorldGen.genRand.Next(5) < 3)
                {
                    num587 = WorldGen.genRand.Next(1, 10);
                }
            }
        }
    }
}
