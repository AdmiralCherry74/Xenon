using Terraria.GameContent.Personalities;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Xenon.Content.WorldGeneration;
using Xenon.Content.Tiles.Natural.Corrosion;
using Xenon.Content.Walls.NaturalWalls.Corrosion;
using Xenon.Content.NPCs.Other;
using Xenon.Content.Items.Placeable.Blocks.Natural.Seed;
using AltLibrary.Common.AltBiomes;
using AltLibrary.Common.AltOres;
using Xenon.Content.Items.Accessories;
using Xenon.Content.Tiles.Building.Bricks;
using Xenon.Content.Tiles.Building.Decorational;
using Xenon.Content.Tiles.Natural.Ores.PreHardOres;
using Xenon.Content.Items.Placeable.Blocks.Natural.OresAndGems.PreHardOres;
using Xenon.Content.Items.Materials.BarsGems.PreHardBars;
using Xenon.Content.Tiles.Natural.Autumn;

namespace Xenon.ModSupport;

[ExtendsFromMod(nameof(AltLibrary))]
public class AluminumAltOre : AltOre
{
	public override OreSlot OreSlot => ModContent.GetInstance<CopperOreSlot>();
	public override void SetStaticDefaults()
	{
		ore = ModContent.TileType<AluminumOre>();
		bar = ModContent.ItemType<AluminumBar>();
		Watch = ModContent.ItemType<AluminumWatch>();
	}
}
[ExtendsFromMod(nameof(AltLibrary))]
public class CinnabarAltOre : AltOre
{
	public override OreSlot OreSlot => ModContent.GetInstance<IronOreSlot>();
	public override void SetStaticDefaults()
	{
		ore = ModContent.TileType<CinnabarOre>();
		bar = ModContent.ItemType<CinnabarBar>();
	}
}
[ExtendsFromMod(nameof(AltLibrary))]
public class IndiumAltOre : AltOre
{
	public override OreSlot OreSlot => ModContent.GetInstance<SilverOreSlot>();
	public override void SetStaticDefaults()
	{
		ore = ModContent.TileType<IndiumOre>();
		bar = ModContent.ItemType<IndiumBar>();
		Watch = ModContent.ItemType<IndiumWatch>();
	}
}
[ExtendsFromMod(nameof(AltLibrary))]
public class FluoriteAltOre : AltOre
{
	public override OreSlot OreSlot => ModContent.GetInstance<GoldOreSlot>();
	public override void SetStaticDefaults()
	{
		ore = ModContent.TileType<FluoriteOre>();
		bar = ModContent.ItemType<FluoriteBar>();
		Watch = ModContent.ItemType<FluoriteWatch>();
	}
}
[ExtendsFromMod(nameof(AltLibrary))]
internal class CorrosionAltBiome : AltBiome
{
    public override string WorldIcon => $"{nameof(Xenon)}/{XenonMod.TextureAssetsPath}/UI/IconOverlayCorrosion";
    public override string OuterTexture => $"{nameof(Xenon)}/{XenonMod.TextureAssetsPath}/UI/LoadingOuterCorrosion";
    public override string IconSmall => $"{nameof(Xenon)}/{XenonMod.TextureAssetsPath}/UI/IconCorrosion";
    public override Color OuterColor => new(167, 158, 29);
    public override IShoppingBiome Biome => ModContent.GetInstance<Content.Biomes.Corrosion>();
    public override Color NameColor => new Color(232, 221, 102);
    public override void SetStaticDefaults()
    {
        BiomeType = AltLibrary.BiomeType.Evil;

        AddTileConversion(ModContent.TileType<CorrosionGrass>(), TileID.Grass);
        AddTileConversion(ModContent.TileType<CorrosionJungleGrass>(), TileID.JungleGrass);
        AddTileConversion(ModContent.TileType<Gutstone>(), TileID.Stone);
        AddTileConversion(ModContent.TileType<Gutsand>(), TileID.Sand);
        AddTileConversion(ModContent.TileType<Gutsandstone>(), TileID.Sandstone);
        AddTileConversion(ModContent.TileType<HardenedGutsand>(), TileID.HardenedSand);
        AddTileConversion(ModContent.TileType<BrownIce>(), TileID.IceBlock);

        GERunnerConversion.Add(TileID.Silt, ModContent.TileType<Gutsand>());


		BiomeFlesh = ModContent.TileType<UlcerBlock>();
		/*BiomeFleshWall = ;

		FleshDoorTile = ;
		FleshChairTile = ;
		FleshTableTile = ;
		FleshChestTile = ;
		FleshDoorTileStyle = 7;
		FleshChairTileStyle = 7;
		FleshTableTileStyle = 7;
		FleshChestTileStyle = 7;
		*/

        //FountainTile = ModContent.TileType<Tiles.Furniture.WaterFountains>();
        //FountainTileStyle = 0;

        SeedType = ModContent.ItemType<CorrosionSeeds>();
        BiomeOre = ModContent.TileType<Content.Tiles.Natural.Ores.PreHardOres.IngestaneOre>();
        BiomeOreItem = ModContent.ItemType<Content.Items.Placeable.Blocks.Natural.OresAndGems.PreHardOres.IngestaneOre>();

        AltarTile = ModContent.TileType<GastricAltar>();
        BiomeOreBrick = ModContent.TileType<IngestaneBrick>();

        BloodBunny = ModContent.NPCType<SulfurBunny>();
        BloodPenguin = ModContent.NPCType<SulfurPenguin>();
        BloodGoldfish = ModContent.NPCType<SulfurGoldfish>();


        /*ArrowType = ModContent.ItemType<Items.Ammo.IckyArrow>();
       

        BiomeChestItem = ModContent.ItemType<VirulentScythe>();
        BiomeChestTile = ModContent.TileType<CorrosionChest>();
        BiomeChestTileStyle = 1;
        BiomeKeyItem = ModContent.ItemType<CorrosionKey>();

        MimicType = ModContent.NPCType<CorrosionMimic>();

        */
        AddWallConversions<CorrosionLumpWallUnsafe>(
            WallID.RocksUnsafe3
        );
        AddWallConversions<CorrosionMoldWallUnsafe>(
            WallID.Cave3Unsafe,
            WallID.RocksUnsafe2
        );
        AddWallConversions<CorrosionCystWallUnsafe>(
            WallID.Cave4Unsafe,
            WallID.Cave5Unsafe,
            WallID.RocksUnsafe1
        );
        AddWallConversions<CorrosionBoilWallUnsafe>(
            WallID.Cave8Unsafe,
            WallID.RocksUnsafe4
        );
		/*AddWallConversions<GutsandstoneWall>(
            WallID.Sandstone,
            WallID.CorruptSandstone,
            WallID.CrimsonSandstone,
            WallID.HallowSandstone
        );
        AddWallConversions<HardenedGutsandWallUnsafe>(
            WallID.HardenedSand,
            WallID.CorruptHardenedSand,
            WallID.CrimsonHardenedSand,
            WallID.HallowHardenedSand
        );*/
		AddWallConversions<CorrosionGrassWall>(
            WallID.GrassUnsafe,
            WallID.Grass,
            WallID.FlowerUnsafe,
            WallID.Flower
        );

        EvilBiomeGenerationPass = new Corrosion();
    }

