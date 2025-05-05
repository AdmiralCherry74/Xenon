using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Bestiary;
using Terraria.Localization;
using Xenon.NPCs.Template;
using Xenon.Content.Items.Placeable.Banner;
using Xenon.Content.Items.Placeable.Tile;
using Xenon.Content.Items.Placeable.Furniture.Painting;
using Xenon.Content.Items.Accessories;

namespace Xenon.Content.NPCs;

public class LavaWormHead : WormHead
{
    public override int BodyType => ModContent.NPCType<LavaWormBody>();
    public override int TailType => ModContent.NPCType<LavaWormTail>();
    public override bool CanFly => true;

	public override void SetStaticDefaults()
    {
        var drawModifier = new NPCID.Sets.NPCBestiaryDrawModifiers()
        {
            CustomTexturePath = Texture + "_Bestiary",
			Position = new Vector2(55f, 18f),
			PortraitPositionXOverride = 10f,
			PortraitPositionYOverride = 11f
		};
        NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, drawModifier);
		NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;
    }
    public override void SetDefaults()
	{
		NPC.damage = 20;
        NPC.netAlways = true;
        NPC.noTileCollide = true;
        NPC.lifeMax = 200;
        NPC.defense = 10;
        NPC.noGravity = true;
        NPC.width = 26;
        NPC.aiStyle = -1;
        NPC.behindTiles = true;
        NPC.value = 500f;
        NPC.height = 26;
        NPC.knockBackResist = 0f;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        Banner = NPC.type;
        BannerItem = ModContent.ItemType<LavaWormBanner>();
        SpawnModBiomes = new int[] { ModContent.GetInstance<Biomes.Rhyolite>().Type };
    }
    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        bestiaryEntry.Info.AddRange(
		[
			new FlavorTextBestiaryInfoElement(Language.GetTextValue("Mods.Xenon.Bestiary.LavaWorm"))
        ]);
    }
    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        if (spawnInfo.Player.InModBiome<Biomes.Rhyolite>() && !spawnInfo.Player.InPillarZone())
            return 0.1f;
        return 0;
    }
	public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
	{
		if (Main.rand.NextBool(3))
			target.AddBuff(BuffID.OnFire3, 60 * 4);
	}
	public override void HitEffect(NPC.HitInfo hit)
    {
        if (NPC.life <= 0 && Main.netMode != NetmodeID.Server)
        {
            Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, Mod.Find<ModGore>("LavaWormHeadGore").Type, 1f);
            for (int i = 0; i < 10; i++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.CorruptGibs, Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-2, 2), 128, default, Main.rand.NextFloat(1, 1.5f));
            }
        }
        for (int i = 0; i < 5; i++)
        {
            Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.CorruptGibs, Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-2, 2), 128, default, Main.rand.NextFloat(1, 1.5f));
        }
    }
    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RhyoliteBlock>(), 1, 5, 11));
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FossilizedBlessing>(), 35));
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EruptionInABottle>(), 35));
    }
    public override void Init()
    {
        MinSegmentLength = 10;
        MaxSegmentLength = 18;

        CommonWormInit(this);
    }
    internal static void CommonWormInit(Worm worm)
    {
        // These two properties handle the movement of the worm
        worm.MoveSpeed = 9.5f;
        worm.Acceleration = 0.075f;
    }
    public class LavaWormBody : WormBody
	{
		public override void SetStaticDefaults()
		{
			var drawModifier = new NPCID.Sets.NPCBestiaryDrawModifiers()
			{
				Hide = true
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, drawModifier);
		}
		public override void Init()
        {
            CommonWormInit(this);
        }
        public override void SetDefaults()
        {
            NPC.damage = 13;
            NPC.netAlways = true;
            NPC.noTileCollide = true;
            NPC.lifeMax = 200;
            NPC.defense = 9;
            NPC.noGravity = true;
            NPC.width = 26;
            NPC.aiStyle = -1;
            NPC.behindTiles = true;
            NPC.value = 500f;
            NPC.height = 26;
            NPC.knockBackResist = 0f;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
        }
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
			return false;
        }
		public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
		{
            if (Main.rand.NextBool(3))
                target.AddBuff(BuffID.OnFire3, 60 * 4);
		}
		public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0 && Main.netMode != NetmodeID.Server)
            {
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, Mod.Find<ModGore>("LavaWormBodyGore").Type, 1f);
                for(int i = 0; i < 10; i++) 
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.CorruptGibs, Main.rand.NextFloat(-2, 2),Main.rand.NextFloat(-2, 2),128,default,Main.rand.NextFloat(1,1.5f));
                }
            }
            for (int i = 0; i < 5; i++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.CorruptGibs, Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-2, 2), 128, default, Main.rand.NextFloat(1, 1.5f));
            }
        }
    }
}
public class LavaWormTail : WormTail
{
	public override void SetStaticDefaults()
	{
		var drawModifier = new NPCID.Sets.NPCBestiaryDrawModifiers()
		{
			Hide = true
		};
		NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, drawModifier);
	}
	public override void SetDefaults()
    {
        NPC.damage = 9;
        NPC.netAlways = true;
        NPC.noTileCollide = true;
        NPC.lifeMax = 200;
        NPC.defense = 8;
        NPC.noGravity = true;
        NPC.width = 26;
        NPC.aiStyle = -1;
        NPC.behindTiles = true;
        NPC.value = 500f;
        NPC.height = 26;
        NPC.knockBackResist = 0f;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
    }
	public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
	{
		if (Main.rand.NextBool(3))
			target.AddBuff(BuffID.OnFire3, 60 * 4);
	}
	public override void HitEffect(NPC.HitInfo hit)
    {
        if (NPC.life <= 0 && Main.netMode != NetmodeID.Server)
        {
            Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, Mod.Find<ModGore>("LavaWormTailGore").Type, 1f);
            for (int i = 0; i < 10; i++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.CorruptGibs, Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-2, 2), 128, default, Main.rand.NextFloat(1, 1.5f));
            }
        }
        for (int i = 0; i < 5; i++)
        {
            Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.CorruptGibs, Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-2, 2), 128, default, Main.rand.NextFloat(1, 1.5f));
        }
    }
    public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
    {
        return false;
    }
    public override void Init()
    {
		LavaWormHead.CommonWormInit(this);
    }
    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GooberPainting>(), 1000, 1, 1));
    }
}