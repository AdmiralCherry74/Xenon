using AltLibrary.Common.AltBiomes;
using Terraria.GameContent.Personalities;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Xenon.Content.Tiles.Corrosion;
using Xenon.Content.WorldGeneration;
using Xenon.Content.Items.Placeable.Seed;
using Xenon.Content.Walls;

namespace Xenon.ModSupport;

[ExtendsFromMod(nameof(AltLibrary))]
internal class CorrosionAltBiome : AltBiome
{
    public override string WorldIcon => $"{nameof(Xenon)}/{Xenon.TextureAssetsPath}/UI/IconOverlayCorrosion";
    public override string OuterTexture => $"{nameof(Xenon)}/{Xenon.TextureAssetsPath}/UI/LoadingOuterCorrosion";
    public override string IconSmall => $"{nameof(Xenon)}/{Xenon.TextureAssetsPath}/UI/IconCorrosion";
    public override Color OuterColor => new(167, 158, 29);
    public override IShoppingBiome Biome => ModContent.GetInstance<Content.Biomes.Corrosion>();
    public override Color NameColor => Color.Yellow;
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
        BiomeOre = ModContent.TileType<UlceriteOre>();
        BiomeOreItem = ModContent.ItemType<Content.Items.Placeable.Tile.UlceriteOre>();
        /*BiomeOreBrick = ModContent.TileType<Tiles.BacciliteBrick>();
        ArrowType = ModContent.ItemType<Items.Ammo.IckyArrow>();
        AltarTile = ModContent.TileType<IckyAltar>();

        BiomeChestItem = ModContent.ItemType<VirulentScythe>();
        BiomeChestTile = ModContent.TileType<CorrosionChest>();
        BiomeChestTileStyle = 1;
        BiomeKeyItem = ModContent.ItemType<CorrosionKey>();

        MimicType = ModContent.NPCType<CorrosionMimic>();

        //BloodBunny = ModContent.NPCType<ContaminatedBunny>();
        //BloodPenguin = ModContent.NPCType<ContaminatedPenguin>();
        //BloodGoldfish = ModContent.NPCType<ContaminatedGoldfish>();
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
