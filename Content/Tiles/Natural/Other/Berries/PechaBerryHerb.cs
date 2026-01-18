using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Xenon.Common.Templates;
using Xenon.Content.Items.Consumables.NomNoms.Berries;

namespace Xenon.Content.Tiles.Natural.Other.Berries;

public class PechaBerryHerb : ModHerb
{
    public override int HerbDrop => ModContent.ItemType<PechaBerry>();
    public override int[] ValidAnchorTiles =>
    [
        TileID.JungleGrass
    ];
    public override LocalizedText MapName => this.GetLocalization("MapEntry");
    public override Color MapColor => new Color(100, 50, 50);
    public override int Dust => DustID.Grass;
    public override void SetStaticDefaults()
    {
        TileID.Sets.TileCutIgnore.Regrowth[Type] = true;
        base.SetStaticDefaults();
    }
    public override void RandomUpdate(int i, int j)
    {
        Tile tile = Framing.GetTileSafely(i, j); //Safe way of getting a tile instance
        PlantStage stage = GetStage(i, j); //The current stage of the herb

        if (stage == PlantStage.Planted && Main.rand.NextBool(12))
        {
            tile.TileFrameX += 18;
            if (Main.netMode != NetmodeID.SinglePlayer)
                NetMessage.SendTileSquare(-1, i, j, 1);
        }
        if (stage == PlantStage.Mature)
        {
            if (Main.dayTime)
            {
                tile.TileFrameX = 36;
            }
            else tile.TileFrameX = 18;
            if (Main.netMode != NetmodeID.SinglePlayer)
                NetMessage.SendTileSquare(-1, i, j, 1);
        }
        if (stage == PlantStage.Blooming && (!Main.dayTime))
        {
            tile.TileFrameX = 18;
            if (Main.netMode != NetmodeID.SinglePlayer)
                NetMessage.SendTileSquare(-1, i, j, 1);
        }

        ////Only grow to the next stage if there is a next stage. We dont want our tile turning pink!
        //if (stage != PlantStage.Grown)
        //{
        //    //Increase the x frame to change the stage
        //    tile.frameX += FrameWidth;

        //    //If in multiplayer, sync the frame change
        //    if (Main.netMode != NetmodeID.SinglePlayer)
        //        NetMessage.SendTileSquare(-1, i, j, 1);
        //}
    }
}
