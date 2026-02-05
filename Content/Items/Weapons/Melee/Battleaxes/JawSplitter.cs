using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Buffs.Debuffs;
using Xenon.Content.Buffs.Epibuffs;

namespace Xenon.Content.Items.Weapons.Melee.Battleaxes;

public class JawSplitter : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 30;
        Item.useAnimation = 30;
        Item.autoReuse = false;

        Item.DamageType = DamageClass.Melee;
        Item.damage = 20;
        Item.knockBack = 4;
        Item.crit = 8;

        Item.value = Item.sellPrice(copper: 90);
        Item.UseSound = SoundID.Item1;
        Item.rare = ItemRarityID.Green;
    }
    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        target.AddBuff(ModContent.BuffType<Cleaved>(), 360);
        player.AddBuff(ModContent.BuffType<FlashRage>(), 180);
    }
    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.CrimtaneBar, 7)
            .AddIngredient(ItemID.TissueSample, 2)
            .AddTile(TileID.Anvils)
            .Register();
    }
}