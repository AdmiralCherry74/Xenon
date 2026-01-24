using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Xenon.Content.Buffs.Debuffs.Counterable
{
    public class Oblivious : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;  // Is it a debuff?
            Main.pvpBuff[Type] = false; // Players can give other players buffs, which are listed as pvpBuff
            Main.buffNoSave[Type] = false; // Causes this buff not to persist when exiting and rejoining the world
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetCritChance(DamageClass.Generic) -= 0;
        }
    }
}