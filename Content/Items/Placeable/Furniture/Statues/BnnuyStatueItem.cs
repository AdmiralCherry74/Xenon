using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.NPCs;
using Xenon.Content.Tiles.Furniture.Statues;

namespace Xenon.Content.Items.Placeable.Furniture.Statues
{
    public class BnnuyStatueItem : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ArmorStatue);
            Item.createTile = ModContent.TileType<BnnuyStatue>();
            Item.placeStyle = 0;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<BnnuyItem>(), 1)
            .AddIngredient(ItemID.StoneBlock, 50)
            .AddTile(TileID.HeavyWorkBench)
            .AddCondition(Condition.InGraveyard)
            .SortAfterFirstRecipesOf(ItemID.BunnyStatue)
            .Register();
        }
    }
}