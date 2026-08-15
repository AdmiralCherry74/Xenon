using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Xenon.Content.Buffs.Debuffs.WeaponSpecificDebuff
{
    public class GlobalNPCSpecificallyForWeaponDefensivePierceLikeDebuffs : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public bool WeakestWeaponDefenseDebuff;
        public bool WeakerWeaponDefenseDebuff;

        public override void ResetEffects(NPC npc)
        {
            WeakestWeaponDefenseDebuff = false;
            WeakestWeaponDefenseDebuff = false;
        }
        public override void ModifyIncomingHit(NPC npc, ref NPC.HitModifiers modifiers)
        {
            if (WeakestWeaponDefenseDebuff)
            {
                modifiers.Defense -= 3;
            }
            if (WeakerWeaponDefenseDebuff)
            {
                modifiers.Defense -= 4;
            }
        }
        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            // This simple color effect indicates that the buff is active
            if (WeakestWeaponDefenseDebuff || WeakerWeaponDefenseDebuff)
            {
                drawColor.G /= 2;
            }
        }
    }
}
