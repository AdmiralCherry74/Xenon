using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Buffs.Debuffs;
using Xenon.Content.Tiles.Natural.Autumn;
using Xenon.Content.Tiles.Natural.Corrosion;

namespace Xenon.Common.Globals.XenonItemGlobals
{
    public class ItemChanges : GlobalItem
    {
        static int[] seeds = [
            ItemID.GrassSeeds,
            ItemID.CorruptSeeds,
            ItemID.CrimsonSeeds,
            ItemID.MushroomGrassSeeds,
            ItemID.JungleGrassSeeds,
            ItemID.HallowedSeeds
        ];

        public override bool InstancePerEntity => true;
        public override void SetDefaults(Item entity)
        {
            //Thank you Terradux
            if (entity.type == ItemID.Rally)
            {
                entity.damage = 18;
            }
        }

    public override bool? UseItem(Item item, Player player)
        {
            if(seeds.Contains<int>(item.type))
            {
                Tile tile = Framing.GetTileSafely(Player.tileTargetX, Player.tileTargetY);
                if (tile.HasTile && player.IsInTileInteractionRange(Player.tileTargetX, Player.tileTargetY, TileReachCheckSettings.Simple))
                {
                    if (tile.TileType == ModContent.TileType<Mulch>())
                    {
                        //HA HA I'M EVIL AND AM USING A SWITCH CASE!!!!! - Emerald
                        switch (item.type)
                        {
                            case ItemID.CorruptSeeds:
                                Main.tile[Player.tileTargetX, Player.tileTargetY].TileType = (ushort)ModContent.TileType<CorruptionAutumnGrass>();
                                WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY, true);
                                SoundEngine.PlaySound(SoundID.Dig, player.Center);
                            return true;
                            case ItemID.CrimsonSeeds:
                                Main.tile[Player.tileTargetX, Player.tileTargetY].TileType = (ushort)ModContent.TileType<CrimsonAutumnGrass>();
                                WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY, true);
                                SoundEngine.PlaySound(SoundID.Dig, player.Center);
                            return true;
                            case ItemID.MushroomGrassSeeds:
                                Main.tile[Player.tileTargetX, Player.tileTargetY].TileType = (ushort)ModContent.TileType<MushroomGrassMulch>();
                                WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY, true);
                                SoundEngine.PlaySound(SoundID.Dig, player.Center);
                            return true;

                            default: return false;
                        }
                    }
                }
                return false;
            }

            
            return null;
        }
    }
        
}
