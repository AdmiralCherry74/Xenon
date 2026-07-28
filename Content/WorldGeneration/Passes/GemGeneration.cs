using Avalon.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Xenon.Content.Items.Placeable.Blocks.ActiveAndWiring.Lighting;
using Xenon.Content.Tiles.ActiveAndWiring.Lighting;
using Xenon.Content.Tiles.Natural.Ores.Gems;

namespace Xenon.Content.WorldGeneration.Passes
{
    public class XenonOreGeneration : ModSystem
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));

            if (ShiniesIndex != -1)
            {
                tasks.Insert(ShiniesIndex + 1, new XenonOreGenPass("XenonGemGen", 237.4298f));
            }
        }
    }
    public class XenonOreGenPass : GenPass
    {
        public XenonOreGenPass(string name, float loadWeight) : base(name, loadWeight)
        {
        }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            //Jade
            for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 6E-05); k++)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);

                // WorldGen.worldSurfaceLow is actually the highest surface tile. In practice you might want to use WorldGen.rockLayer or other WorldGen values.
                int y = WorldGen.genRand.Next((int)Main.rockLayer, Main.UnderworldLayer);

                // Then, we call WorldGen.TileRunner with random "strength" and random "steps", as well as the Tile we wish to place.
                // Feel free to experiment with strength and step to see the shape they generate.
                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), ModContent.TileType<JadeGemstoneBlock>());


                // Alternately, we could check the tile already present in the coordinate we are interested.
                // Wrapping WorldGen.TileRunner in the following condition would make the ore only generate in Snow.
                // Tile tile = Framing.GetTileSafely(x, y);
                // if (tile.HasTile && tile.TileType == TileID.SnowBlock) {
                // 	WorldGen.TileRunner(.....);
                // }
            }
            //Garnet
            for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 6E-05); k++)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);

                int y = WorldGen.genRand.Next((int)Main.rockLayer, Main.UnderworldLayer);

                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), ModContent.TileType<GarnetGemstoneBlock>());
            }
            //Lapis
            for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 6E-05); k++)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);

                int y = WorldGen.genRand.Next((int)Main.rockLayer, Main.UnderworldLayer);

                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), ModContent.TileType<LapisGemstoneBlock>());
            }
        }
    }
}

// This will be a useful mouseskatool later!
//int roiOre = ModContent.TileType<RhodiumOre>();
//if (AvalonWorld.RhodiumOre == AvalonWorld.RhodiumVariant.Osmium)
//{
//    roiOre = ModContent.TileType<OsmiumOre>();
//}
//if (AvalonWorld.RhodiumOre == AvalonWorld.RhodiumVariant.Iridium)
//{
//    roiOre = ModContent.TileType<IridiumOre>();
//}
//for (int roi = 0; roi < (int)(Main.maxTilesX * Main.maxTilesY * 0.00012); roi++)
//{
//    WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.rockLayerLow, Main.maxTilesY), WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(4, 7), roiOre);
//}