using Avalon.Common.Players;
using Avalon.Items.Other;
using Microsoft.Xna.Framework;
using System;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Xenon.Content.Biomes;
using Xenon.Content.Buffs.Debuffs;
using Xenon.Content.Buffs.Debuffs.Counterable;
using Xenon.Content.Buffs.Other;
using Xenon.Content.Items.Consumables;
using Xenon.Content.Items.Fish;
using Xenon.Content.Items.Fish.Quest;
using Xenon.Content.Items.Fish.Valuable;
using Xenon.Content.Items.Other;

namespace Xenon.Common.Globals.XenonPlayerGlobals;

public class BakersHandbooksBool : ModPlayer
{
    public bool BakersHandbookPurityUsed;

    public override void SaveData(TagCompound tag)
    {
        tag["BakersHandbookPurityUsed"] = BakersHandbookPurityUsed;
    }
    public override void LoadData(TagCompound tag)
    {
        BakersHandbookPurityUsed = tag.GetBool("BakersHandbookPurityUsed");
    }
}