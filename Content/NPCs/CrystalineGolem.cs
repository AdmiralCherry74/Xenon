using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Xenon.Content.Buffs.Debuffs.Counterable;

namespace Xenon.Content.NPCs
{
    public class CrystalineGolem : ModNPC
    {
        //This is based off the Adventure Time Enemy.
        //its meant to mimic the players actions and movements but thats beyond my (Selene) coding skills so itll act like other Fighter AI enemies unitl its time to code it.
        //I would like it to also be able to wear the different insane mode armors depending on what the player has equipped at the time (however that might be impossible so any old armor is fine. i just have the Chaos Elemental)
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.ChaosElemental];

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers()
            {
                Velocity = 1f
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.width = 28;
            NPC.height = 42;
            NPC.damage = 0;
            NPC.defense = 999999999;
            NPC.SuperArmor = true;
            NPC.reflectsProjectiles = true;
            NPC.lifeMax = 100;
            NPC.HitSound = new SoundStyle($"Xenon/Assets/SFX/CrystalineGolemHit") { Pitch = 0f, Volume = 0.4f, PitchVariance = 0f, MaxInstances = 5 };
            NPC.DeathSound = SoundID.NPCDeath33;
            NPC.value = 200;
            NPC.knockBackResist = 0f;
            NPC.aiStyle = NPCAIStyleID.Fighter;

            AIType = NPCID.PossessedArmor;
            AnimationType = NPCID.ChaosElemental;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {

            bestiaryEntry.Info.AddRange([
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns,
                new FlavorTextBestiaryInfoElement(Language.GetTextValue("Mods.Xenon.Bestiary.CrystalineGolem")),
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
        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0 && Main.netMode != NetmodeID.Server)
            {
                for (int l = 0; l < 20; l++)
                {
                    int dust = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.BlueCrystalShard, 0f, 0f, 50, default, 1.5f);
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
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.CrystalShard, 1, 7, 10));
        }
    }
}