using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.Map;
using Terraria.ModLoader;
using Xenon.Common;
using Xenon.Content.Items.Armor.PreHardmode.Metal;

namespace Xenon.Hooks;

//internal class TerraduxArmorSprites : GlobalItem
//{
//    public override void Load()
//    {
//        TextureAssets.Item[ModContent.ItemType<AluminumChainmail>()] = ModContent.Request<Texture2D>("Xenon/Assets/Textures/AluminumChainmail_Terradux");
//    }
//    public override void Unload()
//    {
//        TextureAssets.Item[ItemID.WandofSparking] = ModContent.Request<Texture2D>($"Terraria/Images/Item_{ItemID.WandofSparking}");
//    }
//}