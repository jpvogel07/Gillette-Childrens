using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
    private PlayerMovement movement;

    public int KeyNum;
    //public text pop up

    private void Start()
    {
        movement = GameObject.Find("mouse")?.GetComponent<PlayerMovement>();
    }
    public void giveItem()
    {
        if (movement!=null)
        {
            movement.keys[KeyNum] = true;
            Debug.Log(KeyNum);
            Debug.Log(movement.keys[KeyNum]);
            this.gameObject.SetActive(false);
            //create key item pop up now
        }
    }
}
