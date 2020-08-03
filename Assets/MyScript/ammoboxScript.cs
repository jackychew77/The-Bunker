using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoboxScript : MonoBehaviour {
    private float objectLife = 20.0f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (objectLife <= 0.0f)
        {
            Destroy(gameObject);
        }
        objectLife -= Time.deltaTime;
    }
}
