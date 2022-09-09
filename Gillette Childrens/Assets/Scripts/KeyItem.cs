using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
    public PlayerMovement movement;

    public int KeyNum;

    private void Start()
    {
        movement = GameObject.Find("mouse")?.GetComponent<PlayerMovement>();
    }
    public void giveItem()
    {
        if (movement!=null)
        {
            movement.keys[KeyNum] = true;
            Debug.Log(movement.keys);
            this.gameObject.SetActive(false);
        }
    }
}
