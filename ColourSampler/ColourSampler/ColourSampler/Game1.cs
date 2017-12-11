using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace ColourSampler
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        Color colour;
        int menuItem = 1;
        float triggerLT = 0;
        float triggerRT = 0;
        int red, green, blue = 20;
        int textBoxWidth = 90;
        int textBoxHeight = 30;
        int movedLast;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("spritefont1");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {


            // TODO: Add your update logic here

            //Clamp the colours so they between 0 and 255
            red = (int)MathHelper.Clamp(red, 0, 255);
            green = (int)MathHelper.Clamp(green, 0, 255);
            blue = (int)MathHelper.Clamp(blue, 0, 255);

            colour = new Color(red, green, blue);

        //add keyboard and Gamepadstate
             KeyboardState state = Keyboard.GetState();
             GamePadState gamepad1 =GamePad.GetState(PlayerIndex.One);



            //Check triggers here
             
                 //Check Left trigger
                 triggerLT = GamePad.GetState(PlayerIndex.One).Triggers.Left;
                 if (triggerLT > .2 && menuItem == 1 && red > 0 || state.IsKeyDown(Keys.Down) && menuItem == 1 && red > 0)
                 {
                     if (red > 0){
                         red -= 5;
                     }
                 }
                 else if (triggerLT > .2 && menuItem == 2 && green > 0 || state.IsKeyDown(Keys.Down) && menuItem == 2 && green > 0)
                 {
                     green -= 5;
                 }
                 else if (triggerLT > .2 && menuItem == 3 && blue > 0 || state.IsKeyDown(Keys.Down) && menuItem == 3 && blue > 0)
                 {
                     blue -= 5;
                 }

        //Check Right trigger
            triggerRT = GamePad.GetState(PlayerIndex.One).Triggers.Right;
            if (triggerRT > .2 && menuItem == 1 && red < 255 || state.IsKeyDown(Keys.Up) && menuItem == 1 && red < 255)
            {
                red += 5;
            }
            else if (triggerRT > .2 && menuItem == 2 && green < 255 || state.IsKeyDown(Keys.Up) && menuItem == 2 && green < 255)
            {
                green += 5;
            }
            else if (triggerRT > .2 && menuItem == 3 && blue < 255 || state.IsKeyDown(Keys.Up) && menuItem == 3 && blue < 255)
            {
                blue += 5;
            } 



              if (gameTime.TotalGameTime.TotalMilliseconds - movedLast > 115){
         //Check Dpad buttons or up/down on keyboard
                   if(GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed || state.IsKeyDown(Keys.Right))
                   {
                      menuItem++;
                        if (menuItem == 4){
                            menuItem = 1;
                        }
                      movedLast = (int)gameTime.TotalGameTime.TotalMilliseconds;
                   }
              /*     else if (GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Released)
                   {
                       movedLast = (int)gameTime.TotalGameTime.TotalMilliseconds;
                   }           
                  */  //UNNEEDED NOW AS LAST STATEMENT TAKES IN KEYBOARD OR GAMEPAD

                    if(GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed || state.IsKeyDown(Keys.Left))
                   {
                       menuItem--;
                        if (menuItem == 0){
                            menuItem = 3;
                        }
                       movedLast = (int)gameTime.TotalGameTime.TotalMilliseconds;
                    }
                  /*  else if (GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Released){
                        movedLast = (int)gameTime.TotalGameTime.TotalMilliseconds;
                    }*/

                    movedLast = (int)gameTime.TotalGameTime.TotalMilliseconds;
               }

            
         //Check Keyboard keys!!
             //check if R is pressed
                if (state.IsKeyDown(Keys.R))
                {
                    red = 255;
                    green = 0;
                    blue = 0;
                    menuItem = 1;
                }
             //check if G is pressed
                else if (state.IsKeyDown(Keys.G))
                {
                    red = 0;
                    green = 255;
                    blue = 0;
                    menuItem = 2;
                }
             //check if B is pressed
                else if (state.IsKeyDown(Keys.B))
                {
                    red = 0;
                    green = 0;
                    blue = 255;
                    menuItem = 3;
                }


            //Check Gamepad Buttons
              //Check B button   (Red)
                else if (GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed){
                    red = 255;
                    green = 0;
                    blue = 0;
                    menuItem = 1;
                }
             //Check A button   (Green)
               if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed){
                   red = 0;
                   green = 255;
                   blue = 0;
                   menuItem = 2;
               }
             //Check X button   (Blue)
               else if(GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed){
                   red = 0;
                   green = 0;
                   blue = 255;
                   menuItem = 3;
               }

            //Mouse
               IsMouseVisible = true;

            //exits
               if (state.IsKeyDown(Keys.Escape))
                  this.Exit();

            // Allows the game to exit
               if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                   this.Exit();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here

            //draw rectangle
            Texture2D texture = new Texture2D(GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            texture.SetData<Color>(new Color[] { Color.White });
            Texture2D texture2 = this.Content.Load<Texture2D>("Image1");

            spriteBatch.Begin();
            spriteBatch.Draw(texture, new Rectangle(30, 40, 380, 400), colour);
            spriteBatch.Draw(texture, new Rectangle(630, 200, textBoxWidth, textBoxHeight), Color.White);
            spriteBatch.Draw(texture, new Rectangle(630, 200 - textBoxHeight - 60, textBoxWidth, textBoxHeight), Color.White);
            spriteBatch.Draw(texture, new Rectangle(630, 200 + textBoxHeight + 60, textBoxWidth, textBoxHeight), Color.White);
            spriteBatch.DrawString(font, "XNA Colour Settings", new Vector2(500, 30), Color.Black);
            spriteBatch.DrawString(font, green.ToString(), new Vector2(650, 200), Color.Black);
            spriteBatch.DrawString(font, red.ToString(), new Vector2(650, 200 - textBoxHeight - 60), Color.Black);
            spriteBatch.DrawString(font, blue.ToString(), new Vector2(650, 200 + textBoxHeight + 60), Color.Black);
            spriteBatch.DrawString(font, "Green", new Vector2(550, 200), Color.Black);
            spriteBatch.DrawString(font, "Red", new Vector2(550, 200 - textBoxHeight - 60), Color.Black);
            spriteBatch.DrawString(font, "Blue", new Vector2(550, 200 + textBoxHeight + 60), Color.Black);
            if (menuItem == 1)
            {
                spriteBatch.Draw(texture2, new Vector2(730, 30), Color.Black);
            }
            else if (menuItem == 2)
            {
                spriteBatch.Draw(texture2, new Vector2(730, 120), Color.Black);
            }
            else if (menuItem == 3)
            {
                spriteBatch.Draw(texture2, new Vector2(730, 210), Color.Black);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
