using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials.BarsGems;
using Xenon.Common.Globals.XenonItemGlobals;
namespace Xenon.Content.Items.Tools.GardeningHoes;

public class TinHoe : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 24;
        Item.height = 24;

        Item.GetGlobalItem<HoePower>().hoePower = 35;
        Item.knockBack = 1f;
        Item.damage = 3;
        Item.DamageType = DamageClass.Melee;

        Item.useTime = 14;
        Item.useAnimation = 20;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.autoReuse = true;
        Item.useTurn = true;
        Item.UseSound = SoundID.Item1;

        Item.rare = ItemRarityID.White;
        Item.value = Item.sellPrice(silver: 36);
    }
}
