using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Buffs.Debuffs;
using Xenon.Content.Buffs.Epibuffs;
using Xenon.Content.Dusts;
using Xenon.Content.Dusts.WaterSplashes;

namespace Xenon.Content.Items.Weapons.Melee.Battleaxes;

public class LiverSplitter : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 40;
        Item.height = 32;

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
        player.AddBuff(ModContent.BuffType<BlindAnger>(), 180);
    }
    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        if (player.itemAnimation % 2 == 0)
        {
            SpecialUtilities.GetPointOnSwungItemPath(60f, 60f, 0.4f + 0.4f * Main.rand.NextFloat(), Item.scale, out var location2, out var outwardDirection2, player);
            Vector2 vector2 = outwardDirection2.RotatedBy((float)Math.PI / 2f * player.direction * player.gravDir);
            int DustType = ModContent.DustType<CorrosionDust>();
            if (Main.rand.NextBool(3))
                DustType = ModContent.DustType<CorrosionWaterSplash>();

            int num15 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustType, player.velocity.X * 0.2f + player.direction * 3, player.velocity.Y * 0.2f, 140, default, 0.7f);
            Main.dust[num15].position = location2;
            Main.dust[num15].fadeIn = 1.2f;
            Main.dust[num15].noGravity = true;
            Main.dust[num15].velocity *= 0.25f;
            Main.dust[num15].velocity += vector2 * 5f;
            Main.dust[num15].velocity.Y *= 0.3f;
        }
    }
}