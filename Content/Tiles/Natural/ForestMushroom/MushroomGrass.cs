using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Tiles.Natural.ForestMushroom;

public class MushroomGrass : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(167, 146, 0));
        Main.tileSolid[Type] = true;
        Main.tileBrick[Type] = true;
        Main.tileBlockLight[Type] = true;
        TileID.Sets.Conversion.Dirt[Type] = true;
        TileID.Sets.Conversion.MergesWithDirtInASpecialWay[Type] = true;
        TileID.Sets.SpreadOverground[Type] = true;
        TileID.Sets.SpreadUnderground[Type] = true;
        TileID.Sets.CanBeDugByShovel[Type] = true;
        TileID.Sets.NeedsGrassFraming[Type] = true;
        TileID.Sets.NeedsGrassFramingDirt[Type] = TileID.Dirt;
        TileID.Sets.Grass[Type] = true;
        RegisterItemDrop(ItemID.DirtBlock);
        HitSound = SoundID.Dig;
        DustType = DustID.Palladium;
    }
    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}