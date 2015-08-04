using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Illthinkofthenamelater
{
    class Enemy : Entity
    {
        public Enemy(Vector2 a_Position, Vector2 a_Size, int a_Health, int a_Speed, Color a_Color, Texture2D a_Texture)
        {
            m_position = a_Position;
            m_size = a_Size;
            m_Health = a_Health;
            m_Texture = a_Texture;
            m_Color = a_Color;
            m_Speed = a_Speed;
        }
        
        Game1 game1;
        public int m_Health;
        int m_Speed;
        Texture2D m_Texture;
        Color m_Color;
        bool m_isMoving;
        public bool m_isAlive = true;
        Vector2 m_playerPos;
        Vector2 m_direction;
        int movementTimer;
        
        public void Update(GameTime enemyTime)
        {
            movementTimer += enemyTime.ElapsedGameTime.Milliseconds;

            PathFinding();

            /*Psuedo Code time:
             * IF playerDetected = true THEN
             *      alertLevel = true
             *      shoot at player
             * ELSE
             *      follow AI path
             * ENDIF
             * this is a stub :) */
        }

        public void PathFinding()
        {
            
            while (m_isAlive == true)
            {
                m_position.Y += 5;
                if (movementTimer >= 500)
                {
                    m_position.Y -= 0;
                    m_position.X += 5;
                }

                if (movementTimer >= 1000)
                {
                    m_position.X -= 0;
                    m_position.Y += 5;
                }
            }
            
            
        }
    }
}
