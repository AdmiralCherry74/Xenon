using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Buffs.TarotCardBuff;

namespace Xenon.Content.Items.Consumables.TarotCards;

public class TarotCard1Used : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 20;
        Item.height = 30;
        Item.useStyle = ItemUseStyleID.HoldUp;
        Item.useAnimation = 15;
        Item.useTime = 15;
        Item.useTurn = true;
        Item.UseSound = SoundID.Item60;
        Item.maxStack = 1;
        Item.consumable = false;
        Item.rare = ItemRarityID.Master;
        Item.value = 0;
    }

    public override bool? UseItem(Player player)
    {
        Item.SetDefaults(ModContent.ItemType<TarotCard1>());
        player.ClearBuff(ModContent.BuffType<Unpolished>());
        return true;
    }
}