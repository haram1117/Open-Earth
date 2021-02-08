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
            PhotonNetwork.Instantiate("Player", point[(int)PhotonNetwork.LocalPlayer.CustomProperties["Team"] - 1].transform.position, point[(int)PhotonNetwork.LocalPlayer.CustomProperties["Team"] - 1].transform.rotation);
        }
        else if ((int)PhotonNetwork.LocalPlayer.CustomProperties["Team"] == 2)
        {
            PhotonNetwork.Instantiate("Player", point[(int)PhotonNetwork.LocalPlayer.CustomProperties["Team"] - 1].transform.position, point[(int)PhotonNetwork.LocalPlayer.CustomProperties["Team"] - 1].transform.rotation);
        }
        Debug.Log(point[0].transform.position);
        Debug.Log(point[1].transform.position);
        Debug.Log(point[2].transform.position);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }
}
