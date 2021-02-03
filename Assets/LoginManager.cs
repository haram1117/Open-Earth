using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class LoginManager : MonoBehaviourPunCallbacks, IPunObservable
{
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
        PhotonNetwork.LoadLevel(1);

    }
    public override void OnJoinedRoom()
    {
        
    }
    // Update is called once per frame
   

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }
}
