using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Buffs.Debuffs;

namespace Xenon.Content.Projectiles.Summoner.Caltrops;

public class CinnabarCaltropsProj : IronCaltropsProj
{
    public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
    {
        target.AddBuff(BuffID.Confused, 20);
        target.AddBuff(ModContent.BuffType<CinnabarCaltropTagDamage>(), 16);
        Projectile.localNPCHitCooldown = -1; // 1 hit per npc max
    }
}