using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Buffs.Debuffs;
using Xenon.Content.Buffs.Epibuffs;

namespace Xenon.Content.Items.Weapons.Melee.Battleaxes;

public class NightGnasher : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 64;
        Item.height = 54;

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 25;
        Item.useAnimation = 25;
        Item.autoReuse = false;

        Item.DamageType = DamageClass.Melee;
        Item.damage = 15;
        Item.knockBack = 4.5f;
        Item.crit = 4;

        Item.value = Item.sellPrice(copper: 90);
        Item.UseSound = SoundID.Item1;
        Item.rare = ItemRarityID.Green;
    }
    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        target.AddBuff(ModContent.BuffType<Cleaved>(), 360);
        player.AddBuff(ModContent.BuffType<WraithFlash>(), 180);
    }
}