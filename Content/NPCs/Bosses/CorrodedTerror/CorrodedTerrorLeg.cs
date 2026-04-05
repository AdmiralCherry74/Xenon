using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;

using Terraria;
using Terraria.GameContent;

namespace Xenon.Content.NPCs.Bosses.CorrodedTerror;

public class CorrodedTerrorLeg(int i)
{
    public float Upper = 50f;
    public float Lower = 60f;

    private float stepProgress;

    private int index = i;
    private int group = i % 2;

    public Vector2 Root, Middle, Foot, Target;

    public void Update(NPC npc, Player target, ref float globalTimer)
    {
        float angle = MathHelper.TwoPi / 8 * index;

        // Attach the root around the boss' body.
        Vector2 bodyOffset = angle.ToRotationVector2() * 70f;
        Root = npc.Center + bodyOffset;

        // Background "surface" illusion.
        Vector2 outward = Vector2.Normalize(Root - npc.Center);
        Vector2 desired = Root + outward * 120f;

        // Add jitter to simulate crawling across surface.
        desired += new Vector2((float)Math.Sin(globalTimer * 0.05f + index) * 10f, (float)Math.Cos(globalTimer * 0.04f + index) * 10f);

        Target = desired;

        // Alternate stepping.
        if ((globalTimer / 20) % 2 == group)
        {
            if (Vector2.Distance(Foot, Target) > 25f)
            {
                stepProgress += 0.08f;

                Vector2 lifted = Vector2.Lerp(Foot, Target, stepProgress);
                float height = (float)Math.Sin(stepProgress * Math.PI) * 20f;
                lifted.Y -= height;

                Foot = lifted;
            }
            else
                stepProgress = 0f;
        }

        SolveIK(Root, Foot);
    }

    private void SolveIK(Vector2 rootPosition, Vector2 targetPosition)
    {
        Vector2 diff = targetPosition - rootPosition;
        float dist = MathHelper.Clamp(diff.Length(), 10f, Upper + Lower - 1f);

        float a1 = Upper;
        float a2 = Lower;

        float baseAngle = diff.ToRotation();

        float cos = (a1 * a1 + a2 * a2 - dist * dist) / (2 * a1 * a2);
        cos = MathHelper.Clamp(cos, -1f, 1f);
        float angle = (float)Math.Acos(cos);

        float cos2 = (dist * dist + a1 * a1 - a2 * a2) / (2 * dist * a1);
        cos2 = MathHelper.Clamp(cos2, -1f, 1f);
        float angle2 = (float)Math.Acos(cos2);

        float jointAngle = baseAngle - angle2;

        Middle = rootPosition + jointAngle.ToRotationVector2() * a1;
        Foot = Middle + (jointAngle + angle).ToRotationVector2() * a2;
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 screenPosition)
    {
        Texture2D texture = TextureAssets.MagicPixel.Value;
        DrawLine(spriteBatch, texture, Root, Middle, screenPosition, Color.DarkOliveGreen * 0.8f);
        DrawLine(spriteBatch, texture, Middle, Foot, screenPosition, Color.GreenYellow * 0.8f);
    }

    private static void DrawLine(SpriteBatch sb, Texture2D tex, Vector2 start, Vector2 end, Vector2 screenPos, Color color)
    {
        Vector2 edge = end - start;
        sb.Draw(tex, start - screenPos, null, color, edge.ToRotation(), Vector2.Zero, new Vector2(edge.Length(), 3f), SpriteEffects.None, 0f);
    }
}
