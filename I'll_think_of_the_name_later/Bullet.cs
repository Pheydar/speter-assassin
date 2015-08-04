using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Illthinkofthenamelater
{
    class Bullet:Entity
    {
        int m_speed;
        Color m_Color;
        Texture2D m_bulletTexture;
        int m_damage;
        int m_MaxDistFromStart;
        public bool m_bIsAlive = true;
        bool m_isPlaying;
        float m_mousePosX;
        float m_mousePosY;

        public Bullet(Vector2 a_position, Vector2 a_direction, Vector2 a_size, float a_mousePosX, float a_mousePosY,
                             int a_speed, Color a_Color, Texture2D a_bulletTexture, int a_damage, int a_MaxDistFromStart)
        {
            m_position = a_position;
            m_direction = a_direction;
            m_speed = a_speed;
            m_damage = a_damage;
            m_MaxDistFromStart = a_MaxDistFromStart;
            m_mousePosX = a_mousePosX;
            m_mousePosY = a_mousePosY;
            m_bulletTexture = a_bulletTexture;
            m_size = a_size;
            m_Color = Color.White;
            Console.WriteLine("Bullet position: {0}, {1}", m_position.X, m_position.Y);
        }


        public void Draw(SpriteBatch BulletDraw)
        {
            if (m_bIsAlive == true)
            {
                float dir = 0;
                dir = -(float)Math.Atan2(m_direction.X, m_direction.Y) + MathHelper.ToRadians(180);
                BulletDraw.Draw(m_bulletTexture, GetRectangle(), new Rectangle(0, 0, m_bulletTexture.Width + 10, m_bulletTexture.Height + 10), m_Color, dir, new Vector2(m_size.X / 2, m_size.Y / 2), SpriteEffects.None, 0);
            }

        }

        public void Update(GameTime BulletTime, bool isPlaying)
        {
            if (m_bIsAlive == true && m_isPlaying == true)
            {

            }

            m_position += m_direction * m_speed;
        }
    }
}
