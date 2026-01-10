using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace Xenon.Content.Tiles.Natural.Corrosion
{
    public class ExpiredCactus : ModCactus
    {
        private Asset<Texture2D> texture;
        private Asset<Texture2D> fruitTexture;
        public override void SetStaticDefaults()
        {
            GrowsOnTileId = [ModContent.TileType<Gutsand>()];

            texture = ModContent.Request<Texture2D>("Xenon/Content/Tiles/Natural/Corrosion/ExpiredCactus");
            fruitTexture = ModContent.Request<Texture2D>("Xenon/Content/Tiles/Natural/Corrosion/ExpiredCactus_Fruit");
        }
        public override Asset<Texture2D> GetTexture() => texture;

        public override Asset<Texture2D> GetFruitTexture() => fruitTexture;
    }
}