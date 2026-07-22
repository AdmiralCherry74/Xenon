using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials.BarsGems;
using Xenon.Content.Items.Materials.WorldInfectionMaterials;
using Xenon.Content.Projectiles.Melee.Flail;

namespace Xenon.Content.Items.Weapons.Melee.Flails;

public class WishingStar : ModItem
{
    public override void SetStaticDefaults()
    {
        ItemID.Sets.ToolTipDamageMultiplier[Type] = 2f;
    }

    public override void SetDefaults()
    {
        Item.width = 28;
        Item.height = 28;
        Item.channel = true;
        Item.damage = 23;
        Item.DamageType = DamageClass.Melee;
        Item.knockBack = 5.3f;
        Item.noMelee = true;
        Item.noUseGraphic = true;
        Item.shootSpeed = 12f;
        Item.shoot = ModContent.ProjectileType<WishBall>();
        Item.useTime = 45;
        Item.useAnimation = 45;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.UseSound = SoundID.Item1;
        Item.rare = ItemRarityID.Green;
        Item.value = Item.sellPrice(silver: 52);
    }
    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        target.AddBuff(BuffID.OnFire, 4);
    }
    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.FlamingMace, 1)
            .AddIngredient(ItemID.FallenStar, 10)
            .AddIngredient(ItemID.DemoniteBar, 1)
            .AddIngredient(ItemID.ShadowScale, 3)
            .AddIngredient(ItemID.Feather, 2)
            .AddTile(TileID.Anvils)
            .Register();

        CreateRecipe()
            .AddIngredient(ItemID.FlamingMace, 1)
            .AddIngredient(ItemID.FallenStar, 10)
            .AddIngredient(ItemID.CrimtaneBar, 1)
            .AddIngredient(ItemID.TissueSample, 3)
            .AddIngredient(ItemID.Feather, 2)
            .AddTile(TileID.Anvils)
            .Register();

        CreateRecipe()
            .AddIngredient(ItemID.FlamingMace, 1)
            .AddIngredient(ItemID.FallenStar, 10)
            .AddIngredient(ModContent.ItemType<IngestaneBar>(), 1)
            .AddIngredient(ModContent.ItemType<FreshChyme>(), 3)
            .AddIngredient(ItemID.Feather, 2)
            .AddTile(TileID.Anvils)
            .Register();
    }
}