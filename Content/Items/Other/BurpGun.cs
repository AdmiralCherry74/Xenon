using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.Other;

public class BurpGun : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;

        Item.useStyle = ItemUseStyleID.HiddenAnimation;
        Item.useTime = 1;
        Item.useAnimation = 1;
        Item.useTurn = true;
        Item.autoReuse = false;

        Item.value = Item.buyPrice(gold: 1);
        Item.rare = ItemRarityID.Green;
    }
    #region Sound Effects
    public override bool? UseItem(Player player)
    {

        if (Main.rand.NextBool(8))
        {
            SoundEngine.PlaySound(LongBurp, player.Center);
        }
        else if (Main.rand.NextBool(16))
        {
            SoundEngine.PlaySound(SecretBurp, player.Center);
        }
        else
        {
            switch (Main.rand.Next(3))
            {
                case 0:
                    SoundEngine.PlaySound(Burp1, player.Center);
                    break;
                case 1:
                    SoundEngine.PlaySound(Burp2, player.Center);
                    break;
                case 2:
                    SoundEngine.PlaySound(Burp3, player.Center);
                    break;
            }
        }
        return true;
    }
    static SoundStyle Burp1 = new SoundStyle($"Xenon/Assets/SFX/StomachOfCthulhuBurp1")
    {
        Volume = 2f,
        Pitch = 0f,
        PitchVariance = 0f,
        MaxInstances = 10,
    };
    static SoundStyle Burp2 = new SoundStyle($"Xenon/Assets/SFX/StomachOfCthulhuBurp2")
    {
        Volume = 2f,
        Pitch = 0f,
        PitchVariance = 0f,
        MaxInstances = 10,
    };
    static SoundStyle Burp3 = new SoundStyle($"Xenon/Assets/SFX/StomachOfCthulhuBurp3")
    {
        Volume = 2f,
        Pitch = 0f,
        PitchVariance = 0f,
        MaxInstances = 10,
    };
    static SoundStyle SecretBurp = new SoundStyle($"Xenon/Assets/SFX/StomachOfCthulhuBurpRare")
    {
        Volume = 2f,
        Pitch = 0f,
        PitchVariance = 0f,
        MaxInstances = 10,
    };
    static SoundStyle LongBurp = new SoundStyle($"Xenon/Assets/SFX/StomachOfCthulhuDeathBurp")
    {
        Volume = 2f,
        Pitch = -0.75f,
        PitchVariance = 0f,
        MaxInstances = 10,
    };
    #endregion
}