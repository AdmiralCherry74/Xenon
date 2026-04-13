using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials.BarsGems;
using Xenon.Content.Projectiles.Magic.StaveProj;

namespace Xenon.Content.Items.Weapons.Magic.Staves
{
    public class JadeStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.staff[Item.type] = true; //fuck u vaema :3
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.useTime = 37;
            Item.useAnimation = 36;
            Item.autoReuse = false;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.DamageType = DamageClass.Magic;
            Item.damage = 15;
            Item.knockBack = 3.375f;
            Item.crit = 0;
            Item.mana = 5;
            Item.shoot = ModContent.ProjectileType<JadeGemball>();
            Item.shootSpeed = 6.25f;

            Item.value = Item.sellPrice(copper: 90);
            Item.UseSound = SoundID.Item43;
            Item.rare = ItemRarityID.White;
        }
    }
}