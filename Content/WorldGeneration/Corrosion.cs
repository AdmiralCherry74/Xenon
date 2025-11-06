using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Corrosion;
using Microsoft.Xna.Framework;
using Xenon.Content.Walls;
using ReLogic.Utilities;
using System;
using System.Collections.Generic;
using Terraria.WorldBuilding;
using Terraria.Localization;
using AltLibrary.Core.Generation;
using AltLibrary.Common.Systems;
using Xenon.Content.WorldGeneration.Passes;
using Terraria.IO;

namespace Xenon.Content.WorldGeneration;

public class CorrosionGenSystem : ModSystem
{
    public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
    {
        GenPass currentPass;
        int index = tasks.FindIndex(genPass => genPass.Name == "Vines");
        if (index != -1)
        {
            tasks.Insert(index + 1, new Passes.CorrosionVines("Vines", 25f));
        }

        index = tasks.FindIndex(genpass => genpass.Name.Equals("Weeds"));
        if (index != -1)
        {
            tasks.Insert(index + 1, new ShortGrass("Weeds", 50f));
        }

        index = tasks.FindIndex(genPass => genPass.Name == "Remove Broken Traps");
        if (index != -1)
        {
            currentPass = new CorrosionStalac();
            tasks.Insert(index + 1, currentPass);
            totalWeight += currentPass.Weight;
        }
    }
}
public class CorrosionStalac : GenPass
{
    public CorrosionStalac() : base("Corrosion Stalac", 20f)
    {
    }

    protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
    {
        for (int num19 = 20; num19 < Main.maxTilesX - 20; num19++)
        {
            for (int num22 = 5; num22 < Main.maxTilesY - 20; num22++)
            {
                // corrosion stalac
                if (Main.tile[num19, num22 - 1].TileType == ModContent.TileType<Gutstone>() && Main.tile[num19, num22 - 1].HasTile && WorldGen.genRand.NextBool(3))
                {
                    if (!Main.tile[num19, num22].HasTile && !Main.tile[num19, num22 + 1].HasTile && Main.tile[num19, num22 - 1].Slope == SlopeType.Solid)
                    {
                        Utils.PlaceCustomTight(num19, num22, (ushort)ModContent.TileType<Tiles.Corrosion.CorrosionStalac>());
                    }
                }
                if (Main.tile[num19, num22 + 1].TileType == ModContent.TileType<Gutstone>() && Main.tile[num19, num22 + 1].HasTile && WorldGen.genRand.NextBool(3))
                {
                    if (!Main.tile[num19, num22].HasTile && !Main.tile[num19, num22 - 1].HasTile && Main.tile[num19, num22 + 1].Slope == SlopeType.Solid)
                    {
                        Utils.PlaceCustomTight(num19, num22, (ushort)ModContent.TileType<Tiles.Corrosion.CorrosionStalac>());
                    }
                }
            }
        }
    }
}
public class Corrosion : EvilBiomeGenerationPass
{
    public override string ProgressMessage => Language.GetTextValue("Mods.Xenon.Generation.Corrosion.Message");
    public override void GenerateEvil(int evilBiomePosition, int evilBiomePositionWestBound, int evilBiomePositionEastBound)
    {
        WorldBiomeGeneration.ChangeRange.ResetRange();

        CorrosionRunner(evilBiomePosition, (int)GenVars.worldSurfaceLow - 10 + (Main.maxTilesY / 8));
        for (int i = evilBiomePositionWestBound; i < evilBiomePositionEastBound; i++)
        {
            int j = (int)GenVars.worldSurfaceLow;
            while (j < Main.worldSurface - 1.0)
            {
                if (Main.tile[i, j].HasTile)
                {
                    int num220 = j + WorldGen.genRand.Next(10, 14);
                    for (int num221 = j; num221 < num220; num221++)
                    {
                        if (Main.tile[i, num221].TileType == TileID.JungleGrass && i >= evilBiomePositionWestBound + WorldGen.genRand.Next(5) && i < evilBiomePositionEastBound - WorldGen.genRand.Next(5))
                        {
                            Main.tile[i, num221].TileType = (ushort)ModContent.TileType<CorrosionJungleGrass>();
                        }
                    }
                    break;
                }
                j++;
            }
        }
        double num222 = Main.worldSurface + 40.0;
        for (int i = evilBiomePositionWestBound; i < evilBiomePositionEastBound; i++)
        {
            num222 += WorldGen.genRand.Next(-2, 3);
            if (num222 < Main.worldSurface + 30.0)
            {
                num222 = Main.worldSurface + 30.0;
            }
            if (num222 > Main.worldSurface + 50.0)
            {
                num222 = Main.worldSurface + 50.0;
            }
            int num57 = i;
            bool flag13 = false;
            int num224 = (int)GenVars.worldSurfaceLow;
            while (num224 < num222)
            {
                if (Main.tile[num57, num224].HasTile)
                {
                    if (Main.tile[num57, num224].TileType == TileID.Sand && num57 >= evilBiomePositionWestBound + WorldGen.genRand.Next(5) && num57 <= evilBiomePositionEastBound - WorldGen.genRand.Next(5))
                    {
                        Main.tile[num57, num224].TileType = (ushort)ModContent.TileType<Gutsand>();
                    }
                    if (Main.tile[num57, num224].TileType == TileID.Dirt && num224 < Main.worldSurface - 1.0 && !flag13)
                    {
                        WorldGen.grassSpread = 0;
                        WorldGen.SpreadGrass(num57, num224, 0, ModContent.TileType<CorrosionGrass>(), true, default);
                    }
                    flag13 = true;
                    if (Main.tile[num57, num224].TileType == TileID.Stone && num57 >= evilBiomePositionWestBound + WorldGen.genRand.Next(5) && num57 <= evilBiomePositionEastBound - WorldGen.genRand.Next(5))
                    {
                        Main.tile[num57, num224].TileType = (ushort)ModContent.TileType<Gutstone>();
                    }
                    if (Main.tile[num57, num224].TileType == TileID.Grass)
                    {
                        Main.tile[num57, num224].TileType = (ushort)ModContent.TileType<CorrosionGrass>();
                    }
                    if (Main.tile[num57, num224].TileType == TileID.IceBlock)
                    {
                        Main.tile[num57, num224].TileType = (ushort)ModContent.TileType<TanIce>();
                    }
                    if (Main.tile[num57, num224].TileType == TileID.HardenedSand)
                    {
                        Main.tile[num57, num224].TileType = (ushort)ModContent.TileType<HardenedGutsand>();
                    }
                    if (Main.tile[num57, num224].TileType == TileID.Sandstone)
                    {
                        Main.tile[num57, num224].TileType = (ushort)ModContent.TileType<Gutsandstone>();
                    }
                }
                num224++;
            }
        }
        int num225 = WorldGen.genRand.Next(10, 15);
        for (int num226 = 0; num226 < num225; num226++)
        {
            int num227 = 0;
            bool flag14 = false;
            int num228 = 0;
            while (!flag14)
            {
                num227++;
                int num229 = WorldGen.genRand.Next(evilBiomePositionWestBound - num228, evilBiomePositionEastBound + num228);
                int num230 = WorldGen.genRand.Next((int)(Main.worldSurface - num228 / 2), (int)(Main.worldSurface + 100.0 + num228));
                if (num227 > 100)
                {
                    num228++;
                    num227 = 0;
                }
                if (!Main.tile[num229, num230].HasTile)
                {
                    while (!Main.tile[num229, num230].HasTile)
                    {
                        num230++;
                    }
                    num230--;
                }
                else
                {
                    while (Main.tile[num229, num230].HasTile && num230 > Main.worldSurface)
                    {
                        num230--;
                    }
                }
                if (num228 > 10 || (Main.tile[num229, num230 + 1].HasTile && Main.tile[num229, num230 + 1].TileType == ModContent.TileType<Gutstone>()))
                {
                    //WorldGen.Place3x2(num229, num230, (ushort)ModContent.TileType<IckyAltar>());
                    //if (Main.tile[num229, num230].TileType == (ushort)ModContent.TileType<IckyAltar>())
                    //{
                    //    flag14 = true;
                    //}
                }
                if (num228 > 100)
                {
                    flag14 = true;
                }
            }
        }

        WorldBiomeGeneration.ChangeRange.AddChangeToRange(evilBiomePositionWestBound, (int)GenVars.worldSurfaceLow);
        WorldBiomeGeneration.ChangeRange.AddChangeToRange(evilBiomePositionEastBound, (int)Main.worldSurface + 50);

        WorldBiomeGeneration.EvilBiomeGenRanges.Add(WorldBiomeGeneration.ChangeRange.GetRange());
    }

