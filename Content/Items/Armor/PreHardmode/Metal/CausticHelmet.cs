using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Xenon.Common.Globals.XenonPlayerGlobals;
using Xenon.Content.Dusts.WaterSplashes;

namespace Xenon.Content.Items.Armor.PreHardmode.Metal;


[AutoloadEquip(EquipType.Head)]
public class CausticHelmet : ModItem
{
    private const int PercentIncrease = 4;

    public override void SetDefaults()
    {
        Item.width = 14;
        Item.height = 20;

        Item.defense = 6;

        Item.value = Item.sellPrice(0, 0, 80, 0); // (Platinum, Gold, Silver, Copper)
        Item.rare = ItemRarityID.Blue;
    }

    public override void UpdateEquip(Player player)
    {
        player.GetKnockback<GenericDamageClass>() += PercentIncrease / 10;
    }
    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        return head.type == Type && body.type == ModContent.ItemType<CausticScalemail>() && legs.type == ModContent.ItemType<CausticGreaves>();
    }
    public override void UpdateArmorSet(Player player)
    {
        player.setBonus = Language.GetTextValue("Mods.Xenon.SetBonuses.Caustic");
        player.GetModPlayer<XenonPlayer>().KnockbackBoostCaustic = true;
    }
    public override void UpdateVanitySet(Player player)
    {
        if (Main.rand.NextBool(7) && (player.velocity.X > 0 || player.velocity.X < 0|| player.velocity.Y > 0 || player.velocity.Y < 0))
        {
            Dust d = Dust.NewDustDirect(player.position, player.width, player.height, ModContent.DustType<StomachOfCthulhusWaterSplash>());
            d.scale *= 0.8f;
            d.alpha = 132;
            d.velocity *= 0.3f;
            d.velocity += player.velocity + new Vector2(0, 0.9f);
            d.shader = GameShaders.Armor.GetShaderFromItemId(player.dye[Main.rand.Next(3)].type);
        }

        if (Main.rand.NextBool(8) && (player.velocity.X > 0 || player.velocity.X < 0 || player.velocity.Y > 0 || player.velocity.Y < 0))
        {
            Dust d = Dust.NewDustDirect(player.position, player.width, player.height, ModContent.DustType<CorrosionWaterSplash>());
            d.scale *= 0.4f;
            d.alpha = 182;
            d.velocity *= 0.2f;
            d.velocity += player.velocity + new Vector2(0, 0.6f);
            d.shader = GameShaders.Armor.GetShaderFromItemId(player.dye[Main.rand.Next(3)].type);
        }
    }
}
