using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Xenon.Content.Buffs
{
    public class FlashRage : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;  // Is it a debuff?
            Main.pvpBuff[Type] = false; // Players can give other players buffs, which are listed as pvpBuff
            Main.buffNoSave[Type] = true; // Causes this buff not to persist when exiting and rejoining the world
        }

        // Allows you to make this buff give certain effects to the given player
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<FlashRageHeal>().lifeRegenBuff = true;
        }
    }

    public class FlashRageHeal : ModPlayer
    {
        // Flag checking when life regen debuff should be activated
        public bool lifeRegenBuff;

        public override void ResetEffects()
        {
            lifeRegenBuff = false;
        }

        // Allows you to give the player a negative life regeneration based on its state (for example, the "On Fire!" debuff makes the player take damage-over-time)
        // This is typically done by setting player.lifeRegen to 0 if it is positive, setting player.lifeRegenTime to 0, and subtracting a number from player.lifeRegen
        // The player will take damage at a rate of half the number you subtract per second
        public override void UpdateLifeRegen()
        {
            if (lifeRegenBuff)
            {
                // Player.lifeRegenTime used to increase the speed at which the player reaches its maximum natural life regeneration
                // So we set it to 0, and while this debuff is active, it never reaches it
                Player.lifeRegenTime = 1;
                // lifeRegen is measured in 1/2 life per second. Therefore, this effect causes 8 life lost per second
                Player.lifeRegen += 6;
            }
        }
    }
}