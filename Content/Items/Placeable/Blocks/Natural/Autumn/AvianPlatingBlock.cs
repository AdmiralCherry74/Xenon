// What libraries we use in the code
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Blocks.Natural.Stone;
using Xenon.Content.Items.Placeable.Wall.Natural.Stone;
using Xenon.Content.Tiles.Natural.Autumn;

namespace Xenon.Content.Items.Placeable.Blocks.Natural.Autumn
{
    public class AvianPlatingBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }

        public override void SetDefaults()
		{
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.autoReuse = true;
			Item.maxStack = 9999;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<AvianPlating>();
			Item.width = 12;
			Item.height = 12;
			Item.rare = ItemRarityID.White;
		}
    }
}