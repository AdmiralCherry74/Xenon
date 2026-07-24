using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Xenon.Content.Biomes;
using Xenon.Content.Items.Materials.WorldInfectionMaterials;
using Xenon.Content.Items.Placeable.Banner;
using Xenon.Content.Items.Placeable.Blocks.Natural.OresAndGems;

namespace Xenon.Content.NPCs.Bosses.StomachOfCthulhu;

public class GastritisEcho : ModNPC
{
    public override void SetStaticDefaults()
    {
        Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.EaterofSouls];
    }

    public override void SetDefaults()
    {
        NPC.width = 34;
        NPC.height = 72;
        NPC.scale = 0.80f;
        NPC.damage = 17;
        NPC.defense = 6;
        NPC.lifeMax = 30;
        NPC.noGravity = true;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCHit36;
        NPC.knockBackResist = 0.45f;
        NPC.aiStyle = NPCAIStyleID.Flying; 
        
        AIType = NPCID.EaterofSouls;
        AnimationType = NPCID.EaterofSouls;
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
    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<IngestaneOre>(), 2, 2, 4));
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FreshChyme>(), 2, 2, 4));
    }
}