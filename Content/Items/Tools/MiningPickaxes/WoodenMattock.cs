using Avalon.Items.Accessories.Vanity;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Armor.Vanity.OreCrowns;
using Xenon.Content.Items.Materials;
using Xenon.Content.Items.Materials.BarsGems;

namespace Xenon.Content.Items.Tools.MiningPickaxes;

public class WoodenMattock : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 30;
        Item.height = 30;
        Item.useTime = 15;
        Item.useAnimation = 21;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.autoReuse = true;
        Item.useTurn = true;
        Item.UseSound = SoundID.Item1;

        Item.pick = 25;
        Item.tileBoost = -1;
        Item.knockBack = 1.75f;
        Item.damage = 1;
        Item.DamageType = DamageClass.Melee;
    }
}
