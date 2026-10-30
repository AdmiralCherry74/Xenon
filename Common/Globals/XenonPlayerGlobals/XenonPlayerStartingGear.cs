using AltLibrary.Common.AltOres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Tools.CuttingAxes;
using Xenon.Content.Items.Tools.MiningPickaxes;
using Xenon.Content.Items.Weapons.Melee.Shortswords;

namespace Xenon.Common.Globals.XenonPlayerGlobals
{
    public class XenonPlayerStartingGear : ModPlayer
    {
        public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
        {
            if (ModContent.GetInstance<XenonConfig>().BasicGameplayChanges)
                return
                [
                    new Item(ModContent.ItemType<WoodenDagger>()),
                    new Item(ModContent.ItemType<WoodenMattock>()),
                    new Item(ModContent.ItemType<WoodenHatchet>())
                ];
            return Enumerable.Empty<Item>();
        }
        public override void ModifyStartingInventory(IReadOnlyDictionary<string, List<Item>> itemsByMod, bool mediumCoreDeath)
        {
            if (ModContent.GetInstance<XenonConfig>().BasicGameplayChanges)
            {
                itemsByMod["Terraria"].RemoveAll(item => item.type == ItemID.CopperShortsword);
                itemsByMod["Terraria"].RemoveAll(item => item.type == ItemID.CopperPickaxe);
                itemsByMod["Terraria"].RemoveAll(item => item.type == ItemID.CopperAxe);
            }
        }
    }
}