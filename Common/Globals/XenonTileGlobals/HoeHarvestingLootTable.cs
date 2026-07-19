using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Globals.XenonItemGlobals;
using Xenon.Content.Items.Materials.Organic;
using Xenon.Content.Tiles.Natural.Corrosion;

namespace Xenon.Common.Globals.XenonTileGlobals
{
    public class HoeHarvestingLootTable : GlobalTile
    {
        public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            Vector2 worldPosition = new Vector2(i, j).ToWorldCoordinates();
            Player nearestPlayer = Main.player[Player.FindClosest(worldPosition, 16, 16)];
            if (nearestPlayer.active)
            {
                #region lowest hoe power
                if (nearestPlayer.HeldItem.GetGlobalItem<HoePower>().hoePower >= 35 && Main.tile[i, j].TileType == TileID.Cobweb)
                {
                    if (Main.rand.Next(1, 100) > 90)
                    {
                        Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2(i, j) * 16, ItemID.Cobweb, 1);
                    }
                }
                if (nearestPlayer.HeldItem.GetGlobalItem<HoePower>().hoePower >= 35 && Main.tile[i, j].TileType == TileID.SeaOats)
                {
                    if (Main.rand.Next(1, 100) > 80)
                    {
                        Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2(i, j) * 16, HoeLootTables.forestPlantlootTable1[Main.rand.Next(HoeLootTables.forestPlantlootTable1.Length)]);
                    }
                }
                #region Forest
                if (nearestPlayer.HeldItem.GetGlobalItem<HoePower>().hoePower >= 35 && Main.tile[i, j].TileType == TileID.Plants)
                {
                    if (Main.rand.Next(1, 100) > 80)
                    {
                        Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2(i, j) * 16, HoeLootTables.forestPlantlootTable1[Main.rand.Next(HoeLootTables.forestPlantlootTable1.Length)]);
                    }
                }
                if (nearestPlayer.HeldItem.GetGlobalItem<HoePower>().hoePower >= 35 && Main.tile[i, j].TileType == TileID.Plants2)
                {
                    if (Main.rand.Next(1, 100) > 80)
                    {
                        Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2(i, j) * 16, HoeLootTables.forestPlantlootTable1[Main.rand.Next(HoeLootTables.forestPlantlootTable1.Length)]);
                    }
                }
                if (nearestPlayer.HeldItem.GetGlobalItem<HoePower>().hoePower >= 35 && Main.tile[i, j].TileType == TileID.Vines)
                {
                    if (Main.rand.Next(1, 100) > 90)
                    {
                        Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2(i, j) * 16, HoeLootTables.forestPlantlootTable1[Main.rand.Next(HoeLootTables.forestPlantlootTable1.Length)]);
                    }
                }
                #endregion
                #region Jungle
                if (nearestPlayer.HeldItem.GetGlobalItem<HoePower>().hoePower >= 35 && Main.tile[i, j].TileType == TileID.JunglePlants)
                {
                    if (Main.rand.Next(1, 100) > 85)
                    {
                        Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2(i, j) * 16, HoeLootTables.junglePlantlootTable1[Main.rand.Next(HoeLootTables.junglePlantlootTable1.Length)]);
                    }
                }
                if (nearestPlayer.HeldItem.GetGlobalItem<HoePower>().hoePower >= 35 && Main.tile[i, j].TileType == TileID.JunglePlants2)
                {
                    if (Main.rand.Next(1, 100) > 85)
                    {
                        Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2(i, j) * 16, HoeLootTables.junglePlantlootTable1[Main.rand.Next(HoeLootTables.junglePlantlootTable1.Length)]);
                    }
                }
                if (nearestPlayer.HeldItem.GetGlobalItem<HoePower>().hoePower >= 35 && Main.tile[i, j].TileType == ModContent.TileType<CorrosionVines>())
                {
                    if (Main.rand.Next(1, 100) > 85)
                    {
                        Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2(i, j) * 16, HoeLootTables.junglePlantlootTable1[Main.rand.Next(HoeLootTables.junglePlantlootTable1.Length)]);
                    }
                }
                #endregion
                #region Mushroom
                if (nearestPlayer.HeldItem.GetGlobalItem<HoePower>().hoePower >= 35 && Main.tile[i, j].TileType == TileID.MushroomPlants)
                {
                    if (Main.rand.Next(1, 100) > 80)
                    {
                        Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2(i, j) * 16, HoeLootTables.mushroomPlantlootTable1[Main.rand.Next(HoeLootTables.mushroomPlantlootTable1.Length)]);
                    }
                }
                if (nearestPlayer.HeldItem.GetGlobalItem<HoePower>().hoePower >= 35 && Main.tile[i, j].TileType == TileID.MushroomVines)
                {
                    if (Main.rand.Next(1, 100) > 90)
                    {
                        Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2(i, j) * 16, HoeLootTables.mushroomPlantlootTable1[Main.rand.Next(HoeLootTables.mushroomPlantlootTable1.Length)]);
                    }
                }
                #endregion
                #region Corruption
                if (nearestPlayer.HeldItem.GetGlobalItem<HoePower>().hoePower >= 35 && Main.tile[i, j].TileType == TileID.CorruptPlants)
                {
                    if (Main.rand.Next(1, 100) > 80)
                    {
                        Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2(i, j) * 16, HoeLootTables.corruptPlantlootTable1[Main.rand.Next(HoeLootTables.corruptPlantlootTable1.Length)]);
                    }
                }
                if (nearestPlayer.HeldItem.GetGlobalItem<HoePower>().hoePower >= 35 && Main.tile[i, j].TileType == TileID.CorruptVines)
                {
                    if (Main.rand.Next(1, 100) > 90)
                    {
                        Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2(i, j) * 16, HoeLootTables.corruptPlantlootTable1[Main.rand.Next(HoeLootTables.corruptPlantlootTable1.Length)]);
                    }
                }
                #endregion
                #region Crimson
                if (nearestPlayer.HeldItem.GetGlobalItem<HoePower>().hoePower >= 35 && Main.tile[i, j].TileType == TileID.CrimsonPlants)
                {
                    if (Main.rand.Next(1, 100) > 80)
                    {
                        Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2(i, j) * 16, HoeLootTables.crimsonPlantlootTable1[Main.rand.Next(HoeLootTables.crimsonPlantlootTable1.Length)]);
                    }
                }
                if (nearestPlayer.HeldItem.GetGlobalItem<HoePower>().hoePower >= 35 && Main.tile[i, j].TileType == TileID.CrimsonVines)
                {
                    if (Main.rand.Next(1, 100) > 90)
                    {
                        Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2(i, j) * 16, HoeLootTables.crimsonPlantlootTable1[Main.rand.Next(HoeLootTables.crimsonPlantlootTable1.Length)]);
                    }
                }
                #endregion
                #region Corrosion
                if (nearestPlayer.HeldItem.GetGlobalItem<HoePower>().hoePower >= 35 && Main.tile[i, j].TileType == ModContent.TileType<CorrosionShortGrass>())
                {
                    if (Main.rand.Next(1, 100) > 80)
                    {
                        Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2(i, j) * 16, HoeLootTables.corrodedPlantlootTable1[Main.rand.Next(HoeLootTables.corrodedPlantlootTable1.Length)]);
                    }
                }
                if (nearestPlayer.HeldItem.GetGlobalItem<HoePower>().hoePower >= 35 && Main.tile[i, j].TileType == ModContent.TileType<CorrosionVines>())
                {
                    if (Main.rand.Next(1, 100) > 90)
                    {
                        Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2(i, j) * 16, HoeLootTables.corrodedPlantlootTable1[Main.rand.Next(HoeLootTables.corrodedPlantlootTable1.Length)]);
                    }
                }
                #endregion
                #endregion
                #region 50 hoe power
                #region Thorns
                if (nearestPlayer.HeldItem.GetGlobalItem<HoePower>().hoePower >= 50 && Main.tile[i, j].TileType == TileID.JungleThorns)
                {
                    Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2(i, j) * 16, ModContent.ItemType<JungleThornyBushItem>());
                }
                if (nearestPlayer.HeldItem.GetGlobalItem<HoePower>().hoePower >= 50 && Main.tile[i, j].TileType == TileID.CorruptThorns)
                {
                    Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2(i, j) * 16, ModContent.ItemType<CorruptedThornyBushItem>());
                }
                if (nearestPlayer.HeldItem.GetGlobalItem<HoePower>().hoePower >= 50 && Main.tile[i, j].TileType == TileID.CrimsonThorns)
                {
                    Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2(i, j) * 16, ModContent.ItemType<CrimfiedThornyBushItem>());
                }
                if (nearestPlayer.HeldItem.GetGlobalItem<HoePower>().hoePower >= 50 && Main.tile[i, j].TileType == ModContent.TileType<CorrosionThornyBushes>())
                {
                    Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2(i, j) * 16, ModContent.ItemType<CorrodedThornyBushItem>());
                }
                #endregion
                #endregion
            }
        }
    }
}