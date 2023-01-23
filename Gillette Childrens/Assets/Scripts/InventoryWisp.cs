using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWisp : MonoBehaviour
{
    public GameObject start;
    public GameObject end;
    public Sprite image;
    private float rate, speed=820;
    private Vector3 origin;

    private void OnEnable()
    {
        origin = transform.localScale;
        end = GameObject.Find("Jade");
        start = GameObject.Find("inventory");
        //this.GetComponent<Image>().sprite = image;
        this.GetComponent<Image>().sprite = GameObject.Find("mouse").GetComponent<PlayerMovement>().InventoryPics[end.GetComponent<Jade>().JadeSpeech.stage];
        this.GetComponent<Image>().color = Color.white;
        this.transform.position = start.transform.position;
        //StartCoroutine(travelTime());
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
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
