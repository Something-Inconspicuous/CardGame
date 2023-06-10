using GameMechanics.Cards;
using GameMechanics.Enemy;
using UnityEngine;

namespace GameMechanics {
    public static class GeneralManager {
        private static Battlefield battlefield;
        private static Player player;

        public static void Init(){
            battlefield = new Battlefield();
            player = new Player(5);
        }

        public static void Queue(CardEffects effects){
            if((effects.target & CardTarget.ENEMY) == CardTarget.ENEMY){
                battlefield.DamageEnemies(effects.damage);
            }

            if((effects.target & CardTarget.PLAYER) == CardTarget.PLAYER){
                player.health -= effects.damage;
            }

            Debug.Log(player.health);
        }
    }
}