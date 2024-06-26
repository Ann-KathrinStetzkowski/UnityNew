using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIMenu : MonoBehaviour
{
    //SerialzeFields fügen in dem Fall die Buttons oder Panel(Variablen) in den Inspector hinzu
    //hinzu und man kann dann die InGame Elemente reinziehen und sie sind verbunden
    [SerializeField] private CanvasGroup panelMain;
    [SerializeField] private Button buttonNewGame;
    [SerializeField] private Button buttonLevelSelection;
    [SerializeField] private Button buttonExitGame;
  
    
    
    [SerializeField] private CanvasGroup panelLevelSelection;
    [SerializeField] private Button buttonBackToMain;
    [SerializeField] private Button buttonLevel1;
    [SerializeField] private Button buttonLevel2;
    [SerializeField] private Button buttonLevel3;

    [SerializeField] private string[] LevelNames;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //Das MainMenu wird gezeigt mit allen Buttons und es wird festgelegt, was die Buttons machen 
        ShowMainPanel();
        
        buttonLevelSelection.onClick.AddListener(ShowLevelSelection);
        buttonBackToMain.onClick.AddListener(ShowMainPanel);
        buttonNewGame.onClick.AddListener(LoadLevel1);
        buttonExitGame.onClick.AddListener(ExitGame);
        
        buttonLevel1.onClick.AddListener(LoadLevel1);
        buttonLevel2.onClick.AddListener(LoadLevel2);
        buttonLevel3.onClick.AddListener(LoadLevel3);

        
        //man kann den Button nicht benutzen
        buttonLevel2.interactable = false;
        if (PlayerPrefs.HasKey(LevelNames[1]))
        {
            //wenn man das 1. Level geschafft hat, kann man das 2. Level anklicken
            if (PlayerPrefs.GetInt(LevelNames[1]) == 1)
            {
                buttonLevel2.interactable = true;
            }
        }
        
        //man kann den Button nicht benutzen
        buttonLevel3.interactable = false;
        if (PlayerPrefs.HasKey(LevelNames[2]))
        {
            //wenn man das 1. Level geschafft hat, kann man das 3. Level anklicken
            if (PlayerPrefs.GetInt(LevelNames[2]) == 1)
            {
                buttonLevel3.interactable = true;
            }
        }
    }

    void ShowLevelSelection()
    // Die LevelSelection wird angezeigt und MainMenu wird versteckt
    {
        panelMain.HideCanvasGroup();
        panelLevelSelection.ShowCanvasGroup();
    }

    void ShowMainPanel()
    // Das MainMenu wird angezeigt und die LevelSelection wird versteckt
    {
        panelMain.ShowCanvasGroup();
        panelLevelSelection.HideCanvasGroup();
    }

    void LoadLevel1()
    {
        //Das erste Level wird geladen 
        SceneManager.LoadScene(LevelNames[0]);
    }
    void LoadLevel2()
    {
        //Das zweite Level wird geladen 
        SceneManager.LoadScene(LevelNames[1]);
    }
     void LoadLevel3()
    {
        //Das dritte Level wird geladen
       SceneManager.LoadScene(LevelNames[2]);

    }

    void ExitGame()
    //wenn man auf ExitGame im MainMenu geht wird das Spiel nun geschlossen
    {
        Application.Quit();
    }
}
