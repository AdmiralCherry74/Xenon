using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Buffs.Debuffs;
using Xenon.Content.Dusts;

namespace Xenon.Content.Items.Weapons.Melee.Broadswords;

public class SyrupGreatsword : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1; // How many items need for research in Journey Mode
    }

    public override void SetDefaults()
    {
        Item.width = 105;
        Item.height = 105;
        Item.rare = ItemRarityID.Orange;

        Item.damage = 30;
        Item.DamageType = DamageClass.Melee;
        Item.useTime = 25;
        Item.useAnimation = 25;
        Item.useTurn = true;
        Item.knockBack = 6f;
        Item.autoReuse = true;


        Item.value = 4500;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.UseSound = SoundID.Item1;
    }

    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        target.AddBuff(ModContent.BuffType<Sapped>(), 300);
    }


    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        if (player.itemAnimation % 2 == 0)
        {
            SpecialUtilities.GetPointOnSwungItemPath(60f, 60f, 0.4f + 0.4f * Main.rand.NextFloat(), Item.scale, out var location2, out var outwardDirection2, player);
            Vector2 vector2 = outwardDirection2.RotatedBy((float)Math.PI / 2f * player.direction * player.gravDir);
            int DustType = ModContent.DustType<AutumnDust>();

            int num15 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustType, player.velocity.X * 0.2f + player.direction * 3, player.velocity.Y * 0.2f, 140, default, 0.9f);
            Main.dust[num15].position = location2;
            Main.dust[num15].fadeIn = 1.2f;
            Main.dust[num15].noGravity = true;
            Main.dust[num15].velocity *= 0.25f;
            Main.dust[num15].velocity += vector2 * 5f;
            Main.dust[num15].velocity.Y *= 0.3f;
        }
    }
}