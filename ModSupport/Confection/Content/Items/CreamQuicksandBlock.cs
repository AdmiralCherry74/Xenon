using Terraria;
using Terraria.ModLoader;
using Xenon.ModSupport.Confection.Content.Tiles;

namespace Xenon.ModSupport.Confection.Content.Items
{
	public class CreamQuicksandBlock : ModItem
	{
        public override bool IsLoadingEnabled(Mod mod)
        {
            return XenonMod.TheConfectionRebirthContentEnabled;
        }
        public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 100;
		}

		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<Creamquicksand>());
		}
	}
}
