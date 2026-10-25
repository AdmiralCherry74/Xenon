using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Globals.XenonPlayerGlobals;
using Xenon.Content.Buffs.Debuffs.Counterable;
using Xenon.Content.Buffs.Epibuffs.OreFruitBuffs;

namespace Xenon.Content.Items.Consumables.NomNoms.OreFood;

public class FluoriteApple : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 5;
        Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
        ItemID.Sets.FoodParticleColors[Item.type] =
        [
            new Color(245, 186, 187),
            new Color(194, 55, 151),
            new Color(73, 14, 69)
        ];
        ItemID.Sets.IsFood[Type] = true;
    }

    public override void SetDefaults()
    {
        // DefaultToFood sets all of the food related item defaults such as the buff type, buff duration, use sound, and animation time.
        Item.DefaultToFood(22, 18, BuffID.WellFed, 18000);
    }
    public override bool? UseItem(Player player)
    {
        player.AddBuff(ModContent.BuffType<FluoriteAppleBuff>(), 18000);
        player.GetModPlayer<XenonNauseaBuffPlayer>().SpecialFoodCount += 1;
        return null;
    }
}