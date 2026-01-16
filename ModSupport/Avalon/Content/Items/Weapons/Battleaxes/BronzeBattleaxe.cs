using Avalon.Items.Material.Bars;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Buffs.Debuffs;
using Xenon.Content.Items.Materials.OresBarsGems;

namespace Xenon.ModSupport.Avalon.Content.Items.Weapons.Battleaxes;

public class BronzeBattleaxe : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 34;
        Item.height = 34;

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 30;
        Item.useAnimation = 30;
        Item.autoReuse = false;

        Item.DamageType = DamageClass.Melee;
        Item.damage = 8;
        Item.knockBack = 5;
        Item.crit = 2;

        Item.value = Item.sellPrice(copper: 90);
        Item.UseSound = SoundID.Item1;
        Item.rare = 0;
    }

    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        target.AddBuff(ModContent.BuffType<Cleaved>(), 180);
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<BronzeBar>(), 7)
            .AddTile(TileID.Anvils)
            .Register();
    }
}