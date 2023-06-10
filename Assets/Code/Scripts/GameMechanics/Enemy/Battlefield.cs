
using System.Collections.Generic;

namespace GameMechanics.Enemy {
    public class Battlefield {
        private List<Enemy> enemies;
        public Battlefield(){
            enemies = new List<Enemy>();
        }

        public void DamageEnemies(int damage){
            //TODO - allow player to choose enemy to damage
            this[0].health -= damage;
        }

        public void AddEnemy(Enemy enemy){
            enemies.Add(enemy);
        }

        public Enemy GetEnemy(int index){
            return enemies[index];
        }

        public Enemy this[int index] {
            get => enemies[index];
        }
    }
}