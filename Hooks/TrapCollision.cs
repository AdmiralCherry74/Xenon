using Terraria;
using Terraria.ModLoader;
using Xenon.Common;
using Xenon.Content.Effects.Debuffs;
using Xenon.Content.Tiles;

namespace Xenon.Hooks
{
    internal class TrapCollision : ModHook
    {
        protected override void Apply()
        {
            On_Collision.CanTileHurt += On_Collision_CanTileHurt;
            On_Player.ApplyTouchDamage += On_Player_ApplyTouchDamage;
        }

        private void On_Player_ApplyTouchDamage(On_Player.orig_ApplyTouchDamage orig, Player self, int tileId, int x, int y)
        {
            if (tileId == ModContent.TileType<FrozenLava>())
            {
                self.AddBuff(ModContent.BuffType<Iceburn>(), 1);
            }
        }

        private bool On_Collision_CanTileHurt(On_Collision.orig_CanTileHurt orig, ushort type, int i, int j, Player player)
        {
            if (player != null)
            {
                if (type == ModContent.TileType<FrozenLava>())
                {
                    return true;
                }
            }
            return orig.Invoke(type, i, j, player);
        }
    }
}
