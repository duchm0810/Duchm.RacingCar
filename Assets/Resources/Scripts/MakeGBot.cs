using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeGBot : MonoBehaviour {
    public GameObject BrownBot,GreenBot,RedBot,Coin;
    GameObject Bot;
    public float time = 3;

	// Use this for initialization
	void Start () {
        StartCoroutine(delay());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator makeBot()
    {
        yield return new WaitForSeconds(this.time);
        int randBot = Random.Range(0, 9);
        switch (randBot)
        {
            case 0: Bot = GreenBot; break;
            case 1: Bot = GreenBot; break;
            case 2: Bot = GreenBot; break;
            case 3: Bot = GreenBot; break;
            case 4: Bot = GreenBot; break;
            case 5: Bot = GreenBot; break;
            case 6: Bot = BrownBot; break;
            case 7: Bot = BrownBot; break;
            case 8: Bot = RedBot; break;
            //case 9: Bot =  ; break;
            default: break;
        }
        int randPos = Random.Range(0, 4);
        switch (randPos)
        {
            case 0: Instantiate(Bot, new Vector3(-1.55f, 6, 0), Quaternion.identity);
                break;
            case 1: Instantiate(Bot, new Vector3(-0.55f, 6, 0), Quaternion.identity);
                break;
            case 2: Instantiate(Bot, new Vector3(0.55f, 6, 0), Quaternion.identity);
                break;
            case 3: Instantiate(Bot, new Vector3(1.55f, 6, 0), Quaternion.identity);
                break;
            default: break;
        }
        int randCPos = Random.Range(0, 4);
        while (randPos == randCPos)
        {
            randCPos = Random.Range(0, 4);
        }

        switch (randCPos)
        {
            case 0:
                Instantiate(Coin, new Vector3(-1.55f, 6, 0), Quaternion.identity);
                break;
            case 1:
                Instantiate(Coin, new Vector3(-0.55f, 6, 0), Quaternion.identity);
                break;
            case 2:
                Instantiate(Coin, new Vector3(0.55f, 6, 0), Quaternion.identity);
                break;
            case 3:
                Instantiate(Coin, new Vector3(1.55f, 6, 0), Quaternion.identity);
                break;
            default: break;
        }
        time = 5 - ((45 + Scrolling.scrolling.speed) / 20);
        StartCoroutine(makeBot());
    }
    IEnumerator makeCoin()
    {
        yield return new WaitForSeconds(this.time);
        //int randBot = Random.Range(0, 10);
        //switch (randBot)
        //{
        //    case 0: Bot = GreenBot; break;
        //    case 1: Bot = GreenBot; break;
        //    case 2: Bot = GreenBot; break;
        //    case 3: Bot = GreenBot; break;
        //    case 4: Bot = RedBot; break;
        //    case 5: Bot = BrownBot; break;
        //    case 6: Bot = BrownBot; break;
        //    case 7: Bot = BrownBot; break;
        //    case 8: Bot = RedBot; break;
        //    case 9: Bot = RedBot; break;
        //    default: break;
        //}

        int randCPos = Random.Range(0, 4);
        
        switch (randCPos)
        {
            case 0:
                Instantiate(Coin, new Vector3(-1.55f, 6, 0), Quaternion.identity);
                break;
            case 1:
                Instantiate(Coin, new Vector3(-0.55f, 6, 0), Quaternion.identity);
                break;
            case 2:
                Instantiate(Coin, new Vector3(0.55f, 6, 0), Quaternion.identity);
                break;
            case 3:
                Instantiate(Coin, new Vector3(1.55f, 6, 0), Quaternion.identity);
                break;
            default: break;
        }
        time = 5 - ((45 + Scrolling.scrolling.speed) / 20);
        StartCoroutine(makeCoin());
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(2);
        StartCoroutine(makeBot());
        //StartCoroutine(makeCoin());
    }
}
