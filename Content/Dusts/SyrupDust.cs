using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Dusts;

public class SyrupDust : ModDust
{
    public override void SetStaticDefaults()
    {
        UpdateType = DustID.Honey2;
    }
}
