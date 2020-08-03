using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class multiplayer : MonoBehaviour {

    public InputField playerName, playerID, gameType;
    public Button createPlayerBtn;

    public void createplayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
;    }

	// Use this for initialization
	void Start ()
    {
        createPlayerBtn.onClick.AddListener(createBtnClicked);	
	}
	
	void createBtnClicked()
    {
        StartCoroutine(insertRecord());
    }


    IEnumerator insertRecord()
    {
        string player_name = "'" + playerName.text + "'";
        string player_id = playerID.text;
        string game_type = "'" + gameType.text + "'";
        string url = "http://localhost/db_fps_thebunker/insert.php?playerid=" + player_id + "&playername="+ player_name + "&gametype=" + game_type;
        WWW www = new WWW(url);
        yield return www;
    }
}
