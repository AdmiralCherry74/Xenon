using Terraria;
using Terraria.GameContent.Drawing;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Xenon.Common;
using Xenon.Content.Tiles;
using Xenon.Content.Tiles.Furniture.Rhyolite;

namespace Xenon.Hooks
{
    internal class WindHook : ModHook //Should rename since its nolonger just hooks
    {
        protected override void Apply()
        {
            On_TileDrawing.DrawMultiTileVinesInWind += On_TileDrawing_DrawMultiTileVinesInWind;
            On_TileDrawing.PostDrawTiles += On_TileDrawing_PostDrawTiles;
        }

        private void On_TileDrawing_DrawMultiTileVinesInWind(On_TileDrawing.orig_DrawMultiTileVinesInWind orig, TileDrawing self, Vector2 screenPosition, Vector2 offSet, int topLeftX, int topLeftY, int sizeX, int sizeY)
        {
			if (Main.tile[topLeftX, topLeftY].TileType == ModContent.TileType<MonsterBanner>())
			{
				sizeY = 3;
			}
			else if (Main.tile[topLeftX, topLeftY].TileType == ModContent.TileType<RhyoliteLantern>())
            {
                sizeY = 2;
            }
            else if (Main.tile[topLeftX, topLeftY].TileType == ModContent.TileType<RhyoliteChandelier>())
            {
                sizeX = 3;
                sizeY = 3;
            }
            orig.Invoke(self, screenPosition, offSet, topLeftX, topLeftY, sizeX, sizeY);
        }
        private void On_TileDrawing_PostDrawTiles(On_TileDrawing.orig_PostDrawTiles orig, TileDrawing self, bool solidLayer, bool forRenderTargets, bool intoRenderTargets)
        {
            orig.Invoke(self, solidLayer, forRenderTargets, intoRenderTargets);
            if (!solidLayer && !intoRenderTargets)
            {
                Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, Main.Rasterizer, null, Main.Transform);
                DrawChandeliers();
                DrawLanterns();
                Main.spriteBatch.End();
            }
        }
        private void DrawLanterns()
        {
            for (int i = 0; i < ModContent.GetInstance<RhyoliteLantern>().Coordinates.Count; i++)
            {
                ModContent.GetInstance<RhyoliteLantern>().DrawMultiTileVines(ModContent.GetInstance<RhyoliteLantern>().Coordinates[i].X, ModContent.GetInstance<RhyoliteLantern>().Coordinates[i].Y, Main.spriteBatch);
            }
        }
        private void DrawChandeliers()
        {
            for (int i = 0; i < ModContent.GetInstance<RhyoliteChandelier>().Coordinates.Count; i++)
            {
                ModContent.GetInstance<RhyoliteChandelier>().DrawMultiTileVines(ModContent.GetInstance<RhyoliteChandelier>().Coordinates[i].X, ModContent.GetInstance<RhyoliteChandelier>().Coordinates[i].Y, Main.spriteBatch);
            }
        }
    }
}
