using System;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Tiles.Natural.Ores.Gems.GemTrees;

public class GarnetGemLeaves : ModGore
{
    public override void SetStaticDefaults()
    {

        ChildSafety.SafeGore[Type] = true;
        GoreID.Sets.SpecialAI[Type] = 3;
        GoreID.Sets.PaintedFallingLeaf[Type] = true;
    }
}
