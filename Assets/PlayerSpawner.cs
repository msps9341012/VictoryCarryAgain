using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Cinemachine;
using Photon.Realtime;



public class PlayerSpawner : MonoBehaviourPun {

    [SerializeField] private GameObject playerPrefab1 = null;
    [SerializeField] private GameObject playerPrefab2 = null;
    [SerializeField] private CinemachineFreeLook playerCamera = null;

    private void Start()
    {	GameObject player=null;
    	if (PhotonNetwork.IsMasterClient){ //photon 中一個為master 其餘為slave
            //對應生成不同的角色
    		player = PhotonNetwork.Instantiate(playerPrefab1.name, Vector3.zero, Quaternion.identity);

    	}
    	else{
    		player = PhotonNetwork.Instantiate(playerPrefab2.name, Vector3.zero, Quaternion.identity);
    	}
    	playerCamera.Follow = player.transform;
        playerCamera.LookAt = player.transform;

    }
    
}