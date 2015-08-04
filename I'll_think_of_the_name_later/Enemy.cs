using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Illthinkofthenamelater
{
    class Enemy
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
    }
}
