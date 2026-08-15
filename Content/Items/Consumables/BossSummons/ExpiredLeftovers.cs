using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Biomes;
using Xenon.Content.Items.Materials.WorldInfectionMaterials;
using Xenon.Content.Items.Tools.ConversionTools.Powders;
using Xenon.Content.NPCs.Bosses;
using Xenon.Content.NPCs.Bosses.StomachOfCthulhu;

namespace Xenon.Content.Items.Consumables.BossSummons;

public class ExpiredLeftovers : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 3;
    }
    public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup)
    {
        itemGroup = ContentSamples.CreativeHelper.ItemGroup.BossSpawners;
    }
    public override void SetDefaults()
    {
        Item.CloneDefaults(ItemID.WormFood);
    }

    public override bool CanUseItem(Player player)
    {
        return !NPC.AnyNPCs(ModContent.NPCType<StomachOfCthulhu>()) &&
        (player.InModBiome<Corrosion>() || player.InModBiome<CorrosionUnderground>());
    }

    public override bool? UseItem(Player player)
    {
        //NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<BacteriumPrime>());
        //SoundEngine.PlaySound(SoundID.Roar, player.position);
        //return true;
        if (player.whoAmI == Main.myPlayer) // Thanks Examplemod :)
        {
            // If the player using the item is the client
            // (explicitely excluded serverside here)
            SoundEngine.PlaySound(SoundID.Roar, player.position);

            int type = ModContent.NPCType<StomachOfCthulhu>();

            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                // If the player is not in multiplayer, spawn directly
                NPC.SpawnOnPlayer(player.whoAmI, type);
            }
            else
            {
                // If the player is in multiplayer, request a spawn
                // This will only work if NPCID.Sets.MPAllowedEnemies[type] is true, which we set in Mi- BacteriumPrime :)
                NetMessage.SendData(MessageID.SpawnBossUseLicenseStartEvent, number: player.whoAmI, number2: type);
            }
        }

        return true;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<VitriolicPowder>(), 30)
            .AddIngredient(ModContent.ItemType<Bolus>(), 15)
            .AddTile(TileID.DemonAltar)
            .SortAfterFirstRecipesOf(ItemID.WormFood)
            .Register();
    }
}