using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWisp : MonoBehaviour
{
    private GameObject start;
    private GameObject end;
    private Sprite image;
    private float rate, speed = 820;
    private Vector3 origin;

    private void OnEnable()
    {
        end = GameObject.Find("Jade");
        start = GameObject.Find("inventory");
        origin = start.transform.localScale;
        image = start.GetComponent<Image>().sprite;
        this.GetComponent<Image>().sprite = image;
        //this.GetComponent<Image>().sprite = GameObject.Find("mouse").GetComponent<PlayerMovement>().InventoryPics[end.GetComponent<Jade>().JadeSpeech.stage-1];
        this.GetComponent<Image>().color = Color.white;
        this.transform.position = start.transform.position;
        StartCoroutine(travelTime());
    }
    private void Update()
    {
        //travel to end
        this.transform.position = Vector2.MoveTowards(this.transform.position, end.transform.position, Time.deltaTime * speed);
        rate += Time.deltaTime * .7f;
        rate = Mathf.Clamp(rate, 0, 1);
        transform.localScale = Vector3.Slerp(origin, Vector3.zero, rate);
    }

    IEnumerator travelTime()
    {
        yield return new WaitForSeconds(3);
        end.GetComponent<DialogueTrigger>().secret = false;
        Destroy(this.gameObject);
    }
}
