using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Xenon.Content.NPCs.TownNPCs;

namespace Xenon.Common.Systems
{
    public class TownNPCRespawnSystem : ModSystem
    {
        // Tracks if Baker has ever been spawned in a world
        public static bool unlockedBakerSpawn = false;

        public override void ClearWorld()
        {
            unlockedBakerSpawn = false;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            tag[nameof(unlockedBakerSpawn)] = unlockedBakerSpawn;
        }
        public override void LoadWorldData(TagCompound tag)
        {
            unlockedBakerSpawn = tag.GetBool(nameof(unlockedBakerSpawn));

            // This line sets unlockedExamplePersonSpawn to true if an ExamplePerson is already in the world. This is only needed because unlockedExamplePersonSpawn was added in an update to this mod, meaning that existing users might have unlockedExamplePersonSpawn incorrectly set to false.
            // If you are tracking Town NPC unlocks from your initial mod release, then this isn't necessary.
            unlockedBakerSpawn |= NPC.AnyNPCs(ModContent.NPCType<Baker>());
        }

        public override void NetSend(BinaryWriter writer)
        {
            writer.WriteFlags(unlockedBakerSpawn);
        }

        public override void NetReceive(BinaryReader reader)
        {
            reader.ReadFlags(out unlockedBakerSpawn);
        }
    }
}