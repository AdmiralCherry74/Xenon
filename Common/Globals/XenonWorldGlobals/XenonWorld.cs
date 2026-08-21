using Avalon.Biomes;
using Avalon.Tiles.Contagion;
using Avalon.Tiles.Savanna;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent.Biomes;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.WorldBuilding;
using Xenon.Common.Systems;
using Xenon.Content.Tiles.Natural.Autumn;
using Xenon.Content.Tiles.Natural.Corrosion;
using Xenon.Content.Tiles.Natural.MountainsAndTheKarst;
using Xenon.Content.Tiles.Natural.MountainsAndTheKarst.Mossy;

namespace Xenon.Common.Globals.XenonWorldGlobals;

internal class LavaLineSaving : ModHook
{
    protected override void Apply()
	{
		On_TerrainPass.ApplyPass += On_TerrainPass_ApplyPass;

	}
	private void On_TerrainPass_ApplyPass(On_TerrainPass.orig_ApplyPass orig, TerrainPass self, GenerationProgress progress, Terraria.IO.GameConfiguration configuration)
	{
        orig.Invoke(self, progress, configuration);
        ModContent.GetInstance<XenonWorld>().LavaLine = GenVars.lavaLine;
	}
}
internal class XenonWorld : ModSystem
{
    public int LavaLine = 0;
    public const int AutumnBGCount = 2;
    public static int AutumnBG { get; set; } = 0;
    public static float AutumnBGFlash;

