using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.Reflection;
using Terraria;
using Terraria.GameContent.Drawing;
using Terraria.ModLoader;
using Terraria.Utilities;
using Xenon.Common;
using Xenon.Common.Systems;
using Xenon.Content.Dusts;
using static Terraria.GameContent.Drawing.TileDrawing;

namespace Xenon.Content.Tiles.Decoration.Furniture.Rhyolite;

public class RhyoliteBathtub : BathtubTemplate { }

public class RhyoliteBed : BedTemplate
{
	public override int DropItem => ModContent.ItemType<Items.Placeable.Furniture.Rhyolite.RhyoliteBed>();
}

public class RhyoliteBookcase : BookcaseTemplate { }

public class RhyoliteCandelabra : CandelabraTemplate
{
	private static Asset<Texture2D> flameTexture;
	public override void SetStaticDefaults()
	{
		base.SetStaticDefaults();
		flameTexture = ModContent.Request<Texture2D>(Texture + "_Flame");
	}
	public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
	{
		Tile tile = Main.tile[i, j];
		if (tile.TileFrameX <= 36)
		{
			r = (float)(224f / 255f);
			g = (float)(26f / 255f);
			b = (float)(202f / 255f);
		}
	}

	public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
	{
		ulong randSeed = Main.TileFrameSeed ^ (ulong)((long)j << 32 | (long)(ulong)i);
		Color color = new Color(198, 171, 108, 0);
		int frameX = Main.tile[i, j].TileFrameX;
		int frameY = Main.tile[i, j].TileFrameY;
		int width = 18;
		int offsetY = 2;
		int height = 18;
		int offsetX = 1;
		Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
		if (Main.drawToScreen)
		{
			zero = Vector2.Zero;
		}
		for (int k = 0; k < 7; k++)
		{
			float x = Utils.RandomInt(ref randSeed, -10, 11) * 0.15f;
			float y = Utils.RandomInt(ref randSeed, -10, 1) * 0.35f;
			Main.spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X + offsetX - (width - 16f) / 2f + x, j * 16 - (int)Main.screenPosition.Y + offsetY + y) + zero, new Rectangle(frameX, frameY, width, height), color, 0f, default, 1f, SpriteEffects.None, 0f);
		}
	}
}

public class RhyoliteCandle : CandleTemplate
{
	public override int DropItem => ModContent.ItemType<Items.Placeable.Furniture.Rhyolite.RhyoliteCandle>();
	private static Asset<Texture2D> flameTexture;
	public override void SetStaticDefaults()
	{
		base.SetStaticDefaults();
		flameTexture = ModContent.Request<Texture2D>(Texture + "_Flame");
	}
	public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
	{
		Tile tile = Main.tile[i, j];
		if (tile.TileFrameX == 0)
		{
			r = (float)(224f / 255f);
			g = (float)(26f / 255f);
			b = (float)(202f / 255f);
		}
	}

	public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
	{
		ulong randSeed = Main.TileFrameSeed ^ (ulong)((long)j << 32 | (long)(ulong)i);
		Color color = new Color(198, 171, 108, 0);
		int frameX = Main.tile[i, j].TileFrameX;
		int frameY = Main.tile[i, j].TileFrameY;
		int width = 18;
		int offsetY = -4;
		int height = 20;
		int offsetX = 1;
		Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
		if (Main.drawToScreen)
		{
			zero = Vector2.Zero;
		}
		for (int k = 0; k < 7; k++)
		{
			float x = Utils.RandomInt(ref randSeed, -10, 11) * 0.15f;
			float y = Utils.RandomInt(ref randSeed, -10, 1) * 0.35f;
			Main.spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X + offsetX - (width - 16f) / 2f + x, j * 16 - (int)Main.screenPosition.Y + offsetY + y) + zero, new Rectangle(frameX, frameY, width, height), color, 0f, default, 1f, SpriteEffects.None, 0f);
		}
	}
}

public class RhyoliteChair : ChairTemplate
{
	public override int DropItem => ModContent.ItemType<Items.Placeable.Furniture.Rhyolite.RhyoliteChair>();
}

