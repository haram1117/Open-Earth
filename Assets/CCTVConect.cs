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

    bool isOn=false;
    public static int CCTV_Use_Count;

    public void CCTV_on()
    {
        moniter.GetComponent<Renderer>().material = moniter_on;
        Debug.Log("难咙");
        isOn = true;
    }

    public void CCTV_off()
    {
        moniter.GetComponent<Renderer>().material = moniter_off;
        Debug.Log("波咙");
        isOn = false;
    }
    public void CCTV_1()
    {
        if (isOn)
        {
            moniter.GetComponent<Renderer>().material = CCTV1;
            Debug.Log("cctv1 难咙");
        }
        
    }
    public void CCTV_2()
    {
        if (isOn)
        {
            moniter.GetComponent<Renderer>().material = CCTV2;
            Debug.Log("cctv2 难咙");
        }
    }
    public void CCTV_3()
    {
        if (isOn)
        {
            moniter.GetComponent<Renderer>().material = CCTV3;
            Debug.Log("cctv3 难咙");
        }
    }
    public void CCTV_4()
    {
        if (isOn)
        {
            moniter.GetComponent<Renderer>().material = CCTV4;
            Debug.Log("cctv4 难咙");
        }
    }
    public void CCTV_5()
    {
        if (isOn)
        {
            moniter.GetComponent<Renderer>().material = CCTV5;
            Debug.Log("cctv5 难咙");
        }
    }
    public void CCTV_6()
    {
        if (isOn)
        {
            moniter.GetComponent<Renderer>().material = CCTV6;
            Debug.Log("cctv6 难咙");
        }
    }
    public void CCTV_7()
    {
        if (isOn)
        {
            moniter.GetComponent<Renderer>().material = CCTV7;
            Debug.Log("cctv7 难咙");
        }
    }
    public void CCTV_8()
    {
        if (isOn)
        {
            moniter.GetComponent<Renderer>().material = CCTV8;
            Debug.Log("cctv8 难咙");
        }
    }
    public void CCTV_9()
    {
        if (isOn)
        {
            moniter.GetComponent<Renderer>().material = CCTV9;
            Debug.Log("cctv9 难咙");
        }
    }
}
