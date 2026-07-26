using Avalon.Common;
using Avalon.ModSupport;
using Avalon.WorldGeneration.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Xenon.Common.Globals;

namespace Xenon.Common.Systems
{
    public class XenonBossCleared : ModSystem
    {
        public bool DownedStomachOfCthulhu;
        public bool DownedEaterOfWorlds;
        public bool DownedBrainOfCthulhu;
        public override void OnWorldLoad()
        {
            ResetDownedFlags();
        }
        public override void OnWorldUnload()
        {
            ResetDownedFlags();
        }
        private void ResetDownedFlags()
        {
            DownedStomachOfCthulhu = false;
            DownedEaterOfWorlds = false;
            DownedBrainOfCthulhu = false;
        }
        public override void SaveWorldData(TagCompound tag)
        {
            tag["DownedStomachOfCthulhu"] = DownedStomachOfCthulhu;
            tag["DownedEaterOfWorlds"] = DownedEaterOfWorlds;
            tag["DownedBrainOfCthulhu"] = DownedBrainOfCthulhu;
            //tag["WorldEvil"] = (int)ModContent.GetInstance<>();
        }
        public override void LoadWorldData(TagCompound tag)
        {
            if (tag.ContainsKey("DownedStomachOfCthulhu"))
            {
                DownedStomachOfCthulhu = tag.Get<bool>("DownedStomachOfCthulhu");
            }
            if (tag.ContainsKey("DownedEaterOfWorlds"))
            {
                DownedEaterOfWorlds = tag.Get<bool>("DownedEaterOfWorlds");
            }
            if (tag.ContainsKey("DownedBrainOfCthulhu"))
            {
                DownedBrainOfCthulhu = tag.Get<bool>("DownedBrainOfCthulhu");
            }
        }

        public override void NetSend(BinaryWriter writer)
        {
            writer.Write(DownedStomachOfCthulhu);
            writer.Write(DownedEaterOfWorlds);
            writer.Write(DownedBrainOfCthulhu);
        }

        public override void NetReceive(BinaryReader reader)
        {
            reader.ReadFlags(out DownedStomachOfCthulhu);
            reader.ReadFlags(out DownedEaterOfWorlds);
            reader.ReadFlags(out DownedBrainOfCthulhu);
        }
    }
}