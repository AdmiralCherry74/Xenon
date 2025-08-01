using Microsoft.Xna.Framework;
using System.Linq.Expressions;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Xenon.Content.Items.Placeable.Furniture.Painting;

namespace Xenon.Content.NPCs
{
    public class TempleSentry : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.DungeonGuardian];

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers()
            {
                Velocity = 1f
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.width = 110;
            NPC.height = 106;
            NPC.damage = 10000;
            NPC.defense = 99999;
            NPC.lifeMax = 19998;
            NPC.dontTakeDamage = !Main.hardMode;
            NPC.HitSound = SoundID.NPCHit4;
            NPC.DeathSound = SoundID.NPCDeath14;
            NPC.value = 0;
            NPC.knockBackResist = 0f;
            NPC.aiStyle = 11;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPCID.Sets.CanHitPastShimmer[Type] = true;
            NPCID.Sets.ImmuneToAllBuffs[Type] = true;
            NPCID.Sets.ReflectStarShotsInForTheWorthy[Type] = true;
            NPCID.Sets.TeleportationImmune[Type] = true;
            NPCID.Sets.ShouldBeCountedAsBoss[Type] = true;


            AIType = NPCID.DungeonGuardian;
            AnimationType = NPCID.DungeonGuardian;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {

            bestiaryEntry.Info.AddRange([
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement(Language.GetTextValue("Mods.Xenon.Bestiary.TempleSentry")),
            ]);
        }

        public override void AI()
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                return;
            }
        }
        public override void OnKill()
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                return;
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.ZoneLihzhardTemple && !NPC.downedPlantBoss)
                return SpawnCondition.JungleTemple.Chance * 10f;
            return 0f;
        }

         public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GooberPainting>(), 1, 1, 1));
        }
    }
}