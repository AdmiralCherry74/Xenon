using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Materials;
using Xenon.Content.Items.Materials.BarsGems;

namespace Xenon.Content.Items.Tools.MiningPickaxes;

public class XieitePickaxe : ModItem
{
    public override void SetDefaults()
    {
        Item.pick = 57;
        Item.knockBack = 2f;
        Item.damage = 7;
        Item.useTime = 16;
        Item.useAnimation = 18;
        Item.width = 32;
        Item.height = 32;
        Item.DamageType = DamageClass.Melee;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.autoReuse = true;
        Item.useTurn = true;
        Item.UseSound = SoundID.Item1;
        Item.rare = ItemRarityID.White;
        Item.value = Item.sellPrice(0, 1, 23, 0);
    }
}