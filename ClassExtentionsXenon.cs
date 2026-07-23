using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace Xenon
{
    public static class ClassExtentionsXenon
    {
        public static Asset<Texture2D> GetTexture(this ModTexturedType texturedType) =>
        ModContent.Request<Texture2D>(texturedType.Texture);

        public static Asset<Texture2D> GetTexture(this ModItem modItem) =>
            ModContent.Request<Texture2D>(modItem.Texture);

        public static Asset<Texture2D> GetTexture(this ModProjectile modProjectile) =>
            ModContent.Request<Texture2D>(modProjectile.Texture);
    }
}
