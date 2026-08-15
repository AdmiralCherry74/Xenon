using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Buffs.Debuffs;
using Xenon.Content.Buffs.Debuffs.WeaponSpecificDebuff;

namespace Xenon.Content.Items.Weapons.Melee.Broadswords;

public class Scarlet : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 20;
        Item.useTurn = true;
        Item.useAnimation = 20;
        Item.autoReuse = false;

        Item.DamageType = DamageClass.Melee;
        Item.damage = 20;
        Item.knockBack = 5;
        Item.crit = 2;

        Item.value = Item.buyPrice(gold: 10);
        Item.UseSound = SoundID.Item1;
        Item.rare = ItemRarityID.Green;
    }

    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        target.AddBuff(ModContent.BuffType<WeakestWeaponDefensivePierce>(), 150);
    }
}