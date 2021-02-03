using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks, IPunObservable
{
    // Start is called before the first frame update
    public GameObject TitlePanel;
    public InputField IDInput;
    void Awake()
    {

        Screen.SetResolution(960, 540, false);
        PhotonNetwork.SendRate = 60;
        PhotonNetwork.SerializationRate = 30;
        Debug.Log("�漳��");

    }

    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("����");
    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.LocalPlayer.NickName = IDInput.text;
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 5 }, null);
        Debug.Log("�����");

    }
    public override void OnJoinedRoom()
    {
        TitlePanel.SetActive(false);
        Spawn();
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void Spawn()
    {
        Debug.Log("�¾��");
        PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);

    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }
}
