using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class rangedScript : MonoBehaviour {
    UnityEngine.AI.NavMeshAgent agent;
    Animator anim;
    public Transform rangedMob;
    public GameObject rangedAtk;
    private float hp = 50, fireRate = 1.40f, cooldown, atkRange = 5.0f, detectionRange = 500.0f, corpseTimer = 5.0f;
    private bool alive;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        anim.SetBool("died", false);
        alive = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (alive == true)
        {
            float dist2hero = Vector3.Distance(transform.position, GameObject.FindWithTag("mainChar").transform.position);
            if (dist2hero < detectionRange && dist2hero > atkRange)
            {
                agent.destination = GameObject.FindWithTag("mainChar").transform.position;
                anim.SetBool("run", true);
                anim.SetBool("cast", false);
            }
            else if (dist2hero < atkRange)
            {
                anim.SetBool("run", false);
                agent.destination = agent.transform.position;
                ranged();
            }
        }
        if (alive == false)
        {
            corpseTimer -= Time.deltaTime;
            if (corpseTimer <= 0.0f)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet")
        {
            //Debug.Log("Collided with body");
            Destroy(other.gameObject);
            hp -= 15;
            checkIfDie();
        }
        if (other.tag == "shotgunBullet")
        {
            shotgunBulletCollided();
        }
        if (other.tag == "meleeBullet")
        {
            meleeBulletCollided();
        }
    }
    public void headCollided()
    {
        hp = 0;
        checkIfDie();
    }
    public void torsoCollided()
    {
        hp -= 10;
        checkIfDie();
    }
    public void shotgunBulletCollided()
    {
        hp -= 10;
        checkIfDie();
    }
    public void meleeBulletCollided()
    {
        hp -= 30;
        checkIfDie();
    }
    private void checkIfDie()
    {
        if (hp <= 0)
        {
            anim.SetBool("died", true);
            agent.isStopped = true;
            alive = false;
        }
    }
    public void ranged()
    {
        if (cooldown == fireRate)
        {
            //Debug.Log("Ranged Shoot!");
            anim.SetBool("cast", true);
            Vector3 relativePos = GameObject.FindWithTag("mainChar").transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(relativePos);
            GameObject clone = Instantiate(rangedAtk, rangedMob.position, rangedMob.rotation);
            clone.GetComponent<Rigidbody>().velocity = clone.transform.forward * 15.0f;
        }
        cooldown -= Time.deltaTime;
        if (cooldown <= 0.0f)
        {
            cooldown = fireRate;
        }
    }
}
