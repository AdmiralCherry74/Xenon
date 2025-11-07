using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Xenon.Common;

namespace Xenon.Content.Tiles.Decoration.Furniture.Bilewood;

public class BilewoodBathtub : BathtubTemplate { }

public class BilewoodBed : BedTemplate
{
	public override int DropItem => ModContent.ItemType<Items.Placeable.Furniture.Bilewood.BilewoodBed>();
}

public class BilewoodBookcase : BookcaseTemplate { }

public class BilewoodCandelabra : CandelabraTemplate
{
	public override int DropItem => ModContent.ItemType<Items.Placeable.Furniture.Bilewood.BilewoodCandelabra>();
	public override Color FlameColor => new(125, 212, 94, 0);
	public override Vector3 LightColor => new(0.49f, 0.83f, 0.37f);
}

public class BilewoodCandle : CandleTemplate
{
	public override int DropItem => ModContent.ItemType<Items.Placeable.Furniture.Bilewood.BilewoodCandle>();
	public override Color FlameColor => new(125, 212, 94, 0);
	public override Vector3 LightColor => new(0.49f, 0.83f, 0.37f);
}

public class BilewoodChair : ChairTemplate
{
	public override int DropItem => ModContent.ItemType<Items.Placeable.Furniture.Bilewood.BilewoodChair>();
}

public class BilewoodChandelier : ChandelierTemplate
{
	public override int DropItem => ModContent.ItemType<Items.Placeable.Furniture.Bilewood.BilewoodChandelier>();
	public override Color FlameColor => new(125, 212, 94, 0);
	public override Vector3 LightColor => new(0.49f, 0.83f, 0.37f);
}

public class BilewoodChest : ChestTemplate
{
	public override int DropItem => ModContent.ItemType<Items.Placeable.Furniture.Bilewood.BilewoodChest>();
}

public class BilewoodClock : ClockTemplate
{
	public override int DropItem => ModContent.ItemType<Items.Placeable.Furniture.Bilewood.BilewoodClock>();
}

public class BilewoodDoorClosed : ClosedDoorTemplate
{
	public override int DropItem => ModContent.ItemType<Items.Placeable.Furniture.Bilewood.BilewoodDoor>();
}

public class BilewoodDoorOpen : OpenDoorTemplate
{
	public override int DropItem => ModContent.ItemType<Items.Placeable.Furniture.Bilewood.BilewoodDoor>();
}

public class BilewoodDresser : DresserTemplate
{
	public override int DropItem => ModContent.ItemType<Items.Placeable.Furniture.Bilewood.BilewoodDresser>();
}

public class BilewoodLamp : LampTemplate
{
	public override int DropItem => ModContent.ItemType<Items.Placeable.Furniture.Bilewood.BilewoodLamp>();
	public override Color FlameColor => new(125, 212, 94, 0);
	public override Vector3 LightColor => new(0.49f, 0.83f, 0.37f);
}

public class BilewoodLantern : LanternTemplate
{
	public override int DropItem => ModContent.ItemType<Items.Placeable.Furniture.Bilewood.BilewoodLantern>();
	public override bool HasFlameTexture => false;
	public override Vector3 LightColor => new(0.49f, 0.83f, 0.37f);
}

public class BilewoodPiano : PianoTemplate { }

public class BilewoodPlatform : PlatformTemplate
{
	public override int Dust => ModContent.DustType<Dusts.BilewoodDust>();
}

public class BilewoodSink : SinkTemplate { }

public class BilewoodSofa : SofaTemplate
{
	public override int DropItem => ModContent.ItemType<Items.Placeable.Furniture.Bilewood.BilewoodSofa>();
}

public class BilewoodTable : TableTemplate { }

public class BilewoodToilet : ToiletTemplate
{
	public override int DropItem => ModContent.ItemType<Items.Placeable.Furniture.Bilewood.BilewoodToilet>();
}

public class BilewoodWorkBench : WorkbenchTemplate { }
