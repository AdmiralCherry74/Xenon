using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using Xenon.Common.Data;
using Xenon.Common.Systems;
using Xenon.Content.Biomes;
using Xenon.Content.Emoticons;

namespace Xenon.Content.NPCs.TownNPCs
{
    [AutoloadHead]
    public class Baker : ModNPC
    {
        public const string ShopName = "Shop";

        //private static int ShimmerHeadIndex;
        private static Profiles.StackedNPCProfile NPCProfile;

        //public override void Load()
        //{
        //    // Adds our Shimmer Head to the NPCHeadLoader.
        //    ShimmerHeadIndex = Mod.AddNPCHeadTexture(Type, Texture + "_Shimmer_Head");
        //}

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 23; // The total amount of frames the NPC has

            NPCID.Sets.ExtraFramesCount[Type] = 8; // Generally for Town NPCs, but this is how the NPC does extra things such as sitting in a chair and talking to other NPCs. This is the remaining frames after the walking frames.
            NPCID.Sets.AttackFrameCount[Type] = 4; // The amount of frames in the attacking animation.
            NPCID.Sets.DangerDetectRange[Type] = 720; // The amount of pixels away from the center of the NPC that it tries to attack enemies.
            NPCID.Sets.AttackType[Type] = 0; // The type of attack the Town NPC performs. 0 = throwing, 1 = shooting, 2 = magic, 3 = melee
            NPCID.Sets.AttackTime[Type] = 60; // The amount of time it takes for the NPC's attack animation to be over once it starts.
            NPCID.Sets.AttackAverageChance[Type] = 30; // The denominator for the chance for a Town NPC to attack. Lower numbers make the Town NPC appear more aggressive.
            //NPCID.Sets.HatOffsetY[Type] = 4; // For when a party is active, the party hat spawns at a Y offset.
            //NPCID.Sets.ShimmerTownTransform[Type] = true; // This set says that the Town NPC has a Shimmered form. Otherwise, the Town NPC will become transparent when touching Shimmer like other enemies.

            // Connects this NPC with a custom emote.
            // This makes it when the NPC is in the world, other NPCs will "talk about him".
            // By setting this you don't have to override the PickEmote method for the emote to appear.
            NPCID.Sets.FaceEmote[Type] = ModContent.EmoteBubbleType<BakerEmote>();

            // Influences how the NPC looks in the Bestiary
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers()
            {
                Velocity = 1f, // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
                Direction = 1 // -1 is left and 1 is right. NPCs are drawn facing the left by default but ExamplePerson will be drawn facing the right
                              // Rotation = MathHelper.ToRadians(180) // You can also change the rotation of an NPC. Rotation is measured in radians
                              // If you want to see an example of manually modifying these when the NPC is drawn, see PreDraw
            };

            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            // Set Example Person's biome and neighbor preferences with the NPCHappiness hook. You can add happiness text and remarks with localization (See an example in ExampleMod/Localization/en-US.lang).
            // NOTE: The following code uses chaining - a style that works due to the fact that the SetXAffection methods return the same NPCHappiness instance they're called on.
            NPC.Happiness
                .SetBiomeAffection<OceanBiome>(AffectionLevel.Love)
                .SetBiomeAffection<HallowBiome>(AffectionLevel.Like)
                .SetBiomeAffection<DesertBiome>(AffectionLevel.Dislike)
                .SetNPCAffection(NPCID.PartyGirl, AffectionLevel.Love)
                .SetNPCAffection(NPCID.Stylist, AffectionLevel.Like)
                .SetNPCAffection(NPCID.Princess, AffectionLevel.Like)
                .SetNPCAffection(NPCID.Nurse, AffectionLevel.Dislike)
                .SetNPCAffection(NPCID.ArmsDealer, AffectionLevel.Hate);
                

