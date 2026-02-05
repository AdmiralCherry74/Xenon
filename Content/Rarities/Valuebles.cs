using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Xenon.Content.Rarities
{
    internal class Purity : ModRarity
    {
        public override Color RarityColor => new Color(113, 155, 113);
        public override int GetPrefixedRarity(int offset, float valueMult)
        {
            if (offset > 0)
                return ModContent.RarityType<Evil>();
            return Type; // no 'higher' tier to go to, so return the type of this rarity.
        }
    }
    internal class Evil : ModRarity
    {
        public override Color RarityColor => new Color(100, 0, 115);
        public override int GetPrefixedRarity(int offset, float valueMult)
        {
            if (offset < 0)
            {
                return ModContent.RarityType<Purity>();
            }
            else if (offset > 0)
                return ModContent.RarityType<Macabre>();
            return Type;
        }
    }
    internal class Macabre : ModRarity
    {
        public override Color RarityColor => new Color(100, 0, 0);
        public override int GetPrefixedRarity(int offset, float valueMult)
        {
            if (offset < 0)
            {
                return ModContent.RarityType<Evil>();
            }
            else if (offset > 0)
                return ModContent.RarityType<Corroded>();
            return Type;
        }
    }
    internal class Corroded : ModRarity
    {
        public override Color RarityColor => new Color(203, 227, 21);
        public override int GetPrefixedRarity(int offset, float valueMult)
        {
            if (offset < 0)
            {
                return ModContent.RarityType<Macabre>();
            }
            else if (offset > 0)
                return ModContent.RarityType<Light>();
            return Type;
        }
    }
    internal class Light : ModRarity
    {
        public override Color RarityColor => new Color(10, 135, 255);
        public override int GetPrefixedRarity(int offset, float valueMult)
        {
            if (offset < 0)
            {
                return ModContent.RarityType<Corroded>();
            }
            else if (offset > 0)
                return ModContent.RarityType<Xenonic>();
            return Type;
        }
    }
    internal class Xenonic : ModRarity
    {
        public override Color RarityColor
        {
            get
            {
                List<Color> colors = new List<Color>
                {
                    new Color(110, 120, 130),
                    new Color(110, 115, 255),
                    new Color(200, 125, 255),
                    new Color(190, 10, 130)
                };
                int numColors = colors.Count;
                float fade = Main.GameUpdateCount % 60 / 60f;
                int index = (int)(Main.GameUpdateCount / 60 % numColors);
                int nextIndex = (index + 1) % numColors;
                return Color.Lerp(colors[index], colors[nextIndex], fade);
            }
        }
    }
}