    public override void PostGenerateEvil() { }
    public static void CorrosionRunner(int i, int j)
    {
        ushort stone = (ushort)ModContent.TileType<Gutstone>();

        int radius = WorldGen.genRand.Next(70, 75);

        // Shift the Y coord down to the world surface
        j = Utils.TileCheck(i) + radius + 25;
        Vector3 v = CorrosionStart(i, j);

        List<Point> startpoints = new();
        List<Point> endpoints = new();
        List<Point> orbpoints = new();

        bool flag = WorldGen.genRand.NextBool();
        // add either the bottom left or bottom right
        startpoints.Add(new(flag ? (int)v.X : (int)v.Y, (int)v.Z - 20));
        int xmod = WorldGen.genRand.Next(-25, 26);
        if (xmod > -20 && xmod < 0) xmod = -20;
        if (xmod >= 0 && xmod < 20) xmod = 20;
        int ymod = WorldGen.genRand.Next(8, 12);
        endpoints.Add(new(i + xmod, (int)v.Z + ymod));
        int numCurves = WorldGen.genRand.Next(7, 12);
        int direction = 1;
        // add a random number of connected tunnels
        for (int q = 0; q < numCurves; q++)
        {
            startpoints.Add(endpoints[q]);
            endpoints.Add(new(i + xmod * direction, (int)v.Z + ymod * (q + 1)));
            if (q % 2 == 0) direction *= -1;
        }

        // make the tunnels
        for (int z = 0; z < startpoints.Count; z++)
        {
            BoreWavyTunnel(startpoints[z].X, startpoints[z].Y, endpoints[z].X, endpoints[z].Y, 50, 4, 11, stone);
            BoreWavyTunnel(startpoints[z].X, startpoints[z].Y, endpoints[z].X, endpoints[z].Y, 50, 4, 5, 65535);
        }

        // add the points to gen the orbs at
        for (int p = 0; p < endpoints.Count; p++)
        {
            if (WorldGen.genRand.NextBool(2))
            {
                if (endpoints[p].X > i + 5)
                {
                    orbpoints.Add(new(endpoints[p].X + 8, endpoints[p].Y));
                }
                if (endpoints[p].X < i - 5)
                {
                    orbpoints.Add(new(endpoints[p].X - 8, endpoints[p].Y));
                }
            }
        }
        for (int orb = 0; orb < orbpoints.Count; orb++)
        {
            PlaceCorrosionOrb(orbpoints[orb].X, orbpoints[orb].Y + 5);
        }

        CorrosionEnt(i, j, stone, radius, !flag);
    }

    public static void PlaceCorrosionOrb(int i, int j)
    {
        MakeCircle(i, j, 6, (ushort)ModContent.TileType<Gutstone>(), true);
        MakeCircle(i, j, 3, 65535);
        AddGastroOrb(i, j);
    }

