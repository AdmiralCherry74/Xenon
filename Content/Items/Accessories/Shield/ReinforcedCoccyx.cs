using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Globals;

namespace Xenon.Content.Items.Accessories.Shield;

[AutoloadEquip(EquipType.Shield)]
public class ReinforcedCoccyx : ModItem
{
	public override void SetDefaults()
	{
		Item.defense = 2;
		Item.height = 42;
		Item.width = 34;
		Item.DefaultToAccessory();
		Item.sellPrice(silver: 50);
		Item.rare = ItemRarityID.Green;
	}
	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		player.GetModPlayer<XenonPlayer>().HotDamageResistShield = true;
	}
    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<BoneSerpentCoccyx>())
			.AddIngredient(ItemID.Shackle)
            .AddTile(TileID.TinkerersWorkbench)
            .Register();
    }
}