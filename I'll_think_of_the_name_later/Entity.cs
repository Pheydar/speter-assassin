using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Illthinkofthenamelater
{
    class Entity
    {
        protected Vector2 m_position;
        protected Vector2 m_size;
        protected Vector2 m_direction;
        protected Vector2 m_velocity;

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)m_position.X, (int)m_position.Y, (int)m_size.X, (int)m_size.Y);
        }
    }
        
}
