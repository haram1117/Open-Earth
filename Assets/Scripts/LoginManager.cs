using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class LoginManager : MonoBehaviourPunCallbacks, IPunObservable
{
    public GameObject TitlePanel;
    public GameObject PlayerPanel;
    public InputField NicknameInput;

    //Team ����
    public GameObject Team1;
    public GameObject Team2;
    public GameObject Team3;

    GameObject player;

    int whichteam;



    void Awake()
    {

        Screen.SetResolution(1920, 1080, true);
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
        Debug.Log("�����ͼ�������");
        JoinLobby();
    }

    public void JoinLobby()
    {
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby() {

        TitlePanel.SetActive(false);
        print("�κ����ӿϷ�");
        
        
    }
    
    public void Play()
    {   PhotonNetwork.LocalPlayer.NickName = NicknameInput.text;
        //Debug.Log(PhotonNetwork.LocalPlayer.NickName);
        JoinOrCreateRoom();
    }
    // Update is called once per frame
    public void JoinOrCreateRoom() {
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 12 }, null);
        Debug.Log("������");
        PlayerPanel.SetActive(false);
    }
    public void MatchTeam()
    {
        for (int i=0; i<PhotonNetwork.PlayerList.Length; i++)
        {
            print(PhotonNetwork.PlayerList[i].NickName);
            if (i % 3 == 0)
            {
                player=PhotonNetwork.Instantiate("PlayerKit", Vector3.zero, Quaternion.identity);
                player.transform.SetParent(Team1.transform);
                player.GetComponent<UnityEngine.UI.Text>().text = PhotonNetwork.PlayerList[i].NickName;
                whichteam = 1;
            }
            else if (i % 3 == 1)
            {
                player = PhotonNetwork.Instantiate("PlayerKit", Vector3.zero, Quaternion.identity);
                player.transform.SetParent(Team2.transform);
                player.GetComponent<UnityEngine.UI.Text>().text = PhotonNetwork.PlayerList[i].NickName;
                whichteam = 2;
            }
            else
            {
                player = PhotonNetwork.Instantiate("PlayerKit", Vector3.zero, Quaternion.identity);
                player.transform.SetParent(Team3.transform);
                player.GetComponent<UnityEngine.UI.Text>().text = PhotonNetwork.PlayerList[i].NickName;
                whichteam = 3;
            }
        }
    }

    public void Info()
    {
        if (PhotonNetwork.InRoom)
        {
            print(PhotonNetwork.LocalPlayer.NickName);
            print("���� �� �̸� : " + PhotonNetwork.CurrentRoom.Name);
            print("���� �� �ο��� : " + PhotonNetwork.CurrentRoom.PlayerCount);
            print("���� �� �ִ��ο��� : " + PhotonNetwork.CurrentRoom.MaxPlayers);
            print("�÷��̾� ����Ʈ ����"+PhotonNetwork.PlayerList.Length);
            string playerStr = "�濡 �ִ� �÷��̾� ��� : ";
            for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++) playerStr += PhotonNetwork.PlayerList[i].NickName + ", ";
            print(playerStr);
        }
        else
        {
            print("������ �ο� �� : " + PhotonNetwork.CountOfPlayers);
            print("�� ���� : " + PhotonNetwork.CountOfRooms);
            print("��� �濡 �ִ� �ο� �� : " + PhotonNetwork.CountOfPlayersInRooms);
            print("�κ� �ִ���? : " + PhotonNetwork.InLobby);
            print("����ƴ���? : " + PhotonNetwork.IsConnected);
        }
    }
    public void Ready()
    {
        PhotonNetwork.LoadLevel(1);
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }
}
