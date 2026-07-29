using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common;
using Xenon.Content.Items.Placeable.Furniture.OreBasedFurniture.Candelabra;

namespace Xenon.Content.Tiles.Furniture.OreBasedFurniture.Candelabra;

public class AluminumCandelabraTile : CandelabraTemplate
{
    public override int DropItem => ModContent.ItemType<AluminumCandelabra>();
    public override int FlameDust => DustID.Torch;
}