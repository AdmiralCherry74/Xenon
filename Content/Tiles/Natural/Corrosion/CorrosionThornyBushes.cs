using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Globals;
using Xenon.Content.Dusts;
using Xenon.Content.Items.Materials.Organic;

namespace Xenon.Content.Tiles.Natural.Corrosion;

public class CorrosionThornyBushes : ModTile
{
    public override bool IsTileBiomeSightable(int i, int j, ref Color sightColor)
    {
        sightColor = XenonMod.CorrosionBiomeSightColor;
        return true;
    }
    public override void SetStaticDefaults()
    {
        Main.tileNoFail[Type] = true;
        Main.tileCut[Type] = true;
        Main.tileLavaDeath[Type] = true;
        Main.tileBlockLight[Type] = true;
        ItemID.Sets.DisableAutomaticPlaceableDrop[Type] = true;
        TileID.Sets.Conversion.Thorn[Type] = true;
        TileID.Sets.TileCutIgnore.IgnoreDontHurtNature[Type] = true;
        TileID.Sets.GetsDestroyedForMeteors[Type] = true;
        TileID.Sets.TouchDamageDestroyTile[Type] = true;
        TileID.Sets.TouchDamageImmediate[Type] = 12;
        TileID.Sets.SpreadOverground[Type] = true;
        //TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
        //TileObjectData.newTile.CoordinateHeights = new int[] { 16 };
        //TileObjectData.newTile.CoordinateWidth = 16;
        //TileObjectData.newTile.CoordinatePadding = 2;
        //TileObjectData.newTile.StyleHorizontal = false;
        //TileObjectData.newTile.LavaDeath = false;
        //TileObjectData.addTile(Type);
        HitSound = SoundID.Grass;
        AddMapEntry(new Color(155, 174, 50));
        DustType = ModContent.DustType<CorrosionDust>();
    }

    public override IEnumerable<Item> GetItemDrops(int i, int j)
    {
        Vector2 worldPosition = new Vector2(i, j).ToWorldCoordinates();
        Player nearestPlayer = Main.player[Player.FindClosest(worldPosition, 16, 16)];
        if (nearestPlayer.active)
        {
            if (nearestPlayer.HeldItem.GetGlobalItem<HoePower>().hoePower >= 35)
                yield return new Item(ModContent.ItemType<CorrodedThorns>(), 1);
        }
    }
}
