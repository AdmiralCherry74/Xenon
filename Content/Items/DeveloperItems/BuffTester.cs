using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Buffs.Debuffs;
using Xenon.Content.Buffs.Debuffs.Counterable;

namespace Xenon.Content.Items.DeveloperItems;
    public class BuffTester : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 20;

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
            Item.maxStack = 1;
            Item.consumable = false;
            Item.rare = ItemRarityID.Red;
            Item.value = Item.sellPrice(silver: 2);
            Item.buffType = ModContent.BuffType<Boomed>(); // Specify an existing buff to be applied when used.
            Item.buffTime = 999999999; // The amount of time the buff declared in Item.buffType will last in ticks. 14400 / 60 is 240, so this buff will last 240 seconds.
        }
    }