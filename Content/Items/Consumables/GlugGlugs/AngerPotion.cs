using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Buffs.Epibuffs;
using Xenon.Content.Items.Fish;
using Xenon.Content.Items.Materials.EvilMaterials;

namespace Xenon.Content.Items.Consumables.GlugGlugs;
    public class AngerPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 30;

            // Dust that will appear in these colors when the item with ItemUseStyleID.DrinkLiquid is used
            ItemID.Sets.DrinkParticleColors[Type] = [
                new Color(0, 65, 0),
            ];
    }

    public override void SetDefaults()
    {
        Item.width = 20;
        Item.height = 30;
        Item.useStyle = ItemUseStyleID.DrinkLiquid;
        Item.useAnimation = 15;
        Item.useTime = 15;
        Item.useTurn = true;
        Item.UseSound = SoundID.Item3;
        Item.maxStack = Item.CommonMaxStack;
        Item.consumable = true;
        Item.rare = ItemRarityID.Blue;
        Item.value = Item.sellPrice(silver: 2);
        Item.buffType = ModContent.BuffType<Anger>(); // Specify an existing buff to be applied when used.
        Item.buffTime = 14400; // The amount of time the buff declared in Item.buffType will last in ticks. 14400 / 60 is 240, so this buff will last 240 seconds.
    }
    public override void AddRecipes()
    {
        CreateRecipe()
        .AddIngredient(ModContent.ItemType<Corrodoras>())
        .AddIngredient(ModContent.ItemType<Liverwort>())
        .AddIngredient(ItemID.BottledWater)
        .AddTile(TileID.Bottles)
        .Register();
    }
}