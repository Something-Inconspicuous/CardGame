
using UnityEngine;

using GameMechanics.Enemy;

namespace UI {
    [RequireComponent(typeof(BoxCollider2D))]
    public class EnemyUI : MonoBehaviour {
        //[SerializeField]
        private HealthUI[] healthMarkers;

        private Enemy enemy;

        void Awake() {
            
        }

        public void CreateHealthDisplay(){
            healthMarkers = new HealthUI[enemy.health];
            GameObject healthSprite = GameObject.Find("Health");
            //TODO - create health display

            Vector2 size = GetComponent<BoxCollider2D>().size;

            if(enemy.health == 1){
                healthMarkers[0] = GameObject.Instantiate(
                    healthSprite, 
                    new Vector3(
                        transform.position.x,
                        transform.position.y + size.y,
                        transform.position.z
                    ),
                    transform.rotation,
                    transform
                );
                return;
            }

            float distFromEachHealth = width / enemy.health - 1;

            Vector3 posForHealth = new Vector3(
                        transform.position.x - size.x / 2,
                        transform.position.y + size.y,
                        transform.position.z
                    );
            for(int i = 0; i < enemy.health; i++){
                posForHealth.x += i * distFromEachHealth;

                healthMarkers[i] = GameObject.Instantiate(
                    healthSprite,
                    posForHealth,
                    transform.rotation,
                    transform
                );
            }
        }

        public void SetEnemy(Enemy enemy){
            this.enemy = enemy;
        }

        public void Set(Enemy enemy){
            SetEnemy(enemy);
            CreateHealthDisplay();
        }
        public void OnTakeDamage(){
            healthMarkers[enemy.health - 1].onTakeDamage();
        }
    }
}