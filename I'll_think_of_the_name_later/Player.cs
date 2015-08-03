using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Illthinkofthenamelater
{
    class Player : Entity
    {
        float m_hAcceleration;
        float m_vAcceleration;
        float m_speed;
        float m_maxSpeed;
        Texture2D m_texture;
        bool isMoving = false;
        float m_jumpHeight = 5;
        bool jumpReady = false;
        bool onGround;

        public Player (Vector2 a_position, Vector2 a_size, float a_speed, float a_maxSpeed,
                        Texture2D a_texture)
        {
            m_position = a_position;
            m_size = a_size;
            m_speed = a_speed;
            m_maxSpeed = a_maxSpeed;
            m_texture = a_texture;
        }

        public void Update(GameTime m_gameTime)
        {

            //m_position.X += m_hAcceleration;
            m_position.Y += m_vAcceleration;

            if (m_hAcceleration >= m_maxSpeed)
            {
                m_hAcceleration = m_maxSpeed;
            }

            if (onGround == false)
            {
                m_vAcceleration += 0.9f;
            }

            if (m_position.Y >= Game1.screenSizeY - m_size.Y && onGround == false)
            {
                m_position.Y = Game1.screenSizeY - m_size.Y;
                m_vAcceleration = 0;
                onGround = true;
            }                             

            if (isMoving == false)
            {
                m_hAcceleration = 0;                 
            }

            //Controls_start

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                m_position.X += m_speed;
                isMoving = true;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                m_position.X -= m_speed;
                isMoving = true;
            }
            
            if (Keyboard.GetState().IsKeyUp(Keys.A) && Keyboard.GetState().IsKeyUp(Keys.D))
            {
                isMoving = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && onGround == true)
            {
                jumpReady = false;
                onGround = false;
                m_vAcceleration -= 15;
            }

            //Controls_end

            //CM
            //COMBAT_START
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(m_texture, GetRectangle(), Color.Black);
        }
    }
}
