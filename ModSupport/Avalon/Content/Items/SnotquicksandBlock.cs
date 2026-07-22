using Terraria;
using Terraria.ModLoader;
using Xenon.ModSupport.Avalon.Content.Tiles;

namespace Xenon.ModSupport.Avalon.Content.Items;

public class SnotquicksandBlock : ModItem
{
    public override bool IsLoadingEnabled(Mod mod)
    {
        return XenonMod.AvalonContentEnabled;
    }
    public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 100;
	}

	public override void SetDefaults()
	{
		Item.DefaultToPlaceableTile(ModContent.TileType<Snotquicksand>());
	}
}