            NPCProfile = new Profiles.StackedNPCProfile(
                new Profiles.DefaultNPCProfile(Texture, NPCHeadLoader.GetHeadSlot(HeadTexture), Texture + "_Party")
            //new Profiles.DefaultNPCProfile(Texture + "_Shimmer", ShimmerHeadIndex, Texture + "_Shimmer_Party")
            );

            ContentSamples.NpcBestiaryRarityStars[Type] = 2; // We can override the default bestiary star count calculation by setting this.

        }

        public override void SetDefaults()
        {
            NPC.townNPC = true; // Sets NPC to be a Town NPC
            NPC.friendly = true; // NPC Will not attack player
            NPC.width = 30;
            NPC.height = 42;
            NPC.aiStyle = NPCAIStyleID.Passive;
            NPC.damage = 10;
            NPC.defense = 15;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.45f;

            AnimationType = NPCID.Stylist;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange([
				// Sets the preferred biomes of this town NPC listed in the bestiary.
				// With Town NPCs, you usually set this to what biome it likes the most in regards to NPC happiness.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean,
                    new FlavorTextBestiaryInfoElement("Mods.Xenon.Bestiary.Baker")
            ]);
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            int num = NPC.life > 0 ? 1 : 5;

            for (int k = 0; k < num; k++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood);
            }

