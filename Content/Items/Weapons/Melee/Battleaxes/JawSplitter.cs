using Microsoft.Xna.Framework;
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
        Item.width = 64;
        Item.height = 56;
        Item.scale = 1.25f;

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 30;
        Item.useAnimation = 30;
        Item.autoReuse = false;

        Item.DamageType = DamageClass.Melee;
        Item.damage = 20;
        Item.knockBack = 4;
        Item.crit = 4;

        Item.value = Item.sellPrice(copper: 90);
        Item.UseSound = SoundID.Item1;
        Item.rare = ItemRarityID.Green;
    }
    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        int d = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Blood);
        Main.dust[d].noGravity = true;
    }
    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        target.AddBuff(ModContent.BuffType<Cleaved>(), 360);
        player.AddBuff(ModContent.BuffType<FlashRage>(), 180);
    }
}