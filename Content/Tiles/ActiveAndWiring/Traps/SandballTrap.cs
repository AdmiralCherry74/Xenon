using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Projectiles.Traps;

namespace Xenon.Content.Tiles.ActiveAndWiring.Traps
{
    public class SandballTrap : ModTile
    {
        public override void SetStaticDefaults()
        {
            AddMapEntry(new Color(99, 89, 85), this.GetLocalization("MapEntry"));
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileFrameImportant[Type] = true;
            DustType = DustID.Sand;
        }
        public override bool Slope(int i, int j)
        {
            Main.tile[i, j].TileFrameX += 18;
            if (Main.tile[i, j].TileFrameX > 90) Main.tile[i, j].TileFrameX = 0;
            return false;
        }
        public override void HitWire(int i, int j)
        {
            Tile tile = Main.tile[i, j];
            int style = tile.TileFrameY / 18;
            Vector2 spawnPosition;
            // This logic here corresponds to the orientation of the sprites in the spritesheet, change it if your tile is different in design.
            int horizontalDirection = tile.TileFrameX == 0 ? -1 : tile.TileFrameX == 18 ? 1 : 0;
            int verticalDirection = tile.TileFrameX < 36 ? 0 : tile.TileFrameX < 72 ? -1 : 1;
            // Each trap style within this Tile shoots different projectiles.
            if (style == 0)
            {
                // Wiring.CheckMech checks if the wiring cooldown has been reached. Put a longer number here for less frequent projectile spawns. 200 is the dart/flame cooldown. Spear is 90, spiky ball is 300
                if (Wiring.CheckMech(i, j, 60))
                {
                    spawnPosition = new Vector2(i * 16 + 8 + 0 * horizontalDirection, j * 16 + 9 + 0 * verticalDirection); // The extra numbers here help center the projectile spawn position if you need to.

                    // In a real mod you should be spawning projectiles that are both hostile and friendly to do damage to both players and NPC, as Terraria traps do.
                    // Make sure to change velocity, projectile, damage, and knockback.
                    Projectile.NewProjectile(Wiring.GetProjectileSource(i, j), spawnPosition, new Vector2(horizontalDirection, verticalDirection) * 6f, ModContent.ProjectileType<QuicksandBall>(), 20, 2f, Main.myPlayer);
                }
            }
        }
    }
}