public class RhyoliteChandelier : ChandelierTemplate
{
	public override Color FlameColor => new Color(224, 26, 202, 0);
	public override int DropItem => ModContent.ItemType<Items.Placeable.Furniture.Rhyolite.RhyoliteChandelier>();
	public List<Point> Coordinates = new List<Point>();
	private static Asset<Texture2D> flameTexture;
	public override void SetStaticDefaults()
	{
		base.SetStaticDefaults();
		Coordinates = new();
		flameTexture = ModContent.Request<Texture2D>(Texture + "_Flame");
	}
	public override void KillMultiTile(int i, int j, int frameX, int frameY)
	{
		Point p = new(i, j);
		if (Coordinates.Contains(p)) Coordinates.Remove(p);
	}
	public void DrawMultiTileVines(int i, int j, SpriteBatch spriteBatch)
	{
		Vector2 unscaledPosition = Main.Camera.UnscaledPosition;
		Vector2 zero = Vector2.Zero;
		int sizeX = 1;
		int sizeY = 1;
		Tile tile = Main.tile[i, j];
		if (tile != null && tile.HasTile)
		{
			sizeX = 3;
			sizeY = 3;
			DrawMultiTileVinesInWind(unscaledPosition, zero, i, j, sizeX, sizeY, spriteBatch);
		}
	}

