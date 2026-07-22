using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Globals.XenonItemGlobals;
using Xenon.Content.Items.Materials.BarsGems;

namespace Xenon.Content.Items.Tools.GardeningHoes;

public class FluoriteHoe : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;

        Item.GetGlobalItem<HoePower>().hoePower = 57;
        Item.knockBack = 2f;
        Item.damage = 7;
        Item.DamageType = DamageClass.Melee;

        Item.useTime = 16;
        Item.useAnimation = 18;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.autoReuse = true;
        Item.useTurn = true;
        Item.UseSound = SoundID.Item1;

        Item.rare = ItemRarityID.White;
        Item.value = Item.sellPrice(0, 1, 23, 0);
    }
}