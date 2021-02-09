using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class HealthManager : MonoBehaviour
{
   float hp;
    private Transform healthbar;
    public PhotonView PV;
    public Image HEALTH;
    // Start is called before the first frame update
    void Start()
    {
        //체력 기준 100
        if (PV.IsMine)
        {   
            hp = 100f;
            healthbar = HEALTH.transform;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Damaged()
    {
        
        Debug.Log("남은체력:"+hp);
        HEALTH.fillAmount -= 0.1f;
    }
}