	private void DrawMultiTileVinesInWind(Vector2 screenPosition, Vector2 offSet, int topLeftX, int topLeftY, int sizeX, int sizeY, SpriteBatch spriteBatch)
	{
		double _sunflowerWindCounter = (double)typeof(TileDrawing).GetField("_sunflowerWindCounter", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance).GetValue(Main.instance.TilesRenderer);
		UnifiedRandom _rand = (UnifiedRandom)typeof(TileDrawing).GetField("_rand", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance).GetValue(Main.instance.TilesRenderer);
		bool _isActiveAndNotPaused = (bool)typeof(TileDrawing).GetField("_isActiveAndNotPaused", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance).GetValue(Main.instance.TilesRenderer);

		ulong randSeed = Main.TileFrameSeed ^ (ulong)((long)topLeftY << 32 | (long)(ulong)topLeftX);

		float windCycle = (float)typeof(TileDrawing).GetMethod("GetWindCycle", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).Invoke(Main.instance.TilesRenderer, new object[] { topLeftX, topLeftY, _sunflowerWindCounter });
		float num = windCycle;
		int totalPushTime = 60;
		float pushForcePerFrame = 1.26f;
		float highestWindGridPushComplex = (float)typeof(TileDrawing).GetMethod("GetHighestWindGridPushComplex", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).Invoke(Main.instance.TilesRenderer, new object[] { topLeftX, topLeftY, sizeX, sizeY, totalPushTime, pushForcePerFrame, 3, true });
		windCycle += highestWindGridPushComplex;
		new Vector2(sizeX * 16 * 0.5f, 0f);
		Vector2 vector = new Vector2(topLeftX * 16 - (int)screenPosition.X + sizeX * 16f * 0.5f, topLeftY * 16 - (int)screenPosition.Y) + offSet;
		float num2 = 0.07f;
		Tile tile = Main.tile[topLeftX, topLeftY];
		int type = tile.TileType;
		Vector2 vector2 = new(0f, -2f);
		vector += vector2;
		Texture2D texture2D = null;
		Color color = Color.Transparent;
		float? num3 = null;
		float num4 = 1f;
		float num5 = -4f;
		bool flag2 = false;
		num2 = 0.15f;
		num3 = 1f;
		num5 = 0f;
		if (flag2)
		{
			vector += new Vector2(0f, 16f);
		}
		num2 *= -1f;
		if (!WorldGen.InAPlaceWithWind(topLeftX, topLeftY, sizeX, sizeY))
		{
			windCycle -= num;
		}
		Vector2 vector4 = default;
		Rectangle rectangle = default;
		for (int i = topLeftX; i < topLeftX + sizeX; i++)
		{
			for (int j = topLeftY; j < topLeftY + sizeY; j++)
			{
				Tile tile2 = Main.tile[i, j];
				ushort type2 = tile2.TileType;
				if (type2 != type || !IsVisible(tile2))
				{
					return;
				}
				Math.Abs((i - topLeftX + 0.5f) / sizeX - 0.5f);
				short tileFrameX = tile2.TileFrameX;
				short tileFrameY = tile2.TileFrameY;
				float num7 = (j - topLeftY + 1) / (float)sizeY;
				if (num7 == 0f)
				{
					num7 = 0.1f;
				}
				if (num3.HasValue)
				{
					num7 = num3.Value;
				}
				if (flag2 && j == topLeftY)
				{
					num7 = 0f;
				}
				Main.instance.TilesRenderer.GetTileDrawData(i, j, tile2, type2, ref tileFrameX, ref tileFrameY, out var tileWidth, out var tileHeight, out var tileTop, out var halfBrickHeight, out var addFrX, out var addFrY, out var tileSpriteEffect, out var _, out var _, out var _);
				bool flag3 = _rand.Next(4) == 0;
				Color tileLight = Lighting.GetColor(i, j);
				typeof(TileDrawing).GetMethod("DrawAnimatedTile_AdjustForVisionChangers", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).Invoke(Main.instance.TilesRenderer, new object[] { i, j, tile2, type2, tileFrameX, tileFrameY, tileLight, flag3 });
				tileLight = (Color)typeof(TileDrawing).GetMethod("DrawTiles_GetLightOverride", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).Invoke(Main.instance.TilesRenderer, new object[] { j, i, tile2, type2, tileFrameX, tileFrameY, tileLight });
				tileLight = TileGlowDrawing.ActuatedColor(tileLight, tile);
				if (_isActiveAndNotPaused && flag3)
				{
					typeof(TileDrawing).GetMethod("DrawTiles_EmitParticles", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).Invoke(Main.instance.TilesRenderer, new object[] { j, i, tile2, type2, tileFrameX, tileFrameY, tileLight });
				}
				Vector2 vector3 = new Vector2(i * 16 - (int)screenPosition.X, j * 16 - (int)screenPosition.Y + tileTop) + offSet;
				vector3 += vector2;
				vector4 = new(windCycle * num4, Math.Abs(windCycle) * num5 * num7);
				Vector2 vector5 = vector - vector3;
				Texture2D tileDrawTexture = Main.instance.TilesRenderer.GetTileDrawTexture(tile2, i, j);
				if (tileDrawTexture != null)
				{

					Vector2 vector6 = vector + new Vector2(0f, vector4.Y);
					rectangle = new(tileFrameX + addFrX, tileFrameY + addFrY, tileWidth, tileHeight - halfBrickHeight);
					float rotation = windCycle * num2 * num7;
					Main.spriteBatch.Draw(tileDrawTexture, vector6, (Rectangle?)rectangle, tileLight, rotation, vector5, 1f, tileSpriteEffect, 0f);

					for (int q = 0; q < 7; q++)
					{
						float x = Utils.RandomInt(ref randSeed, -10, 11) * FlameJitterMultX;
						float y = Utils.RandomInt(ref randSeed, -10, 1) * FlameJitterMultY;
						spriteBatch.Draw(flameTexture.Value, vector6 + new Vector2(x, y), (Rectangle?)rectangle, FlameColor, rotation, vector5, 1f, tileSpriteEffect, 0f);
					}
				}
			}
		}
	}
	public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
	{
		if (Main.tile[i, j].TileFrameX % 54 == 0 && Main.tile[i, j].TileFrameY % 54 == 0)
		{
			Point p = new(i, j);
			if (!Coordinates.Contains(p)) Coordinates.Add(p);
		}
		return false;
	}
	public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
	{
		Tile tile = Main.tile[i, j];
		if (tile.TileFrameX <= 52)
		{
			r = (float)(224f / 255f);
			g = (float)(26f / 255f);
			b = (float)(202f / 255f);
		}
	}
}

