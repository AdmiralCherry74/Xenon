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
    // TODO: This boss is still unfinished. However, feedback is appreciated.
    // TODO: Make this boss enrage if the player is outside of the Corrosion.

    public enum State
    {
        SummonAnimation,

        // Phase one attacks.
        Crawl,
        //BreatheVenom,
        //Charge,
        //SummonMinions,
        //ShootWebs,

        // Phase two attacks.
        //EnterPhase2,
        //OrbitingGoo,
        //VenomSpores,

        //DeathAnimation
    }

    public float Depth = 0.8f;

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
        State currentState = (State)(int)NPC.ai[0];
        ref float attackTimer = ref NPC.ai[1];
        ref float stepTimer = ref NPC.ai[2];

        Player target = Main.player[NPC.target];

        // Find the nearest target.
        NPC.TargetClosest();

        // Despawn if all remaining targets are dead.
        if (target.dead || !target.active)
        {
            // Crawl down.
            NPC.velocity.Y++;
            if (NPC.Distance(target.Center) > 30f)
            {
                NPC.active = false;
                NPC.netUpdate = true;
            }
            return;
        }

        // Pulse the depth.
        Depth = 0.75f + (float)Math.Sin(Main.GlobalTimeWrappedHourly) * 0.05f;

        // Update the legs based on the step timer.
        stepTimer++;
        foreach (var leg in Legs)
            leg.Update(NPC, target, ref stepTimer);

        // Switch between states.
        switch (currentState)
        {
            case State.SummonAnimation:
                SummonAnimation(NPC, target, ref attackTimer);
                break;
            case State.Crawl:
                Crawl(NPC, target);
                break;
        }

        // Increment the attack timer.
        attackTimer++;
    }

    public static void SummonAnimation(NPC npc, Player target, ref float attackTimer)
    {
        // Summon somewhere near the target.
        if (attackTimer == 0)
        {
            Vector2 spawnOffset = Main.rand.NextVector2CircularEdge(325f, 325f);
            npc.Center = target.Center + spawnOffset;
        }

        // Perform the summon animation.
        if (attackTimer >= 5 && attackTimer <= 240)
        {
            // Crawl a bit closer.
            if (attackTimer <= 75)
                npc.velocity = npc.DirectionTo(target.Center) * 0.3f;
            // Stop moving shortly afterwards.
            else
                npc.velocity = Vector2.Zero;

            // TODO: Make the camera focus on the boss during the summon animation.
            // I (Vaema) will make the system for that later.
        }

        if (attackTimer > 240)
            SelectNextAttack(npc);
    }

    public static void Crawl(NPC npc, Player target)
    {
        // As of right now, just do this. I will return to this later.
        npc.velocity = npc.DirectionTo(target.Center) * 0.75f;
    }

    public static void SelectNextAttack(NPC npc)
    {
        State oldState = (State)(int)npc.ai[0];
        State newState = State.Crawl;

        // TODO: Implement the other states and ensure the boss switches to them.
        switch (oldState)
        {
            case State.SummonAnimation:
                newState = State.Crawl;
                break;
        }

        npc.ai[0] = (int)newState;
        npc.ai[1] = 0;
        npc.netUpdate = true;
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
