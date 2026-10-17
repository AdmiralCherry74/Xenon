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
using Xenon.Content.Items.Valuables.MonsterRemains;

namespace Xenon.Content.NPCs.CorrosionMobs;

public class BigGastritis : Gastritis
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

        NPC.scale = 1.10f;
        NPC.damage = 25;
        NPC.defense = 9;
        NPC.lifeMax = 46;
        NPC.knockBackResist = 0.42f;

    }

    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[Type] = ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[ModContent.NPCType<Gastritis>()];
    }
}