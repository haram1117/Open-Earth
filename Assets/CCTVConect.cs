using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTVConect : MonoBehaviour
{
    public GameObject moniter;
    public Material moniter_on;
    public Material moniter_off;

    public Material CCTV1;
    public Material CCTV2;
    public Material CCTV3;
    public Material CCTV4;
    public Material CCTV5;
    public Material CCTV6;
    public Material CCTV7;
    public Material CCTV8;
    public Material CCTV9;
    bool IsOn=false;


    public void CCTV_on()
    {
        moniter.GetComponent<Renderer>().material = moniter_on;
        Debug.Log("ÄÑÁü");
        IsOn = true;
    }

    public void CCTV_off()
    {
        moniter.GetComponent<Renderer>().material = moniter_off;
        Debug.Log("²¨Áü");
        IsOn = false;
    }
    public void CCTV_1()
    {
        if (IsOn)
        {
            moniter.GetComponent<Renderer>().material = CCTV1;
            Debug.Log("CCTV1");
        }
        
    }
    public void CCTV_2()
    {
        if (IsOn)
        {
            moniter.GetComponent<Renderer>().material = CCTV2;
            Debug.Log("CCTV2");
        }
    }
    public void CCTV_3()
    {
        if (IsOn)
        {
            moniter.GetComponent<Renderer>().material = CCTV3;
            Debug.Log("CCTV3");
        }
    }
    public void CCTV_4()
    {
        if (IsOn)
        {
            moniter.GetComponent<Renderer>().material = CCTV4;
            Debug.Log("CCTV4");
        }
    }
    public void CCTV_5()
    {
        if (IsOn)
        {
            moniter.GetComponent<Renderer>().material = CCTV5;
            Debug.Log("CCTV5");
        }
    }
    public void CCTV_6()
    {
        if (IsOn)
        {
            moniter.GetComponent<Renderer>().material = CCTV6;
            Debug.Log("CCTV6");
        }
    }
    public void CCTV_7()
    {
        if (IsOn)
        {
            moniter.GetComponent<Renderer>().material = CCTV7;
            Debug.Log("CCTV7");
        }
    }
    public void CCTV_8()
    {
        if (IsOn)
        {
            moniter.GetComponent<Renderer>().material = CCTV8;
            Debug.Log("CCTV8");
        }
    }
    public void CCTV_9()
    {
        if (IsOn)
        {
            moniter.GetComponent<Renderer>().material = CCTV9;
            Debug.Log("CCTV9");
        }
    }
}
