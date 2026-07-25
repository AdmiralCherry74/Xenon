using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Xenon.Content.Buffs.Debuffs.Counterable;

public class Iceburn : ModBuff
{
	int timer = 0;
	public override void SetStaticDefaults()
	{
		Main.debuff[Type] = true;
		BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
		Main.buffNoTimeDisplay[Type] = true;
	}
	public override void Update(Player player, ref int buffIndex)
	{
		if (player.lifeRegen > 0)
		{
			player.lifeRegen = 0;
		}
		timer++;
		if (timer % 15 == 0)
		{
			player.statLife -= 2;
			CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), CombatText.LifeRegen, 2, dramatic: false, dot: true);
			if (player.statLife <= 0)
			{
				int type = Main.rand.Next(2) + 1;
				player.KillMe(PlayerDeathReason.ByCustomReason(NetworkText.FromKey($"Mods.Xenon.DeathText.Iceburn_{type}", $"{player.name}")), 10, 0);
			}
			timer = 0;
		}
	}
}
