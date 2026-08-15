using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Xenon.Content.Items.Consumables.StatIncreasers;

namespace Xenon.Common.Globals.XenonPlayerGlobals
{
    public class XenonStatIncrease : ModPlayer
    {
        public int VitalPrismiteUses;
        //public int exampleManaCrystals;

        public override void ModifyMaxStats(out StatModifier health, out StatModifier mana)  //out StatModifier mana
        {
            health = StatModifier.Default;
            health.Base = VitalPrismiteUses * VitalPrismite.LifePerVP;
            // Alternatively:  health = StatModifier.Default with { Base = exampleLifeFruits * ExampleLifeFruit.LifePerFruit };
            mana = StatModifier.Default;
            //mana.Base = exampleManaCrystals * ExampleManaCrystal.ManaPerCrystal;
            // Alternatively:  mana = StatModifier.Default with { Base = exampleManaCrystals * ExampleManaCrystal.ManaPerCrystal };
        }

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = Mod.GetPacket();
            packet.Write((byte)Xenon.XenonMod.MessageType.XenonStatIncreasePlayerSync);
            packet.Write((byte)Player.whoAmI);
            packet.Write((byte)VitalPrismiteUses);
            //packet.Write((byte)exampleManaCrystals);
            packet.Send(toWho, fromWho);
        }

        // Called in ExampleMod.Networking.cs
        public void ReceivePlayerSync(BinaryReader reader)
        {
            VitalPrismiteUses = reader.ReadByte();
            //exampleManaCrystals = reader.ReadByte();
        }

        public override void CopyClientState(ModPlayer targetCopy)
        {
            XenonStatIncrease clone = (XenonStatIncrease)targetCopy;
            clone.VitalPrismiteUses = VitalPrismiteUses;
            //clone.exampleManaCrystals = exampleManaCrystals;
        }

        public override void SendClientChanges(ModPlayer clientPlayer)
        {
            XenonStatIncrease clone = (XenonStatIncrease)clientPlayer;

            if (VitalPrismiteUses != clone.VitalPrismiteUses) //|| exampleManaCrystals != clone.exampleManaCrystals)
            {
                // This example calls SyncPlayer to send all the data for this ModPlayer when any change is detected, but if you are dealing with a large amount of data you should try to be more efficient and use custom packets to selectively send only specific data that has changed.
                SyncPlayer(toWho: -1, fromWho: Main.myPlayer, newPlayer: false);
            }
        }

        // NOTE: The tag instance provided here is always empty by default.
        // Read https://github.com/tModLoader/tModLoader/wiki/Saving-and-loading-using-TagCompound to better understand Saving and Loading data.
        public override void SaveData(TagCompound tag)
        {
            tag["VitalPrismiteUses"] = VitalPrismiteUses;
            //tag["exampleManaCrystals"] = exampleManaCrystals;
        }

        public override void LoadData(TagCompound tag)
        {
            VitalPrismiteUses = tag.GetInt("VitalPrismiteUses");
            //exampleManaCrystals = tag.GetInt("exampleManaCrystals");
        }
    }
}