using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Armor.PreHardmode;
using Xenon.Content.Items.Placeable.Blocks.BuildingTiles.Wood;

namespace Xenon.Content.Items.Accessories
{
    // This example attempts to showcase most of the common boot accessory effects.
    // Of particular note is a showcase of the correct approaches to various movement speed modifications.
    [AutoloadEquip(EquipType.Shoes)]
    public class ZephyrSneakers : ModItem
    {
        public static readonly int SandstormMoveSpeedBonus = 5;
        public static readonly int WindyMoveSpeedBonus = 4;
        public static readonly int NotWindyMoveSpeedBonus = 3;

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 22;
            Item.accessory = true;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.buyPrice(gold: 4); // Equivalent to Item.buyPrice(0, 1, 0, 0);
        }

        public override void AddRecipes()
        {
            Recipe.Create(ModContent.ItemType<ZephyrSneakers>())
                .AddIngredient(ModContent.ItemType<WindSneakers>())
                .AddIngredient(ItemID.SandBoots)
                .AddIngredient(ItemID.LuckyHorseshoe)
                .SortAfterFirstRecipesOf(ItemID.FrostsparkBoots)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.rocketBoots = 0;
            player.noFallDmg = true;
            player.desertBoots = true;
            player.hasLuck_LuckyHorseshoe = true;
            player.buffImmune[BuffID.WindPushed] = true;

            if (player.ZoneSandstorm && Sandstorm.Happening)
            {
                player.moveSpeed += SandstormMoveSpeedBonus / 50f;
                player.accRunSpeed = 7.85f;
            }
            else if (Main.WindyEnoughForKiteDrops)
            {
                player.moveSpeed += WindyMoveSpeedBonus / 50f;
                player.accRunSpeed = 7.50f;
            }
            else
            {
                player.moveSpeed += NotWindyMoveSpeedBonus / 50f;
                player.accRunSpeed = 6.70f;
            }
        }
    }
}