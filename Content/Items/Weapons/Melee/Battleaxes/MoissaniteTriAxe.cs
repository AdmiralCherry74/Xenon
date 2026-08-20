using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Buffs.Debuffs;

namespace Xenon.Content.Items.Weapons.Melee.Battleaxes;

public class MoissaniteTriAxe : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 58;
        Item.height = 58;
        Item.scale = 1.50f;

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 48;
        Item.useAnimation = 48;
        Item.autoReuse = false;

        Item.DamageType = DamageClass.Melee;
        Item.damage = 38;
        Item.knockBack = 6;
        Item.crit = 6;

        Item.value = Item.sellPrice(silver: 64);
        Item.UseSound = SoundID.Item1;
        Item.rare = ItemRarityID.Green;
    }
    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        target.AddBuff(ModContent.BuffType<Cleaved>(), 400);
        target.AddBuff(BuffID.OnFire, 180);
    }
    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        int d = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Torch);
        Main.dust[d].noGravity = true;
    }
    public override void PostUpdate() => Lighting.AddLight(Item.Center, Color.OrangeRed.ToVector3() * 0.55f);
    public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
    {
        Texture2D tex = ModContent.Request<Texture2D>("Xenon/Content/Items/Weapons/Melee/Battleaxes/MoissaniteTriAxe_Glow", AssetRequestMode.ImmediateLoad).Value;
        spriteBatch.Draw(tex, new Vector2(Item.position.X - Main.screenPosition.X + Item.width * 0.5f, Item.position.Y - Main.screenPosition.Y + Item.height - tex.Height * 0.5f), new Rectangle(0, 0, tex.Width, tex.Height), Color.White, rotation, tex.Size() * 0.5f, scale, SpriteEffects.None, 0f);
    }
}