    public const int CorrosionUndergroundBGCount = 2;
    public static int CorrosionUndergroundBG { get; set; } = 0;
    public override void SaveWorldData(TagCompound tag)
	{
        tag["Xenon:LavaLine"] = LavaLine;

        tag["Xenon:AutumnBG"] = AutumnBG;

        tag["Xenon:CorrosionUndergroundBG"] = CorrosionUndergroundBG;
    }
	public override void LoadWorldData(TagCompound tag)
	{
        if (tag.ContainsKey("Xenon:LavaLine"))
        {
            LavaLine = tag.GetAsInt("Xenon:LavaLine");
        }
        else LavaLine = (int)(Main.rockLayer + Main.maxTilesY) / 2;

        if (tag.ContainsKey("Xenon:AutumnBG"))
        {
            AutumnBG = tag.GetAsInt("Xenon:AutumnBG");
        }

        if (tag.ContainsKey("Xenon:CorrosionUndergroundBG"))
        {
            CorrosionUndergroundBG = tag.GetAsInt("Xenon:CorrosionUndergroundBG");
        }
    }
    public override void OnWorldUnload()
    {
        AutumnBG = 0;
        CorrosionUndergroundBG = 0;
    }
    public override void PostUpdateEverything()
    {
        AutumnBGFlash = MathHelper.Clamp(AutumnBGFlash - 0.05f, 0f, 1f);
    }
    public override void PreWorldGen()
    {
        AutumnBG = WorldGen.genRand.Next(AutumnBGCount);

        CorrosionUndergroundBG = WorldGen.genRand.Next(CorrosionUndergroundBGCount);
    }
    public override void ModifySunLightColor(ref Color tileColor, ref Color backgroundColor)
    {
        float CorrosionStrength = ModContent.GetInstance<BiomeTileCounts>().CorrosionTiles / 350f;
        //if (CaptureManager.Instance.Active && CaptureManager.Instance.IsCapturing && CaptureInterface.Settings.BiomeChoiceIndex == AddModdedCaptureBiomes.biomeCapturesIndexs[0])
        //{
        //    ContagionStrength = 1f;
        //}
        if (CorrosionStrength != 0)
        {
            CorrosionStrength = Math.Min(CorrosionStrength, 1f);

            int sunR = backgroundColor.R;
            int sunG = backgroundColor.G;
            int sunB = backgroundColor.B;
            byte readableSunR = 206;
            byte readableSunG = 187;
            byte readableSunB = 83;
            sunR -= (int)((byte.MaxValue - readableSunR) * CorrosionStrength / 1.5f * (backgroundColor.R / 255f));
            sunG -= (int)((byte.MaxValue - readableSunG) * CorrosionStrength / 1.5f * (backgroundColor.G / 255f));
            sunB -= (int)((byte.MaxValue - readableSunB) * CorrosionStrength / 1.5f * (backgroundColor.B / 255f));

            sunR = Utils.Clamp(sunR, 15, 255);
            sunG = Utils.Clamp(sunG, 15, 255);
            sunB = Utils.Clamp(sunB, 15, 255);
            backgroundColor.R = (byte)sunR;
            backgroundColor.G = (byte)sunG;
            backgroundColor.B = (byte)sunB;

            int backgroundColorAverage = (int)((backgroundColor.R + backgroundColor.G + backgroundColor.B) / 2.70f);
            byte readableTint_R = 206;
            byte readableTint_G = 187;
            byte readableTint_B = 83;
            int tileTint_R = (byte)((byte.MaxValue - readableTint_R) * CorrosionStrength * (backgroundColorAverage / 255f));
            int tileTint_G = (byte)((byte.MaxValue - readableTint_G) * CorrosionStrength * (backgroundColorAverage / 255f));
            int tileTint_B = (byte)((byte.MaxValue - readableTint_B) * CorrosionStrength * (backgroundColorAverage / 255f));
            tileTint_R = (int)(tileTint_R - CorrosionStrength * 7f);
            tileTint_G = (int)(tileTint_G - CorrosionStrength * 7f);
            tileTint_B = (int)(tileTint_B - CorrosionStrength * 7f);

            tileColor.R = (byte)Math.Clamp(tileColor.R <= tileTint_R ? 1 : tileColor.R - tileTint_R, CorrosionStrength * 15f, 255f);
            tileColor.G = (byte)Math.Clamp(tileColor.G <= tileTint_G ? 1 : tileColor.G - tileTint_G, CorrosionStrength * 15f, 255f);
            tileColor.B = (byte)Math.Clamp(tileColor.B <= tileTint_B ? 1 : tileColor.B - tileTint_B, CorrosionStrength * 15f, 255f);
        }
        float SomnolentStrength = ModContent.GetInstance<BiomeTileCounts>().SomnolentTiles / 350f;
        if (SomnolentStrength != 0)
        {
            SomnolentStrength = Math.Min(SomnolentStrength, 1f);

            int sunR = backgroundColor.R;
            int sunG = backgroundColor.G;
            int sunB = backgroundColor.B;
            byte readableSunR = 10;
            byte readableSunG = 25;
            byte readableSunB = 75;
            sunR -= (int)((byte.MaxValue - readableSunR) * SomnolentStrength / 1.5f * (backgroundColor.R / 255f));
            sunG -= (int)((byte.MaxValue - readableSunG) * SomnolentStrength / 1.5f * (backgroundColor.G / 255f));
            sunB -= (int)((byte.MaxValue - readableSunB) * SomnolentStrength / 1.5f * (backgroundColor.B / 255f));

            sunR = Utils.Clamp(sunR, 15, 255);
            sunG = Utils.Clamp(sunG, 15, 255);
            sunB = Utils.Clamp(sunB, 15, 255);
            backgroundColor.R = (byte)sunR;
            backgroundColor.G = (byte)sunG;
            backgroundColor.B = (byte)sunB;

            int backgroundColorAverage = (int)((backgroundColor.R + backgroundColor.G + backgroundColor.B) / 2.70f);
            byte readableTint_R = 10;
            byte readableTint_G = 25;
            byte readableTint_B = 75;
            int tileTint_G = (byte)((byte.MaxValue - readableTint_G) * SomnolentStrength * (backgroundColorAverage / 255f));
            int tileTint_B = (byte)((byte.MaxValue - readableTint_B) * SomnolentStrength * (backgroundColorAverage / 255f));
            int tileTint_R = (byte)((byte.MaxValue - readableTint_R) * SomnolentStrength * (backgroundColorAverage / 255f));
            tileTint_R = (int)(tileTint_R - SomnolentStrength * 7f);
            tileTint_G = (int)(tileTint_G - SomnolentStrength * 7f);
            tileTint_B = (int)(tileTint_B - SomnolentStrength * 7f);

            tileColor.R = (byte)Math.Clamp(tileColor.R <= tileTint_R ? 1 : tileColor.R - tileTint_R, SomnolentStrength * 15f, 255f);
            tileColor.G = (byte)Math.Clamp(tileColor.G <= tileTint_G ? 1 : tileColor.G - tileTint_G, SomnolentStrength * 15f, 255f);
            tileColor.B = (byte)Math.Clamp(tileColor.B <= tileTint_B ? 1 : tileColor.B - tileTint_B, SomnolentStrength * 15f, 255f);
        }
        float AutumnStrength = ModContent.GetInstance<BiomeTileCounts>().AutumnTiles / 350f;

        if (AutumnStrength != 0)
        {
            AutumnStrength = Math.Min(AutumnStrength, 1f);

            int sunR = backgroundColor.R;
            int sunG = backgroundColor.G;
            int sunB = backgroundColor.B;
            byte readableSunR = 190;
            byte readableSunG = 137;
            byte readableSunB = 90;
            sunR -= (int)((byte.MaxValue - readableSunR) * AutumnStrength / 1.6f * (backgroundColor.R / 255f));
            sunG -= (int)((byte.MaxValue - readableSunG) * AutumnStrength / 1.6f * (backgroundColor.G / 255f));
            sunB -= (int)((byte.MaxValue - readableSunB) * AutumnStrength / 1.6f * (backgroundColor.B / 255f));

            sunR = Utils.Clamp(sunR, 15, 255);
            sunG = Utils.Clamp(sunG, 15, 255);
            sunB = Utils.Clamp(sunB, 15, 255);
            backgroundColor.R = (byte)sunR;
            backgroundColor.G = (byte)sunG;
            backgroundColor.B = (byte)sunB;

            int backgroundColorAverage = (int)((backgroundColor.R + backgroundColor.G + backgroundColor.B) / 2.70f);
            byte readableTint_R = 190;
            byte readableTint_G = 137;
            byte readableTint_B = 90;
            int tileTint_R = (byte)((byte.MaxValue - readableTint_R) * AutumnStrength * (backgroundColorAverage / 255f));
            int tileTint_G = (byte)((byte.MaxValue - readableTint_G) * AutumnStrength * (backgroundColorAverage / 255f));
            int tileTint_B = (byte)((byte.MaxValue - readableTint_B) * AutumnStrength * (backgroundColorAverage / 255f));
            tileTint_R = (int)(tileTint_R - (AutumnStrength * 7f));
            tileTint_G = (int)(tileTint_G - (AutumnStrength * 7f));
            tileTint_B = (int)(tileTint_B - (AutumnStrength * 7f));

            tileColor.R = (byte)Math.Clamp(tileColor.R <= tileTint_R ? 1 : tileColor.R - tileTint_R, AutumnStrength * 15f, 255f);
            tileColor.G = (byte)Math.Clamp(tileColor.G <= tileTint_G ? 1 : tileColor.G - tileTint_G, AutumnStrength * 15f, 255f);
            tileColor.B = (byte)Math.Clamp(tileColor.B <= tileTint_B ? 1 : tileColor.B - tileTint_B, AutumnStrength * 15f, 255f);
        }
    }
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
            if (TileID.Sets.SpreadOverground[Main.tile[xCoord, yCoord].TileType])
            {
                int type = Main.tile[xCoord, yCoord].TileType;
                if (type == ModContent.TileType<CorrosionThornyBushes>()/* && WorldGen.genRand.NextBool(2)*/)
                {
                    WorldGen.GrowSpike(xCoord, yCoord, (ushort)ModContent.TileType<CorrosionThornyBushes>(), (ushort)ModContent.TileType<CorrosionGrass>());
                }
                else if (!Main.tile[xCoord, num9].HasTile && Main.tile[xCoord, num9].LiquidAmount == 0 &&
                    !Main.tile[xCoord, yCoord].IsHalfBlock && Main.tile[xCoord, yCoord].Slope == SlopeType.Solid &&
                    WorldGen.genRand.NextBool(13) && (type == ModContent.TileType<CorrosionGrass>() || type == ModContent.TileType<CorrosionJungleGrass>() || type == ModContent.TileType<CorrosionAutumnGrass>()))
                {
                    WorldGen.PlaceTile(xCoord, num9, ModContent.TileType<CorrosionThornyBushes>(), mute: true);
                }
            }
            #endregion

