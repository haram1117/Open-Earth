using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTVConect : MonoBehaviour
{
    public GameObject moniter;
    public Material moniter_on;
    public Material moniter_off;

    int channel;


    public void CCTV_on()
    {
        moniter.GetComponent<Renderer>().material = moniter_on;
        Debug.Log("ÄÑÁü");
    }

    public void CCTV_off()
    {
        moniter.GetComponent<Renderer>().material = moniter_off;
        Debug.Log("²¨Áü");
    }

}
