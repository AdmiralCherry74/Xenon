using Terraria;
using Terraria.ModLoader;

namespace Xenon.Content.Buffs.Epibuffs.OreFruitBuffs
{
    public class PlatinumAppleBuff : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            player.endurance += 0.08f;
            player.lifeRegen += 4;
        }
    }
}