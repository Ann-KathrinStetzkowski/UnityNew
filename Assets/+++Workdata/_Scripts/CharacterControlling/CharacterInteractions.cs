using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractions : MonoBehaviour
{
    //Variable wird angelegt
    private UILevelManager uiLevelManager;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //UILevel Manager wird gesucht und man kann dann auf public Funktionen daraus zugreifen
        uiLevelManager = FindObjectOfType<UILevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Goal"))
        {
            Debug.Log("You win!");
            uiLevelManager.OnGameWin();
        }
        if (other.CompareTag("Death"))
        {
            Debug.Log("You loose!");
            uiLevelManager.OnGameLose();
        }

        if (other.CompareTag("Coin"))
        {
            uiLevelManager.AddCoin();
            Destroy(other.gameObject);
        }
    }
    
}