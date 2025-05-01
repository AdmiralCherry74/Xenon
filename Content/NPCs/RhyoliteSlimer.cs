using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Bestiary;
using Xenon.Content.Items.Placeable.Furniture.Painting;
using Xenon.Content.Items.Placeable.Tile;

namespace Xenon.Content.NPCs;

public class RhyoliteSlimer : ModNPC
{
    public override void SetStaticDefaults()
    {
        Main.npcFrameCount[NPC.type] = 4;
		NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;
		NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Poisoned] = true;
	}

    public override void SetDefaults()
    {
        NPC.damage = 22;
        NPC.lifeMax = 105;
        NPC.defense = 15;
        NPC.width = 40;
        NPC.aiStyle = NPCAIStyleID.Bat;
        NPC.scale = 1.2f;
        NPC.value = 100f;
        NPC.height = 30;
        AnimationType = NPCID.Slimer;
        NPC.knockBackResist = 0.05f;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        Banner = NPC.type;
        BannerItem = ModContent.ItemType<Items.Placeable.Banner.RhyoliteSlimerBanner>();
        SpawnModBiomes = [ModContent.GetInstance<Biomes.Rhyolite>().Type];
    }
	public override void HitEffect(NPC.HitInfo hit)
	{
		if (NPC.life <= 0 && Main.netMode != NetmodeID.Server)
		{
			Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity * 0.8f, Mod.Find<ModGore>("RhyoliteSlimerWing").Type, 1f);
			Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity * 0.8f, Mod.Find<ModGore>("RhyoliteSlimerWing").Type, 1f);
		}
	}
    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        bestiaryEntry.Info.AddRange(
		[
			new FlavorTextBestiaryInfoElement("Mods.Xenon.Bestiary.RhyoliteSlimer")
        ]);
    }
    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        if (spawnInfo.Player.InModBiome<Biomes.Rhyolite>() && !spawnInfo.Player.InPillarZone())
        {
            return 0.8f;
        }
        return 0f;
    }
    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RhyoliteBlock>(), 1, 5, 10));
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GooberPainting>(), 1000, 1, 1));
    }
}