public class RhyoliteChest : ChestTemplate
{
	public override int DropItem => ModContent.ItemType<Items.Placeable.Furniture.Rhyolite.RhyoliteChest>();
	//public override IEnumerable<Item> GetItemDrops(int i, int j)
	//{
	//    Tile tile = Main.tile[i, j];
	//    int style = TileObjectData.GetTileStyle(tile);
	//    if (style == 0)
	//    {
	//        yield return new Item(ModContent.ItemType<Items.Placeable.Furniture.Rhyolite.RhyoliteChest>());
	//    }
	//    if (style == 1)
	//    {
	//        // Style 1 is ExampleChest when locked. We want that tile style to drop the ExampleChest item as well. Use the Chest Lock item to lock this chest.
	//        // No item places ExampleChest in the locked style, so the automatic item drop is unknown, this is why GetItemDrops is necessary in this situation.
	//        yield return new Item(ModContent.ItemType<Items.Placeable.Furniture.Rhyolite.RhyoliteChest>());
	//    }
	//}
}

public class RhyoliteClock : ClockTemplate
{
	public override int DropItem => ModContent.ItemType<Items.Placeable.Furniture.Rhyolite.RhyoliteClock>();
}

public class RhyoliteDoorClosed : ClosedDoorTemplate
{
	public override int DropItem => ModContent.ItemType<Items.Placeable.Furniture.Rhyolite.RhyoliteDoor>();
}

public class RhyoliteDoorOpen : OpenDoorTemplate
{
	public override int DropItem => ModContent.ItemType<Items.Placeable.Furniture.Rhyolite.RhyoliteDoor>();
}

public class RhyoliteDresser : DresserTemplate
{
	public override int DropItem => ModContent.ItemType<Items.Placeable.Furniture.Rhyolite.RhyoliteDresser>();
}

public class RhyoliteLamp : LampTemplate
{
	public override int DropItem => ModContent.ItemType<Items.Placeable.Furniture.Rhyolite.RhyoliteLamp>();
	private static Asset<Texture2D> flameTexture;
	public override void SetStaticDefaults()
	{
		base.SetStaticDefaults();
		flameTexture = ModContent.Request<Texture2D>(Texture + "_Flame");
	}
	public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
	{
		Tile tile = Main.tile[i, j];
		if (tile.TileFrameX == 0)
		{
			r = (float)(224f / 255f);
			g = (float)(26f / 255f);
			b = (float)(202f / 255f);
		}
	}

	public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
	{
		ulong randSeed = Main.TileFrameSeed ^ (ulong)((long)j << 32 | (long)(ulong)i);
		Color color = new Color(198, 171, 108, 0);
		int frameX = Main.tile[i, j].TileFrameX;
		int frameY = Main.tile[i, j].TileFrameY;
		int width = 18;
		int offsetY = 0;
		int height = 18;
		int offsetX = 1;
		Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
		if (Main.drawToScreen)
		{
			zero = Vector2.Zero;
		}
		for (int k = 0; k < 7; k++)
		{
			float x = Utils.RandomInt(ref randSeed, -10, 11) * 0.15f;
			float y = Utils.RandomInt(ref randSeed, -10, 1) * 0.35f;
			Main.spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X + offsetX - (width - 16f) / 2f + x, j * 16 - (int)Main.screenPosition.Y + offsetY + y) + zero, new Rectangle(frameX, frameY, width, height), color, 0f, default, 1f, SpriteEffects.None, 0f);
		}
	}
}

public class RhyoliteLantern : LanternTemplate
{
	public override bool HasFlameTexture => false;
	public override int DropItem => ModContent.ItemType<Items.Placeable.Furniture.Rhyolite.RhyoliteLantern>();
	public List<Point> Coordinates = new List<Point>();
	private static Asset<Texture2D> flameTexture;
	public override void SetStaticDefaults()
	{
		base.SetStaticDefaults();
		Coordinates = new();
		flameTexture = HasFlameTexture ? ModContent.Request<Texture2D>(Texture + "_Flame") : null;
	}
	public override void KillMultiTile(int i, int j, int frameX, int frameY)
	{
		Point p = new(i, j);
		if (Coordinates.Contains(p)) Coordinates.Remove(p);
	}
	public void DrawMultiTileVines(int i, int j, SpriteBatch spriteBatch)
	{
		Vector2 unscaledPosition = Main.Camera.UnscaledPosition;
		Vector2 zero = Vector2.Zero;
		int sizeX = 1;
		int sizeY = 1;
		Tile tile = Main.tile[i, j];
		if (tile != null && tile.HasTile)
		{
			sizeX = 1;
			sizeY = 2;
			DrawMultiTileVinesInWind(unscaledPosition, zero, i, j, sizeX, sizeY, spriteBatch);
		}
	}

