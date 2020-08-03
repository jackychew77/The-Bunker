using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class tankScript : MonoBehaviour {
    UnityEngine.AI.NavMeshAgent agent;
    Animator anim;
    public Transform tank;
    //int hp = 100;
    //public Text enemyHP;
    public GameObject tankAtk;
    private float hp = 150, fireRate = 2.67f, cooldown, atkRange = 2.5f, corpseTimer = 5.0f, detectionRange = 500.0f;

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
                anim.SetBool("atk", false);
            }
            else if (dist2hero < atkRange)
            {
                anim.SetBool("run", false);
                agent.destination = agent.transform.position;
                anim.SetBool("atk", true);
                meleeAtk();
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
            hp -= 10; //collide body
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
        hp -= 50;
        checkIfDie();
    }
    public void torsoCollided()
    {
        hp -= 50;
        checkIfDie();
    }
    public void shotgunBulletCollided() //shotgun overall damage
    {
        hp -= 15;
        checkIfDie();
    }
    public void meleeBulletCollided()   //melee overall damage
    {
        hp -= 70;
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
    public void meleeAtk()
    {
        if (cooldown == fireRate)
        {
            //Debug.Log("Melee Shoot!");
            Vector3 relativePos = GameObject.FindWithTag("mainChar").transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(relativePos);
            GameObject clone = Instantiate(tankAtk, tank.position, tank.rotation);
            clone.GetComponent<Rigidbody>().velocity = clone.transform.forward * 65.0f;
        }
        cooldown -= Time.deltaTime;
        if (cooldown <= 0.0f)
        {
            cooldown = fireRate;
        }
    }
}
