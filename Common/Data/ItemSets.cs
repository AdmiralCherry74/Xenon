using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Consumables.NomNoms;
using Xenon.Content.Items.Consumables.NomNoms.Veggies;
using Xenon.Content.Items.Weapons.Melee.Broadswords;
using Xenon.Content.NPCs.RhyoliteMobs;

namespace Xenon.Common.Data
{
    [ReinitializeDuringResizeArrays]
    public static class ItemSets
    {
        public static readonly bool[] BakersFood = ItemID.Sets.Factory.CreateBoolSet(
        #region Vanilla Food and eaten goods
        ItemID.Mushroom,
        ItemID.Apple,
        ItemID.Apricot,
        ItemID.Banana,
        ItemID.BlackCurrant,
        ItemID.BloodOrange,
        ItemID.Cherry,
        ItemID.Coconut,
        ItemID.Elderberry,
        ItemID.Grapefruit,
        ItemID.Lemon,
        ItemID.Mango,
        ItemID.Peach,
        ItemID.Pineapple,
        ItemID.Plum,
        ItemID.Pomegranate,
        ItemID.Rambutan,
        ItemID.SpicyPepper,
        ItemID.Dragonfruit,
        ItemID.Starfruit,
        ItemID.Grapes,
        #endregion

        #region Modded Food
        #region Fruit
        ModContent.ItemType<Lime>(),
        #endregion

        #region Veggies
        ModContent.ItemType<Beetroot>(),
        ModContent.ItemType<Broccoli>(),
        ModContent.ItemType<Cabbage>(),
        ModContent.ItemType<Garlic>(),
        ModContent.ItemType<Corn>(),
        ModContent.ItemType<Kohlrabi>(),
        ModContent.ItemType<Leek>(),
        ModContent.ItemType<Potato>(),
        ModContent.ItemType<Rhubarb>(),
        ModContent.ItemType<Spinach>()
        #endregion
        );
        #endregion

        public static readonly bool[] MechanicalToolReworkItemSet = ItemID.Sets.Factory.CreateBoolSet(
        ItemID.CobaltDrill,
        ItemID.PalladiumDrill,
        ItemID.MythrilDrill,
        ItemID.OrichalcumDrill,
        ItemID.AdamantiteDrill,
        ItemID.TitaniumDrill,
        ItemID.Drax,
        ItemID.ChlorophyteDrill,
        ItemID.LaserDrill,
        ItemID.VortexDrill,
        ItemID.SolarFlareDrill,
        ItemID.NebulaDrill,
        ItemID.StardustDrill,

        ItemID.CobaltChainsaw,
        ItemID.PalladiumChainsaw,
        ItemID.MythrilChainsaw,
        ItemID.OrichalcumChainsaw,
        ItemID.AdamantiteChainsaw,
        ItemID.TitaniumChainsaw,
        ItemID.ChlorophyteChainsaw,
        ItemID.ButchersChainsaw,

        ItemID.ChlorophyteJackhammer
        );

        public static readonly bool[] ItemsThatDefenseDecreaseWithoutSpecialBuffsFromXenonThatShouldGetLocalized = ItemID.Sets.Factory.CreateBoolSet(
            ItemID.Rally,
            ModContent.ItemType<Scarlet>(),
            ModContent.ItemType<Greatsword>()
            );
    }
}
