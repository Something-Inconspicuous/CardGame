using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManageUI : MonoBehaviour
{
    public int playerHealth;
    public int enemyHealth;
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI enemyHealthText;


    private void Update() {
        UpdatePlayerHealth(playerHealth);
        UpdateEnemyHealth(enemyHealth);
    }




    public void UpdatePlayerHealth(int health)
    {
        playerHealth = health;
        playerHealthText.text = "Player Health: " + playerHealth;
    }

    public void UpdateEnemyHealth(int health)
    {
        enemyHealth = health;
        enemyHealthText.text = "Enemy Health: " + enemyHealth;
    }

}
