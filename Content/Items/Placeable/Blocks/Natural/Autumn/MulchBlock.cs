// What libraries we use in the code
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.GameContent.Creative;
using Xenon.Content.Tiles.Natural.Autumn;

namespace Xenon.Content.Items.Placeable.Blocks.Natural.Autumn
{
    public class MulchBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Mulch>());
            
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 9999;
            Item.value = 0;
            Item.rare = ItemRarityID.White;
        }
    }
}