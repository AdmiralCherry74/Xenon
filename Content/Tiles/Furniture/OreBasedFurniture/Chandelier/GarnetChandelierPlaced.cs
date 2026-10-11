using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.Reflection;
using Terraria;
using Terraria.GameContent.Drawing;
using Terraria.ModLoader;
using Terraria.Utilities;
using Xenon.Common;
using Xenon.Common.Systems;
using Xenon.Content.Dusts;
using Xenon.Content.Items.Placeable.Furniture.OreBasedFurniture.Chandelier;
using static Terraria.GameContent.Drawing.TileDrawing;

namespace Xenon.Content.Tiles.Furniture.OreBasedFurniture.Chandelier
{
    public class GarnetChandelierPlaced : ChandelierTemplate
    {
        public override int DropItem => ModContent.ItemType<GarnetChandelier>();
        public override Vector3 LightColor => new(1.3f, 0.43f, 0.93f);

        private static Asset<Texture2D> flameTexture;
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            flameTexture = ModContent.Request<Texture2D>(Texture + "_Flame");
        }
    }
}