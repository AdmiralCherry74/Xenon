using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Buffs.Debuffs.WeaponSpecificDebuff
{
    public class WeakestWeaponDefensivePierce : ModBuff
    {
        //For use with certain weapons
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;  
            Main.pvpBuff[Type] = true; 
        }

        // Allows you to make this buff give certain effects to the given player
        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense -= 3;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<GlobalNPCSpecificallyForWeaponDefensivePierceLikeDebuffs>().WeakestWeaponDefenseDebuff = true;
        }
    }
}