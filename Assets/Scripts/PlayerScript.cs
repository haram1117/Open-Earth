using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviourPunCallbacks, IDamageable{ 

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


    public AudioSource audioSource;
    public AudioClip shootsound;
    public AudioClip footsound;

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
            Destroy(RB); //이거 해주고 fixed Update에다가 추가해줘야 됨 모르겠어.. 두개의 물리엔진인가봄
            Destroy(GetComponent<AudioListener>());
        }
        PlayerHP.fillAmount = 1;

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
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            
            
            Ray raycast = cam.ViewportPointToRay(new Vector3(0.5f,0.5f)); //확인
            raycast.origin = cam.transform.position;
            if(Physics.Raycast(raycast,out RaycastHit hit))
            {
                Debug.Log(hit.collider.gameObject.name+"를 쐈다");

                if (hit.collider.gameObject.tag == "Player")
                {
                    hit.collider.gameObject.GetComponent<IDamageable>()?.TakeDamage(10f);
                    
                }
            }
            AN.SetTrigger("shoot");
            Debug.Log("쏜다");
            audioSource.PlayOneShot(shootsound);
            Debug.DrawRay(raycast.origin, raycast.direction * 1000f, Color.red, 5f);

     
        }
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

    public void TakeDamage(float damage)
    {
        PV.RPC("RPC_TakeDamage", RpcTarget.All, damage);
    }

    [PunRPC]
    void RPC_TakeDamage(float damage)
    {
        if (!PV.IsMine) return;
        else
        {
            Debug.Log("take damage: " + damage);
            PlayerHP.fillAmount -= 0.1f;

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
}
