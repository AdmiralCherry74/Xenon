using Terraria.ID;
using Terraria.ModLoader;
using Xenon.ModSupport.Avalon.Content.Tiles;

namespace Xenon.ModSupport.Avalon.Content.Items;

public class PolloStoneBlock : ModItem
{
    public override bool IsLoadingEnabled(Mod mod)
    {
        return XenonMod.AvalonContentEnabled;
    }
    public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 100;
	}
	public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup)
	{
		itemGroup = ContentSamples.CreativeHelper.ItemGroup.Blocks;
	}
	public override void SetDefaults()
	{
		Item.autoReuse = true;
		Item.consumable = true;
		Item.createTile = ModContent.TileType<PolloStone>();
		Item.width = 16;
		Item.useTurn = true;
		Item.useTime = 10;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.maxStack = 9999;
		Item.useAnimation = 15;
		Item.height = 16;
	}
}
