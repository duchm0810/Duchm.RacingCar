using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using LitJson;
using SimpleJSON;

public class UlaCoinRequest : MonoBehaviour
{
    /* *
    Tạo địa chỉ mới : http://45.32.176.67:4000/newAddress
    Get số dư địa chỉ : http://45.32.176.67:4000/getBalances/:address
    Lấy lịch sử giao dịch : http://45.32.176.67:4000/getTransaction/:address
    Send đi từ ví tổng  : http://45.32.176.67:4000/mainTransaction/:security/:to/:amount
    Send đi từ 1 ví tùy chọn : http://45.32.176.67:4000/sendTransaction/:security/:from/:to/:amount
     * */
    private const string main_url = "http://45.32.176.67:4000";
    private const string new_address = "newAddress";
    private const string get_balance = "getBalances";
    private const string transaction_history = "getTransaction";
    private const string main_transaction_amount = "mainTransaction";
    private const string transaction_amount = "sendTransaction";
    private const string securityKey = "H85H0AN064OCIQP5BNI2";
    private string url = "";

    private string balanceAddress;
    private InputField balance_address;
    private InputField input_amount;
    private Text placeholderAddress;
    private Text placeholderAmount;
    private Text textStatus;
    private Text textRatio;

    [SerializeField]
    private int ratio;

    public GameObject BalancePanel;


    void Start()
    {
        //PlayerPrefs.SetInt("Coin", 200);
        if (balance_address == null)
        {
            try
            {
                balance_address = GameObject.Find("BalanceAddress").GetComponent<InputField>();
            }
            catch
            {

            }
        }
        if (input_amount == null)
        {
            try
            {
                input_amount = GameObject.Find("InputAmount").GetComponent<InputField>();
            }
            catch
            {

            }
        }
        if (placeholderAddress == null)
        {
            try
            {
                placeholderAddress = GameObject.Find("PlaceholderBalanceAddress").GetComponent<Text>();
            }
            catch
            {

            }
        }
        if (placeholderAmount == null)
        {
            try
            {
                placeholderAmount = GameObject.Find("PlaceholderInputAmount").GetComponent<Text>();
            }
            catch
            {

            }
        }
        if (textStatus == null)
        {
            try
            {
                textStatus = GameObject.Find("TextStatus").GetComponent<Text>();
            }
            catch
            {

            }
        }
        if (textRatio == null)
        {
            try
            {
                textRatio = GameObject.Find("TextRatio").GetComponent<Text>();
            }
            catch
            {

            }
        }
        if (PlayerPrefs.GetString("BalanceAddress") == null || PlayerPrefs.GetString("BalanceAddress") == "")
        {

        }
        else
        {
            placeholderAddress.text = PlayerPrefs.GetString("BalanceAddress");
            balance_address.text = PlayerPrefs.GetString("BalanceAddress");
        }

    }
    private void Update()
    {
        textRatio.text = "You have " + PlayerPrefs.GetInt("Coin") + " Point. ";
    }
    public void transactionButton()
    {
        if (balance_address.text == null || balance_address.text == "")
        {
            print("Dont have Wallet");
            textStatus.text = "You must enter your address";
        }
        else
        {
            balanceAddress = balance_address.text;
            int amount;
            if (input_amount.text==null ||input_amount.text == "")
            {
                amount = 0;
            }
            else
            {
                amount = int.Parse(input_amount.text);
            }
            
            print(amount);
            mainTransaction(amount);
        }

    }

    private void mainTransaction(int amount)
    {
        if (PlayerPrefs.GetInt("Coin") >= amount)
        {
            url = main_url + "/" + main_transaction_amount + "/" + securityKey + "/" + balanceAddress + "/" + amount;
            using (WWW www = new WWW(url))
            {
                print(url);
                if (www.error == null)
                {
                    print("Success Transaction");
                    StartCoroutine(dataCallBack());
                    textStatus.text = "Send successfully";
                }
                else
                {
                    print("Failed Transaction");
                    int coin = PlayerPrefs.GetInt("Coin");
                    textStatus.text = "Send Failed, Check Internet";
                }
            }
        }
        else
        {
            //You dont have enough coin
            print("You dont have enough Coin");
            textStatus.text = "You don't have enough coin";
        }
    }
    IEnumerator dataCallBack()
    {
        WWW www = new WWW(url);
        yield return www;
        if (www.error == null)
        {
            Debug.Log(www.text);
            ReadJson(www.text);
        }
        else
        {
            Debug.Log("ERROR: " + www.error);
        }
    }
    void ReadJson(String jsonstring)
    {

        JSONNode jsonNode = JSON.Parse(jsonstring);
        print(jsonNode.Count);
        string status = jsonNode["status"].ToString();
        string error = jsonNode["errors"].ToString();
        print(status);
        print(error);
        if (status == "true")
        {
            int coin = PlayerPrefs.GetInt("Coin") - int.Parse(input_amount.text);
            PlayerPrefs.SetInt("Coin", coin);
            PlayerPrefs.SetString("BalanceAddress", balance_address.text);
            textStatus.text = input_amount + " was sent to your address";
        }
        else
        {
            textStatus.text = "Your address was incorrect";
        }

        //string status = itemdata["status"].ToString();
        //string error = itemdata["errors"].ToString();
        //Debug.Log(status);
        //Debug.Log(error);


    }
    private void getHistory()
    {

    }


    public void closePanel()
    {
        BalancePanel.SetActive(false);
    }
}
public class parseJSON
{
    public string title;
    public string id;
    public ArrayList but_title;
    public ArrayList but_image;
}
