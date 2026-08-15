using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common;
using Xenon.Common.Globals.XenonPlayerGlobals;

namespace Xenon;

public class XenonMod : Mod
{
    public static Color CorrosionBiomeSightColor = new Color(227, 236, 58);
    public static Color SomnolentBiomeSightColor = new Color(10, 25, 75);
    public const string TextureAssetsPath = "Assets/Textures";
    public static bool AvalonContentEnabled = ModLoader.HasMod("Avalon");
    public static bool TheConfectionRebirthContentEnabled = ModLoader.HasMod("TheConfectionRebirth");
    public override void Load()
    {
        while (ModHook.RegisteredHooks.TryDequeue(out ModHook? hook))
        {
            hook.ApplyHook();
        }
        BackgroundReflectionUtilities.Load();
    }
    public override void Unload()
    {
        BackgroundReflectionUtilities.Unload();
    }
    internal enum MessageType : byte
    {
        XenonStatIncreasePlayerSync
    }
    public override void HandlePacket(BinaryReader reader, int whoAmI)
    {
        MessageType msgType = (MessageType)reader.ReadByte();

        switch (msgType)
        {
            // This message syncs ExampleStatIncreasePlayer.exampleLifeFruits and ExampleStatIncreasePlayer.exampleManaCrystals
            case MessageType.XenonStatIncreasePlayerSync:
                byte playerNumber = reader.ReadByte();
                XenonStatIncrease xenonPlayer = Main.player[playerNumber].GetModPlayer<XenonStatIncrease>();
                xenonPlayer.ReceivePlayerSync(reader);

                if (Main.netMode == NetmodeID.Server)
                {
                    // Forward the changes to the other clients
                    xenonPlayer.SyncPlayer(-1, whoAmI, false);
                }
                break;
        }
    }
}
