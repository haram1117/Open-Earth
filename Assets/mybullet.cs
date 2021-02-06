using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class mybullet : MonoBehaviour
{

    int bulletLeft=10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Delete()
    {
        Destroy(gameObject);
    }
}
