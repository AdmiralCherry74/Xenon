using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics;
using Terraria;
using Terraria.Graphics.Renderers;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Xenon.Common;
using Xenon.Content.Buffs;

namespace Xenon.Hooks;

internal class FossilizedBlessingHook : ModHook
{
    protected override void Apply()
    {
        On_LegacyPlayerRenderer.DrawPlayerFull += On_LegacyPlayerRenderer_DrawPlayerFull;
    }

    private void On_LegacyPlayerRenderer_DrawPlayerFull(On_LegacyPlayerRenderer.orig_DrawPlayerFull orig, LegacyPlayerRenderer self, Camera camera, Player drawPlayer)
    {
        if (drawPlayer.HasBuff(ModContent.BuffType<FossilBlessing>()))
        {
            SpriteBatch spriteBatch = camera.SpriteBatch;
            SamplerState samplerState = camera.Sampler;
            if (drawPlayer.mount.Active && drawPlayer.fullRotation != 0f)
            {
                samplerState = LegacyPlayerRenderer.MountedSamplerState;
            }
            spriteBatch.Begin((SpriteSortMode)1, BlendState.AlphaBlend, samplerState, DepthStencilState.None, camera.Rasterizer, null, camera.GameViewMatrix.TransformationMatrix);

            Vector2 position = drawPlayer.position;
            position.Y += drawPlayer.gfxOffY;
            DrawPlayerFossilized(camera, drawPlayer, position);
            spriteBatch.End();
        }
        else orig.Invoke(self, camera, drawPlayer);
    }

    private void DrawPlayerFossilized(Camera camera, Player drawPlayer, Vector2 position)
    {
        if (!drawPlayer.dead)
        {
            SpriteEffects spriteEffects = 0;
            spriteEffects = drawPlayer.direction != 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            Texture2D TEX = ModContent.Request<Texture2D>("Xenon/Assets/FossilizedPlayer").Value;
            camera.SpriteBatch.Draw(TEX, new Vector2((float)(int)(position.X - camera.UnscaledPosition.X - (float)(drawPlayer.bodyFrame.Width / 2) + (float)(drawPlayer.width / 2)), (float)(int)(position.Y - camera.UnscaledPosition.Y + (float)drawPlayer.height - (float)drawPlayer.bodyFrame.Height + 8f)) + drawPlayer.bodyPosition + new Vector2((float)(drawPlayer.bodyFrame.Width / 2), (float)(drawPlayer.bodyFrame.Height / 2)), (Rectangle?)null, Lighting.GetColor((int)((double)position.X + (double)drawPlayer.width * 0.5) / 16, (int)((double)position.Y + (double)drawPlayer.height * 0.5) / 16, Color.White), 0f, new Vector2((float)(TEX.Width / 2), (float)(TEX.Height / 2)), 1f, spriteEffects, 0f);
        }
    }
}
