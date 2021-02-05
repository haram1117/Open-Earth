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

    //Team 설정
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
        Debug.Log("방설정");

    }

    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("연결");
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("마스터서버연결");
        JoinLobby();
    }

    public void JoinLobby()
    {
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby() {

        TitlePanel.SetActive(false);
        print("로비접속완료");
        
        
    }
    
    public void Play()
    {   PhotonNetwork.LocalPlayer.NickName = NicknameInput.text;
        //Debug.Log(PhotonNetwork.LocalPlayer.NickName);
        JoinOrCreateRoom();
    }
    // Update is called once per frame
    public void JoinOrCreateRoom() {
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 12 }, null);
        Debug.Log("룸접속");
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
            print("현재 방 이름 : " + PhotonNetwork.CurrentRoom.Name);
            print("현재 방 인원수 : " + PhotonNetwork.CurrentRoom.PlayerCount);
            print("현재 방 최대인원수 : " + PhotonNetwork.CurrentRoom.MaxPlayers);
            print("플레이어 리스트 길이"+PhotonNetwork.PlayerList.Length);
            string playerStr = "방에 있는 플레이어 목록 : ";
            for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++) playerStr += PhotonNetwork.PlayerList[i].NickName + ", ";
            print(playerStr);
        }
        else
        {
            print("접속한 인원 수 : " + PhotonNetwork.CountOfPlayers);
            print("방 개수 : " + PhotonNetwork.CountOfRooms);
            print("모든 방에 있는 인원 수 : " + PhotonNetwork.CountOfPlayersInRooms);
            print("로비에 있는지? : " + PhotonNetwork.InLobby);
            print("연결됐는지? : " + PhotonNetwork.IsConnected);
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
