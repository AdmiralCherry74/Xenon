using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Xenon.Content.Biomes.Corrosion;
using Xenon.Content.Items.Materials.WorldInfectionMaterials;
using Xenon.Content.Items.Placeable.Banner;
using Xenon.Content.NPCs.Template;
using static Xenon.Content.NPCs.CorrosionMobs.TapeWormHead.TapeWormBody;

namespace Xenon.Content.NPCs.CorrosionMobs;

public class TapeWormHead : WormHead
{
    public override int BodyType => ModContent.NPCType<TapeWormBody>();
    public override int TailType => ModContent.NPCType<TapeWormTail>();
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
        NPC.damage = 26;
        NPC.netAlways = true;
        NPC.noTileCollide = true;
        NPC.lifeMax = 150;
        NPC.defense = 6;
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
        BannerItem = ModContent.ItemType<TapeWormBanner>();
        SpawnModBiomes = new int[] { ModContent.GetInstance<Biomes.Corrosion.Corrosion>().Type, ModContent.GetInstance<Biomes.Corrosion.CorrosionUnderground>().Type };
    }
    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        bestiaryEntry.Info.AddRange(
        [
            new FlavorTextBestiaryInfoElement(Language.GetTextValue("Mods.Xenon.Bestiary.TapeWorm"))
        ]);
    }
    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        if (spawnInfo.Player.InModBiome<Corrosion>() && NPC.downedBoss2 || spawnInfo.Player.InModBiome<CorrosionUnderground>() && NPC.downedBoss2 || spawnInfo.Player.InModBiome<CorrosionDesert>() && NPC.downedBoss2)
            {
            return 0.50f;
        }
        return 0;
    }
    public override void HitEffect(NPC.HitInfo hit)
    {
        if (NPC.life <= 0 && Main.netMode != NetmodeID.Server)
        {
            for (int l = 0; l < 20; l++)
            {
                int dust = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Wraith, 0f, 0f, 50, default, 1.5f);
                Main.dust[dust].velocity *= 2f;
                Main.dust[dust].noGravity = true;
            }
            int gore = Gore.NewGore(NPC.GetSource_FromThis(), new Vector2(NPC.position.X, NPC.position.Y - 10f), NPC.velocity, 99, NPC.scale);
            Main.gore[gore].velocity *= 0.3f;
            gore = Gore.NewGore(NPC.GetSource_FromThis(), new Vector2(NPC.position.X, NPC.position.Y + NPC.height / 2 - 15f), NPC.velocity, 99, NPC.scale);
            Main.gore[gore].velocity *= 0.3f;
            gore = Gore.NewGore(NPC.GetSource_FromThis(), new Vector2(NPC.position.X, NPC.position.Y + NPC.height - 20f), NPC.velocity, 99, NPC.scale);
            Main.gore[gore].velocity *= 0.3f;
        }
    }
    public override void Init()
    {
        MinSegmentLength = 12;
        MaxSegmentLength = 15;

        CommonWormInit(this);
    }
    internal static void CommonWormInit(Worm worm)
    {
        // These two properties handle the movement of the worm
        worm.MoveSpeed = 6f;
        worm.Acceleration = 0.05f;
    }
    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Bolus>(), 3, 1, 2));
        npcLoot.Add(ItemDropRule.Common(ItemID.WormTooth, 1, 3, 8));
    }
    public class TapeWormBody : WormBody
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
            NPC.damage = 11;
            NPC.netAlways = true;
            NPC.noTileCollide = true;
            NPC.lifeMax = 150;
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
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.InModBiome<Corrosion>() && NPC.downedBoss2 || spawnInfo.Player.InModBiome<CorrosionUnderground>() && NPC.downedBoss2 || spawnInfo.Player.InModBiome<CorrosionDesert>() && NPC.downedBoss2)
            {
                return 0.50f;
            }
            return 0;
        }
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return false;
        }
        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0 && Main.netMode != NetmodeID.Server)
            {
                for (int l = 0; l < 20; l++)
                {
                    int dust = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Wraith, 0f, 0f, 50, default, 1.5f);
                    Main.dust[dust].velocity *= 2f;
                    Main.dust[dust].noGravity = true;
                }
                int gore = Gore.NewGore(NPC.GetSource_FromThis(), new Vector2(NPC.position.X, NPC.position.Y - 10f), NPC.velocity, 99, NPC.scale);
                Main.gore[gore].velocity *= 0.3f;
                gore = Gore.NewGore(NPC.GetSource_FromThis(), new Vector2(NPC.position.X, NPC.position.Y + NPC.height / 2 - 15f), NPC.velocity, 99, NPC.scale);
                Main.gore[gore].velocity *= 0.3f;
                gore = Gore.NewGore(NPC.GetSource_FromThis(), new Vector2(NPC.position.X, NPC.position.Y + NPC.height - 20f), NPC.velocity, 99, NPC.scale);
                Main.gore[gore].velocity *= 0.3f;
            }
        }
        public class TapeWormTail : WormTail
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
                NPC.damage = 6;
                NPC.netAlways = true;
                NPC.noTileCollide = true;
                NPC.lifeMax = 150;
                NPC.defense = 14;
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
            public override float SpawnChance(NPCSpawnInfo spawnInfo)
            {
                if (spawnInfo.Player.InModBiome<Corrosion>() && NPC.downedBoss2 || spawnInfo.Player.InModBiome<CorrosionUnderground>() && NPC.downedBoss2 || spawnInfo.Player.InModBiome<CorrosionDesert>() && NPC.downedBoss2)
                {
                    return 0.50f;
                }
                return 0;
            }
            public override void HitEffect(NPC.HitInfo hit)
            {
                if (NPC.life <= 0 && Main.netMode != NetmodeID.Server)
                {
                    for (int l = 0; l < 20; l++)
                    {
                        int dust = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Wraith, 0f, 0f, 50, default, 1.5f);
                        Main.dust[dust].velocity *= 2f;
                        Main.dust[dust].noGravity = true;
                    }
                    int gore = Gore.NewGore(NPC.GetSource_FromThis(), new Vector2(NPC.position.X, NPC.position.Y - 10f), NPC.velocity, 99, NPC.scale);
                    Main.gore[gore].velocity *= 0.3f;
                    gore = Gore.NewGore(NPC.GetSource_FromThis(), new Vector2(NPC.position.X, NPC.position.Y + NPC.height / 2 - 15f), NPC.velocity, 99, NPC.scale);
                    Main.gore[gore].velocity *= 0.3f;
                    gore = Gore.NewGore(NPC.GetSource_FromThis(), new Vector2(NPC.position.X, NPC.position.Y + NPC.height - 20f), NPC.velocity, 99, NPC.scale);
                    Main.gore[gore].velocity *= 0.3f;
                }
            }
            public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
            {
                return false;
            }
            public override void Init()
            {
                CommonWormInit(this);
            }
        }
    }
}