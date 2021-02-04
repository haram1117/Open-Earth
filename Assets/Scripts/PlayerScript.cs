using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.EventSystems;

public class PlayerScript : MonoBehaviour { 

    [SerializeField] GameObject cameraHolder = null;
    [SerializeField] float mouseSensitivity = 1f, sprintSpeed = 1f, walkSpeed = 1f, smoothTime = 1f;

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


    void Awake()
    {

    }

    void Start()
    {
        if (!PV.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
            Destroy(RB); //�̰� ���ְ� fixed Update���ٰ� �߰������ �� �𸣰ھ�.. �ΰ��� ���������ΰ���

        }

    }

    void Update()
    {
        if (PV.IsMine)
        {
            Look();
            Move();
        }
        //Debug.Log("�÷��̾� ��ġ" + transform.position);

    }

    void Look()
    {
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensitivity); //y�� ȸ��
        verticalLookRotation += Input.GetAxisRaw("Mouse Y") * mouseSensitivity;//�ٽôٽôٽôٽ�
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);//�ִ� �ּ� ����

        cameraHolder.transform.localEulerAngles = Vector3.left * verticalLookRotation;


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


    public void SetGroundedState(bool _grounded)
    {
        Debug.Log("�ٴڻ��� ����!");
        grounded = _grounded;
        Debug.Log(grounded);
    }

    void FixedUpdate() //ã�ƺ���
    {
        if (!PV.IsMine)
        {
            return;
        }
        RB.MovePosition(RB.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }

}
