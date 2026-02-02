using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.NPCs.RhyoliteMobs;

namespace Xenon.Common.Data
{
    public static class NPCSets
    {
        public static readonly bool[] NPCFireDamage = NPCID.Sets.Factory.CreateBoolSet(
        #region Vanilla NPCs
        NPCID.MeteorHead,
        NPCID.FireImp,
        NPCID.LavaSlime,
        NPCID.Hellbat,
        NPCID.Demon,
        NPCID.VoodooDemon,
        NPCID.Lavabat,
        NPCID.RedDevil,
        NPCID.BlazingWheel,
        NPCID.HellArmoredBones,
        NPCID.HellArmoredBonesMace,
        NPCID.HellArmoredBonesSpikeShield,
        NPCID.HellArmoredBonesSword,
        NPCID.SolarCrawltipedeHead,
        NPCID.SolarCrawltipedeBody,
        NPCID.SolarCrawltipedeTail,
        NPCID.SolarDrakomire,
        NPCID.SolarDrakomireRider,
        NPCID.SolarSroller,
        NPCID.SolarCorite,
        NPCID.SolarSolenian,
        NPCID.SolarFlare,
        NPCID.LunarTowerSolar,
        NPCID.SolarGoop,
        NPCID.SolarFlare,
        NPCID.DD2Betsy,
        NPCID.TorchZombie,
        NPCID.ArmedTorchZombie,
        #endregion

        #region Modded NPCs
        ModContent.NPCType<LavaWormHead>(),
        ModContent.NPCType<RhyoliteSlimer>());
        #endregion
    }
}
