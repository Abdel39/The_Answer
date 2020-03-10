using System;
using JetBrains.Annotations;
using UnityEngine;

namespace script
{
    public class Cochon : Entity
    {
        private Vector2 velocity;
    
        // physique 2D du cochon
        private Rigidbody2D cochon;
        
        private float fastx;
        private float fasty;
    
        private Vector3 position;
        private Vector3 positionperso;

       public int lifePoint;
        public int damage;

        public Cochon(int lifePoint, int damage) : base(lifePoint, damage, true)
        {
            
        }

        public void Start()
        {
            velocity = Vector2.zero;
            cochon = GetComponent<Rigidbody2D>();  
        }
        
        public void Update()
        {
            
            velocity = Vector2.zero;
            position = this.transform.position;
            positionperso = this.transform.position;
        
            if (positionperso.x - 1.8 < position.x && positionperso.x + 1.8 > position.x)
            {
                fastx = 0;
            }
            else if (positionperso.x < position.x)
            {
                fastx = -4;
            }
            else
            {
                fastx = 4;
            }
            
        
            Vector3 move = new Vector3(fastx, fasty, 0);
            cochon.velocity = move;
        }
    }
}