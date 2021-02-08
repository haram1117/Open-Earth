using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attackManager : MonoBehaviour
{
    public Image PlayerHP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void attacked()
    {
        Debug.Log("공격당했어..");
        PlayerHP.fillAmount -= 0.1f;
    }
}
