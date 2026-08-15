using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Projectiles.Tools.GrapplingHookProj;

namespace Xenon.Content.Items.Tools.GrapplingHooks
{
    public class FlintHook : ModItem
    {
        public override void SetDefaults()
        {
            //If you do not use Item.CloneDefaults(), you must set the following values for the hook to work properly:
            Item.useStyle = ItemUseStyleID.None;
            Item.useTime = 0;
            Item.useAnimation = 0;
            Item.UseSound = SoundID.Item1;
            Item.rare = ItemRarityID.Blue;

            Item.shootSpeed = 12.25f; // This defines how quickly the hook is shot.
            Item.shoot = ModContent.ProjectileType<FlintHookProj>(); // Makes the item shoot the hook's projectile when used.
        }
    }
}