            // Create gore when the NPC is killed.
            if (Main.netMode != NetmodeID.Server && NPC.life <= 0)
            {
                // Retrieve the gore types. This NPC has shimmer and party variants for head, arm, and leg gore. (12 total gores)
                string variant = "";
                //if (NPC.IsShimmerVariant)
                //    variant += "_Shimmer";
                if (NPC.altTexture == 1)
                    variant += "_Party";
                int hatGore = Mod.Find<ModGore>($"Baker_Gore_PartyChefHat").Type;
                int headGore = Mod.Find<ModGore>($"Baker_Gore_Head").Type;
                int armGore = Mod.Find<ModGore>($"Baker_Gore_Arm").Type;
                int legGore = Mod.Find<ModGore>($"Baker_Gore_Leg").Type;

                // Spawn the gores. The positions of the arms and legs are lowered for a more natural look.
                if (hatGore > 0)
                {
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, hatGore);
                }
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, headGore, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position + new Vector2(0, 20), NPC.velocity, armGore);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position + new Vector2(0, 20), NPC.velocity, armGore);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position + new Vector2(0, 34), NPC.velocity, legGore);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position + new Vector2(0, 34), NPC.velocity, legGore);
            }
        }

        public override void OnSpawn(IEntitySource source)
        {
            if (source is EntitySource_SpawnNPC)
            {
                // A TownNPC is "unlocked" once it successfully spawns into the world.
                TownNPCRespawnSystem.unlockedBakerSpawn = true;
            }
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)
        { // Requirements for the town NPC to spawn.
            if (TownNPCRespawnSystem.unlockedBakerSpawn)
            {
                // If the Baker has spawned in this world before this will return true;
                return true;
            }

            foreach (var player in Main.ActivePlayers)
            {
                // Player has to have a specificed Fruit, Veggietable or other foods in order for the NPC to spawn
                if (player.inventory.Any(item => ItemSets.BakersFood[Type]))
                {
                    return true;
                }
            }

            return false;
        }

        public override ITownNPCProfile TownNPCProfile()
        {
            return NPCProfile;
        }

        public override List<string> SetNPCNameList()
        {
            return new List<string>() {
                "Ms Cake",
                "Plum",
                "Vanellope",
                "Cupcake",
                "Shauna",
                "Serena",
                "Bonnibel",
                "Chica",
                "Blossom",
                "Candy",
                "Kattie",
                "Margaret",
                "Hestia",
            };
        }

        public override void FindFrame(int frameHeight)
        {
            /*npc.frame.Width = 40;
			if (((int)Main.time / 10) % 2 == 0)
			{
				npc.frame.X = 40;
			}
			else
			{
				npc.frame.X = 0;
			}*/
        }

        public override string GetChat()
        {
            WeightedRandom<string> chat = new WeightedRandom<string>();

            #region OtherNPC's
            int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
            int armsDealer = NPC.FindFirstNPC(NPCID.ArmsDealer);
            int nurse = NPC.FindFirstNPC(NPCID.Nurse);
            int stylist = NPC.FindFirstNPC(NPCID.Stylist);
            int angler = NPC.FindFirstNPC(NPCID.Angler);
            int princess = NPC.FindFirstNPC(NPCID.Princess);
            int dryad = NPC.FindFirstNPC(NPCID.Dryad);
            int demolitionist = NPC.FindFirstNPC(NPCID.Demolitionist);
            if (partyGirl >= 0 && Main.rand.NextBool(4))
            {
                chat.Add(Language.GetTextValue("Mods.Xenon.NPCs.Baker.Dialouge.PartyGirlDialouge1", Main.npc[partyGirl].GivenName));
                chat.Add(Language.GetTextValue("Mods.Xenon.NPCs.Baker.Dialouge.PartyGirlDialouge2", Main.npc[partyGirl].GivenName));
                chat.Add(Language.GetTextValue("Mods.Xenon.NPCs.Baker.Dialouge.PartyGirlDialouge3", Main.npc[partyGirl].GivenName));
                chat.Add(Language.GetTextValue("Mods.Xenon.NPCs.Baker.Dialouge.PartyGirlDialouge4", Main.npc[partyGirl].GivenName));
            }
            if (armsDealer >= 0 && Main.rand.NextBool(5))
            {
                chat.Add(Language.GetTextValue("Mods.Xenon.NPCs.Baker.Dialouge.ArmsDealerDialouge1", Main.npc[armsDealer].GivenName));
                chat.Add(Language.GetTextValue("Mods.Xenon.NPCs.Baker.Dialouge.ArmsDealerDialouge2", Main.npc[armsDealer].GivenName));
                chat.Add(Language.GetTextValue("Mods.Xenon.NPCs.Baker.Dialouge.ArmsDealerDialouge3", Main.npc[armsDealer].GivenName));
            }
            if (nurse >= 0 && Main.rand.NextBool(6))
            {
                chat.Add(Language.GetTextValue("Mods.Xenon.NPCs.Baker.Dialouge.NurseDialouge1", Main.npc[nurse].GivenName));
                chat.Add(Language.GetTextValue("Mods.Xenon.NPCs.Baker.Dialouge.NurseDialouge2", Main.npc[nurse].GivenName));
                chat.Add(Language.GetTextValue("Mods.Xenon.NPCs.Baker.Dialouge.NurseDialouge3", Main.npc[nurse].GivenName));
            }
            if (stylist >= 0 && Main.rand.NextBool(7))
            {
                chat.Add(Language.GetTextValue("Mods.Xenon.NPCs.Baker.Dialouge.StylistDialouge1", Main.npc[stylist].GivenName));
                chat.Add(Language.GetTextValue("Mods.Xenon.NPCs.Baker.Dialouge.StylistDialouge2", Main.npc[stylist].GivenName));
            }
            if (angler >= 0 && Main.rand.NextBool(8))
            {
                chat.Add(Language.GetTextValue("Mods.Xenon.NPCs.Baker.Dialouge.AnglerDialouge", Main.npc[angler].GivenName));
            }
            if (princess >= 0 && Main.rand.NextBool(9))
            {
                chat.Add(Language.GetTextValue("Mods.Xenon.NPCs.Baker.Dialouge.PrincessDialouge", Main.npc[princess].GivenName));
            }
            if (dryad >= 0 && Main.rand.NextBool(10))
            {
                chat.Add(Language.GetTextValue("Mods.Xenon.NPCs.Baker.Dialouge.DryadDialouge", Main.npc[dryad].GivenName));
            }
            if (armsDealer >= 0 && partyGirl >= 0 && Main.rand.NextBool(11))
            {
                chat.Add(Language.GetTextValue("Mods.Xenon.NPCs.Baker.Dialouge.PartyGirlArmsDealerDialouge1", Main.npc[partyGirl].GivenName, Main.npc[armsDealer].GivenName));
                chat.Add(Language.GetTextValue("Mods.Xenon.NPCs.Baker.Dialouge.PartyGirlArmsDealerDialouge2", Main.npc[partyGirl].GivenName, Main.npc[armsDealer].GivenName));
            }
            if (armsDealer >= 0 && nurse >= 0 && Main.rand.NextBool(12))
            {
                chat.Add(Language.GetTextValue("Mods.Xenon.NPCs.Baker.Dialouge.ArmsDealerNurseDialouge1", Main.npc[armsDealer].GivenName, Main.npc[nurse].GivenName));
                chat.Add(Language.GetTextValue("Mods.Xenon.NPCs.Baker.Dialouge.ArmsDealerNurseDialouge2", Main.npc[armsDealer].GivenName, Main.npc[nurse].GivenName));
            }
            if (armsDealer >= 0 && demolitionist >= 0 && Main.rand.NextBool(13))
            {
                chat.Add(Language.GetTextValue("Mods.Xenon.NPCs.Baker.Dialouge.ArmsDealerDemolitionistDialouge1", Main.npc[armsDealer].GivenName, Main.npc[demolitionist].GivenName));
                chat.Add(Language.GetTextValue("Mods.Xenon.NPCs.Baker.Dialouge.ArmsDealerDemolitionistDialouge2", Main.npc[armsDealer].GivenName, Main.npc[demolitionist].GivenName));
            }
            #endregion
            #region Events
            if (Main.bloodMoon)
            {
                chat.Add(Language.GetTextValue("Mods.Xenon.NPCs.Baker.Dialouge.BloodMoonDialouge1"), 10);
                chat.Add(Language.GetTextValue("Mods.Xenon.NPCs.Baker.Dialouge.BloodMoonDialouge2"), 10);
                chat.Add(Language.GetTextValue("Mods.Xenon.NPCs.Baker.Dialouge.BloodMoonDialouge3"), 10);
            }
            if (Main.bloodMoon && partyGirl >= 0 && Main.rand.NextBool(4))
            {
                chat.Add(Language.GetTextValue("Mods.Xenon.NPCs.Baker.Dialouge.BloodMoonDialouge4", Main.npc[partyGirl].GivenName));
            }
            if (!Main.dayTime)
            {
                chat.Add(Language.GetTextValue("Mods.Xenon.NPCs.Baker.Dialouge.NightDialouge"), 1.25);
            }
            #endregion
            // These are things that the NPC has a chance of telling you when you talk to it.
            chat.Add(Language.GetTextValue("Mods.Xenon.NPCs.Baker.Dialouge.StandardDialouge1"));
            chat.Add(Language.GetTextValue("Mods.Xenon.NPCs.Baker.Dialouge.StandardDialouge2"));
            chat.Add(Language.GetTextValue("Mods.Xenon.NPCs.Baker.Dialouge.StandardDialouge3"));
            chat.Add(Language.GetTextValue("Mods.Xenon.NPCs.Baker.Dialouge.StandardDialouge4"));
            chat.Add(Language.GetTextValue("Mods.Xenon.NPCs.Baker.Dialouge.StandardDialouge5"));
            chat.Add(Language.GetTextValue("Mods.Xenon.NPCs.Baker.Dialouge.CommonDialouge"), 5.0);
            chat.Add(Language.GetTextValue("Mods.Xenon.NPCs.Baker.Dialouge.UncommonDialouge1"), 0.5);
            chat.Add(Language.GetTextValue("Mods.Xenon.NPCs.Baker.Dialouge.UncommonDialouge2"), 0.5);



            string chosenChat = chat; // chat is implicitly cast to a string. This is where the random choice is made.
            return chosenChat;
        }

        //public override void SetChatButtons(ref string button, ref string button2)
        //{ // What the chat buttons are when you open up the chat UI
        //    button = Language.GetTextValue("LegacyInterface.28"); // This is the key to the word "Shop"
        //    button2 = "Awesomeify";
        //    if (Main.LocalPlayer.HasItem(ItemID.HiveBackpack))
        //    {
        //        button = "Upgrade " + Lang.GetItemNameValue(ItemID.HiveBackpack);
        //    }
        //}

        //public override void OnChatButtonClicked(bool firstButton, ref string shop)
        //{
        //    if (firstButton)
        //    {
        //        // We want 3 different functionalities for chat buttons, so we use HasItem to change button 1 between a shop and upgrade action.

        //        if (Main.LocalPlayer.HasItem(ItemID.HiveBackpack))
        //        {
        //            SoundEngine.PlaySound(SoundID.Item37); // Reforge/Anvil sound

        //            Main.npcChatText = UpgradedText.Value;

        //            int hiveBackpackItemIndex = Main.LocalPlayer.FindItem(ItemID.HiveBackpack);
        //            var entitySource = NPC.GetSource_GiftOrReward();

        //            Main.LocalPlayer.inventory[hiveBackpackItemIndex].TurnToAir();
        //            Main.LocalPlayer.QuickSpawnItem(entitySource, ModContent.ItemType<WaspNest>());

        //            return;
        //        }

        //        shop = ShopName; // Name of the shop tab we want to open.
        //    }
        //}

        // Not completely finished, but below is what the NPC will sell
        public override void AddShops()
        {
            var npcShop = new NPCShop(Type, ShopName)
                .Add(new Item(ItemID.PumpkinPie) { shopCustomPrice = Item.buyPrice(silver: 10) });

            if (Main.hardMode)
            {
                npcShop.Add(new Item(ItemID.PumpkinPie) { shopCustomPrice = Item.buyPrice(gold: 1) });
            }
            if (DateTime.Now.Month == 12)
            {
                npcShop.Add(new Item(ItemID.ChristmasPudding) { shopCustomPrice = Item.buyPrice(silver: 10) });
                npcShop.Add(new Item(ItemID.GingerbreadCookie) { shopCustomPrice = Item.buyPrice(silver: 15) });
                npcShop.Add(new Item(ItemID.SugarCookie) { shopCustomPrice = Item.buyPrice(silver: 15) });
            }
            npcShop.Register(); // Name of this shop tab
        }


        public override void ModifyActiveShop(string shopName, Item[] items)
        {
            foreach (Item item in items)
            {
                // Skip 'air' items and null items.
                if (item == null || item.type == ItemID.None)
                {
                    continue;
                }
            }
        }

        public override bool CanGoToStatue(bool toKingStatue) => false;

        // Make something happen when the npc teleports to a statue. Since this method only runs server side, any visual effects like dusts or gores have to be synced across all clients manually.
        public override void OnGoToStatue(bool toKingStatue)
        {
            if (Main.netMode == NetmodeID.Server)
            {
                ModPacket packet = Mod.GetPacket();
                packet.Write((byte)NPC.whoAmI);
                packet.Send();
            }
            else
            {
                StatueTeleport();
            }
        }

        // Create a square of pixels around the NPC on teleport.
        public void StatueTeleport()
        {
            for (int i = 0; i < 30; i++)
            {
                Vector2 position = Main.rand.NextVector2Square(-20, 21);
                if (Math.Abs(position.X) > Math.Abs(position.Y))
                {
                    position.X = Math.Sign(position.X) * 20;
                }
                else
                {
                    position.Y = Math.Sign(position.Y) * 20;
                }

                Dust.NewDustPerfect(NPC.Center + position, DustID.Enchanted_Gold, Vector2.Zero).noGravity = true;
            }
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 20;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 20;
            randExtraCooldown = 20;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileID.MolotovCocktail;
            attackDelay = 5;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }
    }
}