    [ExtendsFromMod(nameof(AltLibrary))]
    public class AutumnAltBiome : AltBiome
    {
        public override string IconSmall => $"{nameof(Xenon)}/{XenonMod.TextureAssetsPath}/UI/IconAutumn";
        public override Color OuterColor => new(220, 148, 199);
        public override IShoppingBiome Biome => ModContent.GetInstance<Content.Biomes.Autumn>();
        public override Color NameColor => new(220, 105, 63);
        //public override bool Selectable => ModContent.GetInstance<AvalonClientConfig>().BetaTropicsGen;
        public override void SetStaticDefaults()
        {
            BiomeType =  AltLibrary.BiomeType.Jungle;
            BiomeJungleGrass = ModContent.TileType<AutumnGrass>();
            BiomeMud = ModContent.TileType<Mulch>();
        }
        public override AltMaterialContext MaterialContext => new()
        {
            //TropicalHerb = ModContent.ItemType<TwilightPlume>(),
            //TropicalBar = ModContent.ItemType<XanthophyteBar>(),
            //TropicalComponent = ModContent.ItemType<>(),
            //TropicalSword = ModContent.ItemType<>()
        };
        /*
        public override void ModifyGenPass(List<GenPass> passes, GenPass originalPass)
        {
            switch (originalPass.Name)
            {
                case "Wet Jungle":
                    originalPass.Disable();
                    passes.Add(new PassLegacy("Wet Savanna", new WorldGenLegacyMethod(Savanna.JunglesWetTask)));
                    break;
                case "Ice":
                    passes.Add(new PassLegacy("Tuhrtl Brick Unsolid", new WorldGenLegacyMethod(delegate (GenerationProgress progress, GameConfiguration config)
                    {
                        Main.tileSolid[ModContent.TileType<Tiles.Savanna.TuhrtlBrick>()] = false;
                        Main.tileSolid[ModContent.TileType<Tiles.Savanna.BrambleSpikes>()] = false;
                    })));
                    break;
                case "Mud Caves To Grass":
                    originalPass.Disable();
                    passes.Add(new PassLegacy("Loam", new WorldGenLegacyMethod(delegate (GenerationProgress progress, GameConfiguration configuration)
                    {
                        int tile = ModContent.TileType<Tiles.Savanna.Loam>();
                        for (int i = 0; i < Main.maxTilesX; i++)
                        {
                            for (int j = 0; j < Main.maxTilesY; j++)
                            {
                                if (Main.tile[i, j].HasTile && Main.tile[i, j].TileType == TileID.Mud)
                                {
                                    Main.tile[i, j].TileType = (ushort)tile;
                                }
                            }
                        }
                    })));
                    passes.Add(new PassLegacy("Loam Caves To Grass", new WorldGenLegacyMethod(Savanna.JunglesGrassTask)));
                    break;
                case "Jungle Temple":
                    originalPass.Disable();
                    passes.Add(new PassLegacy("Tuhrtl Outpost", new WorldGenLegacyMethod(Savanna.TuhrtlOutpostTask)));
                    passes.Add(new PassLegacy("Outpost Traps", new WorldGenLegacyMethod(Savanna.TuhrtlOutpostReplaceTraps)));
                    break;
                case "Hives":
                    originalPass.Disable();
                    passes.Add(new PassLegacy("Wasp Nests", new WorldGenLegacyMethod(Savanna.WaspNests)));
                    break;
                case "Jungle Chests":
                    originalPass.Disable();
                    passes.Add(new PassLegacy("Savanna Sanctums", new WorldGenLegacyMethod(Savanna.SavannaSanctumTask)));
                    break;
                case "Muds Walls In Jungle":
                    originalPass.Disable();
                    passes.Add(new PassLegacy("Loam Walls in Savanna", new WorldGenLegacyMethod(delegate (GenerationProgress progress, GameConfiguration passConfig)
                    {
                        progress.Set(1.0);
                        int num171 = 0;
                        int num172 = 0;
                        bool flag4 = false;
                        for (int num173 = 5; num173 < Main.maxTilesX - 5; num173++)
                        {
                            for (int num174 = 0; num174 < Main.worldSurface + 20.0; num174++)
                            {
                                if (Main.tile[num173, num174].HasTile && Main.tile[num173, num174].TileType == ModContent.TileType<Tiles.Savanna.SavannaGrass>())
                                {
                                    num171 = num173;
                                    flag4 = true;
                                    break;
                                }
                            }

                            if (flag4)
                                break;
                        }

                        flag4 = false;
                        for (int num175 = Main.maxTilesX - 5; num175 > 5; num175--)
                        {
                            for (int num176 = 0; num176 < Main.worldSurface + 20.0; num176++)
                            {
                                if (Main.tile[num175, num176].HasTile && Main.tile[num175, num176].TileType == ModContent.TileType<Tiles.Savanna.SavannaGrass>())
                                {
                                    num172 = num175;
                                    flag4 = true;
                                    break;
                                }
                            }

                            if (flag4)
                                break;
                        }
                        GenVars.jungleMinX = num171;
                        GenVars.jungleMaxX = num172;
                        for (int num177 = num171; num177 <= num172; num177++)
                        {
                            for (int num178 = 0; (double)num178 < Main.maxTilesY - 200; num178++)
                            {
                                if (((num177 >= num171 + 2 && num177 <= num172 - 2) || !WorldGen.genRand.NextBool(2)) &&
                                    ((num177 >= num171 + 3 && num177 <= num172 - 3) || !WorldGen.genRand.NextBool(3)) &&
                                    (Main.tile[num177, num178].WallType == WallID.DirtUnsafe || Main.tile[num177, num178].WallType == WallID.Cave6Unsafe ||
                                    Main.tile[num177, num178].WallType == WallID.MudUnsafe))
                                {
                                    Main.tile[num177, num178].WallType = (ushort)ModContent.WallType<Walls.LoamWall>();
                                }
                            }
                        }
                        for (int q = GenVars.jungleMinX; q <= GenVars.jungleMaxX; q++)
                        {
                            for (int z = 0; (double)z < Main.maxTilesY - 200; z++)
                            {
                                if ((q < GenVars.jungleMinX + 75 && q >= GenVars.jungleMinX + 50) ||
                                    (q > GenVars.jungleMaxX - 75 && q <= GenVars.jungleMaxX - 50) &&
                                    z < Main.rockLayer && z > 250)
                                {
                                    if (Main.tile[q, z].HasTile && WorldGen.genRand.NextBool(10))
                                    {
                                        if (Main.tile[q, z].TileType == TileID.Grass)
                                        {
                                            Main.tile[q, z].TileType = (ushort)ModContent.TileType<Tiles.Savanna.SavannaGrass>();
                                        }
                                        if (Main.tile[q, z].TileType == TileID.Dirt)
                                        {
                                            Main.tile[q, z].TileType = (ushort)ModContent.TileType<Tiles.Savanna.Loam>();
                                        }
                                    }
                                }

                                if (q >= GenVars.jungleMinX + 75 && q <= GenVars.jungleMaxX - 75 && z < Main.rockLayer && z > 250)
                                {
                                    if (Main.tile[q, z].HasTile)
                                    {
                                        if (Main.tile[q, z].TileType == TileID.Grass)
                                        {
                                            Main.tile[q, z].TileType = (ushort)ModContent.TileType<Tiles.Savanna.SavannaGrass>();
                                        }
                                        if (Main.tile[q, z].TileType == TileID.Dirt)
                                        {
                                            Main.tile[q, z].TileType = (ushort)ModContent.TileType<Tiles.Savanna.Loam>();
                                        }
                                        if (Main.tile[q, z].TileType == TileID.Plants)
                                        {
                                            Main.tile[q, z].TileType = (ushort)ModContent.TileType<Tiles.Savanna.SavannaShortGrass>();
                                        }
                                        if (Main.tile[q, z].TileType == TileID.Plants2)
                                        {
                                            Main.tile[q, z].TileType = (ushort)ModContent.TileType<Tiles.Savanna.SavannaLongGrass>();
                                        }
                                    }
                                }
                            }
                        }
                    })));
                    break;
                case "Temple":
                    originalPass.Disable();
                    passes.Add(new PassLegacy("Re-solidify Lihzahrd Brick", new WorldGenLegacyMethod(Savanna.LihzahrdBrickReSolidTask)));
                    break;
                case "Glowing Mushrooms and Jungle Plants":
                    originalPass.Disable();
                    passes.Add(new PassLegacy("Glowing Mushrooms and Savanna Plants", new WorldGenLegacyMethod(Savanna.GlowingMushroomsandJunglePlantsTask)));
                    break;
                case "Jungle Plants":
                    originalPass.Disable();
                    passes.Add(new PassLegacy("Savanna Plants", new WorldGenLegacyMethod(Savanna.JungleBushesTask)));
                    break;
            }
        }
        */
    }
}
