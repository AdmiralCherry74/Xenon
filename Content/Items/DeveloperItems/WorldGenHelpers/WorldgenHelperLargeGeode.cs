using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Xenon.Content.Items.DeveloperItems.WorldGenHelpers;

class WorldgenHelperLargeGeode : ModItem
{
    public override bool IsLoadingEnabled(Mod mod)
    {
        return true;
    }
    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Purple;
        Item.width = 20;
        Item.maxStack = 1;
        Item.useAnimation = Item.useTime = 40;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.value = 0;
        Item.height = 20;
		Item.autoReuse = true;
        Item.UseSound = new SoundStyle($"Xenon/Assets/SFX/CrystalineGolemHit") { Pitch = 0f, Volume = 0.4f, PitchVariance = 0f, MaxInstances = 5 };
    }
    public static float Distance(Vector2 a, Vector2 b)
    {
        float diff_x = a.X - b.X;
        float diff_y = a.Y - b.Y;
        return (float)Math.Sqrt(diff_x * diff_x + diff_y * diff_y);
    }

    public override bool? UseItem(Player player)
    {
        int x = (int)Main.MouseWorld.X / 16;
        int y = (int)Main.MouseWorld.Y / 16;

        if (player.ItemAnimationJustStarted)
        {
            //WorldGeneration.LargeGeode.(x, y);
        }
        return false;
    }
}
