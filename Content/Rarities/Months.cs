using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Xenon.Content.Rarities
{
    //for any Valuables obtained during a month of the year
    internal class Janaury : ModRarity
    {
        public override Color RarityColor => new Color(154, 42, 42); //this is Garnet colour
    }
    internal class Febuaury : ModRarity
    {
        public override Color RarityColor => new Color(153, 102, 204); //this is Amethyst
    }
    internal class March : ModRarity 
    {
        public override Color RarityColor => new Color(127, 255, 212); //this is Aquamarine
    }
    internal class April : ModRarity 
    {
        public override Color RarityColor => new Color(200, 200, 244); //this is Diamond (217, 235, 244)
    }
    internal class May : ModRarity
    {
        public override Color RarityColor => new Color(0, 103, 79); //this is Emerald
    }
    internal class June : ModRarity
    {
        public override Color RarityColor => new Color(153, 153, 204); //this is Alexandrite (153, 153, 204) 
    }
    internal class July : ModRarity
    {
        public override Color RarityColor => new Color(107, 0, 21); //this is Ruby (107, 0, 21)
    }
    internal class August : ModRarity
    {
        public override Color RarityColor => new Color(172, 233, 125); //this is Peridot
    }
    internal class September : ModRarity
    {
        public override Color RarityColor => new Color(43, 61, 171); //this is Sapphire
    }
    internal class October : ModRarity
    {
        public override Color RarityColor => new Color(214, 129, 163); //this is Tourmaline
    }
    internal class November : ModRarity
    {
        public override Color RarityColor => new Color(228, 208, 10); //this is Citrine
    }
    internal class December : ModRarity
    {
        public override Color RarityColor => new Color(77, 226, 226); //this is blue Zircon
    }
}