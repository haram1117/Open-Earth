using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackPackManager : MonoBehaviour
{
    public GameObject myItem;
    public GameObject BulletPrefab;
    public GameObject PortionPrefab;

    GameObject mybullet;
    GameObject myportion;

    int itemCount;

    public void AddBullet()
    {
        if (itemCount == 10)
        {
            Debug.Log("²ËÃ¡¾î");
            return;
        }
        else
        {
            mybullet = Instantiate(BulletPrefab);
            mybullet.transform.SetParent(myItem.transform);
        }


        
    }

    public void AddPortion()
    {
        if (itemCount == 10)
        {
            Debug.Log("²ËÃ¡¾î");
            return;
        }
        else
        {
            myportion = Instantiate(PortionPrefab);
            myportion.transform.SetParent(myItem.transform);
        }
        
    }

    private void Update()
    {
        itemCount = myItem.transform.childCount;
    }


}
