using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrtA_MatchActive : MonoBehaviour
{
    public GameObject Match;

    void Update()
    {
        if (Match == null) {
            this.gameObject.SetActive(false);
        }
        else if (Match.activeSelf == false) { 
            this.gameObject.SetActive(false); 
        }
    }
}
