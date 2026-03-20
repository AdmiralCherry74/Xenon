using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Buffs.Debuffs;

namespace Xenon.Content.Items.Weapons.Melee.Battleaxes;

public class Stratono : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 34;
        Item.height = 30;

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 48;
        Item.useAnimation = 48;
        Item.autoReuse = false;

        Item.DamageType = DamageClass.Melee;
        Item.damage = 24;
        Item.knockBack = 6;
        Item.crit = 5;

        Item.value = Item.sellPrice(silver: 64);
        Item.UseSound = SoundID.Item1;
        Item.rare = ItemRarityID.Green;
    }
    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        target.AddBuff(ModContent.BuffType<Cleaved>(), 400);
    }
}