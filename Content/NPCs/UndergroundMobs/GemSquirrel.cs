using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Xenon.Content.Dusts;
using Xenon.Content.Items.Materials.BarsGems;
using Xenon.Content.Items.Placeable.NPCs;

namespace Xenon.Content.NPCs.UndergroundMobs;

public abstract class GemSquirrel : ModNPC
{
    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
        {
            BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns,
            new FlavorTextBestiaryInfoElement(Language.GetTextValue("CommonBestiaryFlavor.GemSquirrel"))
        });
    }
    public override float SpawnChance(NPCSpawnInfo spawnInfo) //possibly incomplete, needs special rules for special seeds?
    {
        int spawnRangeX = (int)(NPC.sWidth / 16 * 0.7);
        int spawnRangeY = (int)(NPC.sHeight / 16 * 0.7);
        for (int l = 0; l < 255; l++)
        {
            bool spawnThing = false;
            if (!spawnInfo.Player.InPillarZone() && ((!Main.bloodMoon && !Main.pumpkinMoon && !Main.snowMoon) || Main.dayTime) && (!Main.eclipse || !Main.dayTime) && !Main.player[l].ZoneDungeon && !Main.player[l].ZoneCorrupt && !Main.player[l].ZoneCrimson && !Main.player[l].ZoneMeteor && !Main.player[l].ZoneOldOneArmy)
            {
                if (Main.player[l].Center.Y / 16f > (float)Main.UnderworldLayer && (!Main.remixWorld || !((double)(Main.player[l].Center.X / 16f) > (double)Main.maxTilesX * 0.39 + 50.0) || !((double)(Main.player[l].Center.X / 16f) < (double)Main.maxTilesX * 0.61)))
                {
                    if (Main.player[l].townNPCs == 1f && Main.rand.NextBool(10))
                    {
                        spawnThing = true;
                    }
                    else if (Main.player[l].townNPCs == 2f && Main.rand.NextBool(5))
                    {
                        spawnThing = true;
                    }
                    else if (Main.player[l].townNPCs >= 3f && Main.rand.NextBool(3))
                    {
                        spawnThing = true;
                    }
                }
                else if (Main.player[l].townNPCs == 1f)
                {
                    if (Main.player[l].ZoneGraveyard && Main.rand.NextBool(10))
                    {
                        spawnThing = true;
                    }
                    else if (Main.rand.NextBool(3))
                    {
                        spawnThing = true;
                    }
                }
                else if (Main.player[l].townNPCs == 2f)
                {
                    if (Main.player[l].ZoneGraveyard && Main.rand.NextBool(6))
                    {
                        spawnThing = true;
                    }
                    else if (!Main.rand.NextBool(3))
                    {
                        spawnThing = true;
                    }
                }
                else if (Main.player[l].townNPCs >= 3f)
                {
                    if (Main.player[l].ZoneGraveyard && Main.rand.NextBool(3))
                    {
                        spawnThing = true;
                    }
                    else if (!Main.rand.NextBool(30))
                    {
                        spawnThing = true;
                    }
                }
            }

            //int num14 = (int)(Main.player[l].position.X / 16f) - spawnRangeX;
            //int num15 = (int)(Main.player[l].position.X / 16f) + spawnRangeX;
            int num16 = (int)(Main.player[l].position.Y / 16f) - spawnRangeX;
            int num17 = (int)(Main.player[l].position.Y / 16f) + spawnRangeY;
            //int num3 = Main.rand.Next(num14, num15);
            int num4 = Main.rand.Next(num16, num17);
            //int num52 = Main.tile[num3, num4].TileType;
            if (spawnThing)
            {
                //if (num52 != 2 && num52 != 477 && num52 != 109 && num52 != 492 && !((double)num4 > Main.worldSurface))
                //{
                //    break;
                //}
                if (Main.raining && num4 <= Main.UnderworldLayer && num4 >= Main.rockLayer)
                {
                    if (num4 >= Main.rockLayer && Main.rand.NextBool(35))
                    {
                        return 1f;
                    }
                }
                else if (num4 > Main.UnderworldLayer)
                {
                    if (Main.remixWorld && (double)(Main.player[l].Center.X / 16f) > Main.maxTilesX * 0.39 + 50.0 && (double)(Main.player[l].Center.X / 16f) < Main.maxTilesX * 0.61)
                    {
                        if (Main.rand.NextBool(28))
                        {
                            return 1f;
                        }
                    }
                }
                else if (Main.remixWorld)
                {
                    if (num4 < Main.rockLayer && num4 > Main.worldSurface)
                    {
                        if (num4 >= Main.rockLayer && num4 <= Main.UnderworldLayer)
                        {
                            if (Main.rand.NextBool(28))
                            {
                                return 1f;
                            }
                        }
                    }
                }
                else if (num4 >= Main.rockLayer && num4 <= Main.UnderworldLayer)
                {
                    if (Main.rand.NextBool(28))
                    {
                        return 1f;
                    }
                }
            }
        }
        return 0;
    }
    private static Asset<Texture2D> glowTexture;
    public override void Load()
    {
        glowTexture = ModContent.Request<Texture2D>("Xenon/Content/NPCs/UndergroundMobs/GemSquirrel_Glow");
    }
    public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
    {
        SpriteEffects spriteEffects = SpriteEffects.None;
        if (NPC.direction == 1)
        {
            spriteEffects = SpriteEffects.FlipHorizontally;
        }
        Rectangle frame6 = NPC.frame;
        float num35 = 0f;
        float num36 = Main.NPCAddHeight(NPC);
        Vector2 halfSize = new Vector2(TextureAssets.Npc[Type].Width() / 2, TextureAssets.Npc[Type].Height() / Main.npcFrameCount[Type] / 2);
        Main.spriteBatch.Draw(glowTexture.Value, new Vector2(NPC.position.X - screenPos.X + (float)(NPC.width / 2) - (float)TextureAssets.Npc[Type].Width() * NPC.scale / 2f + halfSize.X * NPC.scale, NPC.position.Y - screenPos.Y + (float)NPC.height - (float)TextureAssets.Npc[Type].Height() * NPC.scale / (float)Main.npcFrameCount[Type] + 4f + halfSize.Y * NPC.scale + num36 + num35 + NPC.gfxOffY), frame6, NPC.GetAlpha(Color.White), NPC.rotation, halfSize, NPC.scale, spriteEffects, 0f);
    }
}
public class JadeSquirrel : GemSquirrel
{
    public override void SetStaticDefaults()
    {
        Main.npcFrameCount[Type] = 6;
        Main.npcCatchable[Type] = true;
        NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers()
        {
            // Influences how the NPC looks in the Bestiary
            Velocity = 1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
        };
        NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;
        NPCID.Sets.TakesDamageFromHostilesWithoutBeingFriendly[Type] = true;
        NPCID.Sets.TownCritter[Type] = true;
        NPCID.Sets.CountsAsCritter[Type] = true;
        NPCID.Sets.ShimmerTransformToItem[Type] = ModContent.ItemType<Jade>();
    }
    public override void SetDefaults()
    {
        NPC.CloneDefaults(NPCID.GemSquirrelAmethyst);
        AnimationType = NPCID.GemSquirrelAmethyst;
        AIType = NPCID.GemSquirrelAmethyst;
        NPC.friendly = false;
        NPC.catchItem = ModContent.ItemType<JadeSquirrelItem>();
    }
    public override void HitEffect(NPC.HitInfo hit)
    {
        Player player = Main.player[NPC.target];
        if (NPC.life > 0)
        {
            for (int num461 = 0; (double)num461 < (double)10.0 / (double)NPC.lifeMax * 20.0; num461++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<JadeGemDust>(), hit.HitDirection, -1f);
            }
            return;
        }
        for (int num462 = 0; num462 < 10; num462++)
        {
            Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<JadeGemDust>(), 2 * hit.HitDirection, -2f);
        }
        if (Main.netMode != NetmodeID.Server)
        {
            Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity.RotatedByRandom(MathHelper.Pi / 16), Mod.Find<ModGore>("JadeSquirrelGore").Type);
        }
    }
}
public class GarnetSquirrel : GemSquirrel
{
    public override void SetStaticDefaults()
    {
        Main.npcFrameCount[Type] = 6;
        Main.npcCatchable[Type] = true;
        NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers()
        {
            // Influences how the NPC looks in the Bestiary
            Velocity = 1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
        };
        NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;
        NPCID.Sets.TakesDamageFromHostilesWithoutBeingFriendly[Type] = true;
        NPCID.Sets.TownCritter[Type] = true;
        NPCID.Sets.CountsAsCritter[Type] = true;
        NPCID.Sets.ShimmerTransformToItem[Type] = ModContent.ItemType<Garnet>();
    }
    public override void SetDefaults()
    {
        NPC.CloneDefaults(NPCID.GemSquirrelAmethyst);
        AnimationType = NPCID.GemSquirrelAmethyst;
        AIType = NPCID.GemSquirrelAmethyst;
        NPC.friendly = false;
        NPC.catchItem = ModContent.ItemType<GarnetSquirrelItem>();
    }
    public override void HitEffect(NPC.HitInfo hit)
    {
        Player player = Main.player[NPC.target];
        if (NPC.life > 0)
        {
            for (int num461 = 0; (double)num461 < (double)10.0 / (double)NPC.lifeMax * 20.0; num461++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<GarnetGemDust>(), hit.HitDirection, -1f);
            }
            return;
        }
        for (int num462 = 0; num462 < 10; num462++)
        {
            Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<GarnetGemDust>(), 2 * hit.HitDirection, -2f);
        }
        if (Main.netMode != NetmodeID.Server)
        {
            Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity.RotatedByRandom(MathHelper.Pi / 16), Mod.Find<ModGore>("GarnetSquirrelGore").Type);
        }
    }
}
public class LapisSquirrel : GemSquirrel
{
    public override void SetStaticDefaults()
    {
        Main.npcFrameCount[Type] = 6;
        Main.npcCatchable[Type] = true;
        NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers()
        {
            // Influences how the NPC looks in the Bestiary
            Velocity = 1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
        };
        NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;
        NPCID.Sets.TakesDamageFromHostilesWithoutBeingFriendly[Type] = true;
        NPCID.Sets.TownCritter[Type] = true;
        NPCID.Sets.CountsAsCritter[Type] = true;
        NPCID.Sets.ShimmerTransformToItem[Type] = ModContent.ItemType<Lapis>();
    }
    public override void SetDefaults()
    {
        NPC.CloneDefaults(NPCID.GemSquirrelAmethyst);
        AnimationType = NPCID.GemSquirrelAmethyst;
        AIType = NPCID.GemSquirrelAmethyst;
        NPC.friendly = false;
        NPC.catchItem = ModContent.ItemType<LapisSquirrelItem>();
    }
    public override void HitEffect(NPC.HitInfo hit)
    {
        Player player = Main.player[NPC.target];
        if (NPC.life > 0)
        {
            for (int num461 = 0; (double)num461 < (double)10.0 / (double)NPC.lifeMax * 20.0; num461++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<LapisGemDust>(), hit.HitDirection, -1f);
            }
            return;
        }
        for (int num462 = 0; num462 < 10; num462++)
        {
            Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<LapisGemDust>(), 2 * hit.HitDirection, -2f);
        }
        if (Main.netMode != NetmodeID.Server)
        {
            Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity.RotatedByRandom(MathHelper.Pi / 16), Mod.Find<ModGore>("LapisSquirrelGore").Type);
        }
    }
}
public class FlintSquirrel : GemSquirrel
{
    public override void SetStaticDefaults()
    {
        Main.npcFrameCount[Type] = 6;
        Main.npcCatchable[Type] = true;
        NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers()
        {
            // Influences how the NPC looks in the Bestiary
            Velocity = 1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
        };
        NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;
        NPCID.Sets.TakesDamageFromHostilesWithoutBeingFriendly[Type] = true;
        NPCID.Sets.TownCritter[Type] = true;
        NPCID.Sets.CountsAsCritter[Type] = true;
        NPCID.Sets.ShimmerTransformToItem[Type] = ModContent.ItemType<Flint>();
    }
    public override void SetDefaults()
    {
        NPC.CloneDefaults(NPCID.GemSquirrelAmethyst);
        AnimationType = NPCID.GemSquirrelAmethyst;
        AIType = NPCID.GemSquirrelAmethyst;
        NPC.friendly = false;
        NPC.catchItem = ModContent.ItemType<FlintSquirrelItem>();
    }
    public override void HitEffect(NPC.HitInfo hit)
    {
        Player player = Main.player[NPC.target];
        if (NPC.life > 0)
        {
            for (int num461 = 0; (double)num461 < (double)10.0 / (double)NPC.lifeMax * 20.0; num461++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<FlintDust>(), hit.HitDirection, -1f);
            }
            return;
        }
        for (int num462 = 0; num462 < 10; num462++)
        {
            Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<FlintDust>(), 2 * hit.HitDirection, -2f);
        }
        if (Main.netMode != NetmodeID.Server)
        {
            Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity.RotatedByRandom(MathHelper.Pi / 16), Mod.Find<ModGore>("FlintSquirrelGore").Type);
        }
    }
}