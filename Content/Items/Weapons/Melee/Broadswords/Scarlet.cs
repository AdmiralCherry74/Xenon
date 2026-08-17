using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Buffs.Debuffs;
using Xenon.Content.Buffs.Debuffs.WeaponSpecificDebuff;

namespace Xenon.Content.Items.Weapons.Melee.Broadswords;

public class Scarlet : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;

        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.useTurn = true;
        Item.autoReuse = false;

        Item.DamageType = DamageClass.Melee;
        Item.damage = 20;
        Item.knockBack = 5;
        Item.crit = 2;

        Item.value = Item.buyPrice(gold: 10);
        Item.rare = ItemRarityID.Green;
    }

    #region Scarlet Sound Effects
    public override bool? UseItem(Player player)
    {
        switch (Main.rand.Next(3))
        {
            case 0:
                SoundEngine.PlaySound(ScarletSwing1, player.Center);
                break;
            case 1:
                SoundEngine.PlaySound(ScarletSwing2, player.Center);
                break;
            case 2:
                SoundEngine.PlaySound(ScarletSwing3, player.Center);
                break;
        }
        return true;
    }
    static SoundStyle ScarletSwing1 = new SoundStyle($"Xenon/Assets/SFX/ScarletSwing0")
    {
        Volume = 1f,
        Pitch = 0f,
        PitchVariance = 0f,
        MaxInstances = 10,
    };
    static SoundStyle ScarletSwing2 = new SoundStyle($"Xenon/Assets/SFX/ScarletSwing1")
    {
        Volume = 1f,
        Pitch = 0f,
        PitchVariance = 0f,
        MaxInstances = 10,
    };
    static SoundStyle ScarletSwing3 = new SoundStyle($"Xenon/Assets/SFX/ScarletSwing2")
    {
        Volume = 1f,
        Pitch = 0f,
        PitchVariance = 0f,
        MaxInstances = 10,
    };
    #endregion
    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        target.AddBuff(ModContent.BuffType<WeakestWeaponDefensivePierce>(), 150);
    }
}