	private void DrawMultiTileVinesInWind(Vector2 screenPosition, Vector2 offSet, int topLeftX, int topLeftY, int sizeX, int sizeY, SpriteBatch spriteBatch)
	{
		double _sunflowerWindCounter = (double)typeof(TileDrawing).GetField("_sunflowerWindCounter", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance).GetValue(Main.instance.TilesRenderer);
		UnifiedRandom _rand = (UnifiedRandom)typeof(TileDrawing).GetField("_rand", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance).GetValue(Main.instance.TilesRenderer);
		bool _isActiveAndNotPaused = (bool)typeof(TileDrawing).GetField("_isActiveAndNotPaused", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance).GetValue(Main.instance.TilesRenderer);

		ulong randSeed = Main.TileFrameSeed ^ (ulong)((long)topLeftY << 32 | (long)(ulong)topLeftX);

		float windCycle = (float)typeof(TileDrawing).GetMethod("GetWindCycle", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).Invoke(Main.instance.TilesRenderer, new object[] { topLeftX, topLeftY, _sunflowerWindCounter });
		float num = windCycle;
		int totalPushTime = 60;
		float pushForcePerFrame = 1.26f;
		float highestWindGridPushComplex = (float)typeof(TileDrawing).GetMethod("GetHighestWindGridPushComplex", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).Invoke(Main.instance.TilesRenderer, new object[] { topLeftX, topLeftY, sizeX, sizeY, totalPushTime, pushForcePerFrame, 3, true });
		windCycle += highestWindGridPushComplex;
		new Vector2(sizeX * 16 * 0.5f, 0f);
		Vector2 vector = new Vector2(topLeftX * 16 - (int)screenPosition.X + sizeX * 16f * 0.5f, topLeftY * 16 - (int)screenPosition.Y) + offSet;
		float num2 = 0.07f;
		Tile tile = Main.tile[topLeftX, topLeftY];
		int type = tile.TileType;
		Vector2 vector2 = new(0f, -2f);
		vector += vector2;
		Texture2D texture2D = null;
		Color color = Color.Transparent;
		float? num3 = null;
		float num4 = 1f;
		float num5 = -4f;
		bool flag2 = false;
		num2 = 0.15f;
		num3 = 1f;
		num5 = 0f;
		if (flag2)
		{
			vector += new Vector2(0f, 16f);
		}
		num2 *= -1f;
		if (!WorldGen.InAPlaceWithWind(topLeftX, topLeftY, sizeX, sizeY))
		{
			windCycle -= num;
		}
		Vector2 vector4 = default;
		Rectangle rectangle = default;
		for (int i = topLeftX; i < topLeftX + sizeX; i++)
		{
			for (int j = topLeftY; j < topLeftY + sizeY; j++)
			{
				Tile tile2 = Main.tile[i, j];
				ushort type2 = tile2.TileType;
				if (type2 != type || !IsVisible(tile2))
				{
					return;
				}
				Math.Abs((i - topLeftX + 0.5f) / sizeX - 0.5f);
				short tileFrameX = tile2.TileFrameX;
				short tileFrameY = tile2.TileFrameY;
				float num7 = (j - topLeftY + 1) / (float)sizeY;
				if (num7 == 0f)
				{
					num7 = 0.1f;
				}
				if (num3.HasValue)
				{
					num7 = num3.Value;
				}
				if (flag2 && j == topLeftY)
				{
					num7 = 0f;
				}
				Main.instance.TilesRenderer.GetTileDrawData(i, j, tile2, type2, ref tileFrameX, ref tileFrameY, out var tileWidth, out var tileHeight, out var tileTop, out var halfBrickHeight, out var addFrX, out var addFrY, out var tileSpriteEffect, out var _, out var _, out var _);
				bool flag3 = _rand.Next(4) == 0;
				Color tileLight = Lighting.GetColor(i, j);
				typeof(TileDrawing).GetMethod("DrawAnimatedTile_AdjustForVisionChangers", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).Invoke(Main.instance.TilesRenderer, new object[] { i, j, tile2, type2, tileFrameX, tileFrameY, tileLight, flag3 });
				tileLight = (Color)typeof(TileDrawing).GetMethod("DrawTiles_GetLightOverride", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).Invoke(Main.instance.TilesRenderer, new object[] { j, i, tile2, type2, tileFrameX, tileFrameY, tileLight });
				tileLight = TileGlowDrawing.ActuatedColor(tileLight, tile);
				if (_isActiveAndNotPaused && flag3)
				{
					typeof(TileDrawing).GetMethod("DrawTiles_EmitParticles", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).Invoke(Main.instance.TilesRenderer, new object[] { j, i, tile2, type2, tileFrameX, tileFrameY, tileLight });
				}
				Vector2 vector3 = new Vector2(i * 16 - (int)screenPosition.X, j * 16 - (int)screenPosition.Y + tileTop) + offSet;
				vector3 += vector2;
				vector4 = new(windCycle * num4, Math.Abs(windCycle) * num5 * num7);
				Vector2 vector5 = vector - vector3;
				Texture2D tileDrawTexture = Main.instance.TilesRenderer.GetTileDrawTexture(tile2, i, j);
				if (tileDrawTexture != null)
				{

					Vector2 vector6 = vector + new Vector2(0f, vector4.Y);
					rectangle = new(tileFrameX + addFrX, tileFrameY + addFrY, tileWidth, tileHeight - halfBrickHeight);
					float rotation = windCycle * num2 * num7;
					Main.spriteBatch.Draw(tileDrawTexture, vector6, (Rectangle?)rectangle, tileLight, rotation, vector5, 1f, tileSpriteEffect, 0f);

					if (HasFlameTexture)
					{
						for (int q = 0; q < 7; q++)
						{
							float x = Utils.RandomInt(ref randSeed, -10, 11) * FlameJitterMultX;
							float y = Utils.RandomInt(ref randSeed, -10, 1) * FlameJitterMultY;
							spriteBatch.Draw(flameTexture.Value, vector6 + new Vector2(x, y), (Rectangle?)rectangle, FlameColor, rotation, vector5, 1f, tileSpriteEffect, 0f);
						}
					}
				}
			}
		}
	}
	public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
	{
		if (Main.tile[i, j].TileFrameX % 18 == 0 && Main.tile[i, j].TileFrameY % 36 == 0)
		{
			Point p = new(i, j);
			if (!Coordinates.Contains(p)) Coordinates.Add(p);
		}
		return false;
	}
	public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
	{
		Tile tile = Main.tile[i, j];
		if (tile.TileFrameX == 0)
		{
			r = (float)(224f / 255f);
			g = (float)(26f / 255f);
			b = (float)(202f / 255f);
		}
	}
}

public class RhyolitePiano : PianoTemplate { }

public class RhyolitePlatform : PlatformTemplate
{
	public override int Dust => ModContent.DustType<RhyoliteDust>();
}

public class RhyoliteSink : SinkTemplate { }

public class RhyoliteSofa : SofaTemplate
{
	public override int DropItem => ModContent.ItemType<Items.Placeable.Furniture.Rhyolite.RhyoliteSofa>();
}

public class RhyoliteTable : TableTemplate { }

public class RhyoliteToilet : ToiletTemplate
{
	public override int DropItem => ModContent.ItemType<Items.Placeable.Furniture.Rhyolite.RhyoliteToilet>();
}

public class RhyoliteWorkBench : WorkbenchTemplate { }
