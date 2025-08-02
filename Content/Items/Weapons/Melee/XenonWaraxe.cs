using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Rarities;

namespace Xenon.Content.Items.Weapons.Melee;

public class XenonWaraxe : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 40;
        Item.height = 40;

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 10;
        Item.useAnimation = 20;

        Item.autoReuse = true;

        Item.DamageType = DamageClass.Melee;
        Item.damage = 999999999;
        Item.knockBack = 10;
        Item.crit = 20;

        Item.value = Item.buyPrice(platinum: 1);
        Item.UseSound = SoundID.Item1;
        Item.rare = ModContent.RarityType<Light>();
    }

    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        target.AddBuff(BuffID.OnFire, 5);
        target.AddBuff(BuffID.CursedInferno, 5);
        target.AddBuff(BuffID.Frostburn2, 5);
        target.AddBuff(BuffID.Bleeding, 15);
        target.AddBuff(BuffID.BrokenArmor, 15);
    }
    public override void AddRecipes()
    {
        Recipe Ti = CreateRecipe();
        Ti.AddIngredient(ItemID.CopperAxe);
        Ti.AddIngredient(ItemID.TinAxe);
        Ti.AddIngredient(ItemID.IronAxe);
        Ti.AddIngredient(ItemID.LeadAxe);
        Ti.AddIngredient(ItemID.SilverAxe);
        Ti.AddIngredient(ItemID.GoldAxe);
        Ti.AddIngredient(ItemID.PlatinumAxe);
        Ti.AddIngredient(ItemID.WarAxeoftheNight);
        Ti.AddIngredient(ItemID.BloodLustCluster);
        Ti.AddIngredient(ItemID.CobaltWaraxe);
        Ti.AddIngredient(ItemID.PalladiumWaraxe);
        Ti.AddIngredient(ItemID.MythrilWaraxe);
        Ti.AddIngredient(ItemID.OrichalcumWaraxe);
        Ti.AddIngredient(ItemID.AdamantiteWaraxe);
        Ti.AddIngredient(ItemID.TitaniumWaraxe);
        Ti.AddIngredient(ItemID.ChlorophyteGreataxe);
        Ti.AddTile(TileID.DemonAltar);
        Ti.Register();
    }
}