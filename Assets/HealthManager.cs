using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class HealthManager : MonoBehaviour
{
   
    public PhotonView PV;
    public static Image HEALTH;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void Damaged()
    {
        
        HEALTH.fillAmount -= 0.1f;
    }


  



}
