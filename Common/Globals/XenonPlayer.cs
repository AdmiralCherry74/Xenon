using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Biomes;
using Xenon.Content.Buffs.Debuffs;
using Xenon.Content.Buffs.Debuffs.Counterable;
using Xenon.Content.Buffs.Other;
using Xenon.Content.Items.Consumables;
using Xenon.Content.Items.Fish;
using Xenon.Content.Items.Fish.Quest;
using Xenon.Content.Items.Fish.Valuable;

namespace Xenon.Common.Globals;

public class XenonPlayer : ModPlayer
{
    public bool FossilBlessing;
    public bool FossilBlessingActive;
    public Vector2[] playerOldVelocity = new Vector2[3];
    public bool GroundPoundActivated;
    public bool HotDamageResistShield;
    public bool HotDamageResistPotion;
    public bool KnockbackBoost;

    public override void ResetEffects()
    {
        FossilBlessing = false;
        HotDamageResistShield = false;
        HotDamageResistPotion = false;
        KnockbackBoost = false;
    }
    public override void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar, ref Vector2 sonarPosition)
    {
        int bait = attempt.playerFishingConditions.BaitItemType;
        int power = attempt.playerFishingConditions.BaitPower + attempt.playerFishingConditions.PolePower;
        int questFish = attempt.questFish;
        int poolSize = attempt.waterTilesCount;
        bool water = !attempt.inHoney && !attempt.inLava;
        bool lava = attempt.inLava;

        Point point = Player.Center.ToTileCoordinates();
        bool isCorrosionFishingAttempt = Player.InModBiome<Corrosion>() || Player.InModBiome<CorrosionUnderground>();

        if (isCorrosionFishingAttempt && attempt.uncommon) // not possible via rifts anyways, so doesn't check for it
        {
            if (questFish == ModContent.ItemType<Giardia>())
            {
                itemDrop = ModContent.ItemType<Giardia>();
                return;
            }
        }

        if (attempt.uncommon && isCorrosionFishingAttempt)
        {
            int r = Main.rand.Next(1); // change later, to allow more fish
            if (r == 0)
            {
                itemDrop = ModContent.ItemType<Corrodoras>();
                return;
            }
            else if (r == 1)
            {
            	itemDrop = ModContent.ItemType<CorrosionCrate>();
            	return;
            }
        }
        bool isGraniteFishingAttempt = Player.ZoneGranite;

        if (attempt.uncommon && isGraniteFishingAttempt)
        {
            int r = Main.rand.Next(1); // change later, to allow more fish
            if (r == 0)
            {
                itemDrop = ModContent.ItemType<GraniteFish>();
                return;
            }
        }
        bool isjanuaryfishingattempt = Player.ZoneForest && DateTime.Now.Month == 1;
        if (attempt.uncommon && isjanuaryfishingattempt)
        {
            int r = Main.rand.Next(1); // change later, to allow more fish
            if (r == 0)
            {
                itemDrop = ModContent.ItemType<ExampleFish>(); //change later to be a different fish
                return;
            }
        }
        bool isaprilfishingattempt = Player.ZoneJungle && DateTime.Now.Month == 4 || Player.ZoneJungle && Player.ZoneDirtLayerHeight && DateTime.Now.Month == 4 || Player.ZoneJungle && Player.ZoneRockLayerHeight && DateTime.Now.Month == 4;
        if (attempt.uncommon && isaprilfishingattempt)
        {
            int r = Main.rand.Next(1); // change later, to allow more fish
            if (r == 0)
            {
                itemDrop = ModContent.ItemType<Piranha>();
                return;
            }
        }
        bool ismayfishingattempt = Player.ZoneBeach && DateTime.Now.Month == 5 || Player.ZoneBeach && Player.ZoneDirtLayerHeight && DateTime.Now.Month == 5;
        if (attempt.uncommon && ismayfishingattempt)
        {
            int r = Main.rand.Next(1); // change later, to allow more fish
            if (r == 0)
            {
                itemDrop = ModContent.ItemType<AnglerFish>();
                return;
            }
        }
        bool isnovemberfishingattempt = Player.ZoneForest && !Main.dayTime && DateTime.Now.Month == 11;
        if (attempt.uncommon && isnovemberfishingattempt)
        {
            int r = Main.rand.Next(1); // change later, to allow more fish
            if (r == 0)
            {
                itemDrop = ModContent.ItemType<Foxfish>();
                return;
            }
        }
    }
	public override void ModifyHitNPCWithItem(Item item, NPC target, ref NPC.HitModifiers modifiers)
	{
        // caustic armor setbonus
		if (KnockbackBoost)
        {
            modifiers.Knockback += 1f;
        }
	}
	public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref NPC.HitModifiers modifiers)
	{
        // caustic armor setbonus
		if (KnockbackBoost)
		{
			modifiers.Knockback += 1f;
		}
	}
	public override void PreUpdate()
    {
        playerOldVelocity[2] = playerOldVelocity[1];
        playerOldVelocity[1] = playerOldVelocity[0];
        playerOldVelocity[0] = Player.velocity;

        if (GroundPoundActivated)
        {
            if (!Player.IsOnGroundPrecise())
            {
                Player.velocity.Y = 100f * Player.gravDir;
            }
            if (Player.velocity.Y > 0)
            {
                for (int x = 0; x < 5; x++)
                {
                    int d = Dust.NewDust(new Vector2(Player.Center.X, Player.position.Y + Player.height), 10, 10, DustID.SolarFlare);
                }
            }
            if (Main.rand.NextBool(20))
            {
                int D = Dust.NewDust(Player.position, Player.width, Player.height, DustID.Copper, (Player.velocity.X * 0.2f) + (Player.direction * 3), Player.velocity.Y * 1.2f, 60, new Color(), 1f);
                Main.dust[D].noGravity = true;
                Main.dust[D].velocity.X *= 1.2f;
                Main.dust[D].velocity.X *= 1.2f;
            }
            if (Main.rand.NextBool(20))
            {
                int D2 = Dust.NewDust(Player.position, Player.width, Player.height, DustID.Copper, (Player.velocity.X * 0.2f) + (Player.direction * 3), Player.velocity.Y * 1.2f, 60, new Color(), 1f);
                Main.dust[D2].noGravity = true;
                Main.dust[D2].velocity.X *= -1.2f;
                Main.dust[D2].velocity.X *= 1.2f;
            }
            if (Main.rand.NextBool(20))
            {
                int D3 = Dust.NewDust(Player.position, Player.width, Player.height, DustID.Copper, (Player.velocity.X * 0.2f) + (Player.direction * 3), Player.velocity.Y * 1.2f, 60, new Color(), 1f);
                Main.dust[D3].noGravity = true;
                Main.dust[D3].velocity.X *= 1.2f;
                Main.dust[D3].velocity.X *= -1.2f;
            }
            if (Main.rand.NextBool(20))
            {
                int D4 = Dust.NewDust(Player.position, Player.width, Player.height, DustID.Copper, (Player.velocity.X * 0.2f) + (Player.direction * 3), Player.velocity.Y * 1.2f, 60, new Color(), 1f);
                Main.dust[D4].noGravity = true;
                Main.dust[D4].velocity.X *= -1.2f;
                Main.dust[D4].velocity.X *= -1.2f;
            }
        }
    }
    public override void PostUpdateEquips()
	{
		if (Player.lavaImmune || Player.resistCold)
		{
			Player.buffImmune[ModContent.BuffType<Iceburn>()] = true;
		}

        if (!FossilBlessing)
        {
            FossilBlessingActive = false;
        }
        if (FossilBlessing && !Player.mount.Active && Player.DoublePressedReversedSetBonusActivateKey())
        {
            if (Player.HasBuff<FossilBlessing>())
            {
                Player.ClearBuff(ModContent.BuffType<FossilBlessing>());
            }
            else if (!Player.HasBuff<FossilBlessingCooldown>())
            {
                FossilBlessingActive = true;
                Player.AddBuff(ModContent.BuffType<FossilBlessing>(), 10 * 60);
                Player.AddBuff(ModContent.BuffType<FossilBlessingCooldown>(), 60 * 55);
            }
        }

        if (!FossilBlessing && Player.HasBuff<FossilBlessing>())
        {
            Player.ClearBuff(ModContent.BuffType<FossilBlessing>());
        }
    }
	public override void PostUpdate()
	{
        if (GroundPoundActivated)
        {
            if (!Player.IsOnGroundPrecise())
            {
                Player.velocity.Y = 100f * Player.gravDir;
            }
        }

        QuicksandMovement();

		if (SpecialUtilities.SubmergedInQuicksandTiles(Player.position))
		{
			Player.AddBuff(ModContent.BuffType<QuicksandSuffocation>(), 1);
        }
    }
    public void QuicksandMovement()
    {
        if (Player.shimmering)
            return;

        bool mounted = false;
        if (Player.mount.Type > MountID.Rudolph && MountID.Sets.Cart[Player.mount.Type] && Math.Abs(Player.velocity.X) > 5f)
            mounted = true;

        Vector2 vector = SpecialUtilities.QuicksandTiles(Player.position, Player.velocity, Player.width, Player.height);
        if (vector.Y != -1f && vector.X != -1f)
        {
            int num3 = (int)vector.X;
            int num4 = (int)vector.Y;
            int type = Main.tile[num3, num4].TileType;

            if (mounted)
                return;

            Player.fallStart = (int)(Player.position.Y / 16f);
            if (type != 229)
                Player.jump = 0;

            if (Player.velocity.X > 1f)
                Player.velocity.X = 1f;

            if (Player.velocity.X < -1f)
                Player.velocity.X = -1f;

            if (Player.velocity.X > 0.75f || Player.velocity.X < -0.75f)
                Player.velocity.X *= 0.95f;
            else
                Player.velocity.X *= 0.9f;

            if (Player.gravDir == -1f)
            {
                if (Player.velocity.Y < -1f)
                    Player.velocity.Y = -1f;

                if (Player.velocity.Y > 5f)
                    Player.velocity.Y = 5f;

                if (Player.velocity.Y > 0f)
                    Player.velocity.Y *= 0.99f;
                else
                    Player.velocity.Y *= 0.6f;
            }
            else
            {
                if (Player.velocity.Y > 1f)
                    Player.velocity.Y = 1f;

                if (Player.velocity.Y < -5f)
                    Player.velocity.Y = -5f;

                if (Player.velocity.Y < 0f)
                    Player.velocity.Y *= 0.99f;
                else
                    Player.velocity.Y *= 0.6f;
            }
        }
    }
    public override void ModifyHitByNPC(NPC npc, ref Player.HurtModifiers modifiers)
    {
        if (HotDamageResistPotion) //Fridge Potion
        {
            int dmgPlaceholder = npc.damage;
            if (Common.Data.NPCSets.NPCFireDamage[npc.type])
            {
                modifiers.IncomingDamageMultiplier *= 0.7f;
            }
        }
        if (HotDamageResistShield)  //Bone Serpent Coccyx
        {
            int dmgPlaceholder = npc.damage;
            if (Common.Data.NPCSets.NPCFireDamage[npc.type])
            {
                modifiers.IncomingDamageMultiplier *= 0.8f;
            }
        }
    }
    public override void ModifyHitByProjectile(Projectile proj, ref Player.HurtModifiers modifiers)
    {
        if (HotDamageResistPotion) //Fridge potion
        {
            int dmgPlaceholder = proj.damage;
            if (Common.Data.ProjectileSets.ProjFireDamage[proj.type])
            {
                modifiers.IncomingDamageMultiplier *= 0.7f;
            }
        }
        if (HotDamageResistShield) //Bone Serpent Coccyx
        {
            int dmgPlaceholder = proj.damage;
            if (Common.Data.ProjectileSets.ProjFireDamage[proj.type])
            {
                modifiers.IncomingDamageMultiplier *= 0.8f;
            }
        }
    }
    public override void PostItemCheck()
    {
        base.PostItemCheck();
    }
}