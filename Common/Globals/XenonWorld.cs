using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Corrosion;

namespace Xenon.Common.Globals;

internal class XenonWorld : ModSystem
{
    public override void PostUpdateWorld()
    {
        int num12 = 151;
        int num13 = (int)Utils.Lerp(num12, num12 * 2.8, Utils.Clamp(Main.maxTilesX / 4200.0 - 1.0, 0.0, 1.0));
        float num2 = 3E-05f * (float)WorldGen.GetWorldUpdateRate();
        // float num3 = 1.5E-05f * (float)Main.worldRate;
        for (int num4 = 0; num4 < Main.maxTilesX * Main.maxTilesY * num2; num4++)
        {
            int xCoord = WorldGen.genRand.Next(10, Main.maxTilesX - 10);
            int yCoord = WorldGen.genRand.Next(10, /*(int)Main.worldSurface - 1*/ Main.maxTilesY - 20);
            int num7 = xCoord - 1;
            int num8 = xCoord + 2;
            int num9 = yCoord - 1;
            int num10 = yCoord + 2;
            int num11 = yCoord + 1;
            if (num7 < 10)
            {
                num7 = 10;
            }

            if (num8 > Main.maxTilesX - 10)
            {
                num8 = Main.maxTilesX - 10;
            }

            if (num9 < 10)
            {
                num9 = 10;
            }

            if (num10 > Main.maxTilesY - 10)
            {
                num10 = Main.maxTilesY - 10;
            }

            #region corrosion thorny bushes
            //if (TileID.Sets.SpreadOverground[Main.tile[xCoord, yCoord].TileType])
            //{
            //    int type = Main.tile[xCoord, yCoord].TileType;
            //    if ((type == ModContent.TileType<CorrosionThornyBushes>()) && WorldGen.genRand.NextBool(3))
            //    {
            //        WorldGen.GrowSpike(xCoord, yCoord, (ushort)ModContent.TileType<CorrosionThornyBushes>(), (ushort)ModContent.TileType<CorrosionGrass>());
            //    }
            //    else if (!Main.tile[xCoord, num9].HasTile && Main.tile[xCoord, num9].LiquidAmount == 0 &&
            //        !Main.tile[xCoord, yCoord].IsHalfBlock && Main.tile[xCoord, yCoord].Slope == SlopeType.Solid &&
            //        WorldGen.genRand.NextBool(13) && (type == ModContent.TileType<CorrosionGrass>() || type == ModContent.TileType<CorrosionJungleGrass>()))
            //    {
            //        WorldGen.PlaceTile(xCoord, num9, ModContent.TileType<CorrosionThornyBushes>(), mute: true);
            //    }
            //}
            #endregion

            #region contagion shortgrass/barfbush spawning
            if (Main.tile[xCoord, yCoord].TileType == ModContent.TileType<CorrosionGrass>() || Main.tile[xCoord, yCoord].TileType == ModContent.TileType<CorrosionJungleGrass>())
            {
                int num14 = Main.tile[xCoord, yCoord].TileType;
                if (!Main.tile[xCoord, num9].HasTile && Main.tile[xCoord, num9].LiquidAmount == 0 &&
                    !Main.tile[xCoord, yCoord].IsHalfBlock && Main.tile[xCoord, yCoord].Slope == SlopeType.Solid &&
                    WorldGen.genRand.NextBool(5) && (num14 == ModContent.TileType<CorrosionGrass>() || num14 == ModContent.TileType<CorrosionJungleGrass>()))
                {
                    WorldGen.PlaceTile(xCoord, num9, ModContent.TileType<CorrosionShortGrass>(), true);
                    Main.tile[xCoord, num9].TileFrameX = (short)(WorldGen.genRand.Next(0, 11) * 18);
                    if (Main.tile[xCoord, num9].HasTile)
                    {
                        Tile t = Main.tile[xCoord, num9];
                        t.TileColor = Main.tile[xCoord, yCoord].TileColor;
                    }

                    if (Main.netMode == NetmodeID.Server && Main.tile[xCoord, num9].HasTile)
                    {
                        NetMessage.SendTileSquare(-1, xCoord, num9, 1);
                    }
                }

                //if (!Main.tile[xCoord, num9].HasTile && Main.tile[xCoord, num9].LiquidAmount == 0 && !Main.tile[xCoord, yCoord].IsHalfBlock && Main.tile[xCoord, yCoord].Slope == SlopeType.Solid && WorldGen.genRand.NextBool(yCoord > Main.worldSurface ? 500 : 200) && (num14 == ModContent.TileType<CorrosionGrass>() || num14 == ModContent.TileType<CorrosionJungleGrass>()))
                //{
                //    WorldGen.PlaceTile(xCoord, num9, ModContent.TileType<Barfbush>(), true, false, -1, 0);
                //    if (Main.tile[xCoord, num9].HasTile)
                //    {
                //        Tile t = Main.tile[xCoord, num9];
                //        t.TileColor = Main.tile[xCoord, yCoord].TileColor;
                //    }
                //    if (Main.netMode == NetmodeID.Server && Main.tile[xCoord, num9].HasTile)
                //    {
                //        NetMessage.SendTileSquare(-1, xCoord, num9, 1);
                //    }
                //}
                bool flag2 = false;
                for (int m = num7; m < num8; m++)
                {
                    for (int n = num9; n < num10; n++)
                    {
                        if ((xCoord != m || yCoord != n) && Main.tile[m, n].HasTile)
                        {
                            if (Main.tile[m, n].TileType == 0 || ((num14 == ModContent.TileType<CorrosionGrass>() || num14 == ModContent.TileType<CorrosionJungleGrass>()) && Main.tile[m, n].TileType == TileID.Grass))
                            {
                                TileColorCache color = Main.tile[xCoord, yCoord].BlockColorAndCoating();
                                WorldGen.SpreadGrass(m, n, 0, num14, false, color);
                                if (num14 == ModContent.TileType<CorrosionGrass>() || num14 == ModContent.TileType<CorrosionJungleGrass>())
                                {
                                    WorldGen.SpreadGrass(m, n, TileID.Grass, ModContent.TileType<CorrosionGrass>(), false, color);
                                }
                                if (num14 == ModContent.TileType<CorrosionGrass>() || num14 == ModContent.TileType<CorrosionJungleGrass>())
                                {
                                    WorldGen.SpreadGrass(m, n, TileID.JungleGrass, ModContent.TileType<CorrosionJungleGrass>(), false, color);
                                }
                                if (num14 == ModContent.TileType<CorrosionGrass>() || num14 == ModContent.TileType<CorrosionJungleGrass>())
                                {
                                    WorldGen.SpreadGrass(m, n, TileID.HallowedGrass, ModContent.TileType<CorrosionGrass>(), false, color);
                                }
                                if (Main.tile[m, n].TileType == ModContent.TileType<CorrosionGrass>() || Main.tile[m, n].TileType == ModContent.TileType<CorrosionJungleGrass>())
                                {
                                    WorldGen.SquareTileFrame(m, n, true);
                                    flag2 = true;
                                }
                            }
                            if (Main.tile[m, n].TileType == 0 || (num14 == 109 && Main.tile[m, n].TileType == 2) || (num14 == 109 && Main.tile[m, n].TileType == 23) || (num14 == 109 && Main.tile[m, n].TileType == 199))
                            {
                                if (num14 == TileID.HallowedGrass)
                                {
                                    TileColorCache color = Main.tile[xCoord, yCoord].BlockColorAndCoating();
                                    WorldGen.SpreadGrass(m, n, ModContent.TileType<CorrosionGrass>(), num14, false, color);
                                }
                            }
                        }
                    }
                }
                if (Main.netMode == NetmodeID.Server && flag2)
                {
                    NetMessage.SendTileSquare(-1, xCoord, yCoord, 3);
                }
            }
            #endregion

            #region killing things if the block above/below isn't the necessary type
            // kill contagion vines if block above isn't contagion grass
            if (!(Main.tile[xCoord, num9].TileType == ModContent.TileType<CorrosionGrass>() || Main.tile[xCoord, num9].TileType == ModContent.TileType<CorrosionJungleGrass>() || Main.tile[xCoord, num9].TileType == ModContent.TileType<CorrosionVines>()) &&
                Main.tile[xCoord, yCoord].TileType == ModContent.TileType<CorrosionVines>())
            {
                WorldGen.KillTile(xCoord, yCoord);
            }
            // kill contagion short grass if block below isn't contagion grass
            if (!(Main.tile[xCoord, num11].TileType == ModContent.TileType<CorrosionGrass>() || Main.tile[xCoord, num11].TileType == ModContent.TileType<CorrosionJungleGrass>()) && Main.tile[xCoord, yCoord].TileType == ModContent.TileType<CorrosionShortGrass>())
            {
                WorldGen.KillTile(xCoord, yCoord);
            }
            // kill barfbush if block below isn't contagion grass or chunkstone
            //if (!(Main.tile[xCoord, num11].TileType == ModContent.TileType<CorrosionGrass>() || Main.tile[xCoord, num11].TileType == ModContent.TileType<CorrosionJungleGrass>() || Main.tile[xCoord, num11].TileType == ModContent.TileType<Gutstone>() || Data.Sets.TileSets.SuitableForPlantingHerbs[Main.tile[xCoord, num11].TileType]) &&
            //    Main.tile[xCoord, yCoord].TileType == ModContent.TileType<Barfbush>())
            //{
            //    WorldGen.KillTile(xCoord, yCoord);
            //}
            #endregion
        }
    }
}
