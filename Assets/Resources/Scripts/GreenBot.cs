using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBot : MonoBehaviour {

    public float speed;
	// Use this for initialization
	void Start () {
        speed = (50 + Scrolling.scrolling.speed) / 20;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if(transform.position.y < -6)
        {
            Destroy(gameObject);
        }
	}
}
