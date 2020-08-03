using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    public Button playNowBtn;
    public Button okBtn;
    public InputField playerName;
	// Use this for initialization
	void Start () {
        playNowBtn.onClick.AddListener(startBtnClicked);
        okBtn.onClick.AddListener(okBtnClicked);
	}

    void startBtnClicked()
    {
        Debug.Log("EXPLODED");
        SceneManager.LoadScene("World0.0");
    }
	
    void okBtnClicked()
    {
        Debug.Log("Your name is : "+ playerName.text);
        StartCoroutine(updateDB());     //to function IEnumerator
    }

    IEnumerator updateDB()      //connecting to browser
    {
        string player_name = "'"+playerName.text+"'";
        string url = "http://localhost/fps/index.php" + player_name;
        WWW www = new WWW(url);
        yield return www;
        Debug.Log(www.text);
    }
	// Update is called once per frame
	void Update ()
    {

	}
}
