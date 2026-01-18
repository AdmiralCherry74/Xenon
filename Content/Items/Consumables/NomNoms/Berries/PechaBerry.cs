using AltLibrary.Common.AltOres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Buffs.TarotCardBuff;
using Xenon.Content.Items.Consumables.TarotCards;
using Xenon.Content.Tiles.Natural.Other.Berries;

namespace Xenon.Content.Items.Consumables.NomNoms.Berries
{
    public class PechaBerry : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.DisableAutomaticPlaceableDrop[Type] = true;
            Item.ResearchUnlockCount = 10;
        }
        public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup)
        {
            itemGroup = ContentSamples.CreativeHelper.ItemGroup.AlchemyPlants;
        }
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.DefaultToPlaceableTile(ModContent.TileType<PechaBerryHerb>());
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item2;
            Item.maxStack = 10;
            Item.consumable = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = 500;
        }

        public override bool? UseItem(Player player)
        {
            player.ClearBuff(BuffID.Poisoned);
            player.ClearBuff(BuffID.Venom);
            return true;
        }
    }
}