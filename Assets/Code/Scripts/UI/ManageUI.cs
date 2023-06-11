using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GameMechanics;

public static class ManageUI
{
    public static GameObject canvas {get => canv;}
    private static GameObject canv;
    public static TextMeshProUGUI playerHealthText;
    public static TextMeshProUGUI enemyHealthText;

    public static void Init() {
        Debug.Log("Init...");
        canv = GameObject.Find("Canvas");
        Debug.Log(canv);
        playerHealthText = canv.GetComponentInChildren<TextMeshProUGUI>();
        Debug.Log(playerHealthText);
        enemyHealthText = canv.GetComponentInChildren<TextMeshProUGUI>();

        UpdateEnemyHealth();
        UpdatePlayerHealth();
        
        Debug.Log("...Init");
    }

    //private static void Update() {
    //    UpdatePlayerHealth();
    //    UpdateEnemyHealth();
    //}

    public static void UpdatePlayerHealth()
    {
        playerHealthText.text = $"Player Health: {GeneralManager.PlayerHealth}";
    }

    public static void UpdateEnemyHealth()
    {
        enemyHealthText.text = $"Enemy Health: ";
    }

}
