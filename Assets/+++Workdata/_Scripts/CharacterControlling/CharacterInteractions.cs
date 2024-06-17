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
    //Wenn man mit einem Objekt zusammenprallt, wird etwas ausgelöst
    {
        if (other.CompareTag("Goal"))
            //Wenn man mit Objekten zusammenprallt, die den Tag "Goal" haben, gewinnt man (man kommt in das Win Panel)
        {
            Debug.Log("You win!");
            uiLevelManager.OnGameWin();
        }
        if (other.CompareTag("Death"))
            //Wenn man mit Objekten zusammenprallt, die den Tag "Death" haben, verliert man (man kommt in das Lose Panel)
        {
            Debug.Log("You loose!");
            uiLevelManager.OnGameLose();
        }

        if (other.CompareTag("Coin"))
            //Wenn man mit Objekten zusammenprallt, die den Tag "Coin" haben,wird das Objekt zerstört und der CoinCounter geht hoch
        {
            uiLevelManager.AddCoin();
            Destroy(other.gameObject);
        }
    }
    
}