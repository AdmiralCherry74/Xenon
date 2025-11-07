using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.GameContent.Drawing.TileDrawing;
using Xenon.Content.NPCs.CasterAI;
using Xenon.Content.NPCs.FighterAI;
using Xenon.Content.NPCs.MimicAI;
using Xenon.Content.NPCs.SpiderAI;
using Xenon.Content.NPCs.WormAI;
using Xenon.Content.NPCs.FlyingAI;
using Xenon.Content.NPCs.UniqueAI;
using Xenon.Content.NPCs.UnicornAI;
using Xenon.Content.NPCs.BatAI;
using Xenon.Content.NPCs.SlimeAI;
using Xenon.Content.NPCs.FighterAI.UniqueFighterAI;

namespace Xenon.Content.Tiles;

public class MonsterBanner : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        Main.tileNoAttach[Type] = true;
        Main.tileLavaDeath[Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
        TileObjectData.newTile.Height = 3;
        TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16 };
        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom | AnchorType.PlanterBox, TileObjectData.newTile.Width, 0);
        TileObjectData.newTile.StyleWrapLimit = 111;
        TileObjectData.newTile.DrawYOffset = -2;
        TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
        TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.Platform, TileObjectData.newTile.Width, 0);
        TileObjectData.newAlternate.DrawYOffset = -10;
        TileObjectData.addAlternate(0);
        TileObjectData.addTile(Type);
        DustType = -1;
        TileID.Sets.DisableSmartCursor[Type] = true;
        AddMapEntry(new Color(13, 88, 130));
    }
    public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
    {
        Tile tile = Main.tile[i, j];
        int topLeftX = i - tile.TileFrameX / 18 % 1;
        int topLeftY = j - tile.TileFrameY / 18 % 3;
        if (WorldGen.IsBelowANonHammeredPlatform(topLeftX, topLeftY))
        {
            offsetY -= -2;
        }
    }
    public override void NearbyEffects(int i, int j, bool closer)
    {
        if (closer)
        {
            Player player = Main.LocalPlayer;
            int style = Main.tile[i, j].TileFrameX / 18;
            int t = 1;
            switch (style)
            {
                case 0:
                    t = ModContent.NPCType<RhyoliteSlimer>();
                    break;
                case 1:
                    t = ModContent.NPCType<LavaWormHead>();
                    break;
				case 2:
					t = ModContent.NPCType<Bandit>();
					break;
				case 3:
					t = ModContent.NPCType<BanditLooter>();
					break;
				case 4:
					t = ModContent.NPCType<CapillarieHead>();
					break;
				case 5:
					t = ModContent.NPCType<CorrodedCultist>();
					break;
				case 6:
					t = ModContent.NPCType<CorruptCultist>();
					break;
				case 7:
					t = ModContent.NPCType<CrimsonCultist>();
					break;
				case 8:
					t = ModContent.NPCType<Evphila>();
					break;
				case 9:
					t = ModContent.NPCType<Gastritis>();
					break;
				case 10:
					t = ModContent.NPCType<HalfDigested>();
					break;
				case 11:
					t = ModContent.NPCType<HauntedArmor>();
					break;
				case 12:
					t = ModContent.NPCType<MarbleElemental>();
					break;
				case 13:
					t = ModContent.NPCType<Mimicling>();
					break;
				case 14:
					t = ModContent.NPCType<NightmareWalker>();
					break;
				case 15:
					t = ModContent.NPCType<SnowLeopard>();
					break;
				case 17:
					t = ModContent.NPCType<SporeSlime>();
					break;
				case 18:
					t = ModContent.NPCType<StomachBug>();
					break;
				case 19:
					t = ModContent.NPCType<TapeWormHead>();
					break;
				default:
                    t = 0;
                    return;
            }
            //Main.SceneMetrics.NPCBannerBuff[Mod.Find<ModNPC>(type).Type] = true;
            Main.SceneMetrics.NPCBannerBuff[t] = true;
            Main.SceneMetrics.hasBanner = true;
            //player.hasBannerBuff = true;
        }
    }

    public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
    {
        if (i % 2 == 1)
        {
            spriteEffects = SpriteEffects.FlipHorizontally;
        }
    }

    public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
    {
        bool intoRenderTargets = true;
        bool flag = intoRenderTargets || Main.LightingEveryFrame;

        if (Main.tile[i, j].TileFrameX % 18 == 0 && Main.tile[i, j].TileFrameY % 54 == 0 && flag)
        {
            Main.instance.TilesRenderer.AddSpecialPoint(i, j, TileCounterType.MultiTileVine);
        }

        return false;
    }
}
