using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials.BarsGems;
using Xenon.Content.Projectiles.Magic.StaveProj;

namespace Xenon.Content.Items.Weapons.Magic.Staves
{
    public class LapisStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.staff[Item.type] = true; //fuck u vaema :3
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.useTime = 27;
            Item.useAnimation = 27;
            Item.autoReuse = true;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.DamageType = DamageClass.Magic;
            Item.damage = 22;
            Item.knockBack = 5.125f;
            Item.crit = 0;
            Item.mana = 8;
            Item.shoot = ModContent.ProjectileType<LapisGemball>();
            Item.shootSpeed = 9.25f;

            Item.value = Item.sellPrice(copper: 90);
            Item.UseSound = SoundID.Item43;
            Item.rare = ItemRarityID.Green;
        }
    }
}