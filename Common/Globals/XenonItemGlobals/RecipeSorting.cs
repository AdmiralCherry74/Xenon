using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Xenon.Content.Items;
using Xenon.Content.Items.Accessories;
using Xenon.Content.Items.Accessories.Shield;
using Xenon.Content.Items.Armor.PreHardmode;
using Xenon.Content.Items.Armor.PreHardmode.GemRobes;
using Xenon.Content.Items.Armor.PreHardmode.Metal;
using Xenon.Content.Items.Armor.Vanity.OreCrowns;
using Xenon.Content.Items.Materials.BarsGems;
using Xenon.Content.Items.Materials.WorldInfectionMaterials;
using Xenon.Content.Items.Placeable.Blocks.ActiveAndWiring.Lighting;
using Xenon.Content.Items.Placeable.Blocks.BuildingTiles.Stone;
using Xenon.Content.Items.Placeable.Blocks.BuildingTiles.Wood;
using Xenon.Content.Items.Placeable.Blocks.Natural.OresAndGems;
using Xenon.Content.Items.Placeable.Blocks.Natural.Stone;
using Xenon.Content.Items.Placeable.Furniture.Crafting;
using Xenon.Content.Items.Placeable.Wall.BuildingWalls.Stone;
using Xenon.Content.Items.Placeable.Wall.Natural.Stone;
using Xenon.Content.Items.Tools.CuttingAxes;
using Xenon.Content.Items.Tools.DriverHammers;
using Xenon.Content.Items.Tools.FishingRods;
using Xenon.Content.Items.Tools.GardeningHoes;
using Xenon.Content.Items.Tools.GrapplingHooks;
using Xenon.Content.Items.Tools.MiningPickaxes;
using Xenon.Content.Items.Weapons.Magic.Staves;
using Xenon.Content.Items.Weapons.Melee.Battleaxes;
using Xenon.Content.Items.Weapons.Melee.Boomerangs;
using Xenon.Content.Items.Weapons.Melee.Flails;
using Xenon.Content.Items.Weapons.Melee.Polearms;
using Xenon.Content.Items.Weapons.Melee.Swords;
using Xenon.Content.Items.Weapons.Melee.YoYos;
using Xenon.Content.Items.Weapons.Ranged.Bows;
using Xenon.Content.Items.Weapons.Summon.Caltrops;

namespace Xenon.Common.Globals.XenonItemGlobals
{
    public class RecipeSorting : ModSystem
    {
        //cleverly using the fact that these recipes will load in the order to put them in, too properly sort them into the crafting ui
        public override void AddRecipes()
        {
            #region Building Block
            #region Gem based blocks
            #region Combined Gems
            //Amethyst Block
            Recipe.Create(ModContent.ItemType<AmethystBlockItem>(), 2)
                .AddIngredient(ItemID.Amethyst, 10)
                .AddTile(TileID.WorkBenches)
                .SortBeforeFirstRecipesOf(ItemID.AmethystGemsparkBlock)
                .Register();

            //Amethyst Wall
            Recipe.Create(ModContent.ItemType<AmethystWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<AmethystBlockItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AmethystBlockItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<AmethystBlockItem>())
                .AddIngredient(ModContent.ItemType<AmethystWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AmethystWallItem>())
                .Register();

            //Jade Block
            Recipe.Create(ModContent.ItemType<JadeBlockItem>(), 2)
                .AddIngredient(ModContent.ItemType<Jade>(), 10)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AmethystBlockItem>())
                .Register();

            //Jade Wall
            Recipe.Create(ModContent.ItemType<JadeWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<JadeBlockItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<JadeBlockItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<JadeBlockItem>())
                .AddIngredient(ModContent.ItemType<JadeWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<JadeWallItem>())
                .Register();

            //Topaz Block
            Recipe.Create(ModContent.ItemType<TopazBlockItem>(), 2)
                .AddIngredient(ItemID.Topaz, 10)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<JadeBlockItem>())
                .Register();

            //Topaz Wall
            Recipe.Create(ModContent.ItemType<TopazWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<TopazBlockItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<TopazBlockItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<TopazBlockItem>())
                .AddIngredient(ModContent.ItemType<TopazWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<TopazWallItem>())
                .Register();

