using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Buffs.Debuffs;

public class FossilBlessingCooldown : ModBuff
{
	public override void SetStaticDefaults()
	{
		Main.debuff[Type] = true;
		BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
	}
}
