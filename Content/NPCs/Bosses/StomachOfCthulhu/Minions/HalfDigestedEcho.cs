using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Globals.XenonNPCGlobals;
using Xenon.Content.Items.Materials.WorldInfectionMaterials;
using Xenon.Content.Items.Placeable.Banner;
using Xenon.Content.Items.Placeable.Blocks.Natural.OresAndGems.PreHardOres;
using Xenon.Content.Items.Valuables.MonsterRemains;
using Xenon.Content.NPCs.CorrosionMobs;

namespace Xenon.Content.NPCs.Bosses.StomachOfCthulhu.Minions
{
    public class HalfDigestedEcho : HalfDigested
    {
        private int FollowingBoss = XenonGlobalNPC.corrosionBoss;

        public override void SetDefaults()
        {
            base.SetDefaults();

            NPC.damage = 15;
            NPC.lifeMax = 30;
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<IngestaneOre>(), 3, 1, 2));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FreshChyme>(), 3, 1, 2));
        }

        public override void OnKill()
        {
            base.OnKill();

            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                
                return;
            }

            if (XenonGlobalNPC.corrosionBoss != -1 && XenonGlobalNPC.corrosionBoss == FollowingBoss && Main.npc[XenonGlobalNPC.corrosionBoss].active)
            {
                StomachOfCthulhu.Minions -= 1;
            }
        }
    }
}