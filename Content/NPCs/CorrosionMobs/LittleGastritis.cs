using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;

namespace Xenon.Content.NPCs.CorrosionMobs;

public class LittleGastritis : Gastritis
{
    public override void SetStaticDefaults()
    {
        NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, new NPCID.Sets.NPCBestiaryDrawModifiers
        {
            Hide = true
        });
    }
    
    public override void SetDefaults()
    {
        base.SetDefaults();
        
        NPC.scale = 0.90f;
        NPC.damage = 18;
        NPC.defense = 6;
        NPC.lifeMax = 34;
        NPC.value = 76;
        NPC.knockBackResist = 0.57f;
    }

    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[Type] = ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[ModContent.NPCType<Gastritis>()];
    }

}