using UnityEngine;

namespace GameMechanics.User {
    public class CardUI : MonoBehaviour {

        private const float changeXDef = 0f;
        private const float changeYDef = 0f;
        private const float changeZDef = -0.01f; // Cards will move in front of others
        
        [Header("Change on Hover")]
        [SerializeField] private float changeX = changeXDef;
        [SerializeField] private float changeY = changeYDef;
        [SerializeField] private float changeZ = changeZDef;

        private Vector3 upPos;
        private Vector3 downPos;
        private bool isUp;

        private const float smoothing = 0.1f;

        void Awake() {
            upPos = transform.position + new Vector3(changeX, changeY, changeZ);
            downPos = transform.position;
        }

        void OnMouseEnter() {
            isUp = true;
        }

        void OnMouseExit() {
            isUp = false;
        }

        private Vector3 velocity = new Vector3();
        void Update() {
            if(isUp){
                transform.position = Vector3.SmoothDamp(
                    current: transform.position,
                    target: upPos,
                    currentVelocity: ref velocity,
                    smoothTime: smoothing
                );
            } else {
                transform.position = Vector3.SmoothDamp(
                    current: transform.position,
                    target: downPos,
                    currentVelocity: ref velocity,
                    smoothTime: smoothing
                );
            }
        }
    }
}