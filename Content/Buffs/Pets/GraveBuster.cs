using Xenon.Content.Projectiles;
using Terraria;
using Terraria.ModLoader;

namespace Xenon.Content.Buffs.Pets;
public class GraveBuster : ModBuff
{
    public override void SetStaticDefaults()
    {
        Main.buffNoTimeDisplay[Type] = true;
        Main.projPet[Type] = true;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        bool unused = false;
        player.BuffHandle_SpawnPetIfNeededAndSetTime(buffIndex, ref unused, ModContent.ProjectileType<Projectiles.Pets.GraveBuster>());
    }
}
