using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UILevelManager : MonoBehaviour
{
    //SerialzeFields fügen in dem Fall die Buttons oder Panel (Variablen) in den Inspector hinzu
    //hinzu und man kann dann die InGame Elemente reinziehen und sie sind verbunden
    [SerializeField] private CanvasGroup panelWin;
    [SerializeField] private Button buttonNextLevel;
    [SerializeField] private Button buttonPlayAgainWin;
    [SerializeField] private Button buttonBackToMenu1;
    
    [SerializeField] private CanvasGroup panelLose;
    [SerializeField] private Button buttonPlayAgainLose;
    [SerializeField] private Button buttonBackToMenu2;

    [SerializeField] private CanvasGroup panelPause;
    [SerializeField] private Button buttonBackToGame;
    [SerializeField] private Button buttonBackToMenu3;
    [SerializeField] private string nameNextScene;

    //Münzenzähler hinzugefügt, Anfangswert auf 0 gesetzt
    private int coinCount = 0;
    [SerializeField] private TextMeshProUGUI txtCoincount;
    
    // Start is called before the first frame update
    private void Update()
    {
        //PauseMenu hinzugefügt, Wenn man auf Escape drückt wird das Pause Panel angezeigt und die Zeit wird gestoppt
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panelPause.ShowCanvasGroup();
            Time.timeScale = 0f;
        }
    }


    void Start()
    {
        //Zeit läuft weiter, Win/lose/pause panel werden versteckt
        Time.timeScale = 1f;
        txtCoincount.text = coinCount.ToString();
        panelWin.HideCanvasGroup();
        panelLose.HideCanvasGroup();
        panelPause.HideCanvasGroup();
        
        //on click = wenn man drauf drückt passiert etwas
        //hier werden je nach Button das nächste Level geladen, das Level neugestartet, man kommt zurück zum MainMenu oder man kommt zurück zum Level was gerade läuft
        buttonNextLevel.onClick.AddListener(LoadNextLevel);
        buttonPlayAgainWin.onClick.AddListener(RestartLevel);
        buttonPlayAgainLose.onClick.AddListener(RestartLevel);
        buttonBackToMenu1.onClick.AddListener(BackToMenu);
        buttonBackToMenu2.onClick.AddListener(BackToMenu);
        buttonBackToMenu3.onClick.AddListener(BackToMenu);
        buttonBackToGame.onClick.AddListener(BackToGame);
        
        
    }
    
    public void OnGameWin()
    {
        //Winscreen --> Show
        panelWin.ShowCanvasGroup();
        PlayerPrefs.SetInt(nameNextScene,1);
        
        //Spiel wird angehalten wenn der Winscreen kommt
        Time.timeScale = 0f;
    }
    
    public void OnGameLose()
    {
        //Losescreen --Show
        panelLose.ShowCanvasGroup();
        
        //Spiel wird angehalten wenn der Losescreen kommt
        Time.timeScale = 0f;
    }

    public void AddCoin()
    {
        //hier wird hinzugefügt, dass die Coincount hochgeht, wenn man Münzen einsammelt
        coinCount++;    //das Gleiche wie coincount = +1;
        txtCoincount.text = coinCount.ToString();
    }
    void RestartLevel()
    {
        //Das Level wird neugestartet
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void LoadNextLevel()
    {
        //Das nächste Level wird geladen
        SceneManager.LoadScene(nameNextScene);
    }
    void BackToMenu()
    {
        //Das Menu wird geladen 
        SceneManager.LoadScene("Menu");
    }

    void BackToGame()
    {
        //panelPause wird versteckt und die Zeit geht weiter
        panelPause.HideCanvasGroup();
        Time.timeScale = 1f;
    }

}

public static class UIExtentions
{
    public static void HideCanvasGroup(this CanvasGroup canvasGroup)
    {
        //Die Canvas Group wird versteckt indem man die Transparenz auf 0 setzt (Panel ist durchsichtig), man kann nicht mehr damit interagieren
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
    public static void ShowCanvasGroup(this CanvasGroup canvasGroup)
    {
        //Die Canvas Group wird gezeigt indem man die Transparenz auf 1 setzt (Panel ist nicht durchsichtig), man kann mit ihnen interagieren
        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

   
}