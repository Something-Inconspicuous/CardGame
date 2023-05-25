
namespace GameMechanics.Enemy {
    public class Enemy {
        public int health;

        public Enemy/*#1*/(int health) {
            this.health = health;
        }
            
        public Enemy(){
            health = 2;
        }

        /// <summary>
        /// Make the enemy take a given amount of damage
        /// </summary>
        /// <param name="dmg">The damage to take</param>
        public void TakeDamage(int dmg) => health -= dmg;
    }
}