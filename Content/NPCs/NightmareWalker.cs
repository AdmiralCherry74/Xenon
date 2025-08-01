using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Xenon.Content.NPCs;

public class NightmareWalker : ModNPC
{
    public override void SetStaticDefaults()
    {
        Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.BloodZombie];

        NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers()
        {
            Velocity = 1f
        };
        NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
    }

    public override void SetDefaults()
    {
        NPC.width = 32;
        NPC.height = 44;
        NPC.damage = 30;
        NPC.defense = 6;
        NPC.lifeMax = 50;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath17;
        NPC.value = 200;
        NPC.knockBackResist = .50f;
        NPC.aiStyle = 3; 
        AIType = NPCID.WalkingAntlion;
        AnimationType = NPCID.BloodZombie;
    }

    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        bestiaryEntry.Info.AddRange([
            BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption,
            new FlavorTextBestiaryInfoElement(Language.GetTextValue("Mods.Xenon.Bestiary.NightmareWalker")),
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
        if (spawnInfo.Player.ZoneCorrupt)
        {
            return SpawnCondition.Corruption.Chance * 0.5f;
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
    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ItemID.VilePowder, 2, 1, 2));
        npcLoot.Add(ItemDropRule.Common(ItemID.WormFood, 1500));
    }
}