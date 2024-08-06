using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI levelText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coins: " + PlayerController.instance.totalMoney;
        levelText.text = "" + (LevelManager.instance.levelID+1) ;
    }
}
