using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class MultiPlayerManager : MonoBehaviour
{

    [SerializeField] private InputField Username;
    [SerializeField] private InputField GameName;

    public void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Connected");
    }

    public void JoinGame()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 10;
        PhotonNetwork.JoinOrCreateRoom(GameName.text, roomOptions, TypedLobby.Default);
    }
    public void OnDisconnect()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel("Menu");
    }

    public void CreateGame() { PhotonNetwork.CreateRoom(GameName.text, new RoomOptions() { MaxPlayers = 10 }, null); }
    public void OnJoinedroom() { PhotonNetwork.LoadLevel("Game"); }

    public void SetUsername() { PhotonNetwork.NickName = Username.text; }


}
