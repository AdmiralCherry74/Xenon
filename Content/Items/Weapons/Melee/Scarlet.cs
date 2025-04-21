using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Weapons.Melee;

public class Scarlet : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 40;
        Item.height = 40;

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.autoReuse = false;

        Item.DamageType = DamageClass.Melee;
        Item.damage = 20;
        Item.knockBack = 5;
        Item.crit = 2;

        Item.value = Item.buyPrice(gold: 10);
        Item.UseSound = SoundID.Item1;
        Item.rare = 2;
    }

    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        target.AddBuff(BuffID.BrokenArmor, 60);
    }
    public override void AddRecipes()
    {
        Recipe Ti = CreateRecipe();
        Ti.AddIngredient(ItemID.GoldBar, 10);
        Ti.AddIngredient(ItemID.GoldShortsword, 1);
        Ti.AddIngredient(ItemID.Silk, 5);
        Ti.AddTile(TileID.Anvils);
        Ti.Register();
    }
}