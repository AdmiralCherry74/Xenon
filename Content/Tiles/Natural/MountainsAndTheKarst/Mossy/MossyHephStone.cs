using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Blocks.Natural.Stone;
using Xenon.Content.Tiles.Natural.Corrosion;
using Xenon.Content.Tiles.Natural.MountainsAndTheKarst;

namespace Xenon.Content.Tiles.Natural.MountainsAndTheKarst.Mossy;

public class MossyHephStone : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileMerge[Type][TileID.Stone] = true;
        Main.tileMerge[Type][TileID.Ebonstone] = true;
        Main.tileMerge[Type][TileID.CorruptGrass] = true;
        Main.tileMerge[Type][TileID.Crimstone] = true;
        Main.tileMerge[Type][TileID.CrimsonGrass] = true;
        Main.tileMerge[Type][TileID.Pearlstone] = true;
        Main.tileMerge[Type][TileID.HallowedGrass] = true;
        Main.tileMerge[Type][ModContent.TileType<CorrosionGrass>()] = true;
        Main.tileMerge[Type][ModContent.TileType<Gutstone>()] = true;
        Main.tileMerge[Type][ModContent.TileType<HephStone>()] = true;
        Main.tileMerge[Type][ModContent.TileType<OuranoStone>()] = true;
        Main.tileMerge[Type][ModContent.TileType<MossyOuranoStone>()] = true;
        Main.tileMerge[Type][ModContent.TileType<NyxStone>()] = true;
        Main.tileMerge[Type][ModContent.TileType<MossyNyxStone>()] = true;
        Main.tileMerge[Type][ModContent.TileType<AresStone>()] = true;
        Main.tileMerge[Type][ModContent.TileType<MossyAresStone>()] = true;
        Main.tileMerge[Type][ModContent.TileType<HelioStone>()] = true;
        Main.tileMerge[Type][ModContent.TileType<MossyHelioStone>()] = true;
		Main.tileBrick[Type] = true;
		TileID.Sets.NeedsGrassFraming[Type] = true;
		TileID.Sets.NeedsGrassFramingDirt[Type] = ModContent.TileType<HephStone>();
		TileID.Sets.Grass[Type] = true;
		Main.tileBlockLight[Type] = true;
        AddMapEntry(new Color(190, 223, 232));
        HitSound = SoundID.Tink;
        DustType = DustID.Stone;
		RegisterItemDrop(ModContent.ItemType<HephStoneBlock>());
	}

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}