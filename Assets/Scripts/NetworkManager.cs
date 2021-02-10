using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks, IPunObservable
{
    public GameObject Player;
    GameObject[] point;

    int teamindex;
    void Start()
    {
        DontDestroyOnLoad(Player);
        if (PhotonNetwork.InRoom)
        {
            // CALLED ONLY IF WE DID CAME FROM ANOTHER SCENE
            PhotonNetwork.IsMessageQueueRunning = true;
            //CreatePlayerObject();
            
        }
        
    }
   void OnLevelWasLoaded(int level)
    {
        
        Debug.Log("ÅÂ¾î³µ´Ù");
        point = GameObject.FindGameObjectsWithTag("SpawnPoint");
        Debug.Log("ÆÀ"+ teamindex);
        if ((int)PhotonNetwork.LocalPlayer.CustomProperties["Team"] == 1)
        {
            chooseJob();
        }
        else if ((int)PhotonNetwork.LocalPlayer.CustomProperties["Team"] == 2)
        {
            chooseJob();
        }
        else if ((int)PhotonNetwork.LocalPlayer.CustomProperties["Team"] == 3)
        {
            chooseJob();
        }
        Debug.Log(point[0].transform.position);
        Debug.Log(point[1].transform.position);
        Debug.Log(point[2].transform.position);
    }


    void chooseJob()
    {
        if (LoginManager.jobnumber == 1) born_Hunter();
        else if (LoginManager.jobnumber == 2) born_Bomber();
        else if (LoginManager.jobnumber == 3) born_Healer();
        else if (LoginManager.jobnumber == 4) born_Deliver();
        else if (LoginManager.jobnumber == 5) born_Rader();
    }
    void born_Hunter()
    {
        PhotonNetwork.Instantiate("Player_Hunter", point[(int)PhotonNetwork.LocalPlayer.CustomProperties["Team"] - 1].transform.position, point[(int)PhotonNetwork.LocalPlayer.CustomProperties["Team"] - 1].transform.rotation);
    }
    void born_Bomber()
    {
        PhotonNetwork.Instantiate("Player_Bomb", point[(int)PhotonNetwork.LocalPlayer.CustomProperties["Team"] - 1].transform.position, point[(int)PhotonNetwork.LocalPlayer.CustomProperties["Team"] - 1].transform.rotation);
    }
    void born_Healer()
    {
        PhotonNetwork.Instantiate("Player_Healer", point[(int)PhotonNetwork.LocalPlayer.CustomProperties["Team"] - 1].transform.position, point[(int)PhotonNetwork.LocalPlayer.CustomProperties["Team"] - 1].transform.rotation);
    }
    void born_Deliver()
    {
        PhotonNetwork.Instantiate("Player_Deliver", point[(int)PhotonNetwork.LocalPlayer.CustomProperties["Team"] - 1].transform.position, point[(int)PhotonNetwork.LocalPlayer.CustomProperties["Team"] - 1].transform.rotation);
    }
    void born_Rader()
    {
        PhotonNetwork.Instantiate("Player_Rader", point[(int)PhotonNetwork.LocalPlayer.CustomProperties["Team"] - 1].transform.position, point[(int)PhotonNetwork.LocalPlayer.CustomProperties["Team"] - 1].transform.rotation);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }
}
