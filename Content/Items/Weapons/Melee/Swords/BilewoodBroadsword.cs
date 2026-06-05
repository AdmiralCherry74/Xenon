using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Weapons.Melee.Swords;

public class BilewoodBroadsword : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 19;
        Item.useAnimation = 19;
        Item.autoReuse = false;

        Item.DamageType = DamageClass.Melee;
        Item.damage = 11;
        Item.knockBack = 6f;
        Item.crit = 0;

        Item.value = Item.buyPrice(silver: 50);
        Item.UseSound = SoundID.Item1;
        Item.rare = ItemRarityID.White;
    }
}