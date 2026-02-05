using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Accessories
{
    // This example attempts to showcase most of the common boot accessory effects.
    // Of particular note is a showcase of the correct approaches to various movement speed modifications.
    [AutoloadEquip(EquipType.Shoes)]
    public class ZephyrBoots : ModItem
    {
        public static readonly int MoveSpeedBonus = 4;

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 22;

            Item.accessory = true;
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.buyPrice(gold: 4); // Equivalent to Item.buyPrice(0, 1, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            // player.maxRunSpeed and player.runAcceleration are usually not set by boots and should not be changed in UpdateAccessory due to the logic order. See ExampleStatBonusAccessoryPlayer.PostUpdateRunSpeeds for an example of adjusting those speed stats.
            player.rocketBoots = 0;
            player.noFallDmg = true; // Grants the player the Lucky Horseshoe effect of nullifying fall damage

            if (Main.WindyEnoughForKiteDrops)
            {
                player.moveSpeed += MoveSpeedBonus / 100f; // Modifies the player movement speed bonus.
                player.accRunSpeed = 8.90f;
            }
        }
    }
}