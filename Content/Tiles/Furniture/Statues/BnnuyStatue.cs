using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Xenon.Content.NPCs.Other;

namespace Xenon.Content.Tiles.Furniture.Statues
{
    public class BnnuyStatue : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileObsidianKill[Type] = true;
            Main.tileSpelunker[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileID.Sets.IsAMechanism[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.newTile.StyleMultiplier = 2;
            TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
            TileObjectData.addAlternate(1);
            TileObjectData.addTile(Type);

            DustType = DustID.Stone;

            AddMapEntry(new Color(123, 123, 123), this.GetLocalization("MapEntry"));
        }

        // This hook allows you to make anything happen when this statue is powered by wiring.
        public override void HitWire(int i, int j)
        {
            // Find the coordinates of top left tile square
            (int x, int y) = TileObjectData.TopLeft(i, j);

            const int TileWidth = 2;
            const int TileHeight = 3;

            // Here we call SkipWire on all tile coordinates covered by this tile. This ensures a wire signal won't run multiple times.
            for (int yy = y; yy < y + TileHeight; yy++)
            {
                for (int xx = x; xx < x + TileWidth; xx++)
                {
                    Wiring.SkipWire(xx, yy);
                }
            }

            float spawnX = (x + TileWidth * 0.5f) * 16;
            float spawnY = (y + TileHeight * 0.65f) * 16;


            var entitySource = new EntitySource_TileUpdate(x, y, context: "BnnuyStatue");
{
                // If you want to make an NPC spawning statue, see below.
                int npcIndex = -1;

                // 30 is the time before it can be used again. NPC.MechSpawn checks nearby for other spawns to prevent too many spawns. 3 in immediate vicinity, 6 nearby, 10 in world.
                int spawnedNpcId = ModContent.NPCType<Bnnuy>();

                if (Wiring.CheckMech(x, y, 30) && NPC.MechSpawn(spawnX, spawnY, spawnedNpcId))
                {
                    npcIndex = NPC.NewNPC(entitySource, (int)spawnX, (int)spawnY - 12, spawnedNpcId);
                }

                if (npcIndex >= 0)
                {
                    var npc = Main.npc[npcIndex];

                    npc.value = 0f;
                    npc.npcSlots = 0f;
                    // Prevents Loot if NPCID.Sets.NoEarlymodeLootWhenSpawnedFromStatue and !Main.HardMode or NPCID.Sets.StatueSpawnedDropRarity != -1 and NextFloat() >= NPCID.Sets.StatueSpawnedDropRarity or killed by traps.
                    // Prevents CatchNPC
                    npc.SpawnedFromStatue = true;
                    npc.CanBeReplacedByOtherNPCs = true; // Ensures this NPC won't prevent real NPC spawns if Main.npc somehow becomes full.
                }
            }
        }
    }
}