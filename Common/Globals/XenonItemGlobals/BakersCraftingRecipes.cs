using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Globals.XenonPlayerGlobals;
using Xenon.Content.Items.Placeable.Blocks.Natural.Stone;

namespace Xenon.Common.Globals.XenonItemGlobals
{
    public class BakersCraftingRecipes : ModSystem
    {
        public override void AddRecipes()
        {
            Recipe.Create(ItemID.ApplePie)
            .AddIngredient(ItemID.Apple, 3)
            .AddTile(TileID.CookingPots)
            .AddCondition(new Condition("Mods.Xenon.Conditions.BakersHandbookPurityUsed", () => Main.LocalPlayer.GetModPlayer<BakersHandbooksBool>().BakersHandbookPurityUsed))
            .Register();
        }
    }
}
