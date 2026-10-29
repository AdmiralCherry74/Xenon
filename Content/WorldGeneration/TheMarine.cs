using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Xenon.Common.Globals.XenonWorldGlobals;
using Xenon.Content.Tiles.ActiveAndWiring.Lighting;
using Xenon.Content.Tiles.Natural.OceanAndTheMarine;
using Xenon.Content.Tiles.Natural.Ores.Gems;
using Xenon.Content.WorldGeneration.Passes;

namespace Xenon.Content.WorldGeneration
{
    internal class TheMarine : ModSystem
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            GenPass currentPass;
            int index = tasks.FindIndex(genPass => genPass.Name == "Create Ocean Caves");
            if (index != -1)
            {
                currentPass = new TheMarinePass();
                tasks.Insert(index + 1, currentPass);
                totalWeight += currentPass.Weight;
            }
        }
    }
    public class TheMarinePass : GenPass
    {
        public TheMarinePass() : base("Marine", 10f)
        {
        }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = Language.GetTextValue("Mods.Xenon.Generation.UndergroundOcean");

            int xStart = 0;
            int xEnd = 0;
            if (GenVars.dungeonSide == -1)
            {
                xStart = GenVars.rightBeachStart;
                xEnd = Main.maxTilesX - 10;
            }
            else if (GenVars.dungeonSide == 1)
            {
                xStart = 10;
                xEnd = GenVars.leftBeachEnd;
            }

            for (int x = xStart; x <= xEnd; x++)
            {
                for (int y = (int)Main.worldSurface - 40; y <= GenVars.lavaLine; y++)
                {
                    if (TileID.Sets.CanBeClearedDuringOreRunner[Main.tile[x, y].TileType])
                    {
                        Main.tile[x, y].TileType = (ushort)ModContent.TileType<HardenedMarineSand>();
                    }
                }
            }
            for (int x = xStart; x <= xEnd; x++)
            {
                for (int y = (int)Main.worldSurface - 40; y <= GenVars.lavaLine; y++)
                {
                    if (x == xStart || x == xEnd)
                    {
                        if (y % 5 == 0)
                        {
                            WorldGen.TileRunner(x, y, WorldGen.genRand.Next(10, 13), WorldGen.genRand.Next(11, 14), ModContent.TileType<HardenedMarineSand>(), ignoreTileType: TileID.Grass);
                        }
                    }
                    if (y == GenVars.lavaLine)
                    {
                        if (x % 5 == 0)
                        {
                            WorldGen.TileRunner(x, y, WorldGen.genRand.Next(10, 13), WorldGen.genRand.Next(11, 14), ModContent.TileType<HardenedMarineSand>(), ignoreTileType: TileID.Grass);
                        }
                    }
                }
            }

            #region Ocean Gem Gen
            #region Tier 1 Gems
            //Amethyst
            for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 6E-05); k++)
            {

                int x1 = WorldGen.genRand.Next(0, Main.maxTilesX);

                int y1 = WorldGen.genRand.Next((int)Main.rockLayer, Main.UnderworldLayer);

                Tile tile = Framing.GetTileSafely(x1, y1);
                if (tile.HasTile && tile.TileType == ModContent.TileType<HardenedMarineSand>())
                {
                    WorldGen.TileRunner(x1, y1, WorldGen.genRand.Next(4, 6), WorldGen.genRand.Next(6, 21), TileID.Amethyst);
                }
            }

            //Jade
            for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 6E-05); k++)
            {

                int x1 = WorldGen.genRand.Next(0, Main.maxTilesX);

                int y1 = WorldGen.genRand.Next((int)Main.rockLayer, Main.UnderworldLayer);

                Tile tile = Framing.GetTileSafely(x1, y1);
                if (tile.HasTile && tile.TileType == ModContent.TileType<HardenedMarineSand>())
                {
                    WorldGen.TileRunner(x1, y1, WorldGen.genRand.Next(4, 6), WorldGen.genRand.Next(6, 21), ModContent.TileType<JadeGemstoneBlock>());
                }
            }

            //Topaz
            for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 6E-05); k++)
            {

                int x1 = WorldGen.genRand.Next(0, Main.maxTilesX);

                int y1 = WorldGen.genRand.Next((int)Main.rockLayer, Main.UnderworldLayer);

                Tile tile = Framing.GetTileSafely(x1, y1);
                if (tile.HasTile && tile.TileType == ModContent.TileType<HardenedMarineSand>())
                {
                    WorldGen.TileRunner(x1, y1, WorldGen.genRand.Next(4, 6), WorldGen.genRand.Next(6, 21), TileID.Topaz);
                }
            }
            #endregion

            #region Tier 3 Gems
            //Sapphire
            for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 6E-05); k++)
            {

                int x1 = WorldGen.genRand.Next(0, Main.maxTilesX);

                int y1 = WorldGen.genRand.Next((int)Main.rockLayer, Main.UnderworldLayer);

                Tile tile = Framing.GetTileSafely(x1, y1);
                if (tile.HasTile && tile.TileType == ModContent.TileType<HardenedMarineSand>())
                {
                    WorldGen.TileRunner(x1, y1, WorldGen.genRand.Next(4, 6), WorldGen.genRand.Next(6, 21), TileID.Sapphire);
                }
            }

            //Garnet
            for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 6E-05); k++)
            {

                int x1 = WorldGen.genRand.Next(0, Main.maxTilesX);

                int y1 = WorldGen.genRand.Next((int)Main.rockLayer, Main.UnderworldLayer);

                Tile tile = Framing.GetTileSafely(x1, y1);
                if (tile.HasTile && tile.TileType == ModContent.TileType<HardenedMarineSand>())
                {
                    WorldGen.TileRunner(x1, y1, WorldGen.genRand.Next(4, 6), WorldGen.genRand.Next(6, 21), ModContent.TileType<GarnetGemstoneBlock>());
                }
            }

            //Emerald
            for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 6E-05); k++)
            {

                int x1 = WorldGen.genRand.Next(0, Main.maxTilesX);

                int y1 = WorldGen.genRand.Next((int)Main.rockLayer, Main.UnderworldLayer);

                Tile tile = Framing.GetTileSafely(x1, y1);
                if (tile.HasTile && tile.TileType == ModContent.TileType<HardenedMarineSand>())
                {
                    WorldGen.TileRunner(x1, y1, WorldGen.genRand.Next(4, 6), WorldGen.genRand.Next(6, 21), TileID.Emerald);
                }
            }
            #endregion

            #region Tier 4 Gems
            //Ruby
            for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 6E-05); k++)
            {

                int x1 = WorldGen.genRand.Next(0, Main.maxTilesX);

                int y1 = WorldGen.genRand.Next((int)Main.rockLayer, Main.UnderworldLayer);

                Tile tile = Framing.GetTileSafely(x1, y1);
                if (tile.HasTile && tile.TileType == ModContent.TileType<HardenedMarineSand>())
                {
                    WorldGen.TileRunner(x1, y1, WorldGen.genRand.Next(4, 6), WorldGen.genRand.Next(6, 21), TileID.Ruby);
                }
            }

            //Lapis
            for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 6E-05); k++)
            {

                int x1 = WorldGen.genRand.Next(0, Main.maxTilesX);

                int y1 = WorldGen.genRand.Next((int)Main.rockLayer, Main.UnderworldLayer);

                Tile tile = Framing.GetTileSafely(x1, y1);
                if (tile.HasTile && tile.TileType == ModContent.TileType<HardenedMarineSand>())
                {
                    WorldGen.TileRunner(x1, y1, WorldGen.genRand.Next(4, 6), WorldGen.genRand.Next(6, 21), ModContent.TileType<LapisGemstoneBlock>());
                }
            }

            //Diamond
            for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 6E-05); k++)
            {

                int x1 = WorldGen.genRand.Next(0, Main.maxTilesX);

                int y1 = WorldGen.genRand.Next((int)Main.rockLayer, Main.UnderworldLayer);

                Tile tile = Framing.GetTileSafely(x1, y1);
                if (tile.HasTile && tile.TileType == ModContent.TileType<HardenedMarineSand>())
                {
                    WorldGen.TileRunner(x1, y1, WorldGen.genRand.Next(4, 6), WorldGen.genRand.Next(6, 21), TileID.Diamond);
                }
            }
            #endregion
            #endregion

        }
    }
}