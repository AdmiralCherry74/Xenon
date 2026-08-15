using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Xenon.Content.Tiles.Natural.Ores.HardOres;

namespace Xenon.Common.Globals.XenonWorldGlobals
{
    public class HallowedOreGenerationCode : ModSystem
    {
        //Thank you terradux for help!
        public static LocalizedText BlessedWithHallowedOreMessage { get; private set; }

        public override void SetStaticDefaults()
        {
            BlessedWithHallowedOreMessage = Mod.GetLocalization("World.BlessedWithHallowedOreMessage");
        }

        // This method is called from MinionBossBody.OnKill the first time the boss is killed.
        // The logic is located here for organizational purposes.
        public void BlessWorldWithHallowedOre()
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                return; // This should not happen, but just in case.
            }

            ThreadPool.QueueUserWorkItem(_ => {
                // Broadcast a message to notify the user.
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.NewText(BlessedWithHallowedOreMessage.Value, 50, 255, 130);
                }
                else if (Main.netMode == NetmodeID.Server)
                {
                    ChatHelper.BroadcastChatMessage(BlessedWithHallowedOreMessage.ToNetworkText(), Color.LightCyan);
                }

                // 100 controls how many splotches of ore are spawned into the world, scaled by world size. For comparison, the first 3 times altars are smashed about 275, 190, or 120 splotches of the respective hardmode ores are spawned.
                int splotches = (int)(95 * (Main.maxTilesX / 4200f));
                int highestY = (int)Utils.Lerp(Main.rockLayer, Main.UnderworldLayer, 0.5);
                for (int iteration = 0; iteration < splotches; iteration++)
                {
                    // Find a point in the lower half of the rock layer but above the underworld depth.
                    int i = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
                    int j = WorldGen.genRand.Next(highestY, Main.UnderworldLayer);

                    // OreRunner will spawn MystiliumOre in splotches. OnKill only runs on the server or single player, so it is safe to run world generation code.
                    WorldGen.OreRunner(i, j, WorldGen.genRand.Next(6, 12), WorldGen.genRand.Next(6, 12), (ushort)ModContent.TileType<HallowedOreXenon>());
                }
            });
        }
    }
}
