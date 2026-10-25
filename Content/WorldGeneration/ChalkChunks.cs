using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Xenon.Content.Tiles.Building.BuildingStone;
using Xenon.Content.Tiles.Natural.Ores.Gems;
using Xenon.Content.Tiles.Natural.Ores.HardOres;
using Xenon.Content.WorldGeneration;

namespace Xenon.Common.Globals.XenonWorldGlobals
{
    public class ChalkChunks : ModSystem
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            GenPass currentPass;
            int index = tasks.FindIndex(genPass => genPass.Name == "Remove Broken Traps");
            if (index != -1)
            {
                currentPass = new ChalkChunkGenPass();
                tasks.Insert(index + 1, currentPass);
                totalWeight += currentPass.Weight;
            }
        }
    }
    public class ChalkChunkGenPass : GenPass
    {
        public ChalkChunkGenPass() : base("ChalkChunks", 10f)
        {
        }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 6E-05); k++)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);

                int y = WorldGen.genRand.Next((int)Main.rockLayer + 100, Main.UnderworldLayer);

                Tile tile = Framing.GetTileSafely(x, y);
                if (tile.HasTile && tile.TileType == TileID.Stone)
                {
                    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(36, 144), ModContent.TileType<ChalkBlock>());
                }
            }
        }
    }
}