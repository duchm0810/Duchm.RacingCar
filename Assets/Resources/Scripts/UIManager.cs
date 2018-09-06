using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text speedText;
    public Text scoreText;
    public Text coinText;
    public Text pointText;
    public Text EndSpeed, EndScore, EndCoin;

    // Use this for initialization
    void Start () {
        initGameObject();
	}
	
	// Update is called once per frame
	void Update () {
        speedText.text = EndSpeed.text = "Speed: "+(int)ParameterManager.parameter.roadSpeed + " kph";
        coinText.text  = EndCoin.text  = "Coin: " +PlayerPrefs.GetInt("Coin").ToString();
        scoreText.text = "Score: "+(int)ParameterManager.parameter.score ;
        pointText.text = "";
	}
    
    void initGameObject()
    {
        if (speedText == null)
        {
            try
            {
                speedText = GameObject.Find("SpeedText").GetComponent<Text>();
            }
            catch
            {

            }
        }
        if (scoreText == null)
        {
            try
            {
                scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
            }
            catch
            {

            }
        }
        if (coinText == null)
        {
            try
            {
                coinText = GameObject.Find("CoinText").GetComponent<Text>();
            }
            catch
            {

            }
        }
        if (pointText == null)
        {
            try
            {
                pointText = GameObject.Find("PointText").GetComponent<Text>();
            }
            catch
            {

            }
        }
        if (EndCoin == null)
        {
            try
            {
                EndCoin = GameObject.Find("EndCoin").GetComponent<Text>();
            }
            catch
            {

            }
        }
        if (EndScore == null)
        {
            try
            {
                EndScore = GameObject.Find("EndScore").GetComponent<Text>();
            }
            catch
            {

            }
        }
        if (EndSpeed == null)
        {
            try
            {
                EndSpeed = GameObject.Find("EndSpeed").GetComponent<Text>();
            }
            catch
            {

            }
        }

    }
    public void btnSelectCar()
    {
        GameObject.Find("Sound").GetComponent<SoundManager>().ClickSound();
        Application.LoadLevel("SelectScene");
    }
    public void btnMainMenu()
    {
        GameObject.Find("Sound").GetComponent<SoundManager>().ClickSound();
        Application.LoadLevel("MainMenu");
    }
    public void btnPlayAgain()
    {
        GameObject.Find("Sound").GetComponent<SoundManager>().ClickSound();
        Application.LoadLevel(Application.loadedLevel);
    }
}
