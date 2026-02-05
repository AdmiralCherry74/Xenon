using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Buffs.Debuffs.Counterable;

public class Gnashed : ModBuff
{
    public override void SetStaticDefaults()
    {
        Main.debuff[Type] = true;
        BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;

    }
    public override void Update(Player player, ref int buffIndex)
    {
        player.GetModPlayer<MoveHealthDamage>().lifeRegenDebuff = true;
    }

    public class MoveHealthDamage : ModPlayer
    {
        public bool lifeRegenDebuff;
        public override void ResetEffects()
        {
            lifeRegenDebuff = false;
        }
        public override void UpdateBadLifeRegen()
        {
            if (lifeRegenDebuff)
            {
                if (Player.velocity.X != 0)
                {
                    Player.lifeRegen -= 10; // lifeRegen is measured in 1/2 life per second. Therefore, this effect causes half of the number in life to be lost per second
                    Player.lifeRegenTime = 0;
                }
                else if (Player.velocity.Y != 0)
                {
                    Player.lifeRegen -= 10; // lifeRegen is measured in 1/2 life per second. Therefore, this effect causes half of the number in life to be lost per second
                    Player.lifeRegenTime = 0;
                }
            }
        }
    }
}