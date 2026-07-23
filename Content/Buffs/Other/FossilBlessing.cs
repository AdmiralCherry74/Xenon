using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Xenon.Common.Globals.XenonPlayerGlobals;

namespace Xenon.Content.Buffs.Other;

public class FossilBlessing : ModBuff
{
    public override bool RightClick(int buffIndex)
    {
        Main.LocalPlayer.GetModPlayer<XenonPlayer>().FossilBlessingActive = false;
        return base.RightClick(buffIndex);
    }
    public override void Update(Player player, ref int buffIndex)
    {
		player.velocity.X *= 0f;
		player.statDefense += 20;
		player.lifeRegen += 20;
		player.controlJump = false;
		//player.controlDown = false;
		player.controlLeft = false;
		player.controlRight = false;
		//player.controlUp = false;
		player.controlUseItem = false;
		player.controlUseTile = false;
		player.controlThrow = false;
        player.controlMount = false;
        player.controlHook = false;
		player.gravDir = 1f;

        player.mount.Dismount(player);

        for (int i = 0; i < 1; i++)
        {
            int num9 = Dust.NewDust(player.position, player.width, player.height, DustID.Blood, 0f, 0f, 175, default, 1.75f);
            Main.dust[num9].noGravity = true;
            Main.dust[num9].velocity *= 0.75f;
            int num10 = Main.rand.Next(-40, 41);
            int num11 = Main.rand.Next(-40, 41);
            Main.dust[num9].position.X += num10;
            Main.dust[num9].position.Y += num11;
            Main.dust[num9].velocity.X = -num10 * 0.075f;
            Main.dust[num9].velocity.Y = -num11 * 0.075f;
        }
        if (player.buffTime[buffIndex] == 0)
        {
            player.GetModPlayer<XenonPlayer>().FossilBlessingActive = false;
        }
    }
}
