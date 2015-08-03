using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Illthinkofthenamelater
{
    class Triangle
    {
       Vector2 m_Point1;
       Vector2 m_Point2;
       Vector2 m_Point3;

       BasicEffect basicEffect;

        public Triangle(Vector2 a_Point1, Vector2 a_Point2, Vector2 a_Point3)
        {
            m_Point1 = a_Point1;
            m_Point2 = a_Point2;
            m_Point3 = a_Point3;

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
