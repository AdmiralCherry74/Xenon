//using Terraria;
//using Terraria.ID;
//using Terraria.Localization;
//using Terraria.ModLoader;
//using Xenon.Common;

//namespace Xenon.Hooks;

//internal class ItemNameChange : ModHook
//{
//    protected override void Apply()
//    {
//        On_Lang.GetItemName += On_Lang_GetItemName;
//    }
//    private LocalizedText On_Lang_GetItemName(On_Lang.orig_GetItemName orig, int id)
//    {
//        if (id == ItemID.CrimsonHelmet)
//        {
//            return Language.GetText("Mods.Xenon.VanillaItemRenames.CrimsonHelmet");
//        }
//        return orig.Invoke(id);
//    }
//}