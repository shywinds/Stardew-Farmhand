using Farmhand;
using Farmhand.Events;
using Farmhand.Events.Arguments.ControlEvents;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using StardewValley;

namespace EnableDebugMod
{
    public class EnableDebugMod : Mod
    {
        public static string lastDebugInput;

        public override void Entry()
        {
            ControlEvents.OnKeyPressed += ControlEvents_OnKeyPressed;
        }

        private void ControlEvents_OnKeyPressed(object sender, EventArgsKeyPressed e)
        {
            if (Game1.paused)
                return;

            var keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.F8) && !Game1.oldKBState.IsKeyDown(Keys.F8))
                Game1.game1.requestDebugInput();

            if (e.KeyPressed == Keys.N && (Game1.oldKBState.IsKeyDown(Keys.RightShift) && Game1.oldKBState.IsKeyDown(Keys.LeftControl)))
            {
                Game1.loadForNewGame();
                Game1.saveOnNewDay = false;
                Game1.player.eventsSeen.Add(60367);
                Game1.player.currentLocation = Utility.getHomeOfFarmer(Game1.player);
                Game1.player.position = new Vector2(7f, 9f) * (float)Game1.tileSize;
                Game1.NewDay(0.0f);
                Game1.exitActiveMenu();
                Game1.setGameMode(3);
            }
        }
    }
}
