using AltLibrary.Common.AltBiomes;
using Terraria.GameContent.Personalities;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Xenon.Content.WorldGeneration;
using Xenon.Content.Tiles.Natural.Corrosion;
using Xenon.Content.Walls.NaturalWalls.Corrosion;
using Xenon.Content.NPCs.Other;
using Xenon.Content.Tiles.Bricks;
using Xenon.Content.Items.Placeable.Blocks.Natural.Seed;

namespace Xenon.ModSupport;

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
        AddTileConversion(ModContent.TileType<TanIce>(), TileID.IceBlock);

        GERunnerConversion.Add(TileID.Silt, ModContent.TileType<Gutsand>());

        /* missing flesh/lesion counterpart
		BiomeFlesh = ;
		BiomeFleshWall = ;

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
        BiomeOre = ModContent.TileType<Content.Tiles.Natural.Corrosion.IngestaneOre>();
        BiomeOreItem = ModContent.ItemType<Content.Items.Placeable.Blocks.Natural.OresAndGems.IngestaneOre>();

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
}
