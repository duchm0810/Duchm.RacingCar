using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectMenuManaGer : MonoBehaviour {


    public List<GameObject> listCar = new List<GameObject>();
    public List<GameObject> listButton = new List<GameObject>();
    public GameObject buttonPrefab;
    public GameObject carObj;
    public GameObject BuyButton, SelectButton;

    Text CarName;
    Text CarPrice;
    Text CarSpeed;
    Image CarImage;

    // Use this for initialization
    void Start () {
        if (BuyButton == null)
        {
            BuyButton = GameObject.Find("BuyButton");
        }
        if(SelectButton == null)
        {
            SelectButton = GameObject.Find("SelectButton");
        }
        createList();
        carObj = GameObject.Find("carObj");
        BuyButton.SetActive(false);
        SelectButton.SetActive(false);
        showCurrentCar();

    }
	
	// Update is called once per frame
	void Update () {
        GameObject.Find("CoinText").GetComponent<Text>().text = PlayerPrefs.GetInt("Coin").ToString();
        if (carObj == null)
        {
            carObj = GameObject.Find("carObj");
        }
        else
        {
            if (carObj.transform.GetChild(0).GetComponent<Car>().unlocked)
            {
                BuyButton.SetActive(false);
                SelectButton.SetActive(true);
            }
            else
            {
                BuyButton.SetActive(true);
                SelectButton.SetActive(false);
            }
        }

        GameObject.Find("CarImage").GetComponent<Image>().transform.Rotate(Vector3.back * 180 * Time.deltaTime);

    }

    void createList()
    {
        GameObject Obj = null;
        bool done = false;
        int counter = 1;
        while (!done)
        {
            Obj = Resources.Load("Prefabs/Player/" + counter) as GameObject;
            if(Obj == null)
                done = true;
            else
                listCar.Add(Obj);
            counter++;
        }

        GameObject btn;
        foreach(GameObject car in listCar)
        {
            btn = Object.Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            btn.name = car.name;
            RectTransform rect = btn.GetComponent<RectTransform>();
            rect.SetParent(GameObject.Find("Content").transform);
            rect.localScale = new Vector3(1, 1, 1);
            rect.pivot = new Vector2(0.5f, 0.5f);
            btn.GetComponent<Image>().sprite = car.gameObject.transform.GetChild(0).GetComponent<Car>().gameplaySprite;
        }
    }
    void showCurrentCar()
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
        GameObject[] carlist = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject obj in carlist)
        {
            Destroy(obj.gameObject);
        }
        GameObject car = GameObject.Instantiate(Resources.Load("Prefabs/Player/" + PlayerPrefs.GetInt("current")), new Vector3(-10, -10, 0), Quaternion.identity) as GameObject;
        car.name = "carObj";
        Car carInfor = car.gameObject.transform.GetChild(0).GetComponent<Car>();
        car.GetComponent<PlayerController>().enabled = false;
        CarImage.sprite = carInfor.gameplaySprite;
        CarName.text = carInfor.id;
        CarPrice.text = "Price:   " + carInfor.price + " coin";
        CarSpeed.text = "Speed:   " + carInfor.maxSpeed+"0 kph";
    }

    public void BuyCar()
    {
        if(PlayerPrefs.GetInt("Coin")>= carObj.transform.GetChild(0).GetComponent<Car>().price)
        {
            int coin = PlayerPrefs.GetInt("Coin") - carObj.transform.GetChild(0).GetComponent<Car>().price;
            PlayerPrefs.SetInt("Coin", coin);
            PlayerPrefs.SetInt(carObj.transform.GetChild(0).name + "unlocked", 1);
        }
    }
    public void SelectCar()
    {
        GameObject.Find("Sound").GetComponent<SoundManager>().ClickSound();
        PlayerPrefs.SetInt("current", int.Parse(carObj.transform.GetChild(0).name));
    }
    public void raceButton()
    {
        GameObject.Find("Sound").GetComponent<SoundManager>().ClickSound();
        Application.LoadLevel("GamePlay");
    }
    public void backButton()
    {
        GameObject.Find("Sound").GetComponent<SoundManager>().ClickSound();
        Application.LoadLevel("MainMenu");                                                                                                                                                                                                                                                                                                                                                                                              
    }
}
