using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Dusts;
using Xenon.Content.Items.Materials.BarsGems;
using Xenon.Content.Items.Weapons.Ranged.Bows;

namespace Xenon.Content.Items.Tools.CuttingAxes;

public class CinnabarAxe : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 24;
        Item.height = 24;
        Item.useTime = 19;
        Item.useAnimation = 26;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = true;

        Item.damage = 5;
        Item.DamageType = DamageClass.Melee;
        Item.axe = 10;
        Item.knockBack = 4.5f;

        Item.rare = ItemRarityID.White;
        Item.value = Item.sellPrice(silver: 27);
    }
}
