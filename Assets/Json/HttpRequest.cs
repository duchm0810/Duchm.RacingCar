using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using LitJson;
using SimpleJSON;
public class HttpRequest : MonoBehaviour {

    public string linkJson = "http://ulagame.com/sv/api/lib_questions.php";

    List<ChalengerObject> listChalenger = new List<ChalengerObject>();
    
    string itemString;

    void Start()
    {
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(linkJson);
        request.Method = "GET";
        string test = string.Empty;
        try
        {
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                test = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
            }
            itemString = test.ToString();
        }
        catch
        {

        }

        GetListChalenger();
        print(listChalenger.Count);

        for (int i = 0; i < listChalenger.Count; i++)
        {
            print(listChalenger[i].id + "-" + listChalenger[i].question + "-" + listChalenger[i].level + "-" + listChalenger[i].time);
        }
    }
    void GetListChalenger()
    {
        JSONNode jsonNode = JSON.Parse(itemString);
        print(jsonNode.Count);
        for (int i = 0; i < jsonNode.Count; i++)
        {
            ChalengerObject item = new ChalengerObject();
            item.id = jsonNode[i]["id"];
            item.question = jsonNode[i]["question"];
            item.level = jsonNode[i]["level"];
            item.time = jsonNode[i]["time"];
            listChalenger.Add(item);
        }
    }
}
