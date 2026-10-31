using System.Collections.Generic;
using MagicStorage.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials.BarsGems.PreHardBars;
using Xenon.ModSupport.MagicStorageCompat.Content;

namespace Xenon.ModSupport.MagicStorageCompat
{
    // Not sure how Xenon handles cross mod recipes - Emerald
    [ExtendsFromMod("MagicStorage")]
    public class MagicStorageRecipes : GlobalItem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModLoader.HasMod("MagicStorage");
        }
        public override void AddRecipes()
        {
            Recipe.Create(ModContent.ItemType<IngestaneUpgrade>())
            .AddIngredient(ModContent.ItemType<IngestaneBar>(), 10)
            .AddIngredient(ItemID.Amethyst, 1)
            .AddTile(TileID.Anvils)
            .SortAfterFirstRecipesOf(ModContent.ItemType<UpgradeDemonite>())
            .Register();
        }
    }
}