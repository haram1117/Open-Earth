using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks, IPunObservable
{

    void Start()
    {
        Debug.Log("�¾��");
        PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);

    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }
}
