using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items.Placeable.Blocks.ActiveAndWiring.Traps.Contact;
using Xenon.Content.Projectiles.Ranged.Equipment.Lethal;

namespace Xenon.Content.Items.Weapons.Ranged.Equipment.Lethals
{
    public class Grubnade : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.ItemsThatCountAsBombsForDemolitionistToSpawn[Type] = true;
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.shootSpeed = 5f;
            Item.shoot = ModContent.ProjectileType<GrubnadeProj>();
            Item.width = 10;
            Item.height = 26;
            Item.damage = 18;
            Item.DamageType = DamageClass.Ranged;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.UseSound = SoundID.Item1;
            Item.useAnimation = 40;
            Item.useTime = 40;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.rare = ItemRarityID.Blue;
        }
    }
}