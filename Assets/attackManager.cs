using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Photon.Realtime;
public class attackManager : MonoBehaviourPunCallbacks, IDamageable
{
    public Animator AN;
    public AudioSource audioSource;
    public AudioClip shootsound;
    [SerializeField] Camera cam;
    public Image PlayerHP;

    public PhotonView PV;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        Shoot();
    }
    void Shoot()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {


            Ray raycast = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f)); //확인
            raycast.origin = cam.transform.position;
            if (Physics.Raycast(raycast, out RaycastHit hit))
            {
                Debug.Log(hit.collider.gameObject.name + "를 쐈다");

                if (hit.collider.gameObject.tag == "Player")
                {
                    Debug.Log(hit.collider.gameObject.name);
                   //hit.collider.gameObject.GetComponent<PlayerScript>().PlayerHP.fillAmount -= 0.1f;
                    hit.collider.gameObject.GetComponent<IDamageable>()?.TakeDamage(10f);
                }
            }
            AN.SetTrigger("shoot");
            Debug.Log("쏜다");
            audioSource.PlayOneShot(shootsound);
            Debug.DrawRay(raycast.origin, raycast.direction * 1000f, Color.red, 5f);


        }
    }
    public void TakeDamage(float damage)
    {
        PV.RPC("RPC_TakeDamage", RpcTarget.AllBufferedViaServer, damage);
    }

    [PunRPC]
    void RPC_TakeDamage(float damage)
    {
        if (!PV.IsMine) return;
        else
        {

            PlayerHP.fillAmount -= 0.1f;


        }
        //당하는 쪽만 실행 


        /*if (PlayerHP.fillAmount <= 0)
        {
            Die();
        }*/
    }
    public void attacked()
    {
        Debug.Log("공격당했어..");
        PlayerHP.fillAmount -= 0.1f;
    }
}
