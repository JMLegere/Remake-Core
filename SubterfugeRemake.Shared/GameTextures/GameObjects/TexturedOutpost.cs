﻿using System;
using System.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using SubterfugeCore.Entities;
using SubterfugeCore.Entities.Base;
using SubterfugeFrontend.Shared.Content.Game.Events;
using SubterfugeFrontend.Shared.Content.Game.Events.Events;
using SubterfugeFrontend.Shared.Content.Game.Events.Listeners;
using Color = Microsoft.Xna.Framework.Color;

namespace SubterfugeFrontend.Shared.Content.Game.Graphics.GameObjects
{
    class TexturedOutpost : TexturedGameObject
    {

        public TexturedOutpost(GameObject gameObject) : base(gameObject, SubterfugeApp.SpriteLoader.getSprite("GeneratorFill"),
            100, 100)
        {
            InputListener.touchListener.Press += onPress;
        }

        public void onPress(object sender, TouchPressEvent touchPress)
        {
            /*
            // Get the screen position of the touch.

            // This is slightly confusing so I will explain it here.
            // THis first call is calling the DeviceCamera class to translate the user's touch location to the actual position that the player
            // clicked on the screen. Because the user's device can be of any size, this converts the points to the right location based on the device size.
            Microsoft.Xna.Framework.Point location = DeviceCamera.getWorldLocation(touchPress.touch.Position);

            // This second translation moves the actual touch location to the position in the world map.
            // This location is the final position which can be compared to the outpost's actual location.
            Vector2 worldLocation = Camera.getWorldPosition(new Vector2(location.X, location.Y));

            // Determine if the press was on the outpost.
            if (this.getBoundingBox().Contains(new PointF((int)worldLocation.X, (int)worldLocation.Y)))
            {
                // Set the selected outpost and wait for a release event.
                Console.WriteLine("Outpost Selected!!!");

            }
            */
        }

        public override void render(SpriteBatch spriteBatch)
        {
            Color playerColor;

            switch (((Outpost)this.gameObject).getOwner().getId())
            {
                case 1:
                    playerColor = Color.Blue;
                    break;
                case 2:
                    playerColor = Color.Red;
                    break;
                default:
                    playerColor = Color.White;
                    break;
            }

            spriteBatch.Draw(
                texture: this.getTexture(),
                destinationRectangle: Camera.getRelativeScreenBoundary(this),
                color: playerColor,
                sourceRectangle: this.getTexture().Bounds,
                effects: new SpriteEffects(),
                layerDepth: 1,
                rotation: 0,
                origin: this.getTexture().Bounds.Size.ToVector2() / 2f);


            SpriteFont font = SubterfugeApp.FontLoader.getFont("Arial");
            string drillerCount = ((Outpost)this.gameObject).getDrillerCount().ToString();
            Vector2 stringSize = font.MeasureString(drillerCount);


            spriteBatch.DrawString(
                spriteFont: SubterfugeApp.FontLoader.getFont("Arial"),
                text: drillerCount,
                position: Camera.getRelativeScreenPosition(this.getPosition()),
                color: Color.White,
                rotation: 0,
                origin: stringSize / 2f,
                layerDepth: 1f,
                scale: 1.5f,
                effects: SpriteEffects.None);
        }
    }
}
