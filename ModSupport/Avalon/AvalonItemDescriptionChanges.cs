using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace Xenon.ModSupport.Avalon
{
    [ExtendsFromMod("Avalon")]
    public class AvalonItemDescriptionChanges : GlobalItem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return XenonMod.AvalonContentEnabled;
        }
    }
}
