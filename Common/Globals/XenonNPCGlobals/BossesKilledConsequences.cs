using AltLibrary.Common.AltBiomes;
using AltLibrary.Common.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Globals.XenonWorldGlobals;
using Xenon.Common.Systems;

namespace Xenon.Common.Globals.XenonNPCGlobals
{
    public class BossesKilledConsequences : GlobalNPC
    {
        public override void OnKill(NPC npc)
        {
            if (!Main.hardMode && ModContent.GetInstance<XenonConfig>().BasicProgressionChanges && npc.type == NPCID.WallofFlesh)
            {
                ModContent.GetInstance<HallowedOreGenerationCode>().BlessWorldWithHallowedOre();
            }

            //Downed Systems for Braina and Worm
            if (!NPC.downedBoss2 && npc.type == NPCID.EaterofWorldsHead)
            {
                NPC.SetEventFlagCleared(ref ModContent.GetInstance<XenonBossCleared>().DownedEaterOfWorlds, -1);
            }
            if (!NPC.downedBoss2 && npc.type == NPCID.BrainofCthulhu)
            {
                NPC.SetEventFlagCleared(ref ModContent.GetInstance<XenonBossCleared>().DownedBrainOfCthulhu, -1);
            }
        }
    }
}
