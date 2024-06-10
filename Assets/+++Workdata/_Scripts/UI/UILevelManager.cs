using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UILevelManager : MonoBehaviour
{

    [SerializeField] private CanvasGroup panelWin;
    [SerializeField] private Button buttonNextLevel;
    [SerializeField] private Button buttonPlayAgainWin;
    [SerializeField] private Button buttonBackToMenu1;
    
    [SerializeField] private CanvasGroup panelLose;
    [SerializeField] private Button buttonPlayAgainLose;
    [SerializeField] private Button buttonBackToMenu2;

    [SerializeField] private string nameNextScene;

    //Münzenzähler hinzugefügt
    private int coinCount = 0;
    [SerializeField] private TextMeshProUGUI txtCoincount;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        txtCoincount.text = coinCount.ToString();
        //win und lose screen --> hide
        panelWin.HideCanvasGroup();
        panelLose.HideCanvasGroup();
        
        //on click = wenn man drauf drückt passiert das und das
        buttonNextLevel.onClick.AddListener(LoadNextLevel);
        buttonPlayAgainWin.onClick.AddListener(RestartLevel);
        buttonPlayAgainLose.onClick.AddListener(RestartLevel);
        buttonBackToMenu1.onClick.AddListener(BackToMenu);
        buttonBackToMenu2.onClick.AddListener(BackToMenu);
        
        
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
        coinCount++;    //the same as coincount = +1;
        txtCoincount.text = coinCount.ToString();
    }
    void RestartLevel()
    {
        //Reload Level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void LoadNextLevel()
    {
        //Load next Level
        SceneManager.LoadScene(nameNextScene);
    }
    void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    

}

public static class UIExtentions
{
    public static void HideCanvasGroup(this CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
    public static void ShowCanvasGroup(this CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

   
}