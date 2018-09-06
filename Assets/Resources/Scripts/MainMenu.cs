using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    public GameObject BalancePanel;
    private void Start()
    {
        BalancePanel.SetActive(false);
    }
    public void btnPlay()
    {
        GameObject.Find("Sound").GetComponent<SoundManager>().ClickSound();
        Application.LoadLevel("GamePlay");
    }
    public void btnCoin()
    {
        GameObject.Find("Sound").GetComponent<SoundManager>().ClickSound();
        BalancePanel.SetActive(true);
    }
    public void btnShop()
    {
        GameObject.Find("Sound").GetComponent<SoundManager>().ClickSound();
        Application.LoadLevel("SelectScene");
    }
    public void btnExit()
    {
        GameObject.Find("Sound").GetComponent<SoundManager>().ClickSound();
        Application.Quit();
    }
}
