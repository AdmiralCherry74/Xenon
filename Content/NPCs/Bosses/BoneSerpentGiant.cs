using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Xenon.Content.NPCs.Template;
using static Xenon.Content.NPCs.Bosses.BoneSerpentGiantHead.BoneSerpentGiantBody;

namespace Xenon.Content.NPCs.Bosses;

public class BoneSerpentGiantHead : WormHead
{
    public override int BodyType => ModContent.NPCType<BoneSerpentGiantBody>();
    public override int TailType => ModContent.NPCType<BoneSerpentGiantTail>();
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
        NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.OnFire] = true;
        NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.OnFire3] = true;
        NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.CursedInferno] = true;
        NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Ichor] = true;
    }
    public override void SetDefaults()
    {
        NPC.damage = 175;
        NPC.netAlways = true;
        NPC.noTileCollide = true;
        NPC.lifeMax = 200000;
        NPC.defense = 10;
        NPC.noGravity = true;
        NPC.width = 42;
        NPC.height = 70;
        NPC.scale = 2;
        NPC.aiStyle = -1;
        NPC.behindTiles = true;
        NPC.value = 500f;
        NPC.knockBackResist = 0f;
        NPC.boss = true;
        NPC.HitSound = SoundID.NPCHit2;
        NPC.DeathSound = SoundID.NPCDeath5;
    }
    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        bestiaryEntry.Info.AddRange(
        [
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld,
            new FlavorTextBestiaryInfoElement(Language.GetTextValue("Mods.Xenon.Bestiary.BoneSerpentGiant"))
        ]);
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
        MinSegmentLength = 100;
        MaxSegmentLength = 100;

        CommonWormInit(this);
    }
    internal static void CommonWormInit(Worm worm)
    {
        // These two properties handle the movement of the worm
        worm.MoveSpeed = 8f;
        worm.Acceleration = 0.10f;
    }
    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ItemID.Vertebrae, 3, 1, 2));
        npcLoot.Add(ItemDropRule.Common(ItemID.WormTooth, 1, 3, 8));
    }
    public class BoneSerpentGiantBody : WormBody
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
            NPC.damage = 140;
            NPC.netAlways = true;
            NPC.noTileCollide = true;
            NPC.lifeMax = 200000;
            NPC.defense = 50;
            NPC.noGravity = true;
            NPC.width = 42;
            NPC.height = 24;
            NPC.scale = 2;
            NPC.aiStyle = -1;
            NPC.behindTiles = true;
            NPC.value = 500f;
            NPC.knockBackResist = 0f;
            NPC.boss = true;
            NPC.HitSound = SoundID.NPCHit2;
            NPC.DeathSound = SoundID.NPCDeath5;
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
        public class BoneSerpentGiantTail : WormTail
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
                NPC.damage = 100;
                NPC.netAlways = true;
                NPC.noTileCollide = true;
                NPC.lifeMax = 200000;
                NPC.defense = 60;
                NPC.noGravity = true;
                NPC.width = 22;
                NPC.height = 24;
                NPC.scale = 2;
                NPC.aiStyle = -1;
                NPC.behindTiles = true;
                NPC.value = 500f;
                NPC.knockBackResist = 0f;
                NPC.boss = true;
                NPC.HitSound = SoundID.NPCHit2;
                NPC.DeathSound = SoundID.NPCDeath5;
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