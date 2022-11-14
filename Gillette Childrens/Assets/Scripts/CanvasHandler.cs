using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasHandler : MonoBehaviour
{
    public Sprite RL;
    public Sprite Art;
    private bool check=false;
    public GameObject AR;

    private void Start()
    {
        AR = GameObject.Find("AR switch").gameObject;
        Art = this.GetComponent<Image>().sprite; //<-- does not grab source image from image component 
    }

    public void On()
    {
        this.gameObject.SetActive(true);
        AR.GetComponent<ARHandler>().scene = this.gameObject;
    }
    public void Off()
    {
        this.gameObject.SetActive(false);
    }

    public void ARHandler()
    {
        if (check)
        {
            this.GetComponent<Image>().sprite = Art;
            check = false;
        }
        else
        {
            this.GetComponent<Image>().sprite = RL;
            check = true;
        }
    }
}
