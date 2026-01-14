using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Projectiles.Melee.Sword;

namespace Xenon.Content.Items.Weapons.Melee.Swords;

public class AncientTerraBlade : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 46;
        Item.height = 54;

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 16;
        Item.useAnimation = 16;
        Item.autoReuse = true;

        Item.DamageType = DamageClass.Melee;
        Item.damage = 85;
        Item.knockBack = 6.5f;
        Item.crit = 0;
        Item.shoot = ModContent.ProjectileType<AncientTerraBeam>();
        Item.shootSpeed = 16;

        Item.value = Item.buyPrice(gold: 20);
        Item.UseSound = SoundID.Item1;
        Item.rare = ItemRarityID.Yellow;
    }
    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.TrueExcalibur)
            .AddIngredient(ItemID.BrokenHeroSword)
            .AddIngredient(ItemID.TrueNightsEdge)
            .AddTile(TileID.DemonAltar)
            .Register();
    }
}