    public static void CorrosionEnt(int i, int j, ushort stone, int radius, bool left)
    {
        if (left)
        {
            // Make the tunnel from the surface to the main circle
            for (int x = i - 32; x < i - 4; x++)
            {
                for (int y = j - radius - 25; y < j - radius + 50; y++)
                {
                    int min = WorldGen.genRand.Next(6, 10);
                    int max = WorldGen.genRand.Next(6, 10);
                    int circleSize = WorldGen.genRand.Next(2, 5);
                    int offsetX = WorldGen.genRand.Next(-2, 3);
                    if (x >= i - 25 || x <= i - 11)
                    {
                        MakeCircle(x + offsetX, y + 3, circleSize, stone);
                    }
                    if (x <= i + min - 18 && x >= i - max - 18)
                    {
                        Tile t = Main.tile[x, y];
                        t.HasTile = false;
                        t.WallType = (ushort)ModContent.WallType<GutstoneWall>();
                    }
                    // Make the walls at the top of the entrance randomly jut out
                    if (Main.tile[x, y - 1].WallType == 0 && Main.tile[x, y].WallType == (ushort)ModContent.WallType<GutstoneWall>() && (y < j - radius - 45))
                    {
                        int doubleWide = (WorldGen.genRand.NextBool() ? -1 : 1);
                        Main.tile[x, y - 1].WallType = (ushort)ModContent.WallType<GutstoneWall>();
                        Main.tile[x + doubleWide, y - 1].WallType = (ushort)ModContent.WallType<GutstoneWall>();
                        if (Main.tile[x, y].TileType != stone)
                        {
                            Main.tile[x, y - 2].WallType = (ushort)ModContent.WallType<GutstoneWall>();
                            Main.tile[x + doubleWide, y - 2].WallType = (ushort)ModContent.WallType<GutstoneWall>();
                            Main.tile[x + doubleWide + 1, y - 1].WallType = (ushort)ModContent.WallType<GutstoneWall>();
                            Main.tile[x + doubleWide - 1, y - 1].WallType = (ushort)ModContent.WallType<GutstoneWall>();
                            if (WorldGen.genRand.NextBool(2))
                            {
                                Main.tile[x, y - 3].WallType = (ushort)ModContent.WallType<GutstoneWall>();
                            }
                        }
                    }
                }
            }
        }
        else
        {
            // Make the tunnel from the surface to the main circle
            for (int x = i + 4; x < i + 32; x++)
            {
                for (int y = j - radius - 25; y < j - radius + 50; y++)
                {
                    int min = WorldGen.genRand.Next(6, 10);
                    int max = WorldGen.genRand.Next(6, 10);
                    int circleSize = WorldGen.genRand.Next(2, 5);
                    int offsetX = WorldGen.genRand.Next(-2, 3);
                    if (x >= i + 11 || x <= i + 25)
                    {
                        MakeCircle(x + offsetX, y + 3, circleSize, stone);
                    }
                    if (x <= i + min + 18 && x >= i - max + 18)
                    {
                        Tile t = Main.tile[x, y];
                        t.HasTile = false;
                        t.WallType = (ushort)ModContent.WallType<GutstoneWall>();
                    }
                    // Make the walls at the top of the entrance randomly jut out
                    if (Main.tile[x, y - 1].WallType == 0 && Main.tile[x, y].WallType == (ushort)ModContent.WallType<GutstoneWall>() && (y < j - radius - 45))
                    {
                        int doubleWide = (WorldGen.genRand.NextBool() ? -1 : 1);
                        Main.tile[x, y - 1].WallType = (ushort)ModContent.WallType<GutstoneWall>();
                        Main.tile[x + doubleWide, y - 1].WallType = (ushort)ModContent.WallType<GutstoneWall>();
                        if (Main.tile[x, y].TileType != stone)
                        {
                            Main.tile[x, y - 2].WallType = (ushort)ModContent.WallType<GutstoneWall>();
                            Main.tile[x + doubleWide, y - 2].WallType = (ushort)ModContent.WallType<GutstoneWall>();
                            Main.tile[x + doubleWide + 1, y - 1].WallType = (ushort)ModContent.WallType<GutstoneWall>();
                            Main.tile[x + doubleWide - 1, y - 1].WallType = (ushort)ModContent.WallType<GutstoneWall>();
                            if (WorldGen.genRand.NextBool(2))
                            {
                                Main.tile[x, y - 3].WallType = (ushort)ModContent.WallType<GutstoneWall>();
                            }
                        }
                    }
                }
            }
        }
    }

