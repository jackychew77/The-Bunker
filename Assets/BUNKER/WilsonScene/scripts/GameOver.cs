using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public Text surviveResultUI;
    public void Start()
    {
        surviveResultUI.text = "Survive Time: " + survivalTimer.surviveTime + " s";
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3 ) ;
    }
}
