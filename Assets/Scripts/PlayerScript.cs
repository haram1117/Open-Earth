using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Photon.Realtime;

public class PlayerScript : MonoBehaviourPunCallbacks, IPunObservable{ 

    [SerializeField] GameObject cameraHolder = null;
    [SerializeField] float mouseSensitivity = 1f, sprintSpeed = 1f, walkSpeed = 1f, smoothTime = 1f;
    [SerializeField] Camera cam;
    float verticalLookRotation;
    bool grounded;
    Vector3 smoothMoveVelocity;
    Vector3 moveAmount;
    public PhotonView PV;
    public Animator AN;
    public Rigidbody RB;

    RectTransform joystickholder;
    RectTransform joystick;

    float joystickradius;
    Vector2 fingerposition;
    bool TouchScreen;
    Vector2 touchvector;

    public Image PlayerHP;
    public float player_hp = 100;

    public AudioSource audioSource;
    public AudioClip shootsound;
    public AudioClip footsound;

    public GameObject Myitem;
    GameObject CurrentBullet;
    bool shootable;

    void Awake()
    {
        
    }

    void Start()
    {
        if (!PV.IsMine)
        {
            audioSource = gameObject.GetComponent<AudioSource>();
            //   shootsound = Resources.Load<AudioClip>("shoot");
            Destroy(GetComponentInChildren<Camera>().gameObject);
            Destroy(GetComponentInChildren<Canvas>().gameObject);
            Destroy(RB); //이거 해주고 fixed Update에다가 추가해줘야 됨 모르겠어.. 두개의 물리엔진인가봄
            Destroy(GetComponent<AudioListener>());
        }
        //PlayerHP.fillAmount = 1;

    }

    void Update()
    {
        if (PV.IsMine)
        {
            Look();
            Move();
            Jump();
            Shoot();
        }
        //Debug.Log("플레이어 위치" + transform.position);

    }

    void Look()
    {
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensitivity); //y축 회전
        verticalLookRotation += Input.GetAxisRaw("Mouse Y") * mouseSensitivity;//다시다시다시다시
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);//최대 최소 설정

        cameraHolder.transform.localEulerAngles = Vector3.left * verticalLookRotation;


    }
    public void Move_Sound()
    {
        audioSource.clip = footsound;
        audioSource.Play();
    }

    void Move()
    {

        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        moveAmount = Vector3.SmoothDamp(moveAmount, moveDir * (Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed), ref smoothMoveVelocity, smoothTime);
        
        if (moveDir != Vector3.zero)
        {
            AN.SetBool("walk", true);
        }
        else
        {
            AN.SetBool("walk", false);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RB.AddForce(Vector3.up*8, ForceMode.Impulse);
            Debug.Log("점프");
        }
        
    }
    void Shoot()
     {  Transform[] allitem = Myitem.GetComponentsInChildren<Transform>(true);
           for (int i = 0; i < allitem.Length; i++)
           {
            if (allitem[i].gameObject.name == "bullet")
            {
                CurrentBullet = allitem[i].gameObject;
                shootable = true;
                break;
                
                    }
            else
            {
                shootable = false;
            }
            Debug.Log(allitem[i].gameObject.name); 
                }

        
            //Debug.Log("자식"+Myitem.transform.GetChild(0).gameObject.name);
        if (Input.GetMouseButtonDown(0) == true & shootable)
        {
            
            
            Ray raycast = cam.ViewportPointToRay(new Vector3(0.5f,0.5f)); //확인
            raycast.origin = cam.transform.position;
            if(Physics.Raycast(raycast,out RaycastHit hit))
            {
                Debug.Log(hit.collider.gameObject.name+"를 쐈다");

                if (hit.collider.gameObject.tag == "Player")
                {
                    Debug.Log(hit.collider.gameObject.name);
                    hit.collider.gameObject.GetPhotonView().RPC("RPC_TakeDamage", RpcTarget.All);
                }
            }
            AN.SetTrigger("shoot");
            Debug.Log("쏜다");
            
            CurrentBullet.GetComponent<mybullet>().Use_Bullet();
            audioSource.PlayOneShot(shootsound);
            Debug.DrawRay(raycast.origin, raycast.direction * 1000f, Color.red, 5f);

     
        }
        else
        {
            Debug.Log("총알 없다");
        }
    }

    public void attacked(GameObject gameObject)
    {
        gameObject.GetComponent<PlayerScript>().PlayerHP.fillAmount -= 0.1f;
    }

    public void SetGroundedState(bool _grounded)
    {
        //Debug.Log("바닥상태 변경!");
        grounded = _grounded;
        //Debug.Log(grounded);
    }

    void FixedUpdate() //찾아보자
    {
        if (!PV.IsMine)
        {
            return;
        }
        RB.MovePosition(RB.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }


    [PunRPC]
    private void RPC_TakeDamage()
    {
        if (!PV.IsMine) return;
        else
        {
            Debug.Log("당했다");
            PlayerHP.GetComponent<HealthManager>().Damaged();
            

        }
        //당하는 쪽만 실행 
        

        /*if (PlayerHP.fillAmount <= 0)
        {
            Die();
        }*/
    }

    public void TakePortion()
    {
        PV.RPC("RPC_TakePortion", RpcTarget.All);
    }

    [PunRPC]

    void RPC_TakePortion()
    {
        if (!PV.IsMine) return;
        else
        {
            PlayerHP.fillAmount += 0.1f;
        }
    }

    void Die()
    {
        Debug.Log("나죽어..");
        PhotonNetwork.Destroy(PV);
    }
    
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {/*
        if (stream.IsWriting)
        {
            stream.SendNext(PlayerHP.fillAmount);
        }
        else
        {
            PlayerHP.fillAmount = (float)stream.ReceiveNext();
        }*/
    }
}
