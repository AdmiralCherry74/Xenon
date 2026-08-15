using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Buffs.Debuffs.WeaponSpecificDebuff
{
    public class WeakerWeaponDefensivePierce : ModBuff
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
            player.statDefense -= 4;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<GlobalNPCSpecificallyForWeaponDefensivePierceLikeDebuffs>().WeakerWeaponDefenseDebuff = true;
        }
    }
}