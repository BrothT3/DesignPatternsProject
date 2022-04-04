﻿using Microsoft.Xna.Framework.Graphics;

namespace DesignPatternsProjekt
{
    public class PlayerBuilder : IBuilder
    {
        private GameObject gameObject;

        /// <summary>
        /// Create the component
        /// </summary>
        public void BuildGameObject()
        {
            gameObject = new GameObject();
            BuildComponents();

            Animator animator = (Animator)gameObject.GetComponent<Animator>();
            //animator.AddAnimation(BuildAnimation("navn/identifier", new string[] { "path1", "path2", "path3" }));

        }

        /// <summary>
        /// Attaches the components specified
        /// </summary>
        private void BuildComponents()
        {
            Player p = (Player)gameObject.AddComponent(new Player());

            gameObject.AddComponent(new SpriteRenderer());

            //når vi har animation skal componented tilføjes
            //gameObject.AddComponent(new Animator());

            //collider når det engang er med
            //Collider c = (Collider)gameObject.AddComponent(new Collider());
            //c.CollisionEvent.Attach(p);

        }

        /// <summary>
        /// Creates the animation with a identifier Name and then sprite paths
        /// </summary>
        /// <param name="animationName"></param>
        /// <param name="spriteNames"></param>
        /// <returns></returns>
        private Animation BuildAnimation(string animationName, string[] spriteNames)
        {
            Texture2D[] sprites = new Texture2D[spriteNames.Length];

            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = GameWorld.Instance.Content.Load<Texture2D>(spriteNames[i]);
            }

            Animation animation = new Animation(animationName, sprites, 5);

            return animation;
        }

        public GameObject GetResult()
        {
            return gameObject;
        }
    }

}