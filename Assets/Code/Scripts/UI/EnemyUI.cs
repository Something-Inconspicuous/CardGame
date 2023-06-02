
using UnityEngine;

using GameMechanics.Enemy;

namespace UI {
    public class EnemyUI : MonoBehaviour {
        //[SerializeField]
        private GameObject[] healthMarkers;

        private Enemy enemy;

        void Awake() {
            healthMarkers = new GameObject[enemy.health];
            GameObject healthSprite = GameObject.Find("Health");
            //TODO - create health display
        }

        public void onTakeDamage(){

        }
        
    }
}