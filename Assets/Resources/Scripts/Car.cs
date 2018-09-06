using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Car : MonoBehaviour {

    public string id;

    public int heath;

    public Sprite gameplaySprite;

    public Sprite chooseSprite;

    public float rotSpeed;

    public float turnSpeed;

    public float maxSpeed;

    public int price;

    public bool unlocked;
    Rigidbody2D mBody;
    private void Start()
    {
        mBody = this.GetComponent<Rigidbody2D>();
        if (price == 0)
        {
            PlayerPrefs.SetInt(this.gameObject.name + "unlocked", 1);
        }
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt(this.gameObject.name + "unlocked") == 1)
        {
            unlocked = true;
        }
        else
        {
            unlocked = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Grid")
        {
            print("Enter");
            ParameterManager.parameter.outSide = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Grid")
        {
            print("Exit");
            ParameterManager.parameter.outSide = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bot")
        {
            GameObject.Find("Sound").GetComponent<SoundManager>().CrashSound();
            AdmobIntersititials.admob.showAds();
            ParameterManager.parameter.isDeath = true;
            if(collision.gameObject.transform.position.x >= transform.position.x)
            {
                ParameterManager.parameter.botisRight = true;
            }
        }
        if(collision.gameObject.tag == "Grid")
        {
            ParameterManager.parameter.isGrid = true;
            if (ParameterManager.parameter.isDeath)
            {
                ParameterManager.parameter.isOver = true;
                StartCoroutine(GameOver());
            }
        }
    }
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0f);
        ParameterManager.parameter.Timer = 0;
        ParameterManager.parameter.GameOverPanel.SetActive(true);
        GameObject.Find("EndScore").GetComponent<Text>().text = "Score: " + (int)ParameterManager.parameter.score +"=>"+ChangeCoin((int)ParameterManager.parameter.score)+" Coin";
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + ChangeCoin((int)ParameterManager.parameter.score));
    }
    int ChangeCoin(int score)
    {
        int coin;
        coin = score / 1000;
        return coin;
    }
}
