using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Xenon.Common;
using Xenon.Content.Items.Materials.WorldInfectionMaterials;
using Xenon.Content.Items.Placeable.Banner;
using Xenon.Content.Items.Valuables.MonsterRemains;

namespace Xenon.Content.NPCs.CorrosionMobs;

public class Gastritis : ModNPC
{
    public override void SetStaticDefaults()
    {
        Main.npcFrameCount[Type] = 2;

        NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers()
        {
            Velocity = 1f
            
        };
        NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
    }

    public override void SetDefaults()
    {
        NPC.width = NPC.height = 34;
        NPC.damage = 22;
        NPC.defense = 8;
        NPC.lifeMax = 40;
        NPC.noGravity = true;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath2;
        NPC.value = 90;
        NPC.knockBackResist = 0.5f;
        NPC.aiStyle = NPCAIStyleID.Flying;

        AIType = NPCID.EaterofSouls;
        AnimationType = NPCID.EaterofSouls;
        Banner = NPC.type;
        BannerItem = ModContent.ItemType<GastritisBanner>();
        SpawnModBiomes = new int[] { ModContent.GetInstance<Biomes.Corrosion.Corrosion>().Type, ModContent.GetInstance<Biomes.Corrosion.CorrosionUnderground>().Type };
    }

    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        bestiaryEntry.Info.AddRange([
            new FlavorTextBestiaryInfoElement(Language.GetTextValue("Mods.Xenon.Bestiary.Gastritis")),
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
    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Bolus>(), 3, 1, 1));
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DilutedBile>(), 150, 1, 1));
        npcLoot.Add(ItemDropRule.Common(ItemID.Burger, 100, 1, 1));
    }
    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        return SpawnHelper.Corrosion(ref spawnInfo) ? 1 : 0;
    }
}
public class LittleGastritis : Gastritis
{
    public override void SetStaticDefaults()
    {
        Main.npcFrameCount[Type] = 2;
        NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, new NPCID.Sets.NPCBestiaryDrawModifiers
        {
            Hide = true
        });
    }
    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[Type] = ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[ModContent.NPCType<Gastritis>()];
    }
    public override string Texture => ModContent.GetInstance<Gastritis>().Texture;
    public override LocalizedText DisplayName => ModContent.GetInstance<Gastritis>().DisplayName;
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
    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        return SpawnHelper.Corrosion(ref spawnInfo) ? 1.25f : 0;
    }
}
public class BigGastritis : LittleGastritis
{
    public override void SetDefaults()
    {
        base.SetDefaults();

        NPC.scale = 1.10f;
        NPC.damage = 25;
        NPC.defense = 9;
        NPC.lifeMax = 46;
        NPC.knockBackResist = 0.42f;
    }
    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        return SpawnHelper.Corrosion(ref spawnInfo) ? 0.75f : 0;
    }
}