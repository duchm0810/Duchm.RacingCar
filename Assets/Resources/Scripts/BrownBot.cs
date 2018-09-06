using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownBot : MonoBehaviour {

    public GameObject car;
    public float speed;
    bool isRight;
    Vector3 dir;
	// Use this for initialization
	void Start () {
        speed = (35 + Scrolling.scrolling.speed) / 20;
        this.isRight = ParameterManager.parameter.bBotisRight;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
        Invoke("setTurn",0.75f);
        onTurn();
    }
    void setTurn() {
        if (isRight)
        {
            dir = Vector3.forward;
        }
        else
        {
            dir = Vector3.back;
        }
    }
    void onTurn()
    {
        if (dir == Vector3.back)
        {
            if(car.transform.rotation.z > -0.10f)
            {
                car.transform.Rotate(dir * 30 * Time.deltaTime);
            }
            float speed = -car.transform.rotation.z * 10 * Time.deltaTime;
            transform.Translate(Vector2.right * speed);
        }else if(dir == Vector3.forward)
        {
            if(car.transform.rotation.z < 0.10f)
            {
                car.transform.Rotate(dir * 30 * Time.deltaTime);
            }
            float speed = car.transform.rotation.z * 10 * Time.deltaTime;
            transform.Translate(Vector2.left * speed);
        }
    }

    void changeDirection()
    {
        print("Change");
        if (ParameterManager.parameter.bBotisRight)
        {
            ParameterManager.parameter.bBotisRight = false;
        }
        else
        {
            ParameterManager.parameter.bBotisRight = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Bot" || col.gameObject.tag == "Grid")
        {
            changeDirection();
            if (isRight)
            {
                isRight = false;
            }
            else
            {
                isRight = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Bot" || col.gameObject.tag == "Grid")
        {

        }
    }
}
