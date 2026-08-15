using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Projectiles.Melee.Sword;

namespace Xenon.Content.Items.Weapons.Melee.Broadswords;

public class IodineGreatsword : ModItem
//The Iodine Greatsword is an upcoming sword for Insane mode. Iodine is planned to be the tier two ore. with this being the sword with a projectile planned for it.
//Jona made the sprites for the Iodine Greatsword, Greatbow, and Bar. and since they were unused, he offered them and I took it. Thanks Jona!
//Will not be introduced offically right now
{
    private int fireDelay = 75;
    public override void SetDefaults()
    {
        Item.width = 26;
        Item.height = 26;
        Item.scale = 2f;

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 30;
        Item.useAnimation = 30;
        Item.autoReuse = true;

        Item.DamageType = DamageClass.Melee;
        Item.damage = 169;
        Item.knockBack = 8f;
        Item.crit = 0;
        Item.shoot = ModContent.ProjectileType<AncientTerraBeam>(); //uses the ancient terra-beam for now
        Item.shootSpeed = 16;

        Item.value = Item.buyPrice(gold: 20);
        Item.UseSound = SoundID.Item1;
        Item.rare = ItemRarityID.Master;
    }
    public override void HoldItem(Player player)
    {
        if (fireDelay > 0 && player.itemAnimation > 0) fireDelay--;
        if (fireDelay == 0)
        {
            Vector2 mousePos = Main.MouseScreen;
            float velX = mousePos.X + Main.screenPosition.X - player.Center.X;
            float velY = mousePos.Y + Main.screenPosition.Y - player.Center.Y;
            Vector2 v = new(velX, velY); v.Normalize(); v *= Item.shootSpeed;
            int p = Projectile.NewProjectile(player.GetSource_ItemUse(Item), player.Center, v, ModContent.ProjectileType<AncientTerraBeam>(), 87, 6f);
            Main.projectile[p].owner = player.whoAmI;
            fireDelay = 24;
        }
    }
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        return false;
    }
}