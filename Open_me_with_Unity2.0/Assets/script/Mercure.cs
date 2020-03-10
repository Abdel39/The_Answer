using UnityEngine;

namespace script
{
    public class Mercure : Entity
    {
        private static int mercureNumber;

        private Mercure(int lifePoint, int damage) : base(lifePoint, damage, false)
        {
           
        }

        public static Mercure getInstance(int lifePoint, int damage)
        {
            if (mercureNumber == 0)
            {
                return new Mercure(lifePoint, damage);
                mercureNumber++;
            }
            else
            {
                Debug.Log("mercure ne peux etre instancié car il en existe deja un !");
                return null;
            }

        }

        public void takeDamage(int damagetaken)
        {
            base.takeDamage(damagetaken);
        }
        
        public void attack(Entity entity)
        {
            base.attack(entity);
        }
    }
}