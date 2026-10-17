
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Projectiles.Magic.SpellBookProj;

namespace Xenon.Content.Items.Weapons.Ranged.Flamethrowers
{
    public class Drizzlethrower : ModItem
    {
        public int ammoConsumeTimer = 0;
        public override void SetDefaults()
        {
            Item.width = 50;
            Item.height = 16;

            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.autoReuse = true;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.DamageType = DamageClass.Ranged;
            Item.damage = 19;
            Item.knockBack = 0.1f;
            Item.crit = -2;
            Item.shoot = ProjectileID.MolotovFire;
            Item.shootSpeed = 13;

            Item.noMelee = true;
            Item.value = 20000;
            Item.UseSound = SoundID.Item34;
            Item.rare = ItemRarityID.Green;
            Item.useAmmo = AmmoID.Gel;
    
        }

        public override Vector2? HoldoutOffset() => new Vector2(-10f, 0f);

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            if (ammoConsumeTimer < 5)
            {
                ammoConsumeTimer++;
                return false;
            } else { 
                ammoConsumeTimer = 0;
                return true; 
            }
        }
    }
}