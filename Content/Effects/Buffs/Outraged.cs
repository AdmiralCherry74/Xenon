using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Xenon.Content.Effects.Buffs;
    public class Outraged : ModBuff
{
    public override void Update(Player player, ref int buffIndex)
    {
        player.GetArmorPenetration(DamageClass.Generic) += 5;
    }
}