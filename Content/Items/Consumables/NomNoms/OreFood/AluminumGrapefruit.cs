using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Globals.XenonPlayerGlobals;
using Xenon.Content.Buffs.Debuffs.Counterable;
using Xenon.Content.Buffs.Epibuffs.OreFruitBuffs;
using Xenon.Content.Buffs.TarotCardBuff;
using Xenon.Content.Items.Consumables.TarotCards;

namespace Xenon.Content.Items.Consumables.NomNoms.OreFood;

public class AluminumGrapefruit : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 5;
        Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
        ItemID.Sets.FoodParticleColors[Item.type] =
        [
            new Color(235, 166, 135),
            new Color(205, 134, 71),
            new Color(64, 27, 7)
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
        player.AddBuff(ModContent.BuffType<AluminumGrapefruitBuff>(), 18000);
        player.GetModPlayer<XenonNauseaBuffPlayer>().SpecialFoodCount += 1;
        return null;
    }
}