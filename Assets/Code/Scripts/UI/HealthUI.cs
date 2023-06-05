using UnityEngine;

namespace UI {
    public class HealthUI : Monobehaviour {
        //[SerializeField] private Animator animator;

        public void OnTakeDamage(){
            //animator.SetBool("toDie", true);
            transform.velocity = Transform.TransformDirection(Vector3.Down * 5);
        }
    }
}