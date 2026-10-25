using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Data;
using Xenon.Common.Globals.XenonPlayerGlobals;
using Xenon.Content.Buffs.Epibuffs.OreFruitBuffs;

namespace Xenon.Content.Buffs.Debuffs.Counterable
{
    public class Nausea : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;  // Is it a debuff?
            Main.pvpBuff[Type] = false; // Players can give other players buffs, which are listed as pvpBuff
            Main.buffNoSave[Type] = false; // Causes this buff not to persist when exiting and rejoining the world
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<XenonNauseaBuffPlayer>().NauseaDebuff = true;
            player.GetModPlayer<XenonNauseaBuffPlayer>().SpecialFoodCount = 0;

            #region Clear and Prevent food buffs
            player.buffImmune[BuffID.WellFed] = true;
            player.buffImmune[BuffID.WellFed2] = true;
            player.buffImmune[BuffID.WellFed3] = true;
            player.buffImmune[ModContent.BuffType<CopperGrapefruitBuff>()] = true;
            player.buffImmune[ModContent.BuffType<AluminumGrapefruitBuff>()] = true;
            player.buffImmune[ModContent.BuffType<TinGrapefruitBuff>()] = true;
            player.buffImmune[ModContent.BuffType<IronLemonBuff>()] = true;
            player.buffImmune[ModContent.BuffType<CinnabarLemonBuff>()] = true;
            player.buffImmune[ModContent.BuffType<LeadLemonBuff>()] = true;
            player.buffImmune[ModContent.BuffType<SilverApricotBuff>()] = true;
            player.buffImmune[ModContent.BuffType<IndiumApricotBuff>()] = true;
            player.buffImmune[ModContent.BuffType<TungstenApricotBuff>()] = true;
            player.buffImmune[ModContent.BuffType<GoldAppleBuff>()] = true;
            player.buffImmune[ModContent.BuffType<FluoriteAppleBuff>()] = true;
            player.buffImmune[ModContent.BuffType<PlatinumAppleBuff>()] = true;
            #endregion
        }
    }
    public class XenonNauseaBuffPlayer : ModPlayer
    {
        public bool NauseaDebuff;
        public int SpecialFoodCount = 0;

        public override void ResetEffects()
        {
            NauseaDebuff = false;
        }

        public override void PreUpdateBuffs()
        {
            if (Player.GetModPlayer<XenonNauseaBuffPlayer>().SpecialFoodCount > 2)
            {
                Player.AddBuff(ModContent.BuffType<Nausea>(), 18000);
            }
        }
        public override bool CanUseItem(Item item)
        {
            if (NauseaDebuff)
            {
                if (ItemID.Sets.IsFood[item.type] || ItemSets.FoodOrDrinkLikeConsumables[item.type])
                {
                    return false;
                }
            }
            return true;
        }
    }
}