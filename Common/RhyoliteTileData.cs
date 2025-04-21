using Terraria;

namespace Xenon.Common;

public struct RhyoliteTileData : ITileData
{
	public byte DataByte;

	public bool IsTileActupainted
	{
		get => TileDataPacking.GetBit(DataByte, 1);
		set => DataByte = (byte)TileDataPacking.SetBit(value, DataByte, 1);
	}

	public bool IsWallActupainted
	{
		get => TileDataPacking.GetBit(DataByte, 2);
		set => DataByte = (byte)TileDataPacking.SetBit(value, DataByte, 2);
	}
}
