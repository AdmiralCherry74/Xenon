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
    public class TopazChandelierPlaced : ChandelierTemplate
    {
        public override int DropItem => ModContent.ItemType<TopazChandelier>();
        public override Vector3 LightColor => new(0.9f, 0.9f, 0f);

        private static Asset<Texture2D> flameTexture;
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            flameTexture = ModContent.Request<Texture2D>(Texture + "_Flame");
        }
    }
}