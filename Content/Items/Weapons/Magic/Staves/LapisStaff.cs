using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials.OresBarsGems;
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

            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.autoReuse = true;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.DamageType = DamageClass.Magic;
            Item.damage = 25;
            Item.knockBack = 6.5f;
            Item.crit = 0;
            Item.mana = 11;
            Item.shoot = ModContent.ProjectileType<LapisGemball>();
            Item.shootSpeed = 8f;

            Item.value = Item.sellPrice(copper: 90);
            Item.UseSound = SoundID.Item43;
            Item.rare = ItemRarityID.Green;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.CrimtaneBar, 10)
                .AddIngredient(ModContent.ItemType<Lapis>(), 8)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}