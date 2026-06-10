using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Xenon.Content;
using Xenon.Content.Projectiles.Ranged.Equipment.Lethal;
using Xenon.Content.Projectiles.Tools.FishingBobbers;

namespace Xenon.Content.Items.Tools.FishingRods
{
    public class Regurgitator : ModItem
    {
        public override void SetDefaults()
        {
            Item.fishingPole = 26;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(0, 2, 75);

            Item.shoot = ModContent.ProjectileType<Regurgitator_Bobber>();
            Item.shootSpeed = 13.25f;

            Item.useTime = 8;
            Item.useAnimation = 8;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.UseSound = SoundID.Item1;
        }

        public override void ModifyFishingLine(Projectile bobber, ref Vector2 lineOriginOffset, ref Color lineColor)
        {
            lineOriginOffset = new Vector2(46, -33);
            lineColor = new Color(182, 185, 77);
        }
    }
}
