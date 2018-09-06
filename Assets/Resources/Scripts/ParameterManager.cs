using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParameterManager : MonoBehaviour {


    public static ParameterManager parameter;
    public GameObject GameOverPanel;
    public float roadSpeed;
    public float score;
    public int carHeath;
    public bool outSide;
    public bool rBotColl,bBotisRight;
    public bool isDeath;
    public bool botisRight;
    public float Timer = 1;
    public bool isOver;
    public bool isGrid;
    public GameObject player;

	// Use this for initialization
	void Awake () {
        

		if(parameter == null)
        {
            parameter = this;
        }
        //PlayerPrefs.SetInt("current", 6);
        if (PlayerPrefs.GetInt("current")==0 || PlayerPrefs.GetInt("current") == null)
        {
            PlayerPrefs.SetInt("current", 1);
        }
        GameObject prefab = Resources.Load("Prefabs/Player/" + PlayerPrefs.GetInt("current")) as GameObject;
        player = GameObject.Instantiate(prefab, new Vector3(0, -3.5f, 0), Quaternion.identity);
        player.name = PlayerPrefs.GetInt("current").ToString();

    }
    private void Start()
    {
        if (GameOverPanel == null)
        {
            GameOverPanel = GameObject.Find("GameOverPanel");
        }
        GameOverPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update () {
        roadSpeed = Scrolling.scrolling.speed*10;
        if(!isDeath) score += roadSpeed * 0.1f * Time.deltaTime;
        Time.timeScale = Timer;
        if (Time.timeScale != 0)
        {
            
        }
        else
        {

        }
	}
    void spawPlayer()
    {

    }
}
