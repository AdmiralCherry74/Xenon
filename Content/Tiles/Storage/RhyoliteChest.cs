using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.Enums;
using Xenon.Content.Items.Blocks;

namespace Xenon.Content.Tiles.Storage
{
    public class RhyoliteChest : ModTile
    {
        public override void SetStaticDefaults()
        {
            {
                Main.tileShine2[Type] = true;
                Main.tileShine[Type] = 1200;
            }
            // Properties
            Main.tileSpelunker[Type] = true;
            Main.tileContainer[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileOreFinderPriority[Type] = 500;
            TileID.Sets.HasOutlines[Type] = true;
            TileID.Sets.BasicChest[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileID.Sets.AvoidedByNPCs[Type] = true;
            TileID.Sets.InteractibleByNPCs[Type] = true;
            TileID.Sets.IsAContainer[Type] = true;
            TileID.Sets.FriendlyFairyCanLureTo[Type] = true;

            //DustType = ModContent.DustType<Sparkle>();
            DustType = DustID.Copper;
            AdjTiles = new int[] { TileID.Containers };

            // Other tiles with just one map entry use CreateMapEntryName() to use the default translationkey, "MapEntry"
            // Since ExampleChest needs multiple, we register our own MapEntry keys
            AddMapEntry(new Color(174, 129, 92), this.GetLocalization("MapEntry0"), MapChestName);
            //AddMapEntry(new Color(174, 129, 92), this.GetLocalization("MapEntry1"), MapChestName);
            //AddMapEntry(new Color(174, 129, 92), this.GetLocalization("MapEntry2"), MapChestName);

            // Placement
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };
            TileObjectData.newTile.HookCheckIfCanPlace = new PlacementHook(Chest.FindEmptyChest, -1, 0, true);
            TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(Chest.AfterPlacement_Hook, -1, 0, false);
            TileObjectData.newTile.AnchorInvalidTiles = new int[] {
                TileID.MagicalIceBlock,
                TileID.Boulder,
                TileID.BouncyBoulder,
                TileID.LifeCrystalBoulder,
                TileID.RollingCactus
            };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.addTile(Type);
        }

        public override ushort GetMapOption(int i, int j)
        {
            return (ushort)(Main.tile[i, j].TileFrameX / 36);
        }

        public override LocalizedText DefaultContainerName(int frameX, int frameY)
        {
            int option = frameX / 36;
            return this.GetLocalization("MapEntry" + option);
        }

        public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
        {
            return true;
        }

        public static string MapChestName(string name, int i, int j)
        {
            int left = i;
            int top = j;
            Tile tile = Main.tile[i, j];
            if (tile.TileFrameX % 36 != 0)
            {
                left--;
            }

            if (tile.TileFrameY != 0)
            {
                top--;
            }

            int chest = Chest.FindChest(left, top);
            if (chest < 0)
            {
                return Language.GetTextValue("LegacyChestType.0");
            }

            if (Main.chest[chest].name == "")
            {
                return name;
            }

            return name + ": " + Main.chest[chest].name;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = 1;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            //if (!WorldGen.generatingWorld)
            //{
            //    Item.NewItem(WorldGen.GetItemSource_FromTileBreak(i, j), i * 16, j * 16, 32, 32, DropItem);
            //}
            // We override KillMultiTile to handle additional logic other than the item drop. In this case, unregistering the Chest from the world
            Chest.DestroyChest(i, j);
        }

        public override bool RightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;
            Tile tile = Main.tile[i, j];
            Main.mouseRightRelease = false;
            int left = i;
            int top = j;
            if (tile.TileFrameX % 36 != 0)
            {
                left--;
            }

            if (tile.TileFrameY != 0)
            {
                top--;
            }

            player.CloseSign();
            player.SetTalkNPC(-1);
            Main.npcChatCornerItem = 0;
            Main.npcChatText = "";
            if (Main.editChest)
            {
                SoundEngine.PlaySound(SoundID.MenuTick);
                Main.editChest = false;
                Main.npcChatText = string.Empty;
            }

            if (player.editedChestName)
            {
                NetMessage.SendData(MessageID.SyncPlayerChest, -1, -1, NetworkText.FromLiteral(Main.chest[player.chest].name), player.chest, 1f);
                player.editedChestName = false;
            }

            int chest = Chest.FindChest(left, top);
            if (chest != -1)
            {
                Main.stackSplit = 600;
                if (chest == player.chest)
                {
                    player.chest = -1;
                    SoundEngine.PlaySound(SoundID.MenuClose);
                }
                else
                {
                    SoundEngine.PlaySound(player.chest < 0 ? SoundID.MenuOpen : SoundID.MenuTick);
                    player.OpenChest(left, top, chest);
                }

                Recipe.FindRecipes();
            }
            return true;
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            Tile tile = Main.tile[i, j];
            int left = i;
            int top = j;
            if (tile.TileFrameX % 36 != 0)
            {
                left--;
            }

            if (tile.TileFrameY != 0)
            {
                top--;
            }

            int chest = Chest.FindChest(left, top);
            player.cursorItemIconID = -1;
            if (chest < 0)
            {
                player.cursorItemIconText = Language.GetTextValue("LegacyChestType.0");
            }
            else
            {
                string defaultName = TileLoader.DefaultContainerName(tile.TileType, tile.TileFrameX, tile.TileFrameY); // This gets the ContainerName text for the currently selected language
                player.cursorItemIconText = Main.chest[chest].name.Length > 0 ? Main.chest[chest].name : defaultName;
                if (player.cursorItemIconText == defaultName)
                {
                    player.cursorItemIconID = ModContent.ItemType<Items.Blocks.RhyoliteChest>();
                    player.cursorItemIconText = "";
                }
            }

            player.noThrow = 2;
            player.cursorItemIconEnabled = true;
        }

        public override void MouseOverFar(int i, int j)
        {
            MouseOver(i, j);
            Player player = Main.LocalPlayer;
            if (player.cursorItemIconText == "")
            {
                player.cursorItemIconEnabled = false;
                player.cursorItemIconID = 0;
            }
        }
    }
}