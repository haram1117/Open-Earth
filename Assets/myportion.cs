using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class myportion : MonoBehaviour
{
    public static int portionLeft=1;
   public Image HEALTH;

    void Start()
    {
        
    }
    private void Update()
    {
    }

    public void Use_Portion()
    {
        HEALTH.fillAmount += 0.1f;
        portionLeft = 0;
        Destroy(gameObject);
    }

}
