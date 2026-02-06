using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Projectiles.Tools.ConvertingTools.Solutions;

namespace Xenon.Content.Items.Ammo;

public class DungeonSolution : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 99;
    }

    public override void SetDefaults()
    {
        Item.DefaultToSolution(ModContent.ProjectileType<DungeonSpray>());
        Item.value = Item.buyPrice(0, 0, 25);
        Item.rare = ItemRarityID.Orange;
    }
}
