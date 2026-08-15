using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Buffs.Debuffs.WeaponSpecificDebuff;

namespace Xenon.Content.Items.Weapons.Melee.Broadswords;

public class Greatsword : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 92;
        Item.height = 92;

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 35;
        Item.useAnimation = 35;
        Item.useTurn = true;
        Item.autoReuse = false;

        Item.DamageType = DamageClass.Melee;
        Item.damage = 40;
        Item.knockBack = 8f;
        Item.crit = 0;

        Item.value = Item.buyPrice(silver: 150);
        Item.UseSound = SoundID.Item1;
        Item.rare = ItemRarityID.Green;
    }
    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        target.AddBuff(ModContent.BuffType<WeakerWeaponDefensivePierce>(), 150);
    }
}