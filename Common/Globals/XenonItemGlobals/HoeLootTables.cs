using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Blocks.Decoration.Torches;
using Xenon.Content.Items.Placeable.Blocks.Natural.Seed;
using Xenon.Content.Items.Valuables.Goods;
using Xenon.Content.Items.Valuables.Goods.Books;
using Xenon.Content.Items.Valuables.Mature;
using Xenon.Content.Items.Valuables.MonsterRemains;

namespace Xenon.Common.Globals.XenonItemGlobals
{
    public class HoeLootTables : GlobalItem
    {
        public static int[] forestPlantlootTable1 =
    [
      ItemID.GrassSeeds,
      ItemID.Acorn,
      ItemID.LesserHealingPotion,
      ItemID.LesserManaPotion,
      ItemID.Glowstick,
      ItemID.Torch,
      ModContent.ItemType<OldManual>()
    ];

        public static int[] junglePlantlootTable1 =
    [
      ItemID.JungleGrassSeeds,
      ItemID.Acorn,
      ItemID.LesserHealingPotion,
      ItemID.LesserManaPotion,
      ItemID.Glowstick,
      ItemID.JungleTorch,
      ModContent.ItemType<Ciggies>(),
      ModContent.ItemType<OldManual>()
    ];

        public static int[] mushroomPlantlootTable1 =
    [
          ItemID.GrassSeeds,
      ItemID.Acorn,
      ItemID.LesserHealingPotion,
      ItemID.LesserManaPotion,
      ItemID.Glowstick,
      ItemID.MushroomTorch,
      ModContent.ItemType<Perfume>(),
      ModContent.ItemType<OldManual>()
    ];

        public static int[] SeaOatslootTable1 =
    [
      ModContent.ItemType<MirageGrassSeeds>(),
      ItemID.LesserHealingPotion,
      ItemID.LesserManaPotion,
      ItemID.Glowstick,
      ItemID.DesertTorch,
      ModContent.ItemType<RareBook>(),
      ModContent.ItemType<OldManual>()
    ];

        public static int[] corruptPlantlootTable1 =
    [
      ItemID.CorruptSeeds,
      ItemID.Acorn,
      ItemID.LesserHealingPotion,
      ItemID.LesserManaPotion,
      ItemID.Glowstick,
      ItemID.CorruptTorch,
      ModContent.ItemType<EOSMandible>(),
      ModContent.ItemType<OldManual>()
    ];

        public static int[] crimsonPlantlootTable1 =
    [
      ItemID.CrimsonSeeds,
      ItemID.Acorn,
      ItemID.LesserHealingPotion,
      ItemID.LesserManaPotion,
      ItemID.Glowstick,
      ItemID.CrimsonTorch,
      ModContent.ItemType<ChimeraEye>(),
      ModContent.ItemType<OldManual>()
    ];

        public static int[] corrodedPlantlootTable1 =
    [
      ModContent.ItemType<CorrosionSeeds>(),
      ItemID.Acorn,
      ItemID.LesserHealingPotion,
      ItemID.LesserManaPotion,
      ItemID.Glowstick,
      ModContent.ItemType<CorrosionTorch>(),
      ModContent.ItemType<DilutedBile>(),
      ModContent.ItemType<OldManual>()
    ];

        public static int[] hellPlantlootTable1 =
    [
      ItemID.AshGrassSeeds,
      ItemID.Acorn,
      ItemID.HealingPotion,
      ItemID.ManaPotion,
      ItemID.DemonTorch,
      ModContent.ItemType<RareBook>(),
      ModContent.ItemType<OldManual>(),
      ModContent.ItemType<InterestingBook>(),
];
    }
}