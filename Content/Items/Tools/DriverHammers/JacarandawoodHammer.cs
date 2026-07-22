using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Tools.DriverHammers;

public class JacarandawoodHammer : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 40;
        Item.height = 40;

        Item.hammer = 35;
        Item.knockBack = 5.5f;
        Item.damage = 4;
        Item.DamageType = DamageClass.Melee;

        Item.useTime = 23;
        Item.useAnimation = 33;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.autoReuse = true;
        Item.useTurn = true;
        Item.UseSound = SoundID.Item1;

        Item.rare = ItemRarityID.White;
        Item.value = Item.sellPrice(copper: 10);
    }
}
