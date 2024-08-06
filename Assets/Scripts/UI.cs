using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI gameNameText;
    public Button startButton;
    public GameObject startImage;
    bool gameActive = false;
    private static UI instance;

     void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }  
      void Start()
    {
        PlayerController.instance.isGameEnd = true;
        gameNameText.text = "Deliver it 3d Clone";
        startImage.SetActive(true);
    }
    void Update()
    {
        GamePage();
    }
    void GamePage()
    {
        if(gameActive == true)
        {   
        gameNameText.gameObject.SetActive(false);
        coinText.gameObject.SetActive(true);
        coinText.text = "Coins: " + PlayerController.instance.totalMoney;
        levelText.gameObject.SetActive(true);
        levelText.text = "" + (LevelManager.instance.levelID+1) ;
        }
    }
    public void StartGame()
    {
    startImage.SetActive(false);
    PlayerController.instance.isGameEnd = false;
    gameActive = true;
    startButton.gameObject.SetActive(false);
    }
}
