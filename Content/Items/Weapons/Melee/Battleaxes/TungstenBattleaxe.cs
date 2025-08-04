using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Buffs.Debuffs;

namespace Xenon.Content.Items.Weapons.Melee.Battleaxes;

public class TungstenBattleaxe : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 26;
        Item.useAnimation = 26;
        Item.autoReuse = false;

        Item.DamageType = DamageClass.Melee;
        Item.damage = 13;
        Item.knockBack = 5.5f;
        Item.crit = 4;

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
            .AddIngredient(ItemID.TungstenBar, 9)
            .AddTile(TileID.Anvils)
            .Register();
    }
}