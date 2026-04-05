using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;

using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.NPCs.Bosses.CorrodedTerror;

public class CorrodedTerrorBoss : ModNPC
{
    // Reminder: Selene is a big fat fucking bitch who enslaved me to work on this boss.
    // I will make sure they pay the ultimate price one day. :)
    // - Vaema

    // April 4th, 2026:
    // TODO: Finish this boss. I will work more on this tomorrow or the day after if possible.
    // We also need to plan out the attacks thoroughly.

    public enum State
    {
        SummonAnimation
    }

    public State CurrentState
    {
        get => (State)(int)NPC.ai[0];
        set => NPC.ai[0] = (int)value;
    }

    public ref float AttackTimer => ref NPC.ai[1];

    public ref float StepTimer => ref NPC.ai[2];

    public ref float Phase => ref NPC.ai[3];

    public float LifeRatio => NPC.life / (float)NPC.lifeMax;

    public float Depth = 0.8f;

    public Player Target => Main.player[NPC.target];

    public List<CorrodedTerrorLeg> Legs = [];

    public const int LegCount = 8;

    public override void SetStaticDefaults()
    {
        NPCID.Sets.TrailCacheLength[Type] = 5;
        NPCID.Sets.TrailingMode[Type] = 3;
        NPCID.Sets.MPAllowedEnemies[Type] = true;
        NPCID.Sets.BossBestiaryPriority.Add(Type);
    }

    public override void SetDefaults()
    {
        NPC.width = 160;
        NPC.height = 120;

        NPC.lifeMax = 12000;
        NPC.damage = 55;
        NPC.defense = 20;
        NPC.knockBackResist = 0f;
        NPC.npcSlots = 15f;

        NPC.aiStyle = -1;
        AIType = -1;

        NPC.boss = true;
        NPC.noGravity = true;
        NPC.noTileCollide = true;
        NPC.lavaImmune = true;
        NPC.netAlways = true;

        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
    }

    public override void AI()
    {
        // Find the nearest target.
        NPC.TargetClosest();

        // Despawn if all remaining targets are dead.
        if (Target.dead || !Target.active)
        {
            // Crawl down.
            NPC.velocity.Y++;
            if (NPC.Distance(Target.Center) > 30f)
            {
                NPC.active = false;
                NPC.netUpdate = true;
            }
            return;
        }

        // Pulse the depth.
        Depth = 0.75f + (float)Math.Sin(Main.GlobalTimeWrappedHourly) * 0.05f;

        // Find the target's center and move accordingly.
        Vector2 targetPosition = Target.Center + new Vector2(0, -200);
        NPC.Center = Vector2.Lerp(NPC.Center, targetPosition, 0.05f);

        // Update the legs based on the step timer.
        StepTimer++;
        foreach (var leg in Legs)
            leg.Update(NPC, Target, ref StepTimer);

        // Switch between states.
        switch (CurrentState)
        {
            case State.SummonAnimation:
                SummonAnimation();
                break;
        }

        // Increment the attack timer.
        AttackTimer++;
    }

    public static void SummonAnimation()
    {
        // TODO: Summon animation.
    }

    public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
    {
        // Ensure the legs are positioned behind the boss.
        foreach (var leg in Legs)
            leg.Draw(spriteBatch, screenPos);

        // Draw the boss' main texture.
        Texture2D texture = TextureAssets.Npc[NPC.type].Value;
        spriteBatch.Draw(texture, NPC.Center - screenPos, null, drawColor, 0f, texture.Size() / 2, Depth, SpriteEffects.None, 0f);

        return false;
    }

    public override void OnSpawn(IEntitySource source)
    {
        // Spawn the legs.
        for (int i = 0; i < LegCount; i++)
            Legs.Add(new CorrodedTerrorLeg(i));
    }
}
