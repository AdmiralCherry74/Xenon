using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Buffs.Debuffs;

namespace Xenon.Content.Items.Weapons.Melee.Battleaxes;

public class DebugAxe : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 1;
        Item.useAnimation = 1;
        Item.autoReuse = true;

        Item.DamageType = DamageClass.Melee;
        Item.damage = 999999999;
        Item.knockBack = 0;
        Item.crit = 96;

        Item.value = Item.sellPrice(copper: 90);
        Item.UseSound = SoundID.Item1;
        Item.rare = 11;
    }

    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        target.AddBuff(ModContent.BuffType<Cleaved>(), 180);
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.CopperBar, 7)
            .AddTile(TileID.Anvils)
            .Register();
    }
}