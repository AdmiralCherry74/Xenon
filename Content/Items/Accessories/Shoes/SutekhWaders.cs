using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Globals.XenonPlayerGlobals;

namespace Xenon.Content.Items.Accessories.Shoes
{
    // This example attempts to showcase most of the common boot accessory effects.
    // Of particular note is a showcase of the correct approaches to various movement speed modifications.
    [AutoloadEquip(EquipType.Shoes)]
    public class SutekhWaders : ModItem
    {
        public static readonly int MoveSpeedBonus = 2;

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 22;
            Item.accessory = true;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.buyPrice(gold: 4); // Equivalent to Item.buyPrice(0, 1, 0, 0);
        }

        public override void AddRecipes()
        {
            Recipe.Create(ModContent.ItemType<SutekhWaders>())
                .AddIngredient(ItemID.SandBoots)
                .AddIngredient(ItemID.WaterWalkingBoots)
                .SortBeforeFirstRecipesOf(ItemID.LavaWaders)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.moveSpeed += MoveSpeedBonus / 50f; // Modifies the player movement speed bonus.
            player.accRunSpeed = 6;

            player.desertBoots = true;
            player.GetModPlayer<XenonPlayer>().StandOnSand = true;
        }
    }
}