using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Consumables.NomNoms.Veggies;

public class Beetroot : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 5;
        Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
        ItemID.Sets.FoodParticleColors[Item.type] =
        [
            new Color(255, 255, 255),
            new Color(255, 255, 255),
            new Color(255, 255, 255)
        ];
        ItemID.Sets.IsFood[Type] = true;
    }

    public override void SetDefaults()
    {
        // DefaultToFood sets all of the food related item defaults such as the buff type, buff duration, use sound, and animation time.
        Item.DefaultToFood(22, 18, BuffID.WellFed, 60 * 60 * 5);
    }
}