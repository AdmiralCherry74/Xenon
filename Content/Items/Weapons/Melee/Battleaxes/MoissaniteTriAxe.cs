using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Buffs.Debuffs;

namespace Xenon.Content.Items.Weapons.Melee.Battleaxes;

public class MoissaniteTriAxe : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 48;
        Item.useAnimation = 48;
        Item.autoReuse = false;

        Item.DamageType = DamageClass.Melee;
        Item.damage = 38;
        Item.knockBack = 6;
        Item.crit = 12;

        Item.value = Item.sellPrice(silver: 64);
        Item.UseSound = SoundID.Item1;
        Item.rare = ItemRarityID.Green;
    }
    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        target.AddBuff(ModContent.BuffType<Cleaved>(), 400);
        target.AddBuff(BuffID.OnFire, 180);
    }
    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.HellstoneBar, 18)
            .AddIngredient(ItemID.TissueSample, 6)
            .AddTile(TileID.Anvils)
            .Register();
    }
}