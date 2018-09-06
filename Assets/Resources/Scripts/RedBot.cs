using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBot : MonoBehaviour {

    public GameObject[] listCoin;
    public GameObject car;
    public bool rBotColl,rBotisRight;
    public float speed;
    GameObject coin;
    GameObject nearCoin;
    Vector3 dir;
    // Use this for initialization
    void Start () {
        speed = (30 + Scrolling.scrolling.speed) / 20;
        coin = GameObject.FindGameObjectWithTag("Coin");
        listCoin = GameObject.FindGameObjectsWithTag("Coin");
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if(transform.position.y < -6)
        {
            Destroy(gameObject);
        }
        eatCoin();
        
        transform.Translate(Vector2.left * (car.transform.rotation.z * 10 * Time.deltaTime));
    }
    void eatCoin()
    {
        listCoin = GameObject.FindGameObjectsWithTag("Coin");
        if (rBotColl)
        {
            if (rBotisRight)
            {
                if (car.transform.rotation.z > -0.10f)
                {
                    car.transform.Rotate(Vector3.back * 30 * Time.deltaTime);
                }
               
            }
            else
            {
                if (car.transform.rotation.z < 0.10f)
                {
                    car.transform.Rotate(Vector3.forward * 30 * Time.deltaTime);
                }
               
            }
        }
        else
        {
            if(listCoin.Length != 1)
            {
                nearCoin = listCoin[0].transform.gameObject;
                for (int i = 0; i < listCoin.Length; i++)
                {
                    float distance1 = Vector3.Distance(listCoin[0].transform.position, transform.position);
                    float distance2 = Vector3.Distance(listCoin[i].transform.position, transform.position);
                    if (distance2 < distance1)
                    {
                        nearCoin = listCoin[i].transform.gameObject;
                    }
                    
                }
            }
            else if(listCoin.Length ==1)
            {
                nearCoin = listCoin[0].transform.gameObject;
            }
            else
            {
                if (car.transform.rotation.z >= 0)
                {
                    car.transform.Rotate(Vector3.back * 30 * Time.deltaTime);
                }
                else

                if (car.transform.rotation.z < 0)
                {
                    car.transform.Rotate(Vector3.forward * 30 * Time.deltaTime);
                    
                }
            }
            float distance = Vector3.Distance(nearCoin.transform.position, transform.position);
            if (distance <= 20f && nearCoin.transform.position.y > transform.position.y)
            {
                if (transform.position.x < nearCoin.transform.position.x)
                {
                    if (car.transform.rotation.z > -0.10f)
                    {
                        car.transform.Rotate(Vector3.back * 30 * Time.deltaTime);
                    }
                    
                }
                else if (transform.position.x > nearCoin.transform.position.x)
                {
                    if (car.transform.rotation.z < 0.10f)
                    {
                        car.transform.Rotate(Vector3.forward * 30 * Time.deltaTime);
                    }
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bot" || col.gameObject.tag == "Player" || col.gameObject.tag == "Grid")
        {
            rBotColl = true;
            if (col.transform.position.x >= transform.position.x)
            {
                rBotisRight = true;
            }
            else
            {
                rBotisRight = false;
            }
        }
        if(col.gameObject.tag == "Coin")
        {
            listCoin = GameObject.FindGameObjectsWithTag("Coin");
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bot" || col.gameObject.tag=="Player" || col.gameObject.tag == "Grid")
        {
            rBotColl = false;
        }
    }
}
