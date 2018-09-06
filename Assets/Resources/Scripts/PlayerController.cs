using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public GameObject car;
    public bool btnRight, btnLeft;
    float rotSpeed;
    float turnSpeed;
    Rigidbody2D mBody;
    Car carInfor;
    float rot = 0;
	// Use this for initialization
	void Start () {
        btnRight= btnLeft =false;
        mBody = car.GetComponent<Rigidbody2D>();
        carInfor = car.GetComponent<Car>();
        rotSpeed = carInfor.rotSpeed;
        turnSpeed = carInfor.turnSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (!ParameterManager.parameter.isDeath)
        {
            
            //if (Input.GetKey(KeyCode.A))
            //{
            //    turnLeft();
            //}
            //else if (Input.GetKey(KeyCode.D))
            //{
            //    turnRight();
            //}
            //else
            //{
            //    forward();
            //}
            if (btnLeft)
            {
                turnLeft();
            }
            else if (btnRight)
            {
                turnRight();
            }
            else
            {
                forward();
            }

        }
        else
        {
            if (ParameterManager.parameter.isOver)
            {
                transform.Translate(new Vector3(0 * Time.fixedDeltaTime, 0 * Time.fixedDeltaTime, 0));
                car.transform.Rotate(Vector3.back * 0 * Time.fixedDeltaTime);
            }
            else
            {
                if (ParameterManager.parameter.botisRight)
                {
                    transform.Translate(new Vector3(-2 * Time.fixedDeltaTime, 1 * Time.fixedDeltaTime, 0));
                    car.transform.Rotate(Vector3.back * -180 * Time.fixedDeltaTime);
                }
                else
                {
                    transform.Translate(new Vector3(2 * Time.fixedDeltaTime, 1 * Time.fixedDeltaTime, 0));
                    car.transform.Rotate(Vector3.back * 180 * Time.fixedDeltaTime);
                }
            }
        }
	}

    public void turnRight()
    {
        if(car.transform.rotation.z > -0.20f)
        {
           car.transform.Rotate(Vector3.back * rotSpeed * Time.deltaTime);
        }
        float speed = -car.transform.rotation.z * turnSpeed * Time.deltaTime;
        transform.Translate(Vector2.right * speed);
    }
    public void turnLeft()
    {
        if (car.transform.rotation.z < 0.20f)
        {
            car.transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
        }
        float speed = car.transform.rotation.z * turnSpeed * Time.deltaTime;
        transform.Translate(Vector2.left * speed);
    }
    public void forward()
    {
        if (car.transform.rotation.z >= 0)
        {
            car.transform.Rotate(Vector3.back * rotSpeed * Time.deltaTime);
            float speed = -car.transform.rotation.z * turnSpeed * Time.deltaTime;
            transform.Translate(Vector2.right * speed);
        }else

        if (car.transform.rotation.z <= 0)
        {
            car.transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
            float speed = car.transform.rotation.z * turnSpeed * Time.deltaTime;
            transform.Translate(Vector2.left * speed);
        }
    }

}
