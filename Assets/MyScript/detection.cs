using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detection : MonoBehaviour
{
    public Material green, red;
    public Transform mainChar;
    public GameObject[] detector;
    public GameObject currentD;
    public static int agentAtArea;
    // Use this for initialization
    void Start()
    {
        seperateDetector();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "mainChar")
        {
            Debug.Log("collided with red button");
            currentD.GetComponent<MeshRenderer>().material = green;
            for(int i = 0;i<6;i++)
            {
                if(currentD != detector[i])
                {
                    detector[i].GetComponent<MeshRenderer>().material = red;
                }
                else
                {
                    agentAtArea = i;
                }
            }

        }
            //agentIsHere = false;
    }

    private void seperateDetector()
    {
        if (gameObject.name == "d0")
        {
            currentD = detector[0];
        }
        if (gameObject.name == "d1")
        {
            currentD = detector[1];
        }
        if (gameObject.name == "d2")
        {
            currentD = detector[2];
        }
        if (gameObject.name == "d3")
        {
            currentD = detector[3];
        }
        if (gameObject.name == "d4")
        {
            currentD = detector[4];
        }
        if (gameObject.name == "d5")
        {
            currentD = detector[5];
        }
    }
}
