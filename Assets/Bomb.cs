using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject bomb;
    public GameObject explosion;
    public GameObject explosioninstance;
    bool explosioncheck=false;

    private void Update()
    {
        if (explosioncheck == true)
        {
            Invoke("Destroyexplosion", 2);
        }
        
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            Invoke("Destroybomb", 2);
            explosioninstance=Instantiate(explosion, bomb.transform.position, Quaternion.identity);
            explosioncheck = true;
        }
    }

    

    void Destroybomb()
    {
        Destroy(bomb);
    }

    void Destroyexplosion()
    {
        Destroy(explosioninstance);
    }
}
