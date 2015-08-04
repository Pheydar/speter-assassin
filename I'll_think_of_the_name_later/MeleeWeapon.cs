using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Illthinkofthenamelater
{
    class MeleeWeapon : Entity
    {
        public MeleeWeapon(Vector2 a_postion, Vector2 a_size, Vector2 a_velocity, int a_damage, SpriteEffects a_FlipSide, Texture2D a_weaponTexture)
        {
            m_position = a_postion;
            m_size = a_size;
            m_velocity = a_velocity;
            m_damage = a_damage;
            m_FlipSide = a_FlipSide;
            m_weaponTexture = a_weaponTexture;
        }

        SpriteEffects m_FlipSide;
        int m_damage;
        public bool m_isUsed = false;
        public int usedTimer;
        int idleTimer;
        Texture2D m_weaponTexture;

        public void Update(GameTime weaponTime)
        {
            idleTimer += weaponTime.ElapsedGameTime.Milliseconds;

            if (m_isUsed == true)
            {
                usedTimer += weaponTime.ElapsedGameTime.Milliseconds;
            }

            if (idleTimer >= 25)
            {
                m_isUsed = true;
            }
        }

        public void Draw(SpriteBatch weaponDraw)
        {
            if (usedTimer <= 25 && idleTimer <= 100)
            {
                weaponDraw.Draw(m_weaponTexture, GetRectangle(), new Rectangle(0, 0, (int)m_size.X, (int)m_size.Y), Color.White, 0,
                    new Vector2(0, 0), m_FlipSide, 1);
            }
        }

        public bool IsDeleteTime()
        {
            if (usedTimer >= 25)
            {
                usedTimer = 0;
                return true;
            }
            else return false;
        }

        public bool timeToDie()
        {
            if (idleTimer >= 100)
            {
                return true;
            }
            else return false;
        }
    }
}
