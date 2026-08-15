using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Globals.XenonItemGlobals;
using Xenon.Content.Items.Accessories;
using Xenon.Content.Items.Accessories.Shield;
using Xenon.Content.Items.Materials;
using Xenon.Content.Items.Materials.WorldInfectionMaterials;
using Xenon.Content.Items.Weapons.Melee.Broadswords;

namespace Xenon.Common.Globals.XenonNPCGlobals
{
    public class XenonNPCLootChanges : GlobalNPC
    {

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (Data.NPCSets.Salamanders[npc.type])
            {
                //remove bitch ass rally maybe
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Scarlet>(), 34, 1, 1));
            }
            if (npc.type == NPCID.BoneSerpentHead)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BoneSerpentCoccyx>(), 50, 1, 1));
            }
            if (npc.type == NPCID.UndeadViking)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Greatsword>(), 26, 1, 1));
            }
            if (npc.type == NPCID.FireImp)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ImpWings>(), 43, 1, 1));
            }
        }
    }

    public class SoulConditionsAndShit : GlobalNPC
    {
        public override void ModifyGlobalLoot(GlobalLoot globalLoot)
        {
            globalLoot.Remove(new ItemDropWithConditionRule(520, 5, 1, 1, new Conditions.SoulOfLight()));
            globalLoot.Remove(new ItemDropWithConditionRule(521, 5, 1, 1, new Conditions.SoulOfNight()));

            globalLoot.Add(ItemDropRule.ByCondition(new PuritySoulConditions(), ModContent.ItemType<SoulOfRight>(), 5, 1, 1));
            globalLoot.Add(ItemDropRule.ByCondition(new NewCorruptionSoulConditions(), ItemID.SoulofNight, 5, 1, 1));
            globalLoot.Add(ItemDropRule.ByCondition(new CrimsonSoulConditions(), ModContent.ItemType<SoulofSpite>(), 5, 1, 1));
            globalLoot.Add(ItemDropRule.ByCondition(new CorrosionSoulConditions(), ModContent.ItemType<SoulofBlight>(), 5, 1, 1));
            globalLoot.Add(ItemDropRule.ByCondition(new NewHallowSoulConditions(), ItemID.SoulofLight, 5, 1, 1));
            globalLoot.Add(ItemDropRule.ByCondition(new SomnolentSoulConditions(), ModContent.ItemType<SoulofTwilight>(), 5, 1, 1));
        }
    }
}
