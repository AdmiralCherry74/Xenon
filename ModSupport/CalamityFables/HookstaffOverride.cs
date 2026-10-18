using System;
using CalamityFables.Content.Boss.MushroomCrabBoss;
using CalamityFables.Core;
using CalamityFables.Helpers;
using CalamityFables.Particles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Natural.Autumn;

namespace Xenon.ModSupport.CalamityFables;

// Ovrides the Hookstaff use check to work on Mushroom Mulch Grass

[ExtendsFromMod("CalamityFables")]
public class HookstaffOverride : Hookstaff
{
    internal static Asset<Texture2D> RealSprite;
    public override bool IsLoadingEnabled(Mod mod)
    {
        return XenonMod.CalamityFablesContentEnabled;
    }

    public override void Load()
    {
        FablesPlayer.PostUpdateMiscEffectsEvent += CreateUseVisualsAndSoundsAndSlowdowns;
    }
    public override bool CanUseItem(Player player)
    {
        Tile floorTile = Main.tile[(player.Bottom + new Vector2(8f * player.direction, 8f)).ToTileCoordinates()];
        if (
            !floorTile.HasUnactuatedTile || 
            (
                floorTile.TileType != TileID.MushroomGrass &&
                floorTile.TileType != ModContent.TileType<MushroomGrassMulch>()
            ))
        { return false; }

        return true;

    }

    // Taken From Fables, Changes ONE statement. Thus the way of Modding
    private void CreateUseVisualsAndSoundsAndSlowdowns(Player player)
    {
        if (player.itemTime == 0 || player.itemTime == player.itemTimeMax || player.HeldItem == null || player.HeldItem.type != Type)
            return;

        Point floorTilePos = (player.Bottom + new Vector2(8f * player.direction, 12f)).ToTileCoordinates();
        Tile floorTile = Main.tile[floorTilePos];
        if (
            !floorTile.HasUnactuatedTile || 
            (
                floorTile.TileType != TileID.MushroomGrass &&
                floorTile.TileType != ModContent.TileType<MushroomGrassMulch>()
            ))
        { return; }

        float animProgress = 1 - player.itemTime / (float)player.itemTimeMax;
        bool bigTug = animProgress >= 0.75f;
        bool smallTug = animProgress >= 0.55f && animProgress < 0.65f;

        float lastAnimProgress = 1 - (player.itemTime + 1) / (float)player.itemTimeMax;
        bool bigTugStart = bigTug && lastAnimProgress < 0.75f;
        bool smallTugStart = smallTug && lastAnimProgress < 0.55f;

        if (!bigTug)
        {
            player.controlJump = false;
            player.GetModPlayer<FablesPlayer>().MoveSpeedModifier *= 0.1f;
            if (Math.Abs(player.velocity.X) > player.maxRunSpeed)
                player.velocity.X *= 0.9f;
        }

        //Going down into the floor
        if (animProgress < 0.2f)
            WorldGen.KillTile_MakeTileDust(floorTilePos.X, floorTilePos.Y, floorTile);

        //Going up
        else if (bigTug || smallTug)
        {
            int iterations = 1;
            int fiberChance = 2;

            if (smallTug)
                fiberChance = 6;

            if (smallTugStart)
            {
                SoundEngine.PlaySound(SoundID.LiquidsHoneyLava with { Type = SoundType.Sound, Volume = 0.4f, Pitch = -0.2f }, player.Bottom);
                if (Main.myPlayer == player.whoAmI)
                    CameraManager.Quake += 2.5f;
            }

            if (bigTugStart)
            {
                iterations = 8;

                SoundEngine.PlaySound(RipSound, player.Bottom);

                if (Main.myPlayer == player.whoAmI)
                    CameraManager.AddCameraEffect(new SnappyDirectionalCameraTug(-Vector2.UnitY.RotatedBy(player.direction * 0.15f) * 13f, 20, 0.6f, 0.15f,
                        FablesUtils.PolyOutEasing, 2f, FablesUtils.PolyOutEasing, 2.5f));
            }

            for (int i = 0; i < iterations; i++)
            {
                if (Main.rand.NextBool(fiberChance))
                {
                    Particle fiber = new MyceliumStrandParticle(player.Bottom + Vector2.UnitX * player.direction * Main.rand.NextFloat(5f, 19f));
                    ParticleHandler.SpawnParticle(fiber);
                    if (smallTug)
                    {
                        fiber.Velocity *= 0.8f;
                        fiber.Scale *= 0.7f;
                    }
                    else if (bigTugStart)
                    {
                        fiber.Velocity *= 1.3f;
                    }
                }

                if (Main.rand.NextBool(5) && bigTug)
                {
                    Vector2 sporePos = player.Bottom + Vector2.UnitX * 14f * player.direction + Main.rand.NextVector2Circular(8f, 8f);
                    Vector2 sporeVel = (player.Bottom + Vector2.UnitY * 30f).DirectionTo(sporePos) * Main.rand.NextFloat(0.1f, 1.2f);
                    SporeGas particle = new SporeGas(sporePos, sporeVel, player.Center, 200f, Main.rand.NextFloat(0.9f, 2.5f), 0.01f);
                    particle.dustSpawnRate = 0f;
                    particle.counter = 77;
                    ParticleHandler.SpawnParticle(particle);
                }

                if (Main.rand.NextBool(4))
                {
                    Vector2 dustPos = player.Bottom + Vector2.UnitX * Main.rand.NextFloat(6f, 26f) * player.direction;
                    Dust d = Dust.NewDustPerfect(dustPos, DustID.MushroomSpray, -Vector2.UnitY.RotatedByRandom(0.5f).RotatedBy(player.direction * 0.7f) * Main.rand.NextFloat(0.1f, 1.2f));
                    d.scale = Main.rand.NextFloat(0.8f, 1.2f);
                }
            }
        }
    }

    public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
    {
        if (RealSprite == null)
        {
            RealSprite = ModContent.Request<Texture2D>("CalamityFables/Assets/Boss/Crabulon/" + ModContent.GetModItem(ModContent.ItemType<Hookstaff>()).Name);
        }

        Texture2D value = RealSprite.Value;
        spriteBatch.DrawNewInventorySprite(value, new Vector2(14f, 62f), position, drawColor, origin, scale, new Vector2(-1f, -0f));
        return false;
    }

    public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
    {
        if (RealSprite == null)
        {
            RealSprite = ModContent.Request<Texture2D>("CalamityFables/Assets/Boss/Crabulon/" + ModContent.GetModItem(ModContent.ItemType<Hookstaff>()).Name);
        }

        Texture2D value = RealSprite.Value;
        spriteBatch.Draw(value, base.Item.position - Main.screenPosition, null, lightColor, rotation, value.Size() / 2f, scale, SpriteEffects.None, 0f);
        return false;
    }
}
[ExtendsFromMod("CalamityFables")]
public class HookstaffDropOverride : GlobalTile
{
    public override bool IsLoadingEnabled(Mod mod)
    {
        return XenonMod.CalamityFablesContentEnabled;
    }

    public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
    {
        if(type == ModContent.TileType<HookstaffTile>() || type == ModContent.TileType<HookstaffBuriedTile>())
        {
            noItem = true;
            Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2(i, j) * 16, ModContent.ItemType<HookstaffOverride>(), 1);
        }
        
        
    }
}