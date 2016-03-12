using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShooterGame.Common;
using ShooterGame.GameObjects.FontObjects.DelegatesAndEvents;
using ShooterGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShooterGame.GameObjects.FontObjects.Controls
{
    /// <summary>
    /// Menu control.
    /// </summary>
    public class MenuControl : FontObject
    {
        #region Fields

        private int margin;
        private List<TextControl> controls;
        private readonly string[] _items;
        private readonly int _itemCount;
        private readonly TextAlignment _textAlignment;
        private readonly HorizontalAlignment _horizontalAlignment;
        private readonly VerticalAlignment _verticalAlignment;

        public event OnMenuSelection OnMenuSelection;

        #endregion

        #region Constructor

        /// <summary>
        /// Menu control constructor
        /// </summary>
        public MenuControl(Game1 game, SpriteFont font,
           TextAlignment textAlignment,
           HorizontalAlignment horizontalAlignment,
           VerticalAlignment verticalAlignment,
           params string[] items)
            : base(game, font, String.Empty)
        {
  
            _textAlignment = textAlignment;
            _horizontalAlignment = horizontalAlignment;
            _verticalAlignment = verticalAlignment;
            _items = items;
            _itemCount = items.Count();
            Active = true;

            // Default selected color
            SelectedColor = Color.Yellow;

            // Default margin.
            if (Margin <= 0) Margin = 20;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets and sets margin
        /// </summary>
        public int Margin
        {
            get
            {
                return margin;
            }
            set
            {
                margin = value;
                controls =  SetTextControls(_textAlignment, _horizontalAlignment, _verticalAlignment, _items);
            }
        }

        /// <summary>
        /// Gets and sets color of selected item.
        /// </summary>
        public Color SelectedColor { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Update menu controls.
        /// </summary>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            // Going down or right through items.
            if((InputManager.KeyPress(Keys.Down) && _textAlignment == TextAlignment.Vertical)
                || (InputManager.KeyPress(Keys.Right) && _textAlignment == TextAlignment.Horizontal))
            {
                int previousSelection = controls.FindIndex(x => x.Selected);
                controls.ForEach(x =>
                     {
                         x.Selected = false;
                         x.Color = Color;
                     });
                if (previousSelection >= _itemCount - 1)
                {
                    controls[0].Selected = true;
                    controls[0].Color = SelectedColor;
                }
                else
                {
                    controls[previousSelection + 1].Selected = true;
                    controls[previousSelection + 1].Color = SelectedColor;
                }
            }
            // Going left or up through items.
            else if ((InputManager.KeyPress(Keys.Up) && _textAlignment == TextAlignment.Vertical) 
                || (InputManager.KeyPress(Keys.Left) && _textAlignment == TextAlignment.Horizontal))
            {
                int previousSelection = controls.FindIndex(x => x.Selected);
                controls.ForEach(x =>
                {
                    x.Selected = false;
                    x.Color = Color;
                });
                if (previousSelection <= 0)
                {
                    controls[_itemCount - 1].Selected = true;
                    controls[_itemCount - 1].Color = SelectedColor;
                }
                else
                {
                    controls[previousSelection - 1].Selected = true;
                    controls[previousSelection - 1].Color = SelectedColor;
                }
            }

            // If there is selection
            if(InputManager.KeyPressed(Keys.Enter))
            {
                if(OnMenuSelection != null)
                {
                    string selectedItemTitle = controls.Where(x => x.Selected).FirstOrDefault().Text;
                    OnMenuSelection(this, new MenuControlEventArgs(selectedItemTitle));
                }
            }
        }

        /// <summary>
        /// Draw text items.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch.</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!Active) return;
            for (int i = 0; i < _itemCount; i++)
            {
                spriteBatch.DrawString(Font, controls[i].Text, controls[i].Position, controls[i].Color, 0f, Vector2.Zero, 1f, SpriteEffects.None, LayerDepth);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Sets text controls.
        /// </summary>
        /// <param name="textAlignment">Text alignment.</param>
        /// <param name="horizontalAlignment">Horizontal alignment</param>
        /// <param name="verticalAlignment">Vertical alignment</param>
        /// <param name="items">Items.</param>
        /// <returns>Text control items.</returns>
        private List<TextControl> SetTextControls(TextAlignment textAlignment,
           HorizontalAlignment horizontalAlignment,
           VerticalAlignment verticalAlignment,
           params string[] items)
        {
            List<TextControl> textControls = new List<TextControl>();

            int count = items.Count();
            Vector2 addAmount = Vector2.Zero;
            for (int i = 0; i < count; i++)
            {
                // Apply only if horizontal alignment, x needs to have offset calculated
                // for every entry
                if (textAlignment == TextAlignment.Horizontal && i != 0)
                {
                    addAmount.X += Font.MeasureString(items[i - 1]).X + Margin;
                }
                else if (textAlignment == TextAlignment.Vertical && i != 0)
                {
                    addAmount.Y += Font.MeasureString(items[i - 1]).Y + Margin;
                }

                textControls.Add(new TextControl()
                {
                    Color = i == 0 ? SelectedColor : Color,
                    Text = items[i],
                    Selected = i == 0,
                    Position = addAmount
                });
            }

            if (horizontalAlignment == HorizontalAlignment.Center)
            {
                // Determine amount off offset
                float offset = Game.Window.ClientBounds.Width * .5f;

                // Precalculation if text alignment is horizontal
                float horizontalAlignmentOff = 0f;
                if (textAlignment == TextAlignment.Horizontal)
                {
                    var additonaloffset = Margin / count;
                    textControls.ForEach(x => horizontalAlignmentOff += Font.MeasureString(x.Text).X * .5f + additonaloffset);
                }
                for (int i = 0; i < count; i++)
                {
                    var position = textControls[i].Position;
                    position.X += offset;
                    if (textAlignment == TextAlignment.Horizontal)
                    {
                        position.X -= horizontalAlignmentOff;
                    }
                    else
                    {
                        position.X -= Font.MeasureString(textControls[i].Text).X * .5f;
                    }
                    textControls[i].Position = position;
                }
            }
            else if (horizontalAlignment == HorizontalAlignment.Right)
            {
                float offset = Game.Window.ClientBounds.Width;

                // Precalculate values
                float longestStringX = 0f;
                float sumForTextAlignHor = 0f;
                if(textAlignment == TextAlignment.Vertical)
                {
                    longestStringX = textControls.Max(x => Font.MeasureString(x.Text).X);
                }
                else
                {
                    float add = 0f;
                    textControls.ForEach(x => add += Font.MeasureString(x.Text).X + Margin);
                    sumForTextAlignHor = offset - add;
                }

                for (int i = 0; i < count; i++)
                {
                    var position = textControls[i].Position;
                    if (textAlignment == TextAlignment.Horizontal)
                    {
                        position.X += sumForTextAlignHor;
                    }
                    else
                    {
                        position.X = offset - longestStringX;
                    }
                    textControls[i].Position = position;
                }
            }

            if (verticalAlignment == VerticalAlignment.Center)
            {
                // Determine amount off offset
                float offset = Game.Window.ClientBounds.Height * .5f;

                // Precalculation if text alignment is horizontal
                float verticalAlignmentOff = 0f;
                if (textAlignment == TextAlignment.Vertical)
                {
                    var additonaloffset = Margin / count;
                    textControls.ForEach(x => verticalAlignmentOff += Font.MeasureString(x.Text).Y * .5f + additonaloffset);
                }
                for (int i = 0; i < count; i++)
                {
                    var position = textControls[i].Position;
                    position.Y += offset;
                    if (textAlignment == TextAlignment.Vertical)
                    {
                        position.Y -= verticalAlignmentOff;
                    }
                    else
                    {
                        position.Y -= Font.MeasureString(textControls[i].Text).Y * .5f;
                    }
                    textControls[i].Position = position;
                }
            }
            else if (verticalAlignment == VerticalAlignment.Bottom)
            {
                float offset = Game.Window.ClientBounds.Height;

                // Precalculate values
                float longestStringY = 0f;
                float sumForTextAlignVer = 0f;
                if (textAlignment == TextAlignment.Horizontal)
                {
                    longestStringY = textControls.Max(x => Font.MeasureString(x.Text).Y);
                }
                else
                {
                    float add = 0f;
                    textControls.ForEach(x => add += Font.MeasureString(x.Text).Y + Margin);
                    sumForTextAlignVer = offset - add;
                }

                for (int i = 0; i < count; i++)
                {
                    var position = textControls[i].Position;
                    if (textAlignment == TextAlignment.Horizontal)
                    {
                        position.Y = offset - longestStringY;
                    }
                    else
                    {
                        position.Y += sumForTextAlignVer;
                    }
                    textControls[i].Position = position;
                }
            }

            return textControls;
        }

        #endregion

        /// <summary>
        /// Holds values for menu control.
        /// </summary>
        private class TextControl
        {
            public string Text { get; set; }
            public Color Color { get; set; }
            public Vector2 Position { get; set; }
            public bool Selected { get; set; }
        }
    }
}
