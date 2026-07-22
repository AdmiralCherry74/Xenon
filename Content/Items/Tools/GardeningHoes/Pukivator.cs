using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Globals.XenonItemGlobals;

namespace Xenon.Content.Items.Tools.GardeningHoes;

public class Pukivator : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;
        Item.scale = 1.25f;

        Item.GetGlobalItem<HoePower>().hoePower = 75;
        Item.knockBack = 2f;
        Item.damage = 8;
        Item.DamageType = DamageClass.Melee;

        Item.useTime = 16;
        Item.useAnimation = 18;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.autoReuse = true;
        Item.useTurn = true;
        Item.UseSound = SoundID.Item1;

        Item.rare = ItemRarityID.Blue;
        Item.value = Item.sellPrice(0, 1, 23, 0);
    }
}