using AltLibrary.Common.Systems;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Materials.Fish.Quest;

public class Giardia : ModItem
{
	public override void SetDefaults()
	{
		Item.DefaultToQuestFish();
	}
	public override bool IsQuestFish()
	{
		return true;
	}
	public override bool IsAnglerQuestAvailable()
	{
		return WorldBiomeManager.WorldEvilName == "Corrosion" && Main.hardMode;
	}

	public override void AnglerQuestChat(ref string description, ref string catchLocation)
	{
		description = Language.GetTextValue("Mods.Xenon.QuestFish.Giardia.Description");
		catchLocation = Language.GetTextValue("Mods.Xenon.QuestFish.Giardia.CatchLocation");
	}
}
