using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Xenon.Content.Items.Weapons.Melee.Swords;

namespace Xenon.Content.Tiles.ActiveAndWiring.WireActivators
{
    public class SwordLeverWild : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileID.Sets.IsATrigger[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileObsidianKill[Type] = true;

            TileID.Sets.HasOutlines[Type] = true;
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(107, 107, 107), this.GetLocalization("MapEntry"));
        }
        public override bool RightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;
            for (int num146 = 0; num146 < player.inventory.Length; num146++)
            {
                if (player.inventory[num146].type == ModContent.ItemType<LivingWoodenSword>())
                {
                    SoundEngine.PlaySound(SoundID.Item1, new Vector2(i * 16, j * 16));
                    Wiring.TripWire(i, j, 1, 1);
                    return true;
                }
            }
            return false;
        }
        public override void MouseOver(int i, int j)
        {
            var player = Main.LocalPlayer;
            player.noThrow = 2;
            player.cursorItemIconEnabled = true;
            player.cursorItemIconID = ModContent.ItemType<LivingWoodenSword>();
        }
    }
}