    public static Vector3 CorrosionStart(int i, int j)
    {
        ushort stone = (ushort)ModContent.TileType<Gutstone>();
        ushort wall = (ushort)ModContent.WallType<GutstoneWall>();
        int k = j;
        if (k > Main.worldSurface)
        {
            k = (int)Main.worldSurface;
        }
        //for (; !WorldGen.SolidTile(i, k); k++)
        //{
        //}
        int num = k;
        Vector2D position = new(i, k);
        Vector2D vector2D = new(WorldGen.genRand.Next(-20, 21) * 0.1, WorldGen.genRand.Next(20, 201) * 0.01);
        double num2 = WorldGen.genRand.Next(15, 26);
        num2 = WorldGen.genRand.Next(40, 55);
        for (int n = 0; n < 50; n++)
        {
            int num4 = (int)position.X + WorldGen.genRand.Next(-20, 21);
            int num5 = (int)position.Y + WorldGen.genRand.Next(-20, 21);
            for (int num6 = (int)(num4 - num2 / 2.0); num6 < num4 + num2 / 2.0; num6++)
            {
                for (int num7 = (int)(num5 - num2 / 2.0); num7 < num5 + num2 / 2.0; num7++)
                {
                    double num8 = Math.Abs(num6 - num4);
                    double num9 = Math.Abs(num7 - num5);
                    double num10 = 1.0 + WorldGen.genRand.Next(-20, 21) * 0.01;
                    double num11 = 1.0 + WorldGen.genRand.Next(-20, 21) * 0.01;
                    double num12 = num8 * num10;
                    num9 *= num11;
                    double num13 = Math.Sqrt(num12 * num12 + num9 * num9);
                    if (num13 < num2 * 0.2)
                    {
                        Main.tile[num6, num7].Active(false);
                        Main.tile[num6, num7].WallType = wall;
                    }
                    else if (num13 < num2 * 0.4 && Main.tile[num6, num7].WallType != wall)
                    {
                        Main.tile[num6, num7].Active(true);
                        Main.tile[num6, num7].TileType = stone;
                        if (num13 < num2 * 0.35)
                        {
                            Main.tile[num6, num7].WallType = wall;
                        }
                    }
                }
            }
        }
        int num14 = WorldGen.genRand.Next(5, 9);
        Vector2D[] array = new Vector2D[num14];
        Vector2D vector2D2 = default;
        for (int num15 = 0; num15 < num14; num15++)
        {
            int num16 = (int)position.X;
            int num17 = (int)position.Y;
            int num18 = 0;
            bool flag2 = true;
            vector2D2 = new(WorldGen.genRand.Next(-20, 21) * 0.15, WorldGen.genRand.Next(0, 21) * 0.15);
            while (flag2)
            {
                vector2D2 = new(WorldGen.genRand.Next(-20, 21) * 0.15, WorldGen.genRand.Next(0, 21) * 0.15);
                while (Math.Abs(vector2D2.X) + Math.Abs(vector2D2.Y) < 1.5)
                {
                    vector2D2 = new(WorldGen.genRand.Next(-20, 21) * 0.15, WorldGen.genRand.Next(0, 21) * 0.15);
                }
                flag2 = false;
                for (int num19 = 0; num19 < num15; num19++)
                {
                    if (vector2D.X > array[num19].X - 0.75 && vector2D.X < array[num19].X + 0.75 && vector2D.Y > array[num19].Y - 0.75 && vector2D.Y < array[num19].Y + 0.75)
                    {
                        flag2 = true;
                        num18++;
                        break;
                    }
                }
                if (num18 > 10000)
                {
                    break;
                }
            }
            array[num15] = vector2D2;
        }
        int num20 = Main.maxTilesX;
        int num21 = 0;
        position.X = i;
        position.Y = num;
        num2 = WorldGen.genRand.Next(25, 35);
        double num22 = WorldGen.genRand.Next(0, 6);
        for (int num23 = 0; num23 < 50; num23++)
        {
            if (num22 > 0.0)
            {
                double num24 = WorldGen.genRand.Next(10, 30) * 0.01;
                num22 -= num24;
                position.Y -= num24;
            }
            int num25 = (int)position.X + WorldGen.genRand.Next(-2, 3);
            int num26 = (int)position.Y + WorldGen.genRand.Next(-2, 3);
            for (int num27 = (int)(num25 - num2 / 2.0); num27 < num25 + num2 / 2.0; num27++)
            {
                for (int num28 = (int)(num26 - num2 / 2.0); num28 < num26 + num2 / 2.0; num28++)
                {
                    double num29 = Math.Abs(num27 - num25);
                    double num30 = Math.Abs(num28 - num26);
                    double num31 = 1.0 + WorldGen.genRand.Next(-20, 21) * 0.005;
                    double num32 = 1.0 + WorldGen.genRand.Next(-20, 21) * 0.005;
                    double num33 = num29 * num31;
                    num30 *= num32;
                    double num34 = Math.Sqrt(num33 * num33 + num30 * num30);
                    if (num34 < num2 * 0.2 * (WorldGen.genRand.Next(90, 111) * 0.01))
                    {
                        Main.tile[num27, num28].Active(false);
                        Main.tile[num27, num28].WallType = wall;
                    }
                    else
                    {
                        if (!(num34 < num2 * 0.45))
                        {
                            continue;
                        }
                        if (num27 < num20)
                        {
                            num20 = num27;
                        }
                        if (num27 > num21)
                        {
                            num21 = num27;
                        }
                        if (Main.tile[num27, num28].WallType != wall)
                        {
                            Main.tile[num27, num28].Active(true);
                            Main.tile[num27, num28].TileType = stone;
                            if (num34 < num2 * 0.35)
                            {
                                Main.tile[num27, num28].WallType = wall;
                            }
                        }
                    }
                }
            }
        }
        float yc = 0;
        for (int num35 = num20; num35 <= num21; num35++)
        {
            int num36;
            for (num36 = num; (Main.tile[num35, num36].TileType == stone && Main.tile[num35, num36].HasTile) || Main.tile[num35, num36].WallType == wall; num36++)
            {
            }
            int num37 = WorldGen.genRand.Next(15, 20);
            for (; !Main.tile[num35, num36].HasTile; num36++)
            {
                if (num37 <= 0)
                {
                    break;
                }
                if (Main.tile[num35, num36].WallType == wall)
                {
                    break;
                }
                num37--;
                Main.tile[num35, num36].TileType = stone;
                Main.tile[num35, num36].Active(true);
            }
            yc = num36;
        }
        return new Vector3(num20, num21, yc);
        //CrimEnt(position, crimDir);
    }

