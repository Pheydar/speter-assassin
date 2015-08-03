﻿using System;
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

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)m_position.X, (int)m_position.Y, (int)m_size.X, (int)m_size.Y);
        }
    }
        
}