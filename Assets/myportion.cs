using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class myportion : MonoBehaviour
{
    int portionLeft=1;

    private void Update()
    {
        if (portionLeft <= 0)
        {
            Delete();
        }
    }

    public void Delete()
    {
        Destroy(gameObject);
    }
}
