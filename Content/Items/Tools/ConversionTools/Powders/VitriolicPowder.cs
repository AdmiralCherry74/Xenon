using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials.EvilMaterials;
using Xenon.Content.Projectiles.Tools.ConvertingTools.Powders;

namespace Xenon.Content.Items.Tools.ConversionTools.Powders
{
    public class VitriolicPowder : ModItem
    {
        public override void SetDefaults()
        {
            Item.ResearchUnlockCount = 25;
            Item.UseSound = SoundID.Item1;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.shootSpeed = 4f;
            Item.consumable = true;
            Item.stack = 9999;
            Item.shoot = ModContent.ProjectileType<VitriolicPowderProj>();
            Item.value = Item.sellPrice(copper: 20);
        }

        public override void AddRecipes()
        {
            CreateRecipe(5).AddIngredient(ModContent.ItemType<VitriolicMushroom>()).AddTile(TileID.Bottles).Register();
        }
    }
}