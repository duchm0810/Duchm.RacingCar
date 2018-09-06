using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    public float speed;
	// Use this for initialization
	void Start () {
        speed = (50 + Scrolling.scrolling.speed) / 20;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if(this.transform.position.y < -5)
        {
            Destroy(this.gameObject);
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Car")
        {
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 1);
            Destroy(gameObject);
            print(collision.gameObject.name);
        }
        if(collision.gameObject.tag == "Bot")
        {
            if (PlayerPrefs.GetInt("Coin") > 0)
            {
                PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - 1);
            }
            Destroy(gameObject);
            print(collision.gameObject.name);
        }
    }
}
