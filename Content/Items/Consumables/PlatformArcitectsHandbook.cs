using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Globals.XenonPlayerGlobals;

namespace Xenon.Content.Items.Consumables;

public class PlatformArcitectsHandbook : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 20;
        Item.height = 30;
        Item.useStyle = ItemUseStyleID.HoldUp;
        Item.useAnimation = 15;
        Item.useTime = 15;
        Item.useTurn = true;
        Item.UseSound = SoundID.Item3;
        Item.maxStack = Item.CommonMaxStack;
        Item.consumable = true;
        Item.rare = ItemRarityID.Green;
        Item.value = Item.sellPrice(silver: 2);
    }
    public override bool? UseItem(Player player)
    {
        player.GetModPlayer<XenonPlayer>().BiomePlatform = true;
        return true;
    }
}