    /// <summary>
    /// Helper method to generate a sinewave-like tunnel between 2 points. 
    /// Uses the MakeCircle method to generate the tunnel.
    /// </summary>
    /// <param name="startX">The starting X coordinate.</param>
    /// <param name="startY">The starting Y coordinate.</param>
    /// <param name="endX">The ending X coordinate.</param>
    /// <param name="endY">The ending Y coordinate.</param>
    /// <param name="wavelength">The wavelength of the wave.</param>
    /// <param name="amplitude">The amiplitude of the wave.</param>
    /// <param name="radius">The radius of the tunnel.</param>
    /// <param name="type">The tile type to place.</param>
    public static void BoreWavyTunnel(int startX, int startY, int endX, int endY, int wavelength, float amplitude, int radius, ushort type)
    {
        float length = Vector2.Distance(new Vector2(startX, startY), new Vector2(endX, endY));
        float direction = (float)Math.Atan2(endY - startY, endX - startX);
        float t = 0f;

        while (t <= 1f)
        {
            int x = (int)MathHelper.Lerp(startX, endX, t);
            int y = (int)MathHelper.Lerp(startY, endY, t) + (int)(Math.Sin(t * length / wavelength * MathHelper.TwoPi) * amplitude);

            // Place the desired tile or perform any other action
            MakeCircle(x, y, radius, type);

            t += 1f / length;
        }
    }
    /// <summary>
    ///     Places a Gastro Orb at the given coordinates. For the Corrosion.
    /// </summary>
    /// <param name="x">X coordinate.</param>
    /// <param name="y">Y coordinate.</param>
    /// <param name="style">Unused.</param>
    public static void AddGastroOrb(int x, int y)
    {
        if (x < 10 || x > Main.maxTilesX - 10)
        {
            return;
        }

        if (y < 10 || y > Main.maxTilesY - 10)
        {
            return;
        }

        for (int i = x - 1; i < x + 1; i++)
        {
            for (int j = y - 1; j < y + 1; j++)
            {
                if (Main.tile[i, j].HasTile && Main.tile[i, j].TileType == (ushort)ModContent.TileType<GastroOrb>())
                {
                    return;
                }
            }
        }

        short num = 0;
        Main.tile[x - 1, y - 1].Active(true);
        Main.tile[x - 1, y - 1].TileType = (ushort)ModContent.TileType<GastroOrb>();
        Main.tile[x - 1, y - 1].TileFrameX = num;
        Main.tile[x - 1, y - 1].TileFrameY = 0;
        Main.tile[x, y - 1].Active(true);
        Main.tile[x, y - 1].TileType = (ushort)ModContent.TileType<GastroOrb>();
        Main.tile[x, y - 1].TileFrameX = (short)(18 + num);
        Main.tile[x, y - 1].TileFrameY = 0;
        Main.tile[x - 1, y].Active(true);
        Main.tile[x - 1, y].TileType = (ushort)ModContent.TileType<GastroOrb>();
        Main.tile[x - 1, y].TileFrameX = num;
        Main.tile[x - 1, y].TileFrameY = 18;
        Main.tile[x, y].Active(true);
        Main.tile[x, y].TileType = (ushort)ModContent.TileType<GastroOrb>();
        Main.tile[x, y].TileFrameX = (short)(18 + num);
        Main.tile[x, y].TileFrameY = 18;
    }
    public static void MakeCircle(int x, int y, float r, ushort type, bool center = false)
    {
        int num = (int)(x - r);
        int num2 = (int)(y - r);
        int num3 = (int)(x + r);
        int num4 = (int)(y + r);
        for (int i = num; i < num3 + 1; i++)
        {
            for (int j = num2; j < num4 + 1; j++)
            {
                if (Vector2.Distance(new Vector2(i, j), new Vector2(x, y)) <= r &&
                    Main.tile[i, j].TileType != TileID.ShadowOrbs && Main.tile[i, j].TileType != ModContent.TileType<GastroOrb>())
                {
                    if (type == 65535)
                    {
                        Main.tile[i, j].Active(false);
                        Main.tile[i, j].WallType = (ushort)ModContent.WallType<GutstoneWall>();
                    }
                    else
                    {
                        if (Main.tile[i, j].WallType != ModContent.WallType<GutstoneWall>())
                        {
                            Main.tile[i, j].Active(true);
                            Main.tile[i, j].TileType = type;
                            if (Vector2.Distance(new Vector2(i, j), new Vector2(x, y)) <= r - 2)
                            {
                                Main.tile[i, j].WallType = (ushort)ModContent.WallType<GutstoneWall>();
                            }
                            WorldGen.SquareTileFrame(i, j);
                        }
                        else if (center)
                        {
                            Main.tile[i, j].Active(true);
                            Main.tile[i, j].TileType = type;
                            Main.tile[i, j].WallType = (ushort)ModContent.WallType<GutstoneWall>();
                            WorldGen.SquareTileFrame(i, j);
                        }
                    }
                }
            }
        }
    }
}
