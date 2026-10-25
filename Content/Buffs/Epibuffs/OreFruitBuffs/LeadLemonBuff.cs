using Terraria;
using Terraria.ModLoader;

namespace Xenon.Content.Buffs.Epibuffs.OreFruitBuffs
{
    public class LeadLemonBuff : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            player.endurance += 0.04f;
        }
    }
}