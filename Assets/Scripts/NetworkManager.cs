using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks, IPunObservable
{
    public InputField IDInput;
  
    public override void OnJoinedRoom()
    {
        Spawn();
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void Spawn()
    {
        Debug.Log("ÅÂ¾î³µ´Ù");
<<<<<<< Updated upstream
        PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);

=======
        point = GameObject.FindGameObjectsWithTag("SpawnPoint");
        Debug.Log("ÆÀ"+ teamindex);
        if ((int)PhotonNetwork.LocalPlayer.CustomProperties["Team"] == 1)
        {
            PhotonNetwork.Instantiate("Player_Deliver", point[(int)PhotonNetwork.LocalPlayer.CustomProperties["Team"] - 1].transform.position, point[(int)PhotonNetwork.LocalPlayer.CustomProperties["Team"] - 1].transform.rotation);
        }
        else if ((int)PhotonNetwork.LocalPlayer.CustomProperties["Team"] == 2)
        {
            PhotonNetwork.Instantiate("Player_Deliver", point[(int)PhotonNetwork.LocalPlayer.CustomProperties["Team"] - 1].transform.position, point[(int)PhotonNetwork.LocalPlayer.CustomProperties["Team"] - 1].transform.rotation);
        }
        Debug.Log(point[0].transform.position);
        Debug.Log(point[1].transform.position);
        Debug.Log(point[2].transform.position);
>>>>>>> Stashed changes
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }
}
