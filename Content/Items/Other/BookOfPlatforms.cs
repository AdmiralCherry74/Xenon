using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Policy;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Common.Globals.XenonPlayerGlobals;
using Xenon.Content.Biomes.Corrosion;
using Xenon.Content.Biomes.Somnolent;
using Xenon.Content.Items.Materials;
using Xenon.Content.Tiles.Furniture.BiomePlatforms;

namespace Xenon.Content.Items.Other;

public class BookOfPlatforms : ModItem
{
    public override void SetStaticDefaults()
    {
        ItemID.Sets.DisableAutomaticPlaceableDrop[Type] = true;
    }
    public override void SetDefaults()
    {
        Item.autoReuse = true;
        Item.width = 16;
        Item.useTurn = true;
        Item.createTile = ModContent.TileType<FallbackBiomePlatform>();
        Item.useTime = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 1;
        Item.useAnimation = 15;
        Item.height = 16;
    }
    public override bool? UseItem(Player player)
    {
        //Purity
        if (!(player.ZoneSnow || player.ZoneDesert || player.ZoneUndergroundDesert || player.ZoneJungle || player.ZoneSkyHeight))
        {
            if ((Main.screenPosition.Y / 16 < Main.worldSurface + 1))
            {
                if (player.ZoneCorrupt)
                {
                    Item.createTile = ModContent.TileType<CorruptGrassPlatformEcho>();
                }
                else if (player.ZoneCrimson)
                {
                    Item.createTile = ModContent.TileType<CrimsonGrassPlatformEcho>();
                }
                else if (player.InModBiome<Corrosion>())
                {
                    Item.createTile = ModContent.TileType<CorrosionGrassPlatformEcho>();
                }

                else if (player.ZoneHallow)
                {
                    Item.createTile = ModContent.TileType<HallowGrassPlatformEcho>();
                }
                else if (player.InModBiome<Somnolent>())
                {
                    Item.createTile = ModContent.TileType<SomnolentGrassPlatformEcho>();
                }

                else
                {
                    Item.createTile = ModContent.TileType<GrassPlatformEcho>();
                }
            }
            else
            {
                if (player.ZoneCorrupt)
                {
                    Item.createTile = ModContent.TileType<EbonstonePlatformEcho>();
                }
                else if (player.ZoneCrimson)
                {
                    Item.createTile = ModContent.TileType<CrimstonePlatformEcho>();
                }
                else if (player.InModBiome<CorrosionUnderground>())
                {
                    Item.createTile = ModContent.TileType<GutstonePlatformEcho>();
                }

                else if (player.ZoneHallow)
                {
                    Item.createTile = ModContent.TileType<PearlstonePlatformEcho>();
                }
                //else if (player.InModBiome<Somnolent>())
                //{
                //    Item.createTile = ModContent.TileType<SomnolentFrozenPlatformEcho>();
                //}
                else
                {
                    Item.createTile = ModContent.TileType<StonePlatformEcho>();
                }
            }
        }

        //Jungle and Underground Jungle
        else if (player.ZoneJungle && !(player.ZoneDesert || player.ZoneUndergroundDesert || player.ZoneSnow || player.ZoneSkyHeight))
        {
            if (player.ZoneCorrupt)
            {
                Item.createTile = ModContent.TileType<CorruptGrassPlatformEcho>();
            }
            else if (player.ZoneCrimson)
            {
                Item.createTile = ModContent.TileType<CrimsonGrassPlatformEcho>();
            }
            else if (player.InModBiome<Corrosion>())
            {
                Item.createTile = ModContent.TileType<CorrosionGrassPlatformEcho>();
            }

            else if (player.ZoneHallow)
            {
                Item.createTile = ModContent.TileType<HallowGrassPlatformEcho>();
            }
            else if (player.InModBiome<Somnolent>())
            {
                Item.createTile = ModContent.TileType<SomnolentGrassPlatformEcho>();
            }

            else
            {
                Item.createTile = ModContent.TileType<JungleGrassPlatformEcho>();
            }
        }

        //Desert and Underground Desert
        else if ((player.ZoneDesert || player.ZoneUndergroundDesert) && !(player.ZoneSnow || player.ZoneJungle || player.ZoneSkyHeight))
        {
            if (player.ZoneCorrupt)
            {
                Item.createTile = ModContent.TileType<HardenedEbonsandPlatformEcho>();
            }
            else if (player.ZoneCrimson)
            {
                Item.createTile = ModContent.TileType<HardenedCrimsandPlatformEcho>();
            }
            else if (player.InModBiome<Corrosion>())
            {
                Item.createTile = ModContent.TileType<HardenedGutsandPlatformEcho>();
            }

            else if (player.ZoneHallow)
            {
                Item.createTile = ModContent.TileType<HardenedPearlsandPlatformEcho>();
            }
            //else if (player.InModBiome<Somnolent>())
            //{
            //    Item.createTile = ModContent.TileType<SomnolentGrassPlatformEcho>();
            //}

            else
            {
                Item.createTile = ModContent.TileType<HardenedSandPlatformEcho>();
            }
        }

        //Snow and Ice
        else if (player.ZoneSnow && !(player.ZoneDesert || player.ZoneJungle || player.ZoneSkyHeight))
        {
            if (player.ZoneCorrupt)
            {
                Item.createTile = ModContent.TileType<CorruptFrozenPlatformEcho>();
            }
            else if (player.ZoneCrimson)
            {
                Item.createTile = ModContent.TileType<CrimsonFrozenPlatformEcho>();
            }
            else if (player.InModBiome<Corrosion>())
            {
                Item.createTile = ModContent.TileType<CorrosionFrozenPlatformEcho>();
            }

            else if (player.ZoneHallow)
            {
                Item.createTile = ModContent.TileType<HallowFrozenPlatformEcho>();
            }
            else if (player.InModBiome<Somnolent>())
            {
                Item.createTile = ModContent.TileType<SomnolentFrozenPlatformEcho>();
            }

            else
            {
                Item.createTile = ModContent.TileType<FrozenPlatformEcho>();
            }
        }

        //Underworld. doesnt work!
        else if (player.ZoneUnderworldHeight)
        {
            Item.createTile = ModContent.TileType<AshGrassPlatformEcho>();
        }

        //Fallback incase it cant detect a biome
        else
        {
            Item.createTile = ModContent.TileType<FallbackBiomePlatform>();
        }
        return null;
    }
    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.WoodPlatform, 99)
            .AddIngredient(ItemID.SpellTome)
            .AddTile(TileID.Bookcases)
            .Register();
    }
}