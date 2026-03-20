using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Consumables.NomNoms;
using Xenon.Content.Items.Placeable.Blocks.Natural.Stone;
using Xenon.Content.Items.Placeable.Wall.BuildingWalls.Stone.Catacombs;
using Xenon.Content.Items.Weapons.Melee.Swords;

namespace Xenon.Common.Globals;

public class XenonGlobalItem : GlobalItem
{
    public override void SetStaticDefaults()
    {
        ItemID.Sets.ShimmerTransformToItem[ItemID.Marble] = ItemID.Granite;
        ItemID.Sets.ShimmerTransformToItem[ItemID.Granite] = ModContent.ItemType<RhyoliteBlock>();
        ItemID.Sets.ShimmerTransformToItem[ModContent.ItemType<RhyoliteBlock>()] = ItemID.Marble;

        ItemID.Sets.ShimmerTransformToItem[ItemID.Pizza] = ItemID.Spaghetti;
        ItemID.Sets.ShimmerTransformToItem[ItemID.Spaghetti] = ModContent.ItemType<TunaMelt>();
        ItemID.Sets.ShimmerTransformToItem[ModContent.ItemType<TunaMelt>()] = ItemID.Pizza;

        ItemID.Sets.ShimmerTransformToItem[ItemID.IceFeather] = ItemID.FireFeather; //this shit is fucking glitched i spent nearly an irl hour straight farming and I got jack shit. the drop rates are bugged idgaf for the balence, Flame wings should be pre-mech anyway fuck you balence nerds
        ItemID.Sets.ShimmerTransformToItem[ItemID.FireFeather] = ItemID.IceFeather; //seriously how the fuck has relogic not checked this shit for a damn bug, im so angry, horny and sleep deprived you dont even know it and this shits gonna make me kill ReLogic so hard seriously please fucking fix your drop chance

        ItemID.Sets.ShimmerTransformToItem[ItemID.LavaCharm] = ItemID.MagmaStone;
        ItemID.Sets.ShimmerTransformToItem[ItemID.MagmaStone] = ItemID.ObsidianRose;
        ItemID.Sets.ShimmerTransformToItem[ItemID.ObsidianRose] = ItemID.LavaCharm;

        ItemID.Sets.ShimmerTransformToItem[ItemID.AnglerHat] = ItemID.AnglerVest;
        ItemID.Sets.ShimmerTransformToItem[ItemID.AnglerVest] = ItemID.AnglerPants;
        ItemID.Sets.ShimmerTransformToItem[ItemID.AnglerPants] = ItemID.AnglerHat;

        ItemID.Sets.ShimmerTransformToItem[ItemID.MiningHelmet] = ItemID.MiningShirt;
        ItemID.Sets.ShimmerTransformToItem[ItemID.MiningShirt] = ItemID.MiningPants;
        ItemID.Sets.ShimmerTransformToItem[ItemID.MiningPants] = ItemID.MiningHelmet;

        ItemID.Sets.ShimmerTransformToItem[ItemID.SuperAbsorbantSponge] = ItemID.LavaAbsorbantSponge;
        ItemID.Sets.ShimmerTransformToItem[ItemID.LavaAbsorbantSponge] = ItemID.HoneyAbsorbantSponge;
        ItemID.Sets.ShimmerTransformToItem[ItemID.HoneyAbsorbantSponge] = ItemID.SuperAbsorbantSponge;

        ItemID.Sets.ShimmerTransformToItem[ItemID.Compass] = ItemID.DepthMeter;
        ItemID.Sets.ShimmerTransformToItem[ItemID.DepthMeter] = ItemID.Compass;

        ItemID.Sets.ShimmerTransformToItem[ItemID.DPSMeter] = ItemID.Stopwatch;
        ItemID.Sets.ShimmerTransformToItem[ItemID.Stopwatch] = ItemID.MetalDetector;
        ItemID.Sets.ShimmerTransformToItem[ItemID.MetalDetector] = ItemID.DPSMeter;


        ItemID.Sets.ShimmerTransformToItem[ItemID.Radar] = ItemID.LifeformAnalyzer;
        ItemID.Sets.ShimmerTransformToItem[ItemID.LifeformAnalyzer] = ItemID.TallyCounter;
        ItemID.Sets.ShimmerTransformToItem[ItemID.TallyCounter] = ItemID.Radar;

        ItemID.Sets.ShimmerTransformToItem[ItemID.TerraBlade] = ModContent.ItemType<AncientTerraBlade>();
        ItemID.Sets.ShimmerTransformToItem[ModContent.ItemType<AncientTerraBlade>()] = ItemID.TerraBlade;

        #region Normal Catacombs
        ItemID.Sets.ShimmerTransformToItem[ModContent.ItemType<RedCatacombWallItem>()] = ModContent.ItemType<RedCatacombWallUnsafeItem>();
        ItemID.Sets.ShimmerTransformToItem[ModContent.ItemType<RedCatacombWallUnsafeItem>()] = ModContent.ItemType<RedCatacombWallItem>();
        ItemID.Sets.ShimmerTransformToItem[ModContent.ItemType<LavenderCatacombWallItem>()] = ModContent.ItemType<LavenderCatacombWallUnsafeItem>();
        ItemID.Sets.ShimmerTransformToItem[ModContent.ItemType<LavenderCatacombWallUnsafeItem>()] = ModContent.ItemType<LavenderCatacombWallItem>();
        ItemID.Sets.ShimmerTransformToItem[ModContent.ItemType<CharcoalCatacombWallItem>()] = ModContent.ItemType<CharcoalCatacombWallUnsafeItem>();
        ItemID.Sets.ShimmerTransformToItem[ModContent.ItemType<CharcoalCatacombWallUnsafeItem>()] = ModContent.ItemType<CharcoalCatacombWallItem>();
        #endregion

        #region Tile Catacombs
        ItemID.Sets.ShimmerTransformToItem[ModContent.ItemType<RedCatacombTileWallItem>()] = ModContent.ItemType<RedCatacombTileWallUnsafeItem>();
        ItemID.Sets.ShimmerTransformToItem[ModContent.ItemType<RedCatacombTileWallUnsafeItem>()] = ModContent.ItemType<RedCatacombTileWallItem>();
        ItemID.Sets.ShimmerTransformToItem[ModContent.ItemType<LavenderCatacombTileWallItem>()] = ModContent.ItemType<LavenderCatacombTileWallUnsafeItem>();
        ItemID.Sets.ShimmerTransformToItem[ModContent.ItemType<LavenderCatacombTileWallUnsafeItem>()] = ModContent.ItemType<LavenderCatacombTileWallItem>();
        ItemID.Sets.ShimmerTransformToItem[ModContent.ItemType<CharcoalCatacombTileWallItem>()] = ModContent.ItemType<CharcoalCatacombTileWallUnsafeItem>();
        ItemID.Sets.ShimmerTransformToItem[ModContent.ItemType<CharcoalCatacombTileWallUnsafeItem>()] = ModContent.ItemType<CharcoalCatacombTileWallItem>();
        #endregion

        ItemID.Sets.ShimmerTransformToItem[ItemID.SlimeGun] = ItemID.WaterGun;
        ItemID.Sets.ShimmerTransformToItem[ItemID.WaterGun] = ItemID.SlimeGun; //change to shimmer gun when tmod is 1.4.5
        //ItemID.Sets.ShimmerTransformToItem[ItemID.ShimmerGun] = ItemID.SlimeGun; change this to shimmer gun
    }
}