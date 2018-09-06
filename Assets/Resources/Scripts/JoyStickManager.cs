using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStickManager : MonoBehaviour,IPointerDownHandler,IPointerUpHandler {

    public PlayerController player;

    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if(this.gameObject.name == "LeftButton")
        {
            player.btnLeft = true;
        }else if(this.gameObject.name == "RightButton")
        {
            player.btnRight = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (this.gameObject.name == "LeftButton")
        {
            player.btnLeft = false;

        }
        else if (this.gameObject.name == "RightButton")
        {
            player.btnRight = false;
        }
    }

}
