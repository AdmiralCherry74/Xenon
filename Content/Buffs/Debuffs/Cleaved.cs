using Terraria;
using Terraria.ModLoader;

namespace Xenon.Content.Buffs.Debuffs
{
    public class Cleaved : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;  // Is it a debuff?
            Main.pvpBuff[Type] = true; // Players can give other players buffs, which are listed as pvpBuff
        }

        // Allows you to make this buff give certain effects to the given player
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<AxeOuch>().lifeRegenDebuff = true;
        }
    }

    public class AxeOuch : ModPlayer
    {
        // Flag checking when life regen debuff should be activated
        public bool lifeRegenDebuff;

        public override void ResetEffects()
        {
            lifeRegenDebuff = false;
        }

        // Allows you to give the player a negative life regeneration based on its state (for example, the "On Fire!" debuff makes the player take damage-over-time)
        // This is typically done by setting player.lifeRegen to 0 if it is positive, setting player.lifeRegenTime to 0, and subtracting a number from player.lifeRegen
        // The player will take damage at a rate of half the number you subtract per second
        public override void UpdateBadLifeRegen()
        {
            if (lifeRegenDebuff)
            {
                // These lines zero out any positive lifeRegen. This is expected for all bad life regeneration effects
                if (Player.lifeRegen > 0)
                    Player.lifeRegen = 0;
                // Player.lifeRegenTime used to increase the speed at which the player reaches its maximum natural life regeneration
                // So we set it to 0, and while this debuff is active, it never reaches it
                Player.lifeRegenTime = 0;
                // lifeRegen is measured in 1/2 life per second. Therefore, this effect causes 8 life lost per second
                Player.lifeRegen -= 8;
            }
        }
    }
    public class AxeOuchNPC : GlobalNPC
    {
        public bool lifeRegenDebuff;
        public override bool InstancePerEntity => true;

        public override void ResetEffects(NPC npc)
        {
            lifeRegenDebuff = false;
        }
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (lifeRegenDebuff == true)
            {
                // lifeRegen for npc's is measured in 1 life per second. Therefore, this effect causes 4 life lost per second
                npc.lifeRegen -= 4;
            }
        }
    }
}