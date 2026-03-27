using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheConfectionRebirth.Items;
using TheConfectionRebirth.Items.Placeable;
using TheConfectionRebirth.Items.Weapons;
using Xenon.Common.Globals;

namespace Xenon.ModSupport.Confection.Content.Items.Tools.GardeningHoes;

[ExtendsFromMod("TheConfectionRebirth")]
public class SweetTooth : ModItem
{
    public override bool IsLoadingEnabled(Mod mod)
    {
        return XenonMod.TheConfectionRebirthContentEnabled;
    }
    public override void SetDefaults()
    {
        Item.width = 24;
        Item.height = 24;
        Item.scale = 1.45f;

        Item.GetGlobalItem<HoePower>().hoePower = 150;
        Item.knockBack = 1f;
        Item.damage = 8;
        Item.DamageType = DamageClass.Melee;

        Item.useTime = 15;
        Item.useAnimation = 18;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.autoReuse = true;
        Item.useTurn = true;
        Item.UseSound = SoundID.Item1;

        Item.rare = ItemRarityID.White;
        Item.value = Item.sellPrice(silver: 36);
    }
    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<NeapoliniteBar>(), 9)
            .AddIngredient(ModContent.ItemType<SoulofDelight>(), 3)
            .AddTile(TileID.MythrilAnvil)
            .SortAfterFirstRecipesOf(ModContent.ItemType<Pix>())
            .Register();
    }
}
