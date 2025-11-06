using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Projectiles;

namespace Xenon.Content.Items.Weapons.Magic.Staves
{
    public class SewerFury : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 54; // Hitbox width of the item
            Item.height = 22; // Hitbox height of the item.
            Item.damage = 16;
            Item.scale = 1f;
            Item.mana = 10;
            Item.DamageType = DamageClass.Magic;
            Item.noMelee = true;
            Item.useTime = 35;
            Item.knockBack = 4f;
            Item.shoot = ModContent.ProjectileType<SewerFuryBall>();
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = 1000;
            Item.useAnimation = 35;
            Item.UseSound = SoundID.Item20;
            Item.rare = ItemRarityID.Blue;
            Item.autoReuse = false;
            Item.channel = true;
        }
    }
}