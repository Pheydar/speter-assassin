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
        public bool m_isPlaying = true;
        public int m_ammo;
        public int m_clipCount;
        int maxClips = 10;
        public int reloadTime;
        Texture2D m_bulletTexture;
        Color m_colour;
        public int bulletdmg = 25;
        public int rateOfFire = 150;
        int bulletTimer;
        Vector2 mousePos;
        int deleteBulletTime;
        bool attackButtonDown = false;
        bool timeToDieWep = false;
        bool attackCantMove = false;
        int attackTimer;
        int attackMoveTimer;
        bool hasWeaponSpawned = false;

        Camera cam = new Camera();

        public List<MeleeWeapon> weaponList = new List<MeleeWeapon>();
        MeleeWeapon newWeapon;

        public List<Bullet> playerBulletList = new List<Bullet>();

        public Player (Vector2 a_position, Vector2 a_size, float a_speed, float a_maxSpeed,
                        Texture2D a_texture, int a_ammo, int a_clipCount, Texture2D a_bulletTexture,
                        Color a_colour)
        {
            m_position = a_position;
            m_size = a_size;
            m_speed = a_speed;
            m_maxSpeed = a_maxSpeed;
            m_texture = a_texture;
            m_ammo = a_ammo;
            m_clipCount = a_clipCount;
            m_bulletTexture = a_bulletTexture;
            m_colour = a_colour;
        }

        public Vector2 GetPlayerPos()
        {
            return m_position;
        }

        public void Update(GameTime m_gameTime)
        {
            playerControls();
            FindDeadBullets();
            foreach (Bullet bullet in playerBulletList)
            {
                bullet.Update(m_gameTime, m_isPlaying);
            }

            bulletTimer += m_gameTime.ElapsedGameTime.Milliseconds;

            if (Keyboard.GetState().IsKeyDown(Keys.R) && m_ammo != 30 && m_clipCount >= 1)
            {
                reloadTime += m_gameTime.ElapsedGameTime.Milliseconds;
            }

            if (Keyboard.GetState().IsKeyUp(Keys.R))
            {
                reloadTime = 0;
            }

            if (reloadTime >= 588)
            {
                reloadTime = 588;
            }

            foreach (Bullet newBullet in playerBulletList)
            {
                deleteBulletTime += m_gameTime.ElapsedGameTime.Milliseconds;
                if (deleteBulletTime >= 200)
                {
                    newBullet.m_bIsAlive = false;
                }
                deleteBulletTime = 0;
            }
            //m_position.X += m_hAcceleration;
            /*m_position.Y += m_vAcceleration;

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
            }*/

            //Controls_end

            //CM
            //COMBAT_START
        }

        public void playerControls ()
        {
            float mouseX = Mouse.GetState().X + cam._pos.X ;
            float mouseY = Mouse.GetState().Y + cam._pos.Y ;

            mousePos = new Vector2(mouseX, mouseY);
            Vector2 direction = mousePos - m_position;
            direction.Normalize();
            m_direction = direction;

            if (Keyboard.GetState().IsKeyDown(Keys.W) && m_isPlaying == true)
            {
                m_position.Y -= 5;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S) && m_isPlaying == true)
            {
                m_position.Y += 5;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A) && m_isPlaying == true)
            {
                m_position.X -= 5;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D) && m_isPlaying == true)
            {
                m_position.X += 5;
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && m_isPlaying == true && bulletTimer >= rateOfFire && m_ammo > 0)
            {

                Shoot();
                bulletTimer = 0;
                m_ammo -= 1;

            }

            if (Keyboard.GetState().IsKeyDown(Keys.R) && m_isPlaying == true)
            {
                Reload();
            }
        }

        public void FindDeadBullets()
        {
            for (int i = 0; i < playerBulletList.Count; ++i)
            {
                if (!playerBulletList[i].m_bIsAlive)
                {
                    playerBulletList.Remove(playerBulletList[i]);
                }
            }
        }

        public void Reload()
        {
            if (m_clipCount > 0 && m_ammo != 30 && reloadTime >= 588)
            {
                m_ammo = 30;
                m_clipCount -= 1;
                reloadTime = 0;
            }

            if (m_ammo > 30)
            {
                m_ammo = 30;
            }
        }

        public void Shoot()
        {

            Bullet newBullet = new Bullet((m_position - new Vector2(m_size.X, 0) / 2) + m_direction * 25.0f, m_direction, new Vector2(5, 10), mousePos.X, mousePos.Y, 32, m_colour, m_bulletTexture, bulletdmg, 1920);
            playerBulletList.Add(newBullet);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(m_texture, GetRectangle(), Color.Black);

            float dir = 0;
            dir = -(float)Math.Atan2(m_direction.X, m_direction.Y) + MathHelper.ToRadians(180);
            spriteBatch.Draw(m_texture, GetRectangle(), new Rectangle(0, 0, m_texture.Width, m_texture.Height),
                            m_colour, dir, new Vector2(m_size.X / 2, m_size.Y / 2), SpriteEffects.None, 0);

            foreach (Bullet bullet in playerBulletList)
            {
                bullet.Draw(spriteBatch);
            }
        }
    }
}
