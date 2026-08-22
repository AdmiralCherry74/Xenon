using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.Graphics.Effects;
using Terraria.ModLoader;
using Xenon.Common.Globals.XenonWorldGlobals;

namespace Xenon.Content.Biomes.Autumn
{
    public class AutumnBackgroundStyle : ModSurfaceBackgroundStyle
    {
        public override void ModifyFarFades(float[] fades, float transitionSpeed)
        {
            for (int i = 0; i < fades.Length; i++)
            {
                if (i == Slot)
                {
                    fades[i] += transitionSpeed;
                    if (fades[i] > 1f)
                    {
                        fades[i] = 1f;
                    }
                }
                else
                {
                    fades[i] -= transitionSpeed;
                    if (fades[i] < 0f)
                    {
                        fades[i] = 0f;
                    }
                }
            }
        }

        public override int ChooseFarTexture()
        {
            if (XenonWorld.AutumnBG == 1)
            {
                return BackgroundTextureLoader.GetBackgroundSlot(Mod, "Assets/Textures/Backgrounds/AutumnBackgrounds/Surface/AutumnTreeStyle/AutumnSurfaceFar1");
            }
            else
            {
                return BackgroundTextureLoader.GetBackgroundSlot(Mod, "Assets/Textures/Backgrounds/AutumnBackgrounds/Surface/AutumnClassicStyle/AutumnSurfaceFar0");
            }
        }
        public override int ChooseMiddleTexture()
        {
            if (XenonWorld.AutumnBG == 1)
            {
                return BackgroundTextureLoader.GetBackgroundSlot(Mod, "Assets/Textures/Backgrounds/AutumnBackgrounds/Surface/AutumnTreeStyle/AutumnSurfaceMid1");
            }
            else
            {
                return BackgroundTextureLoader.GetBackgroundSlot(Mod, "Assets/Textures/Backgrounds/AutumnBackgrounds/Surface/AutumnClassicStyle/AutumnSurfaceMid0");
            }
        }
        public override int ChooseCloseTexture(ref float scale, ref double parallax, ref float a, ref float b)
        {
            if (XenonWorld.AutumnBG == 1)
            {
                return BackgroundTextureLoader.GetBackgroundSlot(Mod, "Assets/Textures/Backgrounds/AutumnBackgrounds/Surface/AutumnTreeStyle/AutumnSurfaceCloseFAR1");
            }
            else
            {
                return BackgroundTextureLoader.GetBackgroundSlot(Mod, "Assets/Textures/Backgrounds/AutumnBackgrounds/Surface/AutumnClassicStyle/AutumnSurfaceClose0");
            }
        }
        public override bool PreDrawCloseBackground(SpriteBatch spriteBatch)
        {
            float bgScale = Main.instance.GetBGScale();
            float screenOff = Main.instance.GetScreenOff();
            double bgParallax = Main.instance.GetBGParallax();
            int bgTopY = Main.instance.GetBGTopY();
            float scAdj = Main.instance.GetSCAdj();
            int bgWidthScaled = Main.instance.GetBGWidthScaled();
            int bgStartX = Main.instance.GetBGStartX();
            int bgLoops = Main.instance.GetBGLoops();
            Color ColorOfSurfaceBackgroundsModified = Main.instance.GetColorOFSurfaceBackgroundsModified();

            string? closeBGPath;
            string? closeMidBGPath;
            string? closeFarBGPath;
            switch (XenonWorld.AutumnBG)
            {
                case 1:
                    {
                        // trees
                        closeBGPath = "Xenon/Assets/Textures/Backgrounds/AutumnBackgrounds/Surface/AutumnTreeStyle/AutumnSurfaceCloseCLOSE1";
                        closeMidBGPath = "Xenon/Assets/Textures/Backgrounds/AutumnBackgrounds/Surface/AutumnTreeStyle/AutumnSurfaceCloseMID1";
                        closeFarBGPath = "Xenon/Assets/Textures/Backgrounds/AutumnBackgrounds/Surface/AutumnTreeStyle/AutumnSurfaceCloseFAR1";
                        break;
                    }
                default:
                    {
                        //classic
                        closeBGPath = "Xenon/Assets/Textures/Backgrounds/AutumnBackgrounds/Surface/AutumnClassicStyle/AutumnSurfaceClose0";
                        closeMidBGPath = "Xenon/Assets/Textures/Backgrounds/AutumnBackgrounds/Surface/AutumnClassicStyle/AutumnSurfaceInvisible";
                        closeFarBGPath = "Xenon/Assets/Textures/Backgrounds/AutumnBackgrounds/Surface/AutumnClassicStyle/AutumnSurfaceInvisible";
                        break;
                    }
            }

            bool renderBG = false;
            if ((!Main.remixWorld || (Main.gameMenu && !WorldGen.remixWorldGen)) && (!WorldGen.remixWorldGen || !WorldGen.drunkWorldGen))
            {
                renderBG = true;
            }
            if (Main.mapFullscreen)
            {
                renderBG = false;
            }
            int topPos = 30;
            if (Main.gameMenu)
            {
                topPos = 0;
            }
            if (WorldGen.drunkWorldGen)
            {
                topPos = -180;
            }
            float surfacePos = (float)Main.worldSurface;
            if (surfacePos == 0f)
            {
                surfacePos = 1f;
            }
            float dynamicTopPos = Main.screenPosition.Y + (float)(Main.screenHeight / 2) - 600f;
            double backgroundTopMagicNumber = (dynamicTopPos - screenOff / 2f) / (surfacePos * 16f);
            backgroundTopMagicNumber = 0f - MathHelper.Lerp((float)backgroundTopMagicNumber, 1f, 0f);
            backgroundTopMagicNumber = (0f - dynamicTopPos + screenOff / 2f) / (surfacePos * 16f);
            float bgGlobalScaleMultiplier = 2f;
            int pushBGTopHack = 0;
            int topOffset = -180;
            bool canOffset = true;
            int topHackPos = 0;
            if (Main.gameMenu)
            {
                topHackPos -= topOffset;
            }
            pushBGTopHack = topHackPos;
            pushBGTopHack += topPos;
            if (canOffset)
            {
                pushBGTopHack += topOffset;
            }
            if (renderBG)
            {
                if (closeFarBGPath != null)
                {
                    Texture2D closeFarBG = ModContent.Request<Texture2D>(closeFarBGPath).Value;
                    switch (XenonWorld.AutumnBG)
                    {
                        case 1:
                            {
                                bgScale = 1.25f;
                                bgParallax = 0.25;
                                bgTopY = (int)(backgroundTopMagicNumber * 1800.0 + 1300.0) + (int)scAdj + pushBGTopHack;
                                break;
                            }
                        default:
                            {
                                bgScale = 1.25f;
                                bgParallax = 0.245;
                                bgTopY = (int)(backgroundTopMagicNumber * 1800.0 + 1500.0) + (int)scAdj + pushBGTopHack;
                                break;
                            }
                    }
                    //Main.instance.SetBackgroundOffsets((Texture2D)ModContent.Request<Texture2D>("TheConfectionRebirth/Backgrounds/ConfectionSurfaceClose1"), backgroundTopMagicNumber, pushBGTopHack);
                    bgScale *= bgGlobalScaleMultiplier;
                    //Main.instance.LoadBackground(ModContent.Request<Texture2D>("TheConfectionRebirth/Backgrounds/ConfectionSurfaceClose1").Value);
                    bgWidthScaled = (int)((float)closeFarBG.Width * bgScale);
                    SkyManager.Instance.DrawToDepth(Main.spriteBatch, 1.2f / (float)bgParallax);
                    bgStartX = (int)(0.0 - Math.IEEERemainder((double)Main.screenPosition.X * bgParallax, bgWidthScaled) - (double)(bgWidthScaled / 2));
                    if (Main.gameMenu)
                        bgTopY = 320 + pushBGTopHack;

                    bgLoops = Main.screenWidth / bgWidthScaled + 2;
                    if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
                    {
                        for (int i = 0; i < bgLoops; i++)
                        {
                            Main.spriteBatch.Draw(closeFarBG, new Vector2(bgStartX + bgWidthScaled * i, bgTopY), new Rectangle(0, 0, closeFarBG.Width, closeFarBG.Height), ColorOfSurfaceBackgroundsModified, 0f, default(Vector2), bgScale, SpriteEffects.None, 0f);
                        }
                    }
                }
                if (closeMidBGPath != null)
                {
                    Texture2D closeMidBG = ModContent.Request<Texture2D>(closeMidBGPath).Value;
                    switch (XenonWorld.AutumnBG)
                    {
                        case 1:
                            {
                                bgScale = 1.31f;
                                bgParallax = 0.28;
                                bgTopY = (int)(backgroundTopMagicNumber * 1950.0 + 1750.0) + (int)scAdj + pushBGTopHack;
                                break;
                            }
                        default:
                            {
                                bgScale = 1.31f;
                                bgParallax = 0.32;
                                bgTopY = (int)(backgroundTopMagicNumber * 1950.0 + 1850.0) + (int)scAdj + pushBGTopHack;
                                break;
                            }
                    }
                    //Main.instance.SetBackgroundOffsets(textureSlot2, backgroundTopMagicNumber, pushBGTopHack);
                    bgScale *= bgGlobalScaleMultiplier;
                    //Main.instance.LoadBackground(textureSlot2);
                    bgWidthScaled = (int)((float)closeMidBG.Width * bgScale);
                    SkyManager.Instance.DrawToDepth(Main.spriteBatch, 1f / (float)bgParallax);
                    bgStartX = (int)(0.0 - Math.IEEERemainder((double)Main.screenPosition.X * bgParallax, bgWidthScaled) - (double)(bgWidthScaled / 2));
                    if (Main.gameMenu)
                    {
                        bgTopY = 400 + pushBGTopHack;
                        bgStartX -= 80;
                    }

                    bgLoops = Main.screenWidth / bgWidthScaled + 2;
                    if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
                    {
                        for (int i = 0; i < bgLoops; i++)
                        {
                            Main.spriteBatch.Draw(closeMidBG, new Vector2(bgStartX + bgWidthScaled * i, bgTopY), new Rectangle(0, 0, closeMidBG.Width, closeMidBG.Height), ColorOfSurfaceBackgroundsModified, 0f, default(Vector2), bgScale, SpriteEffects.None, 0f);
                        }
                    }
                }
                if (closeBGPath != null)
                {
                    Texture2D closeBG = ModContent.Request<Texture2D>(closeBGPath).Value;
                    switch (XenonWorld.AutumnBG)
                    {
                        case 0:
                            {
                                bgScale = 1.34f;
                                bgParallax = 0.34;
                                bgTopY = (int)(backgroundTopMagicNumber * 2100.0 + 1850.0) + (int)scAdj + pushBGTopHack;
                                break;
                            }
                        default:
                            {
                                bgScale = 1.34f;
                                bgParallax = 0.35;
                                bgTopY = (int)(backgroundTopMagicNumber * 2100.0 + 2000.0) + (int)scAdj + pushBGTopHack;
                                break;
                            }
                    }
                    //Main.instance.SetBackgroundOffsets(textureSlot3, backgroundTopMagicNumber, pushBGTopHack);
                    bgScale *= bgGlobalScaleMultiplier;
                    //Main.instance.LoadBackground(textureSlot3);
                    bgWidthScaled = (int)((float)closeBG.Width * bgScale);
                    SkyManager.Instance.DrawToDepth(Main.spriteBatch, 1f / (float)bgParallax);
                    bgStartX = (int)(0.0 - Math.IEEERemainder((double)Main.screenPosition.X * bgParallax, bgWidthScaled) - (double)(bgWidthScaled / 2));
                    if (Main.gameMenu)
                    {
                        bgTopY = 480 + pushBGTopHack;
                        bgStartX -= 120;
                    }

                    bgLoops = Main.screenWidth / bgWidthScaled + 2;
                    if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
                    {
                        for (int i = 0; i < bgLoops; i++)
                        {
                            Main.spriteBatch.Draw(closeBG, new Vector2(bgStartX + bgWidthScaled * i, bgTopY), new Rectangle(0, 0, closeBG.Width, closeBG.Height), ColorOfSurfaceBackgroundsModified, 0f, default(Vector2), bgScale, SpriteEffects.None, 0f);
                        }
                    }
                }
            }
            if (canOffset)
            {
                pushBGTopHack -= topOffset;
            }

            //Flashcode, flashes the background when the world globe is used
            Texture2D blackPixel = TextureAssets.MagicPixel.Value;
            float flashPower = XenonWorld.AutumnBGFlash;
            Color color = Color.Black * flashPower;
            Main.spriteBatch.Draw(blackPixel, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), color);
            return false;
        }
    }
    public class UndergroundAutumnBackgroundStyle : ModUndergroundBackgroundStyle
    {
        public override void FillTextureArray(int[] textureSlots)
        {
            textureSlots[0] = ModContent.GetModBackgroundSlot($"{Mod.Name}/Assets/Textures/Backgrounds/AutumnBackgrounds/UndergroundAutumnBackground0_0"); // Sky border
            textureSlots[1] = ModContent.GetModBackgroundSlot($"{Mod.Name}/Assets/Textures/Backgrounds/AutumnBackgrounds/UndergroundAutumnBackground0_1"); // Undeground layer. refered to as Dirt Layer in code
            textureSlots[2] = ModContent.GetModBackgroundSlot($"{Mod.Name}/Assets/Textures/Backgrounds/AutumnBackgrounds/UndergroundAutumnBackground0_2"); // Underground-Cavern border. refered to as underground border in code
            textureSlots[3] = ModContent.GetModBackgroundSlot($"{Mod.Name}/Assets/Textures/Backgrounds/AutumnBackgrounds/UndergroundAutumnBackground0_3"); // Cavern. refered to as Underground in code.
            textureSlots[4] = ModContent.GetModBackgroundSlot($"{Mod.Name}/Assets/Textures/Backgrounds/AutumnBackgrounds/UndergroundAutumnBackground0_4"); // Hell border?
        }
    }
}