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
        public static readonly int DefenseBonus = 1;

        public override LocalizedText Description => base.Description.WithFormatArgs(DefenseBonus);

        public override void Update(Player player, ref int buffIndex)
        {
        player.statDefense += DefenseBonus; // Grant a +10 defense boost to the player while the buff is active.
    }
    }