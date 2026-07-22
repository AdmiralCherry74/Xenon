using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Tools.DriverHammers;

public class AluminumHammer : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 24;
        Item.height = 24;

        Item.hammer = 37;
        Item.knockBack = 5.5f;
        Item.damage = 5;
        Item.DamageType = DamageClass.Melee;

        Item.useTime = 22;
        Item.useAnimation = 31;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.autoReuse = true;
        Item.useTurn = true;
        Item.UseSound = SoundID.Item1;

        Item.rare = ItemRarityID.White;
        Item.value = Item.sellPrice(silver: 36);
    }
}
