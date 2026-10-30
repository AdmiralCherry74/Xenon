using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Biomes.Catacombs;
using Xenon.Content.Biomes.Corrosion;
using Xenon.Content.Tiles.ActiveAndWiring.Traps;
using Xenon.Content.Tiles.Natural.Autumn;
using Xenon.Content.Tiles.Natural.Corrosion;
using Xenon.Content.Tiles.Natural.MountainsAndTheKarst;
using Xenon.Content.Tiles.Natural.MountainsAndTheKarst.Mossy;
using Xenon.Content.Tiles.Natural.NaturalStone;
using Xenon.Content.Tiles.Natural.OceanAndTheMarine;
using Xenon.Content.Tiles.Natural.Ores.PreHardOres;

namespace Xenon.Common;

public class SpawnHelper
{
    public static bool Evil(ref NPCSpawnInfo spawnInfo)
    {
        return Corrosion(ref spawnInfo) || Crimson(ref spawnInfo) || Corruption(ref spawnInfo);
    }
    public static bool Autumn(ref NPCSpawnInfo spawnInfo)
    {
        return spawnInfo.SpawnTileType == ModContent.TileType<AutumnGrass>()
        //|| spawnInfo.SpawnTileType == ModContent.TileType<CorrosionAutumnGrass>()
        //|| spawnInfo.SpawnTileType == ModContent.TileType<CorruptionAutumnGrass>()
        //|| spawnInfo.SpawnTileType == ModContent.TileType<CrimsonAutumnGrass>()
        || spawnInfo.SpawnTileType == ModContent.TileType<Mulch>();
    }
    public static bool Corrosion(ref NPCSpawnInfo spawnInfo)
    {
        return !spawnInfo.Player.InPillarZone() && ((spawnInfo.Player.InModBiome<Corrosion>() && spawnInfo.SpawnTileType == ModContent.TileType<IngestaneOre>())
            || spawnInfo.SpawnTileType == ModContent.TileType<CorrosionGrass>()
            || spawnInfo.SpawnTileType == ModContent.TileType<CorrosionJungleGrass>()
            || spawnInfo.SpawnTileType == ModContent.TileType<Gutstone>()
            || spawnInfo.SpawnTileType == ModContent.TileType<Gutsand>()
            || spawnInfo.SpawnTileType == ModContent.TileType<CorrosionAutumnGrass>()
            || spawnInfo.SpawnTileType == ModContent.TileType<BrownIce>());
    }
    public static bool Crimson(ref NPCSpawnInfo spawnInfo)
    {
        return !spawnInfo.Player.InPillarZone() && ((spawnInfo.Player.ZoneCrimson && spawnInfo.SpawnTileType == TileID.Crimtane)
            || spawnInfo.SpawnTileType == TileID.CrimsonGrass
            || spawnInfo.SpawnTileType == TileID.CrimsonJungleGrass
            || spawnInfo.SpawnTileType == TileID.Crimstone
            || spawnInfo.SpawnTileType == TileID.Crimsand
            || spawnInfo.SpawnTileType == ModContent.TileType<CrimsonAutumnGrass>()
            || spawnInfo.SpawnTileType == TileID.FleshIce);
    }
    public static bool Corruption(ref NPCSpawnInfo spawnInfo)
    {
        return !spawnInfo.Player.InPillarZone() && ((spawnInfo.Player.ZoneCorrupt && spawnInfo.SpawnTileType == TileID.Demonite)
            || spawnInfo.SpawnTileType == TileID.CorruptGrass
            || spawnInfo.SpawnTileType == TileID.CorruptJungleGrass
            || spawnInfo.SpawnTileType == TileID.Ebonstone
            || spawnInfo.SpawnTileType == TileID.Ebonsand
            || spawnInfo.SpawnTileType == ModContent.TileType<CorruptionAutumnGrass>()
            || spawnInfo.SpawnTileType == TileID.CorruptIce);
    }
    public static bool Hallow(ref NPCSpawnInfo spawnInfo)
    {
        return !spawnInfo.Player.InPillarZone() && Main.hardMode &&
            (spawnInfo.SpawnTileType == TileID.HallowedGrass
            || spawnInfo.SpawnTileType == TileID.HallowedIce
            || spawnInfo.SpawnTileType == TileID.Pearlstone
            || spawnInfo.SpawnTileType == TileID.Pearlsand);
    }
    public static bool NotInDungeonsOrPillar(ref NPCSpawnInfo spawnInfo)
    {
        return !spawnInfo.Player.ZoneDungeon && !spawnInfo.Player.InPillarZone() && !Catacombs(ref spawnInfo);
    }
    public static bool Catacombs(ref NPCSpawnInfo spawnInfo)
    {
        return spawnInfo.Player.InModBiome<Catacombs>();
    }
    public static bool Surface(ref NPCSpawnInfo spawnInfo)
    {
        return spawnInfo.SpawnTileY <= Main.worldSurface && NotInDungeonsOrPillar(ref spawnInfo);
    }
    public static bool Underground(ref NPCSpawnInfo spawnInfo)
    {
        return spawnInfo.SpawnTileY > Main.worldSurface && NotInDungeonsOrPillar(ref spawnInfo);
    }
    public static bool RockLayer(ref NPCSpawnInfo spawnInfo)
    {
        return spawnInfo.SpawnTileY > Main.rockLayer && NotInDungeonsOrPillar(ref spawnInfo);
    }
    public static bool NotNoWorms(ref NPCSpawnInfo spawnInfo)
    {
        return spawnInfo.Player.afkCounter < NPC.AFKTimeNeededForNoWorms || spawnInfo.Player.ZoneShadowCandle;
    }
    public static bool Mushroom(ref NPCSpawnInfo spawnInfo)
    {
        return NotInDungeonsOrPillar(ref spawnInfo) && (spawnInfo.SpawnTileType == TileID.MushroomGrass || spawnInfo.SpawnTileType == ModContent.TileType<MushroomGrassMulch>());
    }
    public static bool Ocean(ref NPCSpawnInfo spawnInfo)
    {
        return NotInDungeonsOrPillar(ref spawnInfo) && spawnInfo.Water && (spawnInfo.SpawnTileX < 250 || spawnInfo.SpawnTileX > Main.maxTilesX - 250) && Main.tileSand[spawnInfo.SpawnTileType] && spawnInfo.SpawnTileY < Main.rockLayer;
    }
    public static bool Beach(ref NPCSpawnInfo spawnInfo)
    {
        return NotInDungeonsOrPillar(ref spawnInfo) && (spawnInfo.SpawnTileX < 340 || spawnInfo.SpawnTileX > Main.maxTilesX - 340) && Main.tileSand[spawnInfo.SpawnTileType] && spawnInfo.SpawnTileY < Main.rockLayer;
    }
    public static bool UndergroundOcean(ref NPCSpawnInfo spawnInfo)
    {
        return Underground(ref spawnInfo) && (
            spawnInfo.SpawnTileType == ModContent.TileType<MarineSand>() ||
            spawnInfo.SpawnTileType == ModContent.TileType<MarineSandstone>() ||
            spawnInfo.SpawnTileType == ModContent.TileType<MarineQuicksand>() ||
            spawnInfo.SpawnTileType == ModContent.TileType<HardenedMarineSand>()
            );
    }
    public static bool Mountain(ref NPCSpawnInfo spawnInfo)
    {
        return
            NotInDungeonsOrPillar(ref spawnInfo) && (
            spawnInfo.SpawnTileType == ModContent.TileType<OuranoStone>() ||
            spawnInfo.SpawnTileType == ModContent.TileType<NyxStone>() ||
            spawnInfo.SpawnTileType == ModContent.TileType<AresStone>() ||
            spawnInfo.SpawnTileType == ModContent.TileType<HelioStone>() ||
            spawnInfo.SpawnTileType == ModContent.TileType<HephStone>() ||
            spawnInfo.SpawnTileType == ModContent.TileType<MossyOuranoStone>() ||
            spawnInfo.SpawnTileType == ModContent.TileType<MossyNyxStone>() ||
            spawnInfo.SpawnTileType == ModContent.TileType<MossyAresStone>() ||
            spawnInfo.SpawnTileType == ModContent.TileType<MossyHelioStone>() ||
            spawnInfo.SpawnTileType == ModContent.TileType<MossyHephStone>());
    }
    public static bool Rhyolite(ref NPCSpawnInfo spawnInfo)
    {
        return NotInDungeonsOrPillar(ref spawnInfo) && spawnInfo.SpawnTileType == ModContent.TileType<Rhyolite>();
    }
    public static bool Snow(ref NPCSpawnInfo spawnInfo)
    {
        return
            NotInDungeonsOrPillar(ref spawnInfo) && (
            spawnInfo.SpawnTileType == TileID.SnowBlock ||
            TileID.Sets.Conversion.Ice[spawnInfo.SpawnTileType]);
    }
    public static bool Desert(ref NPCSpawnInfo spawnInfo)
    {
        return
            NotInDungeonsOrPillar(ref spawnInfo) && (
            TileID.Sets.Conversion.Sand[spawnInfo.SpawnTileType] ||
            TileID.Sets.Conversion.HardenedSand[spawnInfo.SpawnTileType] ||
            TileID.Sets.Conversion.Sandstone[spawnInfo.SpawnTileType]);
    }
    public static bool Purity(ref NPCSpawnInfo spawnInfo)
    {
        if (spawnInfo.SpawnTileY > Main.UnderworldLayer)
            return false;
        if (TileLoader.TryGetConversionFallback(spawnInfo.SpawnTileType, BiomeConversionID.Purity, out int t))
            return t == spawnInfo.SpawnTileType;
        return !Autumn(ref spawnInfo) && !Desert(ref spawnInfo) && !Snow(ref spawnInfo);
    }
}
