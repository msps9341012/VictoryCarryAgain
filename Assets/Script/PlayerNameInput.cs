using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;



public class PlayerNameInput : MonoBehaviour {

	// Use this for initialization
	[SerializeField] private GameObject findOpponentPanel = null;
	[SerializeField] private GameObject inputPanel = null;
	[SerializeField] private InputField nameInputField=null;
	[SerializeField] private Button continueButton = null;
	private const string PlayerPrefsNameKey = "PlayerName";
	void Start () {
		SetupInputField();
	}
	private void SetupInputField(){
        if (!PlayerPrefs.HasKey(PlayerPrefsNameKey)) { return; }
        //
        string defaultName = PlayerPrefs.GetString(PlayerPrefsNameKey);

        nameInputField.text = defaultName;

        SetPlayerName(defaultName);
	}

	public void SetPlayerName(string text){
		//有輸入文字才能按continue
		continueButton.interactable = !string.IsNullOrEmpty(nameInputField.text);

	}
	public void SavePlayerName(){
		//記錄玩家上一次輸入的
        string playerName = nameInputField.text;

        PhotonNetwork.NickName = playerName;

        PlayerPrefs.SetString(PlayerPrefsNameKey, playerName);
        findOpponentPanel.SetActive(true);
        inputPanel.SetActive(false);
		
	}
}
