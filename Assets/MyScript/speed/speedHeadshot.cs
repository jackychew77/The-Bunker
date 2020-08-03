using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedHeadshot : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet")
        {
            //Debug.Log("Head Collided");
            GetComponent<speedScript>().headCollided();
            Destroy(other.gameObject);
        }
        if (other.tag == "shotgunBullet")
        {
            GetComponent<speedScript>().shotgunBulletCollided();
        }
        if (other.tag == "meleeBullet")
        {
            GetComponent<speedScript>().meleeBulletCollided();
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
