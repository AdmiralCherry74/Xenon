using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Weapons.Melee.Broadswords;

public class IndiumBroadsword : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.autoReuse = false;

        Item.DamageType = DamageClass.Melee;
        Item.damage = 14;
        Item.knockBack = 6.1f;
        Item.crit = 0;

        Item.value = Item.buyPrice(silver: 50);
        Item.UseSound = SoundID.Item1;
        Item.rare = ItemRarityID.White;
    }
}