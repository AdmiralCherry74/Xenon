using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Xenon.Content.Items.Placeable.Furniture.Painting;
using Xenon.Content.Items.Placeable.Tile;
using Xenon.NPCs.Template;
using static Xenon.Content.NPCs.BloodWormHead.BloodWormBody;

namespace Xenon.Content.NPCs;

public class BloodWormHead : WormHead
{
    public override int BodyType => ModContent.NPCType<BloodWormBody>();
    public override int TailType => ModContent.NPCType<BloodWormTail>();
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
        NPC.damage = 36;
        NPC.netAlways = true;
        NPC.noTileCollide = true;
        NPC.lifeMax = 75;
        NPC.defense = 0;
        NPC.noGravity = false;
        NPC.width = 26;
        NPC.aiStyle = -1;
        NPC.behindTiles = true;
        NPC.value = 500f;
        NPC.height = 26;
        NPC.knockBackResist = 0f;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
    }
    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        bestiaryEntry.Info.AddRange(
        [
            new FlavorTextBestiaryInfoElement(Language.GetTextValue("Mods.Xenon.Bestiary.BloodWorm"))
        ]);
    }
    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        if (spawnInfo.Player.ZoneCrimson)

        {
            {
                return SpawnCondition.Crimson.Chance * 0.050f;

            }
        }
        return 0f;
    }
    public override void HitEffect(NPC.HitInfo hit)
    {
        if (NPC.life <= 0 && Main.netMode != NetmodeID.Server)
        {
            for (int l = 0; l < 20; l++)
            {
                int dust = Dust.NewDust(NPC.position, NPC.width, NPC.height, 54, 0f, 0f, 50, default, 1.5f);
                Main.dust[dust].velocity *= 2f;
                Main.dust[dust].noGravity = true;
            }
            int gore = Gore.NewGore(NPC.GetSource_FromThis(), new Vector2(NPC.position.X, NPC.position.Y - 10f), NPC.velocity, 99, NPC.scale);
            Main.gore[gore].velocity *= 0.3f;
            gore = Gore.NewGore(NPC.GetSource_FromThis(), new Vector2(NPC.position.X, NPC.position.Y + (NPC.height / 2) - 15f), NPC.velocity, 99, NPC.scale);
            Main.gore[gore].velocity *= 0.3f;
            gore = Gore.NewGore(NPC.GetSource_FromThis(), new Vector2(NPC.position.X, NPC.position.Y + NPC.height - 20f), NPC.velocity, 99, NPC.scale);
            Main.gore[gore].velocity *= 0.3f;
        }
    }
    public override void Init()
    {
        MinSegmentLength = 6;
        MaxSegmentLength = 10;

        CommonWormInit(this);
    }
    internal static void CommonWormInit(Worm worm)
    {
        // These two properties handle the movement of the worm
        worm.MoveSpeed = 10f;
        worm.Acceleration = 2f;
    }
    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ItemID.Vertebrae, 3, 1, 2));
    }
    public class BloodWormBody : WormBody
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
            NPC.damage = 20;
            NPC.netAlways = true;
            NPC.noTileCollide = true;
            NPC.lifeMax = 75;
            NPC.defense = 2;
            NPC.noGravity = false;
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
        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0 && Main.netMode != NetmodeID.Server)
            {
                for (int l = 0; l < 20; l++)
                {
                    int dust = Dust.NewDust(NPC.position, NPC.width, NPC.height, 54, 0f, 0f, 50, default, 1.5f);
                    Main.dust[dust].velocity *= 2f;
                    Main.dust[dust].noGravity = true;
                }
                int gore = Gore.NewGore(NPC.GetSource_FromThis(), new Vector2(NPC.position.X, NPC.position.Y - 10f), NPC.velocity, 99, NPC.scale);
                Main.gore[gore].velocity *= 0.3f;
                gore = Gore.NewGore(NPC.GetSource_FromThis(), new Vector2(NPC.position.X, NPC.position.Y + (NPC.height / 2) - 15f), NPC.velocity, 99, NPC.scale);
                Main.gore[gore].velocity *= 0.3f;
                gore = Gore.NewGore(NPC.GetSource_FromThis(), new Vector2(NPC.position.X, NPC.position.Y + NPC.height - 20f), NPC.velocity, 99, NPC.scale);
                Main.gore[gore].velocity *= 0.3f;
            }
        }
        public class BloodWormTail : WormTail
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
                NPC.damage = 17;
                NPC.netAlways = true;
                NPC.noTileCollide = true;
                NPC.lifeMax = 75;
                NPC.defense = 6;
                NPC.noGravity = false;
                NPC.width = 26;
                NPC.aiStyle = -1;
                NPC.behindTiles = true;
                NPC.value = 500f;
                NPC.height = 26;
                NPC.knockBackResist = 0f;
                NPC.HitSound = SoundID.NPCHit1;
                NPC.DeathSound = SoundID.NPCDeath1;
            }
            public override void HitEffect(NPC.HitInfo hit)
            {
                if (NPC.life <= 0 && Main.netMode != NetmodeID.Server)
                {
                    for (int l = 0; l < 20; l++)
                    {
                        int dust = Dust.NewDust(NPC.position, NPC.width, NPC.height, 54, 0f, 0f, 50, default, 1.5f);
                        Main.dust[dust].velocity *= 2f;
                        Main.dust[dust].noGravity = true;
                    }
                    int gore = Gore.NewGore(NPC.GetSource_FromThis(), new Vector2(NPC.position.X, NPC.position.Y - 10f), NPC.velocity, 99, NPC.scale);
                    Main.gore[gore].velocity *= 0.3f;
                    gore = Gore.NewGore(NPC.GetSource_FromThis(), new Vector2(NPC.position.X, NPC.position.Y + (NPC.height / 2) - 15f), NPC.velocity, 99, NPC.scale);
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
                LavaWormHead.CommonWormInit(this);
            }
        }
    }
}