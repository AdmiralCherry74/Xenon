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

public class LittleGastritis : Gastritis
{
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
}