using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common;
using Xenon.Content.Biomes;

namespace Xenon.Hooks;

internal class MountainBiomeMusicHook : ModHook
{
	protected override void Apply()
	{
		On_Main.UpdateAudio_DecideOnNewMusic += On_Main_UpdateAudio_DecideOnNewMusic;
	}

	private void On_Main_UpdateAudio_DecideOnNewMusic(On_Main.orig_UpdateAudio_DecideOnNewMusic orig, Main self)
	{
		orig.Invoke(self);
		if (!Main.gameMenu && Main.player[Main.myPlayer].InModBiome<Mountain>())
		{
			Main.newMusic = MusicID.OtherworldlyUnderground;
		}
        if (!Main.gameMenu && Main.player[Main.myPlayer].InModBiome<Mountain>() && Main.player[Main.myPlayer].ZoneCorrupt)
        {
            Main.newMusic = MusicID.UndergroundCorruption;
        }
        if (!Main.gameMenu && Main.player[Main.myPlayer].InModBiome<Mountain>() && Main.player[Main.myPlayer].ZoneCrimson)
        {
            Main.newMusic = MusicID.UndergroundCrimson;
        }
        if (!Main.gameMenu && Main.player[Main.myPlayer].InModBiome<Mountain>() && Main.player[Main.myPlayer].InModBiome<Corrosion>())
        {
            Main.newMusic = MusicLoader.GetMusicSlot(Mod, "Assets/Music/UndergroundCorrosionIntroDemonDaysPlaceholder");
        }
    }
}
