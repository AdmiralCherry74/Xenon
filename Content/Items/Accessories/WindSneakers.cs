using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Accessories
{
    // This example attempts to showcase most of the common boot accessory effects.
    // Of particular note is a showcase of the correct approaches to various movement speed modifications.
    [AutoloadEquip(EquipType.Shoes)]
    public class WindSneakers : ModItem
    {
        public static readonly int WeakWindyMoveSpeedBonus = 3;
        public static readonly int WeakNotWindyMoveSpeedBonus = 2;
        
        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 22;
            Item.shoeSlot = 1;
            Item.accessory = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.buyPrice(gold: 4); // Equivalent to Item.buyPrice(0, 1, 0, 0);
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            // player.maxRunSpeed and player.runAcceleration are usually not set by boots and should not be changed in UpdateAccessory due to the logic order. See ExampleStatBonusAccessoryPlayer.PostUpdateRunSpeeds for an example of adjusting those speed stats.
            player.rocketBoots = 0;

            if (Main.WindyEnoughForKiteDrops)
            {
                player.moveSpeed += WeakWindyMoveSpeedBonus / 50f; // Modifies the player movement speed bonus.
                player.accRunSpeed = 6.70f;
            }
            else
            {
                player.moveSpeed += WeakNotWindyMoveSpeedBonus / 50f; // Modifies the player movement speed bonus.
                player.accRunSpeed = 6;
            }
        }
    }
}