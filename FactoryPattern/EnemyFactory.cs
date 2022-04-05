﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsProjekt
{
    class EnemyFactory : Factory
    {
        private static EnemyFactory instance;
        private Random rnd = new Random();
        public static EnemyFactory Instance //Singlton start
        {
            get
            {
                if (instance == null)
                {
                    instance = new EnemyFactory();
                }
                return instance;
            }
        } //Singleton end

        public override GameObject CreateObject()
        {

            GameObject item = new GameObject();
            SpriteRenderer rend = (SpriteRenderer)item.AddComponent(new SpriteRenderer());

            rend.SetSprite("EvilGirth");
            Vector2 moveDir = new Vector2(0, 0);
            Vector2 spawnPoint = new Vector2(0, 0);
            switch (rnd.Next(0,4))
            {
                case 0:
                    moveDir = new Vector2(0, 1);
                    spawnPoint = new Vector2(rnd.Next(0,GameWorld.Instance.Graphics.PreferredBackBufferWidth),0);
                    break;
                case 1:
                    moveDir = new Vector2(0, -1);
                    spawnPoint = new Vector2(rnd.Next(0, GameWorld.Instance.Graphics.PreferredBackBufferWidth), GameWorld.Instance.Graphics.PreferredBackBufferHeight);
                    break;
                case 2:
                    moveDir = new Vector2(-1, 0);
                    spawnPoint = new Vector2(GameWorld.Instance.Graphics.PreferredBackBufferWidth, rnd.Next(0, GameWorld.Instance.Graphics.PreferredBackBufferHeight));
                    break;
                case 3:
                    moveDir = new Vector2(1, 0);
                    spawnPoint = new Vector2(0,rnd.Next(0, GameWorld.Instance.Graphics.PreferredBackBufferHeight));
                    break;
            }
            item.AddComponent(new Enemy(2, moveDir, spawnPoint));

            return item;


        }
    }
}