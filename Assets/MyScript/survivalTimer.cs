using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class survivalTimer : MonoBehaviour {
    public Text surviveTimeUI;
    public static float surviveTime = 0.0f;

    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
    }
    // Use this for initialization
    void Start () {

        
    }
	
	// Update is called once per frame
	void Update () {
        if (HealthBar.health > 0)
        {
            surviveTime += Time.deltaTime;
            surviveTime = Mathf.Round(surviveTime * 100f) / 100f;
            surviveTimeUI.text = "Survive Time: " + surviveTime + "s";
        }
    }
}
