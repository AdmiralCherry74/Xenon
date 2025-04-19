using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Rarities
{
    internal class Brown : ModRarity
    {
        public override Color RarityColor => new Color(105, 50, 0);
        public override int GetPrefixedRarity(int offset, float valueMult)
        {
            if (offset > 0)
                return ModContent.RarityType<Indigo>();
            return Type;
        }
    }
    internal class Indigo : ModRarity
    {
        public override Color RarityColor => new Color(85, 75, 165);
        public override int GetPrefixedRarity(int offset, float valueMult)
        {
            if (offset < 0)
            {
                return ModContent.RarityType<Brown>();
            }
            else if (offset > 0)
                return ModContent.RarityType<Evil>();
            return Type;
        }
    }
    internal class Evil : ModRarity
    {
        public override Color RarityColor => new Color(100, 0, 115);
        public override int GetPrefixedRarity(int offset, float valueMult)
        {
            if (offset < 0)
            {
                return ModContent.RarityType<Indigo>();
            }
            else if (offset > 0)
                return ModContent.RarityType<AcidicGreen>();
            return Type;
        }
    }
    internal class AcidicGreen : ModRarity
    {
        public override Color RarityColor => new Color(169, 175, 110);
        public override int GetPrefixedRarity(int offset, float valueMult)
        {
            if (offset < 0)
            {
                return ModContent.RarityType<Evil>();
            }
            else if (offset > 0)
                return ModContent.RarityType<Periwinkle>();
            return Type;
        }
    }

    internal class Periwinkle : ModRarity
    {
        public override Color RarityColor => new Color(135, 135, 200);
        public override int GetPrefixedRarity(int offset, float valueMult)
        {
            if (offset < 0)
            {
                return ModContent.RarityType<AcidicGreen>();
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
                return ModContent.RarityType<Periwinkle>();
            }
            else if (offset > 0)
                return ModContent.RarityType<Alizarin>();
            return Type;
        }
    }
    internal class Alizarin : ModRarity
    {
        public override Color RarityColor => new Color(145, 30, 45);
        public override int GetPrefixedRarity(int offset, float valueMult)
        {
            if (offset < 0)
            { 
                return ModContent.RarityType<Macabre>();
            }
            else if (offset > 0)
                return ModContent.RarityType<Blush>();
            return Type;
        }
    }
    internal class Blush : ModRarity
    {
        public override Color RarityColor => new Color(187, 136, 151);
        public override int GetPrefixedRarity(int offset, float valueMult)
        {
            if (offset < 0)
            {
                return ModContent.RarityType<Alizarin>();
            }
            else if (offset > 0)
                return ModContent.RarityType<Gross>();
            return Type;
        }
    }
    internal class Gross : ModRarity
    {
        public override Color RarityColor => new Color(135, 170, 10);
        public override int GetPrefixedRarity(int offset, float valueMult)
        {
            if (offset < 0)
            {
                return ModContent.RarityType<Blush>();
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
                return ModContent.RarityType<Gross>();
            }
            else if (offset > 0)
                return ModContent.RarityType<Purity>();
            return Type;
        }
    }
    internal class Purity : ModRarity
    {
        public override Color RarityColor => new Color(113, 155, 113);
        public override int GetPrefixedRarity(int offset, float valueMult)
        {
            if (offset < 0)
            { // If the offset is -1 or -2 (a negative modifier).
                return ModContent.RarityType<Light>(); // Make the rarity of items that have this rarity with a negative modifier the lower tier one.
            }
            else if (offset > 0)
                return ModContent.RarityType<Xenon>();
            return Type; // no 'higher' tier to go to, so return the type of this rarity.
        }
    }
    internal class Xenon : ModRarity
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