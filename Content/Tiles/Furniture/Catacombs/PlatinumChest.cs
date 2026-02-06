using Avalon.Items.Other;
using Avalon.Tiles.Furniture.Tuhrtl;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common;
using Xenon.Content.Items.Consumables;

namespace Xenon.Content.Tiles.Furniture.Catacombs
{
    public class PlatinumChest : ChestTemplate
    {
        public override int DropItem => ModContent.ItemType<Items.Placeable.Furniture.Catacombs.PlatinumChest>();
        protected override bool CanBeLocked => true;
        protected override int ChestKeyItemId => ModContent.ItemType<PlatinumKey>();
        public override bool UnlockChest(int i, int j, ref short frameXAdjustment, ref int dustType, ref bool manual)
        {
            return true;
        }
        public override bool LockChest(int i, int j, ref short frameXAdjustment, ref bool manual)
        {
            return base.LockChest(i, j, ref frameXAdjustment, ref manual);
        }
    }
}