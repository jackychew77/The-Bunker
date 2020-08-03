using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class mainCharScript : MonoBehaviour {

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "tankAtk")
        {
            //Debug.Log("Attacked by Melee");
            Destroy(other.gameObject);
            HealthBar.health -= 10; //collided
            checkIfDie();
        }
        if (other.tag == "parasiteAtk")
        {
            //Debug.Log("Attacked by Parasite");
            Destroy(other.gameObject);
            HealthBar.health -= 1; //collided
            checkIfDie();
        }
        if (other.tag == "rangedAtk")
        {
            //Debug.Log("Attacked by Spell");
            Destroy(other.gameObject);
            HealthBar.health -= 3; //collided
            checkIfDie();
        }
        if (other.tag == "healthpack")
        {
            Debug.Log("Picked Health");
            if((HealthBar.health+20) <= 100)
            {
                HealthBar.health += 20;
            }
            else
            {
                HealthBar.health = 100;
            }
            Destroy(other.gameObject);
        }
    }
    private void checkIfDie()
    {
        if(HealthBar.health <= 0)
        {
            Cursor.lockState = 0;
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
