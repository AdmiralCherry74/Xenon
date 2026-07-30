using Terraria;
using Terraria.ID;
using Xenon.Common;
using Xenon.Content.Biomes;

namespace Xenon.Hooks;

//internal class TheMirageBiomeMusicHook : ModHook
//{
//	protected override void Apply()
//	{
//		On_Main.UpdateAudio_DecideOnNewMusic += On_Main_UpdateAudio_DecideOnNewMusic;
//	}
//
//	private void On_Main_UpdateAudio_DecideOnNewMusic(On_Main.orig_UpdateAudio_DecideOnNewMusic orig, Main self)
//	{
//		orig.Invoke(self);
//		if (!Main.gameMenu && Main.player[Main.myPlayer].InModBiome<UndergroundOcean>() && !Main.player[Main.myPlayer].ZoneBeach && Main.player[Main.myPlayer].ZoneOverworldHeight)
//		{
//			Main.newMusic = MusicID.Desert;
//		}
//	}
//}
//