using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour {

    public static Scrolling scrolling;
    public float speed;
    public GameObject[] road;
    GameObject player;
    Vector3 Epos, Spos;
    Car  _car;
    float maxSpeed;

    private void Awake()
    {
        if (scrolling == null)
        {
            scrolling = this;
        }

    }
    // Use this for initialization
    void Start () {
        
        player = GameObject.FindGameObjectWithTag("Car");
        maxSpeed = player.GetComponent<Car>().maxSpeed;
        Spos = road[0].transform.position;
        Epos = road[road.Length - 1].transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (!ParameterManager.parameter.isDeath)
        if(ParameterManager.parameter.outSide == false)
        {
            if (speed < maxSpeed)
            {
                speed += 0.02f;
            }
        }
        else
        {
            if (speed > 20)
            {
                speed -= 0.1f;
                print("OutSide");
            }
        }
        
        for(int i = 0; i < road.Length; i++)
        {
            road[i].transform.Translate(Vector3.down * speed * Time.deltaTime);
            if(road[i].transform.position.y <= Epos.y)
            {
                road[i].transform.position = Spos;
            }
        }

	}
}
