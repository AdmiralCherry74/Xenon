using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Globals;

namespace Xenon.Content.Items.Accessories;

public class EruptionInABottle : ModItem
{
    private int fall_time = 0;
    public override void SetDefaults()
    {
        Item.DefaultToAccessory();
        Item.rare = ItemRarityID.Green;
    }

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        if (player.DoublePressedDown())
        {
            player.GetModPlayer<XenonPlayer>().GroundPoundActivated = true;
            SoundEngine.PlaySound(SoundID.DoubleJump, player.position);
        }

        if (player.GetModPlayer<XenonPlayer>().GroundPoundActivated)
        {
            Vector2 p_pos = player.position + (new Vector2(player.width, player.height) / 2f);
            //int numOfNPCs = 0;
            if (player.gravDir == 1f ? player.velocity.Y > 0f : player.velocity.Y < 0f)
            {
                fall_time++;
                if (fall_time > 76)
                {
                    fall_time = 76;
                }
            }

            if ((player.gravDir == 1f ? player.GetModPlayer<XenonPlayer>().playerOldVelocity[2].Y < 0f : player.GetModPlayer<XenonPlayer>().playerOldVelocity[2].Y > 0f) || player.GetModPlayer<XenonPlayer>().playerOldVelocity[2].Y == 0f || player.GetModPlayer<XenonPlayer>().playerOldVelocity[2].Y == 1E-05f)
            {
                fall_time = 0;
            }
            if (player.IsOnGroundPrecise() && (player.gravDir == 1f ? player.GetModPlayer<XenonPlayer>().playerOldVelocity[2].Y > 0f : player.GetModPlayer<XenonPlayer>().playerOldVelocity[2].Y < 0f) && player.velocity.Y == 0f && fall_time > 1) // just fell
            {
                for (int dustCount = 0; dustCount < 50; dustCount++)
                {
                    float rotation = Main.rand.NextFloat() * MathHelper.TwoPi;
                    Dust D2 = Dust.NewDustDirect(new Vector2(player.Center.X, player.Bottom.Y), 16, 16, DustID.SolarFlare, 0, 0, 100, new Color(), 1f);
                    D2.velocity = new Vector2((float)Math.Sin(rotation), (float)Math.Cos(rotation)) * Main.rand.NextFloat(2.5f, 4f);
                    D2.noGravity = true;
                }
                player.GetModPlayer<XenonPlayer>().GroundPoundActivated = false;
                float fall_dist = ((fall_time - 23f) / (76f - 23f) * (21f - 3.5f) + 3.5f) * (player.GetModPlayer<XenonPlayer>().playerOldVelocity[2].Y * player.gravDir / 10f); // remap fall_time to range from 3.5f to 21f

                float Radius = 8f * fall_time * (player.GetModPlayer<XenonPlayer>().playerOldVelocity[2].Y * player.gravDir / 10f);
                for (int o = Main.npc.Length - 1; o > 0; o--)
                {
                    // iterate through NPCs
                    NPC N = Main.npc[o];
                    var list = new List<NPC>();
                    if (!N.active || N.dontTakeDamage || N.friendly || N.life < 1 || N.type == NPCID.TargetDummy)
                    {
                        continue;
                    }

                    if (N.Center.Distance(player.Center) < Radius)
                    {
                        list.Add(N);
                    }

                    var n_pos = N.Center; // NPC location
                    int HitDir = -1;
                    if (n_pos.X > p_pos.X)
                    {
                        HitDir = 1;
                    }

                    if (N.Center.Distance(player.Center) < Radius)
                    {
                        int multiplier = 5;
                        int dmg = N.SimpleStrikeNPC(damage: (int)(multiplier * fall_dist * -((N.Center.Distance(player.Center) / Radius) - 1)) * 2, hitDirection: HitDir, knockBack: fall_dist * -((N.Center.Distance(player.Center) / Radius) - 1) * 2.7f);
                        N.AddBuff(BuffID.OnFire, 60 * 5);
                        player.addDPS(dmg);
                        // optionally add debuff here
                    } // END on screen
                } // END iterate through NPCs

                var Sound = SoundEngine.PlaySound(SoundID.Item14, player.position);

                if (SoundEngine.TryGetActiveSound(Sound, out ActiveSound sound) && sound != null && sound.IsPlaying)
                {
                    sound.Volume = MathHelper.Clamp(fall_dist / 7f, 0.2f, 3);
                }
                //if (player.whoAmI == Main.myPlayer && ModContent.GetInstance<AvalonClientConfig>().AdditionalScreenshakes)
                //{
                //    PunchCameraModifier modifier = new PunchCameraModifier(player.Center, new Vector2(Main.rand.NextFloat(-0.3f, 0.3f), fall_dist / 2f), 1f, 3f, 15, 300f, player.name);
                //    Main.instance.CameraModifiers.Add(modifier);
                //}
                fall_time = 0; // just in case the checks above fail for whatever reason
            } // END just fell

            // this check happens after the shockwave logic because it would cancel the shockwave if run beforehand
            // it basically just checks if the player ever stops moving on the Y axis, used to check if they're flying into a ceiling
            if (player.oldPosition.Y == player.position.Y)
            {
                fall_time = 0;
            }
        }
    }
}
