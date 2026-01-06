using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Xenon.Common.Globals;

namespace Xenon.Content.Buffs.TarotCardBuff;

public class Unpolished : ModBuff
{
    public const int DefenseReduction = 25;
    public static float DefenseMultiplier = 1 - DefenseReduction / 100f;
    public override void SetStaticDefaults()
	{
		Main.debuff[Type] = true;
		BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
		Main.buffNoTimeDisplay[Type] = true;

	}
    public override void Update(Player player, ref int buffIndex)
    {
        player.statDefense *= DefenseMultiplier;
    }
}