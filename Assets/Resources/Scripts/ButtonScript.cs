using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

    public GameObject CarPanel;
    public Text CarName;
    public Text CarPrice;
    public Text CarSpeed;
    public Image CarImage;

    private void Start()
    {
        if (CarImage == null)
        {
            CarImage = GameObject.Find("CarImage").GetComponent<Image>();
        }
        if (CarName == null)
        {
            CarName = GameObject.Find("NameText").GetComponent<Text>();
        }
        if (CarPrice == null)
        {
            CarPrice = GameObject.Find("PriceText").GetComponent<Text>();
        }
        if (CarSpeed == null)
        {
            CarSpeed = GameObject.Find("SpeedText").GetComponent<Text>();
        }
    }
    public void getCarInfomation()
    {
        GameObject[] carlist = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject obj in carlist)
        {
            Destroy(obj.gameObject);
        }
        GameObject car = GameObject.Instantiate(Resources.Load("Prefabs/Player/" + this.gameObject.name), new Vector3(-10, -10, 0), Quaternion.identity) as GameObject;
        car.name = "carObj";
        Car carInfor = car.gameObject.transform.GetChild(0).GetComponent<Car>();
        car.GetComponent<PlayerController>().enabled = false;
        CarImage.sprite = carInfor.gameplaySprite;
        CarName.text = carInfor.id;
        CarPrice.text = "Price:   " + carInfor.price + " coin";
        CarSpeed.text = "Speed:   " + carInfor.maxSpeed + "0 kph";

    }
}
