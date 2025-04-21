using System.Collections.Generic;
using System;
using Terraria;
using Terraria.ModLoader;
using Xenon.Common;
using Microsoft.Xna.Framework;
using Xenon.Content.Biomes;

namespace Xenon
{
	public class Xenon : Mod
	{
		public override void Load()
		{
			while (ModHook.RegisteredHooks.TryDequeue(out ModHook? hook))
			{
				hook.ApplyHook();
			}
		}
		public void BTitlesHook_SetupBiomeCheckers(out Func<Player, string> miniBiomeChecker, out Func<Player, string> biomeChecker)
		{
			miniBiomeChecker = player =>
			{


				return "";
			};
			biomeChecker = player =>
			{
				if (player.InModBiome<Rhyolite>()) return "Rhyolite";

				return "";
			};
		}

		public string BTitlesHook_BiomeChecker(Player player)
		{
			if (player.InModBiome<Rhyolite>()) return "Rhyolite";

			return "";
		}

		public IEnumerable<dynamic> BTitlesHook_GetBiomes()
		{
			yield return new
			{
				Key = "Rhyolite",
				Title = "Rhyolite Cave",
				SubTitle = "Xenon",
				TitleColor = new Color(150, 101, 93),
				TitleStroke = new Color(53, 40, 37),
			};
		}
	}
}
