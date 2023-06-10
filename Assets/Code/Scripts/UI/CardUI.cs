using GameMechanics;
using GameMechanics.Cards;
using UnityEngine;

namespace UI {
    public class CardUI : MonoBehaviour {
        [Header("Change on Hover")]

        [SerializeField] private GameObject cardToMove;
        [SerializeField] private Card card;

        [SerializeField] private float changeX = 0f;
        [SerializeField] private float changeY = 0f;
        [SerializeField] private float changeZ = -0.01f;

        private Vector3 upPos;
        private Vector3 downPos;
        private bool isUp;

        private const float smoothing = 0.1f;

        void Awake() {
            if(cardToMove == null)
                cardToMove = GetComponentInChildren<Transform>().gameObject;

            upPos = cardToMove.transform.position + new Vector3(changeX, changeY, changeZ);
            downPos = cardToMove.transform.position;
        }

        void OnMouseEnter() {
            transform.Translate(0, 0, changeZ);
            isUp = true;
        }

        void OnMouseExit() {
            transform.Translate(0, 0, -changeZ);
            isUp = false;
        }

        void OnMouseDown() {
            GeneralManager.Queue(card.effects);
        }

        private Vector3 velocity = new Vector3();

        void Update() {
            if(isUp){
                cardToMove.transform.position = Vector3.SmoothDamp(
                    current: cardToMove.transform.position,
                    target: upPos,
                    currentVelocity: ref velocity,
                    smoothTime: smoothing
                );
            } else {
                cardToMove.transform.position = Vector3.SmoothDamp(
                    current: cardToMove.transform.position,
                    target: downPos,
                    currentVelocity: ref velocity,
                    smoothTime: smoothing
                );
            }
        }
    }
}