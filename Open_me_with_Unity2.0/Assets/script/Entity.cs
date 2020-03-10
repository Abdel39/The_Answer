using System;
using UnityEngine;

namespace script
{
    public abstract class Entity : MonoBehaviour
    {
        private int LifePoint;
        private bool isDead;
        private int damage;
        private bool isEnnemy;

        protected Entity(int lifePoint, int damage, bool isEnnemy)
        {
            this.LifePoint = lifePoint;
            this.damage = damage;
            this.isDead = false;
            this.isEnnemy = isEnnemy;
            updateVariables();
        }
        

        public void attack(Entity victim)
        {
            victim.takeDamage(this.damage);
        }

        public void takeDamage(int damageTaken)
        {
            this.damage -= damageTaken;
            updateVariables();
        }
        
        protected void setLifePoint(int newLifePoint)
        {
            this.LifePoint = newLifePoint;
            updateVariables();
        }

        public int getLifePoint()
        {
            return this.LifePoint;
        }
        
        protected void setDamage(int damage)
        {
            this.damage = damage;
            if (damage < 0)
                damage = 0;
            updateVariables();
        }

        public int getDamage()
        {
            return this.damage;
        }
        
        private void updateVariables()
        {
            if (this.LifePoint <= 0)
            {
                this.LifePoint = 0;
                this.isDead = true;
                Destroy(this);
            }
            else
            {
                this.isDead = false;
            }
        }
    }
}