            //Sapphire Block
            Recipe.Create(ModContent.ItemType<SapphireBlockItem>(), 2)
                .AddIngredient(ItemID.Sapphire, 10)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<TopazBlockItem>())
                .Register();

            //Sapphire Wall
            Recipe.Create(ModContent.ItemType<SapphireWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<SapphireBlockItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<SapphireBlockItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<SapphireBlockItem>())
                .AddIngredient(ModContent.ItemType<SapphireWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<SapphireWallItem>())
                .Register();

            //Garnet Block
            Recipe.Create(ModContent.ItemType<GarnetBlockItem>(), 2)
                .AddIngredient(ModContent.ItemType<Garnet>(), 10)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<SapphireBlockItem>())
                .Register();

            //Garnet Wall
            Recipe.Create(ModContent.ItemType<GarnetWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<GarnetBlockItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<GarnetBlockItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<GarnetBlockItem>())
                .AddIngredient(ModContent.ItemType<GarnetWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<GarnetWallItem>())
                .Register();

            //Emerald Block
            Recipe.Create(ModContent.ItemType<EmeraldBlockItem>(), 2)
                .AddIngredient(ItemID.Emerald, 10)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<GarnetBlockItem>())
                .Register();

            //Emerald Wall
            Recipe.Create(ModContent.ItemType<EmeraldWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<EmeraldBlockItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<EmeraldBlockItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<EmeraldBlockItem>())
                .AddIngredient(ModContent.ItemType<EmeraldWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<EmeraldWallItem>())
                .Register();

            //Ruby Block
            Recipe.Create(ModContent.ItemType<RubyBlockItem>(), 2)
                .AddIngredient(ItemID.Ruby, 10)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<EmeraldBlockItem>())
                .Register();

            //Ruby Wall
            Recipe.Create(ModContent.ItemType<RubyWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<RubyBlockItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<RubyBlockItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<RubyBlockItem>())
                .AddIngredient(ModContent.ItemType<RubyWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<RubyWallItem>())
                .Register();

            //Lapis Block
            Recipe.Create(ModContent.ItemType<LapisBlockItem>(), 2)
                .AddIngredient(ModContent.ItemType<Lapis>(), 10)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<RubyBlockItem>())
                .Register();

            //Lapis Wall
            Recipe.Create(ModContent.ItemType<LapisWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<LapisBlockItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<LapisBlockItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<LapisBlockItem>())
                .AddIngredient(ModContent.ItemType<LapisWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<LapisWallItem>())
                .Register();

            //Diamond Block
            Recipe.Create(ModContent.ItemType<DiamondBlockItem>(), 2)
                .AddIngredient(ItemID.Diamond, 10)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<LapisBlockItem>())
                .Register();

            //Diamond Wall
            Recipe.Create(ModContent.ItemType<DiamondWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<DiamondBlockItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<DiamondBlockItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<DiamondBlockItem>())
                .AddIngredient(ModContent.ItemType<DiamondWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<DiamondWallItem>())
                .Register();

            //Amber Block
            Recipe.Create(ModContent.ItemType<AmberBlockItem>(), 2)
                .AddIngredient(ItemID.Amber, 10)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<DiamondBlockItem>())
                .Register();

            //Amber Wall
            Recipe.Create(ModContent.ItemType<AmberWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<AmberBlockItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AmberBlockItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<AmberBlockItem>())
                .AddIngredient(ModContent.ItemType<AmberWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AmberWallItem>())
                .Register();
            #endregion

            #region Gemspark
            Recipe.Create(ModContent.ItemType<JadeGemsparkBlock>(), 20)
                .AddIngredient(ItemID.Glass, 20)
                .AddIngredient(ModContent.ItemType<Jade>(), 1)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ItemID.AmethystGemsparkBlock)
                .Register();

            Recipe.Create(ModContent.ItemType<GarnetGemsparkBlock>(), 20)
                .AddIngredient(ItemID.Glass, 20)
                .AddIngredient(ModContent.ItemType<Garnet>(), 1)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ItemID.SapphireGemsparkBlock)
                .Register();

            Recipe.Create(ModContent.ItemType<LapisGemsparkBlock>(), 20)
                .AddIngredient(ItemID.Glass, 20)
                .AddIngredient(ModContent.ItemType<Lapis>(), 1)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ItemID.RubyGemsparkBlock)
                .Register();
            #endregion

            #region Gem Bricks
            //Amethyst Brick
            Recipe.Create(ModContent.ItemType<AmethystBrickItem>(), 1)
                .AddIngredient(ModContent.ItemType<AmethystBlockItem>())
                .AddIngredient(ItemID.StoneBlock)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ItemID.RedBrickWall)
                .Register();

            //Amethyst Brick Wall
            Recipe.Create(ModContent.ItemType<AmethystBrickWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<AmethystBrickItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AmethystBrickItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<AmethystBrickItem>())
                .AddIngredient(ModContent.ItemType<AmethystBrickWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AmethystBrickWallItem>())
                .Register();

            //Jade Brick
            Recipe.Create(ModContent.ItemType<JadeBrickItem>())
                .AddIngredient(ModContent.ItemType<JadeBlockItem>())
                .AddIngredient(ItemID.StoneBlock)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AmethystBrickItem>())
                .Register();

            //Jade Brick Wall
            Recipe.Create(ModContent.ItemType<JadeBrickWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<JadeBrickItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<JadeBrickItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<JadeBrickItem>())
                .AddIngredient(ModContent.ItemType<JadeBrickWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<JadeBrickWallItem>())
                .Register();

            //Topaz Brick
            Recipe.Create(ModContent.ItemType<TopazBrickItem>())
                .AddIngredient(ModContent.ItemType<TopazBlockItem>())
                .AddIngredient(ItemID.StoneBlock)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<JadeBrickItem>())
                .Register();

            //Topaz Brick Wall
            Recipe.Create(ModContent.ItemType<TopazBrickWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<TopazBrickItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<TopazBrickItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<TopazBrickItem>())
                .AddIngredient(ModContent.ItemType<TopazBrickWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<TopazBrickWallItem>())
                .Register();

            //Sapphire Brick
            Recipe.Create(ModContent.ItemType<SapphireBrickItem>())
                .AddIngredient(ModContent.ItemType<SapphireBlockItem>())
                .AddIngredient(ItemID.StoneBlock)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<TopazBrickItem>())
                .Register();

            //Sapphire Brick Wall
            Recipe.Create(ModContent.ItemType<SapphireBrickWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<SapphireBrickItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<SapphireBrickItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<SapphireBrickItem>())
                .AddIngredient(ModContent.ItemType<SapphireBrickWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<SapphireBrickWallItem>())
                .Register();

            //Garnet Brick
            Recipe.Create(ModContent.ItemType<GarnetBrickItem>())
                .AddIngredient(ModContent.ItemType<GarnetBlockItem>())
                .AddIngredient(ItemID.StoneBlock)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<SapphireBrickItem>())
                .Register();

            //Garnet Brick Wall
            Recipe.Create(ModContent.ItemType<GarnetBrickWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<GarnetBrickItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<GarnetBrickItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<GarnetBrickItem>())
                .AddIngredient(ModContent.ItemType<GarnetBrickWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<GarnetBrickWallItem>())
                .Register();

            //Emerald Brick
            Recipe.Create(ModContent.ItemType<EmeraldBrickItem>())
                .AddIngredient(ModContent.ItemType<EmeraldBlockItem>())
                .AddIngredient(ItemID.StoneBlock)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<GarnetBrickItem>())
                .Register();

            //Emerald Brick Wall
            Recipe.Create(ModContent.ItemType<EmeraldBrickWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<EmeraldBrickItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<EmeraldBrickItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<EmeraldBrickItem>())
                .AddIngredient(ModContent.ItemType<EmeraldBrickWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<EmeraldBrickWallItem>())
                .Register();

            //Ruby Brick
            Recipe.Create(ModContent.ItemType<RubyBrickItem>())
                .AddIngredient(ModContent.ItemType<RubyBlockItem>())
                .AddIngredient(ItemID.StoneBlock)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<EmeraldBrickItem>())
                .Register();

            //Ruby Brick Wall
            Recipe.Create(ModContent.ItemType<RubyBrickWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<RubyBrickItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<RubyBrickItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<RubyBrickItem>())
                .AddIngredient(ModContent.ItemType<RubyBrickWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<RubyBrickWallItem>())
                .Register();

            //Lapis Brick
            Recipe.Create(ModContent.ItemType<LapisBrickItem>())
                .AddIngredient(ModContent.ItemType<LapisBlockItem>())
                .AddIngredient(ItemID.StoneBlock)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<RubyBrickItem>())
                .Register();

            //Lapis Brick Wall
            Recipe.Create(ModContent.ItemType<LapisBrickWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<LapisBrickItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<LapisBrickItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<LapisBrickItem>())
                .AddIngredient(ModContent.ItemType<LapisBrickWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<LapisBrickWallItem>())
                .Register();

            //Diamond Brick
            Recipe.Create(ModContent.ItemType<DiamondBrickItem>())
                .AddIngredient(ModContent.ItemType<DiamondBlockItem>())
                .AddIngredient(ItemID.StoneBlock)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<LapisBrickItem>())
                .Register();

            //Diamond Brick Wall
            Recipe.Create(ModContent.ItemType<DiamondBrickWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<DiamondBrickItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<DiamondBrickItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<DiamondBrickItem>())
                .AddIngredient(ModContent.ItemType<DiamondBrickWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<DiamondBrickWallItem>())
                .Register();

            //Amber Brick
            Recipe.Create(ModContent.ItemType<AmberBrickItem>())
                .AddIngredient(ModContent.ItemType<AmberBlockItem>())
                .AddIngredient(ItemID.StoneBlock)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<DiamondBrickItem>())
                .Register();

            //Amber Brick Wall
            Recipe.Create(ModContent.ItemType<AmberBrickWallItem>(), 4)
                .AddIngredient(ModContent.ItemType<AmberBrickItem>())
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AmberBrickItem>())
                .Register();

            Recipe.Create(ModContent.ItemType<AmberBrickItem>())
                .AddIngredient(ModContent.ItemType<AmberBrickWallItem>(), 4)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AmberBrickWallItem>())
                .Register();
            #endregion
            #endregion

            #region Stone based blocks
            //Smooth Stone
            Recipe.Create(ModContent.ItemType<SmoothStoneItem>(), 1)
            .AddIngredient(ItemID.StoneBlock, 2)
            .AddTile(TileID.WorkBenches)
            .SortAfterFirstRecipesOf(ItemID.GrayBrickWall)
            .Register();

            #region Gemstone Walls
            #region Jade
            Recipe.Create(ModContent.ItemType<JadeGemstoneItem>())
            .AddIngredient(ModContent.ItemType<Jade>())
            .AddIngredient(ItemID.StoneBlock)
            .AddTile(TileID.HeavyWorkBench)
            .AddCondition(Condition.InGraveyard)
            .SortAfterFirstRecipesOf(ItemID.AmethystStoneBlock)
            .Register();

            Recipe.Create(ModContent.ItemType<JadeGemstoneWallItem>(), 4)
            .AddIngredient(ModContent.ItemType<JadeGemstoneItem>())
            .AddTile(TileID.WorkBenches)
            .AddCondition(Condition.InGraveyard)
            .SortBeforeFirstRecipesOf(ItemID.TopazEcho)
            .Register();

            Recipe.Create(ModContent.ItemType<JadeGemstoneItem>())
            .AddIngredient(ModContent.ItemType<JadeGemstoneWallItem>(), 4)
            .AddTile(TileID.WorkBenches)
            .SortAfterFirstRecipesOf(ModContent.ItemType<JadeGemstoneWallItem>())
            .Register();
            #endregion

            #region Garnet
            Recipe.Create(ModContent.ItemType<GarnetGemstoneItem>())
            .AddIngredient(ModContent.ItemType<Garnet>())
            .AddIngredient(ItemID.StoneBlock)
            .AddTile(TileID.HeavyWorkBench)
            .AddCondition(Condition.InGraveyard)
            .SortAfterFirstRecipesOf(ItemID.SapphireStoneBlock)
            .Register();

            Recipe.Create(ModContent.ItemType<GarnetGemstoneWallItem>(), 4)
            .AddIngredient(ModContent.ItemType<GarnetGemstoneItem>())
            .AddTile(TileID.WorkBenches)
            .AddCondition(Condition.InGraveyard)
            .SortBeforeFirstRecipesOf(ItemID.EmeraldEcho)
            .Register();

            Recipe.Create(ModContent.ItemType<GarnetGemstoneItem>())
            .AddIngredient(ModContent.ItemType<GarnetGemstoneWallItem>(), 4)
            .AddTile(TileID.WorkBenches)
            .SortAfterFirstRecipesOf(ModContent.ItemType<GarnetGemstoneWallItem>())
            .Register();
            #endregion

            #region Lapis
            Recipe.Create(ModContent.ItemType<LapisGemstoneItem>())
            .AddIngredient(ModContent.ItemType<Lapis>())
            .AddIngredient(ItemID.StoneBlock)
            .AddTile(TileID.HeavyWorkBench)
            .AddCondition(Condition.InGraveyard)
            .SortAfterFirstRecipesOf(ItemID.RubyStoneBlock)
            .Register();

            Recipe.Create(ModContent.ItemType<LapisGemstoneWallItem>(), 4)
            .AddIngredient(ModContent.ItemType<LapisGemstoneItem>())
            .AddTile(TileID.WorkBenches)
            .AddCondition(Condition.InGraveyard)
            .SortBeforeFirstRecipesOf(ItemID.DiamondEcho)
            .Register();

            Recipe.Create(ModContent.ItemType<LapisGemstoneItem>())
            .AddIngredient(ModContent.ItemType<LapisGemstoneWallItem>(), 4)
            .AddTile(TileID.WorkBenches)
            .SortAfterFirstRecipesOf(ModContent.ItemType<LapisGemstoneWallItem>())
            .Register();
            #endregion
            #endregion
            #endregion

            #region Catacombs
            #region Red Catacombs
            #endregion
            #endregion
            #endregion

            #region Ore and Wood based gear, tools, weapons and armor recipes

            #region Vanilla Ore based Recipes

            #region Hoes
            //Copper Hoe
            Recipe.Create(ModContent.ItemType<CopperHoe>())
                .AddIngredient(ItemID.CopperBar, 4)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .SortAfterFirstRecipesOf(ItemID.CopperHammer)
                .AddTile(TileID.Anvils)
            .Register();

            //Tin Hoe
            Recipe.Create(ModContent.ItemType<TinHoe>())
                .AddIngredient(ItemID.TinBar, 4)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.TinHammer)
                .Register();

            //Iron Hoe
            Recipe.Create(ModContent.ItemType<IronHoe>())
                .AddIngredient(ItemID.IronBar, 5)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.IronHammer)
                .Register();

            //Lead Hoe
            Recipe.Create(ModContent.ItemType<LeadHoe>())
                .AddIngredient(ItemID.LeadBar, 5)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.LeadHammer)
                .Register();

            //Silver Hoe
            Recipe.Create(ModContent.ItemType<SilverHoe>())
                .AddIngredient(ItemID.SilverBar, 5)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.SilverHammer)
                .Register();

            //Tungsten Hoe
            Recipe.Create(ModContent.ItemType<TungstenHoe>())
                .AddIngredient(ItemID.TungstenBar, 5)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.TungstenHammer)
                .Register();

            //Gold Hoe
            Recipe.Create(ModContent.ItemType<GoldHoe>())
                .AddIngredient(ItemID.GoldBar, 5)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.GoldHammer)
                .Register();

            //Platinum Hoe
            Recipe.Create(ModContent.ItemType<PlatinumHoe>())
                .AddIngredient(ItemID.PlatinumBar, 5)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.PlatinumHammer)
                .Register();
            #endregion

            #region Battleaxes
            //Copper Battleaxe
            Recipe.Create(ModContent.ItemType<CopperBattleaxe>())
                .AddIngredient(ItemID.CopperBar, 7)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.CopperShortsword)
                .Register();

            //Tin Battleaxe
            Recipe.Create(ModContent.ItemType<TinBattleaxe>())
                .AddIngredient(ItemID.TinBar, 7)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.TinShortsword)
                .Register();

            //Iron Battleaxe
            Recipe.Create(ModContent.ItemType<IronBattleaxe>())
                .AddIngredient(ItemID.IronBar, 9)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.IronShortsword)
                .Register();

            //Lead Battleaxe
            Recipe.Create(ModContent.ItemType<LeadBattleaxe>())
                .AddIngredient(ItemID.LeadBar, 9)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.LeadShortsword)
                .Register();

            //Silver Battleaxe
            Recipe.Create(ModContent.ItemType<SilverBattleaxe>())
                .AddIngredient(ItemID.SilverBar, 9)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.SilverShortsword)
                .Register();

            //Tungsten Battleaxe
            Recipe.Create(ModContent.ItemType<TungstenBattleaxe>())
                .AddIngredient(ItemID.TungstenBar, 9)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.TungstenShortsword)
                .Register();

            //Gold Battleaxe
            Recipe.Create(ModContent.ItemType<GoldBattleaxe>())
                .AddIngredient(ItemID.GoldBar, 9)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.GoldShortsword)
                .Register();

            //Platinum Battleaxe
            Recipe.Create(ModContent.ItemType<PlatinumBattleaxe>())
                .AddIngredient(ItemID.PlatinumBar, 9)
                .SortAfterFirstRecipesOf(ItemID.PlatinumShortsword)
                .AddTile(TileID.Anvils)
                .Register();
            #endregion

            #region Caltrops
            Recipe.Create(ModContent.ItemType<IronCaltrops>(), 5)
                .AddIngredient(ItemID.IronBar, 1)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.IronBow)
                .Register();

            Recipe.Create(ModContent.ItemType<LeadCaltrops>(), 5)
                .AddIngredient(ItemID.LeadBar, 1)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.LeadBow)
                .Register();
            #endregion

            #region Crowns
            Recipe.Create(ModContent.ItemType<CopperCrown>())
                .AddIngredient(ItemID.CopperBar, 5)
                .AddIngredient(ItemID.Amethyst)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.CopperWatch)
                .Register();

            Recipe.Create(ModContent.ItemType<TinCrown>())
                .AddIngredient(ItemID.TinBar, 5)
                .AddIngredient(ItemID.Topaz)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.TinWatch)
                .Register();

            Recipe.Create(ModContent.ItemType<SilverCrown>())
                .AddIngredient(ItemID.SilverBar, 5)
                .AddIngredient(ItemID.Sapphire)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.SilverWatch)
                .Register();

            Recipe.Create(ModContent.ItemType<TungstenCrown>())
                .AddIngredient(ItemID.TungstenBar, 5)
                .AddIngredient(ItemID.Emerald)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.TungstenWatch)
                .Register();

            Recipe.Create(ModContent.ItemType<PlatinumCrownModern>())
                .AddIngredient(ItemID.PlatinumBar, 5)
                .AddIngredient(ItemID.Diamond)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.PlatinumWatch)
                .Register();
            #endregion

            #region Corrupt Special Weapons
            //Battleaxe
            Recipe.Create(ModContent.ItemType<NightGnasher>())
                .AddIngredient(ItemID.DemoniteBar, 9)
                .AddIngredient(ItemID.ShadowScale, 2)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.TheBreaker)
                .Register();

            //Spear
            Recipe.Create(ModContent.ItemType<TheEbonStabber>())
                .AddIngredient(ItemID.DemoniteBar, 12)
                .AddIngredient(ItemID.ShadowScale, 6)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<NightGnasher>())
                .Register();

            //Boomerang
            Recipe.Create(ModContent.ItemType<Depraverang>())
            .AddIngredient(ItemID.DemoniteBar, 8)
            .AddIngredient(ItemID.ShadowScale, 2)
            .AddTile(TileID.Anvils)
            .SortAfterFirstRecipesOf(ItemID.CorruptYoyo)
            .Register();
            #endregion

            #region Crimfied Special Weapons
            //Battleaxe
            Recipe.Create(ModContent.ItemType<JawSplitter>())
                .AddIngredient(ItemID.CrimtaneBar, 7)
                .AddIngredient(ItemID.TissueSample, 2)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.FleshGrinder)
                .Register();

            //Boomerang
            Recipe.Create(ModContent.ItemType<Zygomatarang>())
            .AddIngredient(ItemID.CrimtaneBar, 8)
            .AddIngredient(ItemID.TissueSample, 2)
            .AddTile(TileID.Anvils)
            .SortAfterFirstRecipesOf(ItemID.CrimsonYoyo)
            .Register();

            #endregion

            Recipe.Create(ItemID.SlimeCrown)
                .AddIngredient(ItemID.Gel, 20)
                .AddIngredient(ModContent.ItemType<FluoriteCrown>())
                .AddTile(TileID.DemonAltar)
                .SortAfterFirstRecipesOf(ItemID.SlimeCrown)
                .Register();

            Recipe.Create(ItemID.SlimeCrown)
                .AddIngredient(ItemID.Gel, 20)
                .AddIngredient(ModContent.ItemType<PlatinumCrownModern>())
                .AddTile(TileID.DemonAltar)
                .SortAfterFirstRecipesOf(ItemID.SlimeCrown)
                .Register();
            #endregion

            #region Xenon Wood Recipes
            #region Bilewood
            //Bilewood Helmet
            Recipe.Create(ModContent.ItemType<BilewoodHelmet>())
                .AddIngredient(ModContent.ItemType<BilewoodItem>(), 20)
                .SortAfterFirstRecipesOf(ItemID.EbonwoodBow)
                .AddTile(TileID.WorkBenches)
                .Register();

            //Bilewood Breastplate
            Recipe.Create(ModContent.ItemType<BilewoodBreastplate>())
                .AddIngredient(ModContent.ItemType<BilewoodItem>(), 30)
                .SortAfterFirstRecipesOf(ModContent.ItemType<BilewoodHelmet>())
                .AddTile(TileID.WorkBenches)
                .Register();

            //Bilewood Greaves
            Recipe.Create(ModContent.ItemType<BilewoodGreaves>())
                .AddIngredient(ModContent.ItemType<BilewoodItem>(), 25)
                .SortAfterFirstRecipesOf(ModContent.ItemType<BilewoodBreastplate>())
                .AddTile(TileID.WorkBenches)
                .Register();

            //Bilewood Broadsword
            Recipe.Create(ModContent.ItemType<BilewoodBroadsword>())
                .AddIngredient(ModContent.ItemType<BilewoodItem>(), 7)
                .SortAfterFirstRecipesOf(ModContent.ItemType<BilewoodGreaves>())
                .AddTile(TileID.WorkBenches)
                .Register();

            //Bilewood Hammer
            Recipe.Create(ModContent.ItemType<BilewoodHammer>())
                .AddIngredient(ModContent.ItemType<BilewoodItem>(), 8)
                .SortAfterFirstRecipesOf(ModContent.ItemType<BilewoodBroadsword>())
                .AddTile(TileID.WorkBenches)
                .Register();

            //Bilewood Bow
            Recipe.Create(ModContent.ItemType<BilewoodBow>())
                .AddIngredient(ModContent.ItemType<BilewoodItem>(), 10)
                .SortAfterFirstRecipesOf(ModContent.ItemType<BilewoodHammer>())
                .AddTile(TileID.WorkBenches)
                .Register();
            #endregion

            #region JacarandaWood
            //Jacarandawood Helmet
            Recipe.Create(ModContent.ItemType<JacarandawoodHelmet>())
                .AddIngredient(ModContent.ItemType<JacarandawoodItem>(), 20)
                .SortAfterFirstRecipesOf(ItemID.PalmWoodBow)
                .AddTile(TileID.WorkBenches)
                .Register();

            //Jacarandawood Breastplate
            Recipe.Create(ModContent.ItemType<JacarandawoodBreastplate>())
                .AddIngredient(ModContent.ItemType<JacarandawoodItem>(), 30)
                .SortAfterFirstRecipesOf(ModContent.ItemType<JacarandawoodHelmet>())
                .AddTile(TileID.WorkBenches)
                .Register();

            //Jacarandawood Greaves
            Recipe.Create(ModContent.ItemType<JacarandawoodGreaves>())
                .AddIngredient(ModContent.ItemType<JacarandawoodItem>(), 25)
                .SortAfterFirstRecipesOf(ModContent.ItemType<JacarandawoodBreastplate>())
                .AddTile(TileID.WorkBenches)
                .Register();

            //Jacarandawood Broadsword
            Recipe.Create(ModContent.ItemType<JacarandawoodBroadsword>())
                .AddIngredient(ModContent.ItemType<JacarandawoodItem>(), 7)
                .SortAfterFirstRecipesOf(ModContent.ItemType<JacarandawoodGreaves>())
                .AddTile(TileID.WorkBenches)
                .Register();

            //Jacarandawood Hammer
            Recipe.Create(ModContent.ItemType<JacarandawoodHammer>())
                .AddIngredient(ModContent.ItemType<JacarandawoodItem>(), 8)
                .SortAfterFirstRecipesOf(ModContent.ItemType<JacarandawoodBroadsword>())
                .AddTile(TileID.WorkBenches)
                .Register();

            //Jacarandawood Bow
            Recipe.Create(ModContent.ItemType<JacarandawoodBow>())
                .AddIngredient(ModContent.ItemType<JacarandawoodItem>(), 10)
                .SortAfterFirstRecipesOf(ModContent.ItemType<JacarandawoodHammer>())
                .AddTile(TileID.WorkBenches)
                .Register();
            #endregion
            #endregion

            #region Aluminum Recipes
            //Bar
            Recipe.Create(ModContent.ItemType<AluminumBar>())
                .AddIngredient(ModContent.ItemType<AluminumOreBlock>(), 3)
                .AddTile(TileID.Furnaces)
                .SortAfterFirstRecipesOf(ModContent.ItemType<CopperCrown>())
                .Register();

            //Pickaxe
            Recipe.Create(ModContent.ItemType<AluminumPickaxe>())
                .AddIngredient(ModContent.ItemType<AluminumBar>(), 8)
                .AddRecipeGroup(RecipeGroupID.Wood, 4)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AluminumBar>())
                .Register();

            //Axe
            Recipe.Create(ModContent.ItemType<AluminumAxe>())
                .AddIngredient(ModContent.ItemType<AluminumBar>(), 6)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AluminumPickaxe>())
                .Register();

            //Hammer
            Recipe.Create(ModContent.ItemType<AluminumHammer>())
                .AddIngredient(ModContent.ItemType<AluminumBar>(), 8)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AluminumAxe>())
                .Register();

            //Hoe
            Recipe.Create(ModContent.ItemType<AluminumHoe>())
                .AddIngredient(ModContent.ItemType<AluminumBar>(), 4)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AluminumHammer>())
                .Register();

            //Broadsword
            Recipe.Create(ModContent.ItemType<AluminumBroadsword>())
                .AddIngredient(ModContent.ItemType<AluminumBar>(), 6)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AluminumHoe>())
                .Register();

            //Shortsword
            Recipe.Create(ModContent.ItemType<AluminumShortsword>())
                .AddIngredient(ModContent.ItemType<AluminumBar>(), 5)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AluminumBroadsword>())
                .Register();

            //Battleaxe
            Recipe.Create(ModContent.ItemType<AluminumBattleaxe>())
                .AddIngredient(ModContent.ItemType<AluminumBar>(), 7)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AluminumShortsword>())
                .Register();

            //Bow
            Recipe.Create(ModContent.ItemType<AluminumBow>())
                .AddIngredient(ModContent.ItemType<AluminumBar>(), 7)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AluminumBattleaxe>())
                .Register();

            //Jade Staff
            Recipe.Create(ModContent.ItemType<JadeStaff>())
                .AddIngredient(ModContent.ItemType<AluminumBar>(), 10)
                .AddIngredient(ModContent.ItemType<Jade>(), 8)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AluminumBow>())
                .Register();

            //Helmet
            Recipe.Create(ModContent.ItemType<AluminumHelmet>())
                .AddIngredient(ModContent.ItemType<AluminumBar>(), 12)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<JadeStaff>())
                .Register();

            //Chainmail
            Recipe.Create(ModContent.ItemType<AluminumChainmail>())
                .AddIngredient(ModContent.ItemType<AluminumBar>(), 20)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AluminumHelmet>())
                .Register();

            //Greaves
            Recipe.Create(ModContent.ItemType<AluminumGreaves>())
                .AddIngredient(ModContent.ItemType<AluminumBar>(), 16)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AluminumChainmail>())
                .Register();

            //Watch
            Recipe.Create(ModContent.ItemType<AluminumWatch>())
                .AddIngredient(ModContent.ItemType<AluminumBar>(), 10)
                .AddIngredient(ItemID.Chain)
                .AddTile(TileID.Tables)
                .AddTile(TileID.Chairs)
                //.AddTile(TileID.WorkBenches) for when Tmodloader updates to 1.4.5
                .SortAfterFirstRecipesOf(ModContent.ItemType<AluminumGreaves>())
                .Register();

            //Crown
            Recipe.Create(ModContent.ItemType<AluminumCrown>())
                .AddIngredient(ModContent.ItemType<AluminumBar>(), 5)
                .AddIngredient(ModContent.ItemType<Jade>())
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<AluminumWatch>())
                .Register();

            //Jade Hook
            Recipe.Create(ModContent.ItemType<JadeHook>())
                .AddIngredient(ModContent.ItemType<Jade>(), 15)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.AmethystHook)
                .Register();

            //Jade Robe
            Recipe.Create(ModContent.ItemType<JadeRobe>())
                .AddIngredient(ItemID.Robe)
                .AddIngredient(ModContent.ItemType<Jade>(), 10)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.AmethystRobe)
                .Register();

            //Large Jade
            Recipe.Create(ModContent.ItemType<LargeJade>())
                .AddIngredient(ModContent.ItemType<Jade>(), 15)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.LargeAmethyst)
                .Register();
            #endregion

            #region Cinnabar Recipes
            //Bar
            Recipe.Create(ModContent.ItemType<CinnabarBar>())
                .AddIngredient(ModContent.ItemType<CinnabarOreBlock>(), 3)
                .AddTile(TileID.Furnaces)
                .SortAfterFirstRecipesOf(ItemID.IronGreaves)
                .Register();

            //Anvil
            Recipe.Create(ModContent.ItemType<CinnabarAnvilItem>())
                .AddIngredient(ModContent.ItemType<CinnabarBar>(), 6)
                .SortAfterFirstRecipesOf(ModContent.ItemType<CinnabarBar>())
                .AddTile(TileID.WorkBenches).Register();

            //Pickaxe
            Recipe.Create(ModContent.ItemType<CinnabarPickaxe>())
                .AddIngredient(ModContent.ItemType<CinnabarBar>(), 10)
                .AddRecipeGroup(RecipeGroupID.Wood, 4)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<CinnabarAnvilItem>())
                .Register();

            //Axe
            Recipe.Create(ModContent.ItemType<CinnabarAxe>())
                .AddIngredient(ModContent.ItemType<CinnabarBar>(), 8)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<CinnabarPickaxe>())
                .Register();

            //Hammer
            Recipe.Create(ModContent.ItemType<CinnabarHammer>())
                .AddIngredient(ModContent.ItemType<CinnabarBar>(), 8)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<CinnabarAxe>())
                .Register();

            //Hoe
            Recipe.Create(ModContent.ItemType<CinnabarHoe>())
                .AddIngredient(ModContent.ItemType<CinnabarBar>(), 5)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<CinnabarHammer>())
                .Register();

            //Broadsword
            Recipe.Create(ModContent.ItemType<CinnabarBroadsword>())
                .AddIngredient(ModContent.ItemType<CinnabarBar>(), 8)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<CinnabarHoe>())
                .Register();

            //Shortsword
            Recipe.Create(ModContent.ItemType<CinnabarShortsword>())
                .AddIngredient(ModContent.ItemType<CinnabarBar>(), 6)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<CinnabarBroadsword>())
                .Register();

            //Battleaxe
            Recipe.Create(ModContent.ItemType<CinnabarBattleaxe>())
                .AddIngredient(ModContent.ItemType<CinnabarBar>(), 9)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<CinnabarShortsword>())
                .Register();

            //Bow
            Recipe.Create(ModContent.ItemType<CinnabarBow>())
                .AddIngredient(ModContent.ItemType<CinnabarBar>(), 7)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<CinnabarBattleaxe>())
                .Register();

            //Caltrop


            //Helmet
            Recipe.Create(ModContent.ItemType<CinnabarHelmet>())
                .AddIngredient(ModContent.ItemType<CinnabarBar>(), 15)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<CinnabarBow>())
                .Register();

            //Chainmail
            Recipe.Create(ModContent.ItemType<CinnabarChainmail>())
                .AddIngredient(ModContent.ItemType<CinnabarBar>(), 25)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<CinnabarHelmet>())
                .Register();

            //Greaves
            Recipe.Create(ModContent.ItemType<CinnabarGreaves>())
                .AddIngredient(ModContent.ItemType<CinnabarBar>(), 20)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<CinnabarChainmail>())
                .Register();
            #endregion

            #region Indium Recipes
            //Bar
            Recipe.Create(ModContent.ItemType<IndiumBar>())
                .AddIngredient(ModContent.ItemType<IndiumOreBlock>(), 4)
                .AddTile(TileID.Furnaces)
                .SortAfterFirstRecipesOf(ItemID.SilverWatch)
                .Register();

            //Pickaxe
            Recipe.Create(ModContent.ItemType<IndiumPickaxe>())
            .AddIngredient(ModContent.ItemType<IndiumBar>(), 10)
            .AddRecipeGroup(RecipeGroupID.Wood, 4)
            .AddTile(TileID.Anvils)
            .SortAfterFirstRecipesOf(ModContent.ItemType<IndiumBar>())
            .Register();

            //Axe
            Recipe.Create(ModContent.ItemType<IndiumAxe>())
                .AddIngredient(ModContent.ItemType<IndiumBar>(), 8)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<IndiumPickaxe>())
                .Register();

            //Hammer
            Recipe.Create(ModContent.ItemType<IndiumHammer>())
                .AddIngredient(ModContent.ItemType<IndiumBar>(), 8)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<IndiumAxe>())
                .Register();

            //Hoe
            Recipe.Create(ModContent.ItemType<IndiumHoe>())
                .AddIngredient(ModContent.ItemType<IndiumBar>(), 5)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<IndiumHammer>())
                .Register();

            //Broadsword
            Recipe.Create(ModContent.ItemType<IndiumBroadsword>())
                .AddIngredient(ModContent.ItemType<IndiumBar>(), 8)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<IndiumHoe>())
                .Register();

            //Shortsword
            Recipe.Create(ModContent.ItemType<IndiumShortsword>())
                .AddIngredient(ModContent.ItemType<IndiumBar>(), 6)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<IndiumBroadsword>())
                .Register();

            //Battleaxe
            Recipe.Create(ModContent.ItemType<IndiumBattleaxe>())
                .AddIngredient(ModContent.ItemType<IndiumBar>(), 9)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<IndiumShortsword>())
                .Register();

            //Bow
            Recipe.Create(ModContent.ItemType<IndiumBow>())
                .AddIngredient(ModContent.ItemType<IndiumBar>(), 7)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<IndiumBattleaxe>())
                .Register();

            //Garnet Staff
            Recipe.Create(ModContent.ItemType<GarnetStaff>())
                .AddIngredient(ModContent.ItemType<IndiumBar>(), 10)
                .AddIngredient(ModContent.ItemType<Garnet>(), 8)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<IndiumBow>())
                .Register();

            //Helmet
            Recipe.Create(ModContent.ItemType<IndiumHelmet>())
                .AddIngredient(ModContent.ItemType<IndiumBar>(), 15)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<GarnetStaff>())
                .Register();

            //Chainmail
            Recipe.Create(ModContent.ItemType<IndiumChainmail>())
                .AddIngredient(ModContent.ItemType<IndiumBar>(), 25)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<IndiumHelmet>())
                .Register();

            //Greaves
            Recipe.Create(ModContent.ItemType<IndiumGreaves>())
                .AddIngredient(ModContent.ItemType<IndiumBar>(), 20)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<IndiumChainmail>())
                .Register();

            //Watch
            Recipe.Create(ModContent.ItemType<IndiumWatch>())
                .AddIngredient(ModContent.ItemType<IndiumBar>(), 10)
                .AddIngredient(ItemID.Chain)
                .AddTile(TileID.Tables)
                .AddTile(TileID.Chairs)
                //.AddTile(TileID.WorkBenches) for when Tmodloader updates to 1.4.5
                .SortAfterFirstRecipesOf(ModContent.ItemType<IndiumGreaves>())
                .Register();

            //Crown
            Recipe.Create(ModContent.ItemType<IndiumCrown>())
                .AddIngredient(ModContent.ItemType<IndiumBar>(), 5)
                .AddIngredient(ModContent.ItemType<Garnet>())
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<IndiumWatch>())
                .Register();

            //Garnet Hook
            Recipe.Create(ModContent.ItemType<GarnetHook>())
                .AddIngredient(ModContent.ItemType<Garnet>(), 15)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.SapphireHook)
                .Register();

            //Garnet Robe
            Recipe.Create(ModContent.ItemType<GarnetRobe>())
                .AddIngredient(ItemID.Robe)
                .AddIngredient(ModContent.ItemType<Garnet>(), 10)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.SapphireRobe)
                .Register();

            //Large Garnet
            Recipe.Create(ModContent.ItemType<LargeGarnet>())
                .AddIngredient(ModContent.ItemType<Garnet>(), 15)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.LargeSapphire)
                .Register();
            #endregion

            #region Fluortie Recipes
            //Bar
            Recipe.Create(ModContent.ItemType<FluoriteBar>())
                .AddIngredient(ModContent.ItemType<FluoriteOreBlock>(), 3)
                .AddTile(TileID.Furnaces)
                .SortAfterFirstRecipesOf(ItemID.GoldCrown)
                .Register();

            //Pickaxe
            Recipe.Create(ModContent.ItemType<FluoritePickaxe>())
                .AddIngredient(ModContent.ItemType<FluoriteBar>(), 10)
                .AddRecipeGroup(RecipeGroupID.Wood, 4)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<FluoriteBar>())
                .Register();

            //Axe
            Recipe.Create(ModContent.ItemType<FluoriteAxe>())
            .AddIngredient(ModContent.ItemType<FluoriteBar>(), 8)
            .AddRecipeGroup(RecipeGroupID.Wood, 3)
            .AddTile(TileID.Anvils)
            .SortAfterFirstRecipesOf(ModContent.ItemType<FluoritePickaxe>())
            .Register();

            //Hammer
            Recipe.Create(ModContent.ItemType<FluoriteHammer>())
                .AddIngredient(ModContent.ItemType<FluoriteBar>(), 8)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<FluoriteAxe>())
                .Register();
            //Hoe
            Recipe.Create(ModContent.ItemType<FluoriteHoe>())
                .AddIngredient(ModContent.ItemType<FluoriteBar>(), 5)
                .AddRecipeGroup(RecipeGroupID.Wood, 3)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<FluoriteHammer>())
                .Register();

            //Broadsword
            Recipe.Create(ModContent.ItemType<FluoriteBroadsword>())
                .AddIngredient(ModContent.ItemType<FluoriteBar>(), 8)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<FluoriteHoe>())
                .Register();

            //Shortsword
            Recipe.Create(ModContent.ItemType<FluoriteShortsword>())
                .AddIngredient(ModContent.ItemType<FluoriteBar>(), 6)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<FluoriteBroadsword>())
                .Register();

            //Battleaxe
            Recipe.Create(ModContent.ItemType<FluoriteBattleaxe>())
                .AddIngredient(ModContent.ItemType<FluoriteBar>(), 9)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<FluoriteShortsword>())
                .Register();

            //Bow
            Recipe.Create(ModContent.ItemType<FluoriteBow>())
                .AddIngredient(ModContent.ItemType<FluoriteBar>(), 7)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<FluoriteBattleaxe>())
                .Register();

            //Lapis Staff
            Recipe.Create(ModContent.ItemType<LapisStaff>())
                .AddIngredient(ModContent.ItemType<FluoriteBar>(), 10)
                .AddIngredient(ModContent.ItemType<Lapis>(), 8)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<FluoriteBow>())
                .Register();

            //Helmet
            Recipe.Create(ModContent.ItemType<FluoriteHelmet>())
                .AddIngredient(ModContent.ItemType<FluoriteBar>(), 20)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<LapisStaff>())
                .Register();

            //Chainmail
            Recipe.Create(ModContent.ItemType<FluoriteChainmail>())
                .AddIngredient(ModContent.ItemType<FluoriteBar>(), 30)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<FluoriteHelmet>())
                .Register();

            //Greaves
            Recipe.Create(ModContent.ItemType<FluoriteGreaves>())
                .AddIngredient(ModContent.ItemType<FluoriteBar>(), 25)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<FluoriteChainmail>())
                .Register();

            //Watch
            Recipe.Create(ModContent.ItemType<FluoriteWatch>())
                .AddIngredient(ModContent.ItemType<FluoriteBar>(), 10)
                .AddIngredient(ItemID.Chain)
                .AddTile(TileID.Tables)
                .AddTile(TileID.Chairs)
                //.AddTile(TileID.WorkBenches) for when Tmodloader updates to 1.4.5
                .SortAfterFirstRecipesOf(ModContent.ItemType<FluoriteGreaves>())
                .Register();

            //Crown
            Recipe.Create(ModContent.ItemType<FluoriteCrown>())
                .AddIngredient(ModContent.ItemType<FluoriteBar>(), 5)
                .AddIngredient(ModContent.ItemType<Lapis>())
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<FluoriteWatch>())
                .Register();

            //Lapis Hook
            Recipe.Create(ModContent.ItemType<LapisHook>())
                .AddIngredient(ModContent.ItemType<Lapis>(), 15)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.RubyHook)
                .Register();

            //Lapis Robe
            Recipe.Create(ModContent.ItemType<LapisRobe>())
                .AddIngredient(ItemID.Robe)
                .AddIngredient(ModContent.ItemType<Lapis>(), 10)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.RubyRobe)
                .Register();

            //Large Lapis
            Recipe.Create(ModContent.ItemType<LargeLapis>())
                .AddIngredient(ModContent.ItemType<Lapis>(), 15)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ItemID.LargeRuby)
                .Register();
            #endregion

            #region Ingestane Recipes
            //Bar
            Recipe.Create(ModContent.ItemType<IngestaneBar>())
            .AddIngredient(ModContent.ItemType<IngestaneOre>(), 3)
            .AddTile(TileID.Furnaces)
            .SortAfterFirstRecipesOf(ModContent.ItemType<Depraverang>())
            .Register();

            //Fishing Rod
            Recipe.Create(ModContent.ItemType<Regurgitator>())
            .AddIngredient(ModContent.ItemType<IngestaneBar>(), 8)
            .AddTile(TileID.Anvils)
            .SortAfterFirstRecipesOf(ModContent.ItemType<IngestaneBar>())
            .Register();

            //Bow
            Recipe.Create(ModContent.ItemType<SulfirBow>())
            .AddIngredient(ModContent.ItemType<IngestaneBar>(), 8)
            .AddTile(TileID.Anvils)
            .SortAfterFirstRecipesOf(ModContent.ItemType<Regurgitator>())
            .Register();

            //Axe
            Recipe.Create(ModContent.ItemType<DirtySwamp>())
                .AddIngredient(ModContent.ItemType<IngestaneBar>(), 10)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<SulfirBow>())
                .Register();

            //Sword
            Recipe.Create(ModContent.ItemType<TheIndigestion>())
                .AddIngredient(ModContent.ItemType<IngestaneBar>(), 10)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<DirtySwamp>())
                .Register();

            Recipe.Create(ItemID.NightsEdge)
                .AddIngredient(ModContent.ItemType<TheIndigestion>(), 1)
                .AddIngredient(ItemID.BladeofGrass, 1)
                .AddIngredient(ItemID.FieryGreatsword, 1)
                .AddIngredient(ItemID.Muramasa, 1)
                .AddTile(TileID.DemonAltar)
                .Register();

            //Helmet
            Recipe.Create(ModContent.ItemType<CausticHelmet>())
                .AddIngredient(ModContent.ItemType<IngestaneBar>(), 15)
                .AddIngredient(ModContent.ItemType<FreshChyme>(), 10)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<TheIndigestion>())
                .Register();

            //Scalemail
            Recipe.Create(ModContent.ItemType<CausticScalemail>())
                .AddIngredient(ModContent.ItemType<IngestaneBar>(), 25)
                .AddIngredient(ModContent.ItemType<FreshChyme>(), 20)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<CausticHelmet>())
                .Register();

            //Greaves
            Recipe.Create(ModContent.ItemType<CausticGreaves>())
                .AddIngredient(ModContent.ItemType<IngestaneBar>(), 20)
                .AddIngredient(ModContent.ItemType<FreshChyme>(), 15)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<CausticScalemail>())
                .Register();

            //Pickaxe
            Recipe.Create(ModContent.ItemType<IngestedPickaxe>())
                .AddIngredient(ModContent.ItemType<IngestaneBar>(), 12)
                .AddIngredient(ModContent.ItemType<FreshChyme>(), 6)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<CausticGreaves>())
                .Register();

            //Hammer
            Recipe.Create(ModContent.ItemType<Squasher>())
                .AddIngredient(ModContent.ItemType<IngestaneBar>(), 11)
                .AddIngredient(ModContent.ItemType<FreshChyme>(), 4)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<IngestedPickaxe>())
                .Register();

            //Hoe
            Recipe.Create(ModContent.ItemType<Pukivator>())
                .AddIngredient(ModContent.ItemType<IngestaneBar>(), 5)
                .AddIngredient(ModContent.ItemType<FreshChyme>(), 3)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<Squasher>())
                .Register();

            //Battleaxe
            Recipe.Create(ModContent.ItemType<TheDisembowelment>())
                .AddIngredient(ModContent.ItemType<IngestaneBar>(), 9)
                .AddIngredient(ModContent.ItemType<FreshChyme>(), 2)
                .SortAfterFirstRecipesOf(ModContent.ItemType<Pukivator>())
                .AddTile(TileID.Anvils)
                .Register();

            //Spear
            Recipe.Create(ModContent.ItemType<TheToothpick>())
                .AddIngredient(ModContent.ItemType<IngestaneBar>(), 12)
                .AddIngredient(ModContent.ItemType<FreshChyme>(), 6)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<TheDisembowelment>())
                .Register();

            //Flail
            Recipe.Create(ModContent.ItemType<NauseaCudgel>())
                .AddIngredient(ModContent.ItemType<IngestaneBar>(), 10)
                .AddIngredient(ModContent.ItemType<FreshChyme>(), 2)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<TheToothpick>())
                .Register();

            //Yoyo
            Recipe.Create(ModContent.ItemType<TheDamp>())
                .AddIngredient(ModContent.ItemType<IngestaneBar>(), 12)
                .AddTile(TileID.Anvils)
                .SortAfterFirstRecipesOf(ModContent.ItemType<NauseaCudgel>())
                .Register();

            //Biliary Shield
            Recipe.Create(ModContent.ItemType<BiliaryShield>())
                .AddIngredient(ItemID.BandofStarpower)
                .AddIngredient(ItemID.AegisCrystal)
                .AddTile(TileID.TinkerersWorkbench)
                .AddCondition(Condition.InGraveyard)
                .SortAfterFirstRecipesOf(ItemID.BandofStarpower)
                .Register();

            Recipe.Create(ItemID.BandofStarpower)
                .AddIngredient(ModContent.ItemType<BiliaryShield>())
                .AddIngredient(ItemID.ManaCrystal)
                .AddTile(TileID.TinkerersWorkbench)
                .AddCondition(Condition.InGraveyard)
                .SortBeforeFirstRecipesOf(ItemID.BandofStarpower)
                .Register();

            Recipe.Create(ModContent.ItemType<BiliaryShield>())
                .AddIngredient(ItemID.PanicNecklace)
                .AddIngredient(ItemID.AegisCrystal)
                .AddTile(TileID.TinkerersWorkbench)
                .AddCondition(Condition.InGraveyard)
                .SortAfterFirstRecipesOf(ModContent.ItemType<BiliaryShield>())
                .Register();

            Recipe.Create(ItemID.PanicNecklace)
                .AddIngredient(ModContent.ItemType<BiliaryShield>())
                .AddIngredient(ItemID.LifeCrystal)
                .AddTile(TileID.TinkerersWorkbench)
                .AddCondition(Condition.InGraveyard)
                .SortBeforeFirstRecipesOf(ItemID.PanicNecklace)
                .Register();
            #endregion
            #endregion
        }
    }
}