            #region corrosion shortgrass/herb spawning
            if (Main.tile[xCoord, yCoord].TileType == ModContent.TileType<CorrosionGrass>() || Main.tile[xCoord, yCoord].TileType == ModContent.TileType<CorrosionJungleGrass>() || Main.tile[xCoord, yCoord].TileType == ModContent.TileType<CorrosionAutumnGrass>())
            {
                int num14 = Main.tile[xCoord, yCoord].TileType;
                if (!Main.tile[xCoord, yCoord - 1].HasTile && Main.tile[xCoord, yCoord - 1].LiquidAmount == 0 &&
                    !Main.tile[xCoord, yCoord].IsHalfBlock && Main.tile[xCoord, yCoord].Slope == SlopeType.Solid &&
                    WorldGen.genRand.NextBool(5))
                {
                    Main.tile[xCoord, yCoord - 1].TileType = (ushort)ModContent.TileType<CorrosionShortGrass>();
                    Main.tile[xCoord, yCoord - 1].TileFrameX = (short)(WorldGen.genRand.Next(0, 11) * 18);
                    if (Main.tile[xCoord, yCoord - 1].HasTile)
                    {
                        Tile t = Main.tile[xCoord, yCoord - 1];
                        t.TileColor = Main.tile[xCoord, yCoord].TileColor;
                    }

                    if (Main.netMode == NetmodeID.Server && Main.tile[xCoord, yCoord - 1].HasTile)
                    {
                        NetMessage.SendTileSquare(-1, xCoord, yCoord - 1, 1);
                    }
                }

                if (!Main.tile[xCoord, num9].HasTile && Main.tile[xCoord, num9].LiquidAmount == 0 && !Main.tile[xCoord, yCoord].IsHalfBlock && Main.tile[xCoord, yCoord].Slope == SlopeType.Solid && WorldGen.genRand.NextBool(yCoord > Main.worldSurface ? 500 : 200) && (num14 == ModContent.TileType<CorrosionGrass>() || num14 == ModContent.TileType<Gutstone>() || num14 == ModContent.TileType<CorrosionJungleGrass>() || num14 == ModContent.TileType<CorrosionAutumnGrass>()))
                {
                    WorldGen.PlaceTile(xCoord, num9, ModContent.TileType<Liverwort>(), true, false, -1, 0);
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
                bool flag2 = false;
                for (int m = num7; m < num8; m++)
                {
                    for (int n = num9; n < num10; n++)
                    {
                        if ((xCoord != m || yCoord != n) && Main.tile[m, n].HasTile)
                        {
                            if (Main.tile[m, n].TileType == TileID.Dirt || (num14 == ModContent.TileType<CorrosionGrass>() || num14 == ModContent.TileType<CorrosionJungleGrass>()) && Main.tile[m, n].TileType == TileID.Grass)
                            {
                                TileColorCache color = Main.tile[xCoord, yCoord].BlockColorAndCoating();
                                WorldGen.SpreadGrass(m, n, 0, num14, false, color);
                                if (num14 == ModContent.TileType<CorrosionGrass>() || num14 == ModContent.TileType<CorrosionJungleGrass>() || num14 == ModContent.TileType<CorrosionAutumnGrass>())
                                {
                                    WorldGen.SpreadGrass(m, n, TileID.Grass, ModContent.TileType<CorrosionGrass>(), false, color);
                                }
                                if (num14 == ModContent.TileType<CorrosionGrass>() || num14 == ModContent.TileType<CorrosionJungleGrass>() || num14 == ModContent.TileType<CorrosionAutumnGrass>())
                                {
                                    WorldGen.SpreadGrass(m, n, TileID.JungleGrass, ModContent.TileType<CorrosionJungleGrass>(), false, color);
                                }
                                if (num14 == ModContent.TileType<CorrosionGrass>() || num14 == ModContent.TileType<CorrosionJungleGrass>() || num14 == ModContent.TileType<CorrosionAutumnGrass>())
                                {
                                    WorldGen.SpreadGrass(m, n, TileID.HallowedGrass, ModContent.TileType<CorrosionGrass>(), false, color);
                                }
                                if (num14 == ModContent.TileType<CorrosionGrass>() || num14 == ModContent.TileType<CorrosionJungleGrass>() || num14 == ModContent.TileType<CorrosionAutumnGrass>())
                                {
                                    WorldGen.SpreadGrass(m, n, ModContent.TileType<AutumnGrass>(), ModContent.TileType<CorrosionAutumnGrass>(), false, color);
                                }
                                if (Main.tile[m, n].TileType == ModContent.TileType<CorrosionGrass>() || Main.tile[m, n].TileType == ModContent.TileType<CorrosionJungleGrass>())
                                {
                                    WorldGen.SquareTileFrame(m, n, true);
                                    flag2 = true;
                                }
                            }
                            if (Main.tile[m, n].TileType == TileID.Dirt || num14 == TileID.HallowedGrass && Main.tile[m, n].TileType == TileID.Grass || num14 == TileID.HallowedGrass && Main.tile[m, n].TileType == TileID.CorruptGrass || num14 == TileID.HallowedGrass && Main.tile[m, n].TileType == TileID.CrimsonGrass)
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

            #region corrosion vines growing (for Grass, look at CorrosionGrass Code)

            if ((Main.tile[xCoord, yCoord].TileType == ModContent.TileType<CorrosionGrass>() ||
                 Main.tile[xCoord, yCoord].TileType == ModContent.TileType<CorrosionJungleGrass>() ||
                 Main.tile[xCoord, yCoord].TileType == ModContent.TileType<CorrosionAutumnGrass>() ||
                 Main.tile[xCoord, yCoord].TileType == ModContent.TileType<CorrosionVines>()) &&
                WorldGen.genRand.NextBool(15) && !Main.tile[xCoord, yCoord + 1].HasTile &&
                Main.tile[xCoord, yCoord + 1].LiquidType != LiquidID.Lava)
            {
                bool flag10 = false;
                for (int num47 = yCoord; num47 > yCoord - 10; num47--)
                {
                    if (Main.tile[xCoord, num47].BottomSlope)
                    {
                        flag10 = false;
                        break;
                    }

                    if (Main.tile[xCoord, num47].HasTile &&
                        (Main.tile[xCoord, num47].TileType == ModContent.TileType<CorrosionGrass>() ||
                         Main.tile[xCoord, yCoord].TileType == ModContent.TileType<CorrosionAutumnGrass>() ||
                         Main.tile[xCoord, num47].TileType == ModContent.TileType<CorrosionJungleGrass>()) &&
                        !Main.tile[xCoord, num47].BottomSlope)
                    {
                        flag10 = true;
                        break;
                    }
                }

                if (flag10)
                {
                    int num48 = xCoord;
                    int num49 = yCoord + 1;
                    Main.tile[num48, num49].TileType = (ushort)ModContent.TileType<CorrosionVines>();

                    Tile t = Main.tile[num48, num49];
                    t.HasTile = true;
                    WorldGen.SquareTileFrame(num48, num49);
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendTileSquare(-1, num48, num49, 3);
                    }
                }
            }

            #endregion

            #region autumn shortgrass/herb spawning
            if (Main.tile[xCoord, yCoord].TileType == ModContent.TileType<AutumnGrass>())
            {
                int num14 = Main.tile[xCoord, yCoord].TileType;
                if (!Main.tile[xCoord, yCoord - 1].HasTile && Main.tile[xCoord, yCoord - 1].LiquidAmount == 0 &&
                    !Main.tile[xCoord, yCoord].IsHalfBlock && Main.tile[xCoord, yCoord].Slope == SlopeType.Solid &&
                    WorldGen.genRand.NextBool(5))
                {
                    Main.tile[xCoord, yCoord - 1].TileType = (ushort)ModContent.TileType<AutumnFoliage>();
                    Main.tile[xCoord, yCoord - 1].TileFrameX = (short)(WorldGen.genRand.Next(0, 6) * 18);
                    if (Main.tile[xCoord, yCoord - 1].HasTile)
                    {
                        Tile t = Main.tile[xCoord, yCoord - 1];
                        t.TileColor = Main.tile[xCoord, yCoord].TileColor;
                    }

                    if (Main.netMode == NetmodeID.Server && Main.tile[xCoord, yCoord - 1].HasTile)
                    {
                        NetMessage.SendTileSquare(-1, xCoord, yCoord - 1, 1);
                    }
                }

                //if (!Main.tile[xCoord, num9].HasTile && Main.tile[xCoord, num9].LiquidAmount == 0 && !Main.tile[xCoord, yCoord].IsHalfBlock && Main.tile[xCoord, yCoord].Slope == SlopeType.Solid && WorldGen.genRand.NextBool(yCoord > Main.worldSurface ? 500 : 200) && (num14 == ModContent.TileType<AutumnGrass>()))
                //{
                //    WorldGen.PlaceTile(xCoord, num9, ModContent.TileType<Liverwort>(), true, false, -1, 0);
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
                            if ((num14 == ModContent.TileType<AutumnGrass>()) && Main.tile[m, n].TileType == ModContent.TileType<Mulch>())
                            {
                                TileColorCache color = Main.tile[xCoord, yCoord].BlockColorAndCoating();
                                WorldGen.SpreadGrass(m, n, 0, num14, false, color);
                                if (num14 == ModContent.TileType<AutumnGrass>())
                                {
                                    WorldGen.SpreadGrass(m, n, ModContent.TileType<Mulch>(), ModContent.TileType<AutumnGrass>(), false, color);
                                }
                                if (Main.tile[m, n].TileType == ModContent.TileType<AutumnGrass>())
                                {
                                    WorldGen.SquareTileFrame(m, n, true);
                                    flag2 = true;
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

            #region autumn vines growing (for Grass, look at Autumn Grass Code)

            if ((Main.tile[xCoord, yCoord].TileType == ModContent.TileType<AutumnGrass>() ||
                 Main.tile[xCoord, yCoord].TileType == ModContent.TileType<AutumnVines>()) &&
                WorldGen.genRand.NextBool(15) && !Main.tile[xCoord, yCoord + 1].HasTile &&
                Main.tile[xCoord, yCoord + 1].LiquidType != LiquidID.Lava)
            {
                bool flag10 = false;
                for (int num47 = yCoord; num47 > yCoord - 10; num47--)
                {
                    if (Main.tile[xCoord, num47].BottomSlope)
                    {
                        flag10 = false;
                        break;
                    }

                    if (Main.tile[xCoord, num47].HasTile &&
                        (Main.tile[xCoord, num47].TileType == ModContent.TileType<AutumnGrass>() &&
                        !Main.tile[xCoord, num47].BottomSlope))
                    {
                        flag10 = true;
                        break;
                    }
                }

                if (flag10)
                {
                    int num48 = xCoord;
                    int num49 = yCoord + 1;
                    Main.tile[num48, num49].TileType = (ushort)ModContent.TileType<AutumnVines>();

                    Tile t = Main.tile[num48, num49];
                    t.HasTile = true;
                    WorldGen.SquareTileFrame(num48, num49);
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendTileSquare(-1, num48, num49, 3);
                    }
                }
            }

            #endregion

            #region autumn thorny bushes
            if (TileID.Sets.SpreadOverground[Main.tile[xCoord, yCoord].TileType])
            {
                int type = Main.tile[xCoord, yCoord].TileType;
                if ((type == ModContent.TileType<AutumnThornyBushes>())/* && WorldGen.genRand.NextBool(3)*/)
                {
                    WorldGen.GrowSpike(xCoord, yCoord, (ushort)ModContent.TileType<AutumnThornyBushes>(), (ushort)ModContent.TileType<AutumnGrass>());
                }
                else if (!Main.tile[xCoord, num9].HasTile && Main.tile[xCoord, num9].LiquidAmount == 0 &&
                    !Main.tile[xCoord, yCoord].IsHalfBlock && Main.tile[xCoord, yCoord].Slope == SlopeType.Solid &&
                    yCoord > Main.worldSurface &&
                    WorldGen.genRand.NextBool(13) && (type == ModContent.TileType<AutumnGrass>()))
                {
                    WorldGen.PlaceTile(xCoord, num9, ModContent.TileType<AutumnThornyBushes>(), mute: true);
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
            if (!(Main.tile[xCoord, num11].TileType == ModContent.TileType<CorrosionGrass>() || Main.tile[xCoord, num11].TileType == ModContent.TileType<CorrosionJungleGrass>() || Main.tile[xCoord, num11].TileType == ModContent.TileType<Gutstone>() || Main.tile[xCoord, num11].TileType == TileID.PlanterBox || Main.tile[xCoord, num11].TileType == TileID.ClayPot) &&
                Main.tile[xCoord, yCoord].TileType == ModContent.TileType<Liverwort>())
            {
                WorldGen.KillTile(xCoord, yCoord);
            }

            if (!(Main.tile[xCoord, num9].TileType == ModContent.TileType<AutumnGrass>()) &&
                Main.tile[xCoord, yCoord].TileType == ModContent.TileType<AutumnVines>())
            {
                WorldGen.KillTile(xCoord, yCoord);
            }
            // kill contagion short grass if block below isn't contagion grass
            if (!(Main.tile[xCoord, num11].TileType == ModContent.TileType<AutumnGrass>()) && Main.tile[xCoord, yCoord].TileType == ModContent.TileType<AutumnFoliage>())
            {
                WorldGen.KillTile(xCoord, yCoord);
            }
            #endregion

            #region spreading biomes
            if (Main.tile[xCoord, yCoord].HasUnactuatedTile)
            {
                UpdateSpreadingBiomes(xCoord, yCoord);
            }
			#endregion
		}
	}
    public static void UpdateSpreadingBiomes(int i, int j)
    {
        if (Main.hardMode)
        {
            if (Main.tile[i, j].IsActuated)
            {
                return;
            }
			int type = Main.tile[i, j].TileType;
            // corruption
			if (type == TileID.CorruptGrass || type == TileID.Ebonstone || type == TileID.CorruptThorns ||
                type == TileID.Ebonsand || type == TileID.CorruptIce || type == TileID.CorruptHardenedSand ||
                type == TileID.CorruptSandstone || type == TileID.CorruptJungleGrass ||
                type == ModContent.TileType<NyxStone>() || type == ModContent.TileType<MossyNyxStone>())
			{
				bool flag = true;
				while (flag)
				{
					flag = false;
					int num11 = i + WorldGen.genRand.Next(-3, 4);
					int num12 = j + WorldGen.genRand.Next(-3, 4);
					if (Main.tile[num11, num12 - 1].TileType != TileID.Sunflower)
					{
						if (Main.tile[num11, num12].TileType == ModContent.TileType<OuranoStone>() ||
                            Main.tile[num11, num12].TileType == ModContent.TileType<AresStone>() ||
                            Main.tile[num11, num12].TileType == ModContent.TileType<HephStone>() ||
                            Main.tile[num11, num12].TileType == ModContent.TileType<HelioStone>())
						{
							if (WorldGen.genRand.NextBool(2))
							{
								flag = true;
							}
							Main.tile[num11, num12].TileType = (ushort)ModContent.TileType<NyxStone>();
							WorldGen.SquareTileFrame(num11, num12, true);
							NetMessage.SendTileSquare(-1, num11, num12, 1);
						}
						if (Main.tile[num11, num12].TileType == ModContent.TileType<MossyOuranoStone>() ||
							Main.tile[num11, num12].TileType == ModContent.TileType<MossyAresStone>() ||
							Main.tile[num11, num12].TileType == ModContent.TileType<MossyHephStone>() ||
							Main.tile[num11, num12].TileType == ModContent.TileType<MossyHelioStone>())
						{
							if (WorldGen.genRand.NextBool(2))
							{
								flag = true;
							}
							Main.tile[num11, num12].TileType = (ushort)ModContent.TileType<MossyNyxStone>();
							WorldGen.SquareTileFrame(num11, num12, true);
							NetMessage.SendTileSquare(-1, num11, num12, 1);
						}
					}
				}
			}
            // crimson
			if (type == TileID.CrimsonGrass || type == TileID.Crimstone || type == TileID.CrimsonThorns ||
				type == TileID.Crimsand || type == TileID.FleshIce || type == TileID.CrimsonHardenedSand ||
				type == TileID.CrimsonSandstone || type == TileID.CrimsonJungleGrass ||
				type == ModContent.TileType<AresStone>() || type == ModContent.TileType<MossyAresStone>())
			{
				bool flag = true;
				while (flag)
				{
					flag = false;
					int num11 = i + WorldGen.genRand.Next(-3, 4);
					int num12 = j + WorldGen.genRand.Next(-3, 4);
					if (Main.tile[num11, num12 - 1].TileType != TileID.Sunflower)
					{
						if (Main.tile[num11, num12].TileType == ModContent.TileType<OuranoStone>() ||
							Main.tile[num11, num12].TileType == ModContent.TileType<NyxStone>() ||
							Main.tile[num11, num12].TileType == ModContent.TileType<HephStone>() ||
							Main.tile[num11, num12].TileType == ModContent.TileType<HelioStone>())
						{
							if (WorldGen.genRand.NextBool(2))
							{
								flag = true;
							}
							Main.tile[num11, num12].TileType = (ushort)ModContent.TileType<AresStone>();
							WorldGen.SquareTileFrame(num11, num12, true);
							NetMessage.SendTileSquare(-1, num11, num12, 1);
						}
						if (Main.tile[num11, num12].TileType == ModContent.TileType<MossyOuranoStone>() ||
							Main.tile[num11, num12].TileType == ModContent.TileType<MossyNyxStone>() ||
							Main.tile[num11, num12].TileType == ModContent.TileType<MossyHephStone>() ||
							Main.tile[num11, num12].TileType == ModContent.TileType<MossyHelioStone>())
						{
							if (WorldGen.genRand.NextBool(2))
							{
								flag = true;
							}
							Main.tile[num11, num12].TileType = (ushort)ModContent.TileType<MossyAresStone>();
							WorldGen.SquareTileFrame(num11, num12, true);
							NetMessage.SendTileSquare(-1, num11, num12, 1);
						}
					}
				}
			}
            // hallow
			if (type == TileID.HallowedGrass || type == TileID.Pearlstone || type == TileID.Pearlsand ||
                type == TileID.HallowedIce || type == TileID.HallowHardenedSand || type == TileID.HallowSandstone ||
				type == ModContent.TileType<HelioStone>() || type == ModContent.TileType<MossyHelioStone>())
			{
				bool flag = true;
				while (flag)
				{
					flag = false;
					int num11 = i + WorldGen.genRand.Next(-3, 4);
					int num12 = j + WorldGen.genRand.Next(-3, 4);
					if (Main.tile[num11, num12].TileType == ModContent.TileType<OuranoStone>() ||
						Main.tile[num11, num12].TileType == ModContent.TileType<NyxStone>() ||
						Main.tile[num11, num12].TileType == ModContent.TileType<HephStone>() ||
						Main.tile[num11, num12].TileType == ModContent.TileType<AresStone>())
					{
						if (WorldGen.genRand.NextBool(2))
						{
							flag = true;
						}
						Main.tile[num11, num12].TileType = (ushort)ModContent.TileType<HelioStone>();
						WorldGen.SquareTileFrame(num11, num12, true);
						NetMessage.SendTileSquare(-1, num11, num12, 1);
					}
					if (Main.tile[num11, num12].TileType == ModContent.TileType<MossyOuranoStone>() ||
						Main.tile[num11, num12].TileType == ModContent.TileType<MossyNyxStone>() ||
						Main.tile[num11, num12].TileType == ModContent.TileType<MossyHephStone>() ||
						Main.tile[num11, num12].TileType == ModContent.TileType<MossyAresStone>())
					{
						if (WorldGen.genRand.NextBool(2))
						{
							flag = true;
						}
						Main.tile[num11, num12].TileType = (ushort)ModContent.TileType<MossyHelioStone>();
						WorldGen.SquareTileFrame(num11, num12, true);
						NetMessage.SendTileSquare(-1, num11, num12, 1);
					}
				}
			}
			// corrosion
			if (type == ModContent.TileType<CorrosionGrass>() || type == ModContent.TileType<Gutstone>() || type == ModContent.TileType<Gutsand>() ||
				type == ModContent.TileType<BrownIce>() || type == ModContent.TileType<HardenedGutsand>() || type == ModContent.TileType<Gutsandstone>() ||
				type == ModContent.TileType<CorrosionJungleGrass>() || type == ModContent.TileType<HephStone>() || type == ModContent.TileType<MossyHephStone>())
			{
				bool flag = true;
				while (flag)
				{
					flag = false;
					int num11 = i + WorldGen.genRand.Next(-3, 4);
					int num12 = j + WorldGen.genRand.Next(-3, 4);
					if (Main.tile[num11, num12 - 1].TileType != TileID.Sunflower)
					{
						if (Main.tile[num11, num12].TileType == ModContent.TileType<OuranoStone>() ||
							Main.tile[num11, num12].TileType == ModContent.TileType<NyxStone>() ||
							Main.tile[num11, num12].TileType == ModContent.TileType<HelioStone>() ||
							Main.tile[num11, num12].TileType == ModContent.TileType<AresStone>())
						{
							if (WorldGen.genRand.NextBool(2))
							{
								flag = true;
							}
							Main.tile[num11, num12].TileType = (ushort)ModContent.TileType<HephStone>();
							WorldGen.SquareTileFrame(num11, num12, true);
							NetMessage.SendTileSquare(-1, num11, num12, 1);
						}
						if (Main.tile[num11, num12].TileType == ModContent.TileType<MossyOuranoStone>() ||
							Main.tile[num11, num12].TileType == ModContent.TileType<MossyNyxStone>() ||
							Main.tile[num11, num12].TileType == ModContent.TileType<MossyHelioStone>() ||
							Main.tile[num11, num12].TileType == ModContent.TileType<MossyAresStone>())
						{
							if (WorldGen.genRand.NextBool(2))
							{
								flag = true;
							}
							Main.tile[num11, num12].TileType = (ushort)ModContent.TileType<MossyHephStone>();
							WorldGen.SquareTileFrame(num11, num12, true);
							NetMessage.SendTileSquare(-1, num11, num12, 1);
						}
					}
				}
			}
		}
	}
}
