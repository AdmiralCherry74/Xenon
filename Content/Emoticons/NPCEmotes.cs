using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.GameContent.UI;
using Terraria.ModLoader;

namespace Xenon.Content.Emoticons
{
    public abstract class ModTownEmote : ModEmoteBubble
    {
        // Redirecting texture path.
        public override string Texture => "Xenon/Content/Emoticons/NPCEmotes";

        public override void SetStaticDefaults()
        {
            // Add NPC emotes to "Town" category.
            AddToCategory(EmoteID.Category.Town);
        }

        /// <summary>
        /// Which row of the sprite sheet is this NPC emote in?
        /// This is used to help get the correct frame rectangle for different emotes.
        /// </summary>
        public virtual int Row => 0;

        // You should decide the frame rectangle yourself by these two methods.
        public override Rectangle? GetFrame()
        {
            return new Rectangle(EmoteBubble.frame * 34, 28 * Row, 34, 28);
        }

        // Do note that you should never use EmoteBubble instance as the GetFrame() method above
        // in "Emote Menu Methods" (methods with -InEmoteMenu suffix).
        // Because in that case the value of EmoteBubble is always null.
        public override Rectangle? GetFrameInEmoteMenu(int frame, int frameCounter)
        {
            return new Rectangle(frame * 34, 28 * Row, 34, 28);
        }
    }
    public class BakerEmote : ModTownEmote
    {
        public override void OnSpawn()
        {
            // This code makes the emote remain longer than vanilla emotes.
            EmoteBubble.lifeTime *= 1;
            EmoteBubble.lifeTimeStart *= 1;
        }

        public override int Row => 0;
    }
}