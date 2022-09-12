using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviorScript : MonoBehaviour
{
    public Transform coverPos;

    bool alive;
    int health = 100;
    float speed = 3;

    [SerializeField] Transform shootFrom;
    Transform targetRobot;
    Animator animator;
    LevelManager levelManager;


    private void Start()
    {
        
        targetRobot = GameObject.FindWithTag("Player").transform;
        alive = true;
        animator = GetComponent<Animator>();
        levelManager = LevelManager.instance;
        
    }

    private void Update()
    {
        MoveEnemy();
    }

    public void ResetEnemy()
    {
        gameObject.SetActive(false);
        health = 100;
        speed = 3;
        alive = false;
        gameObject.transform.localPosition = Vector3.zero;
        gameObject.GetComponent<Collider>().enabled = true;
    }

    public void TakeHit()
    {
        health -= 10;
        if (health <= 0)
        {
            gameObject.GetComponent<Collider>().enabled = false;
            KillEnemy();
        }
    }
    
    void MoveEnemy()
    {
        transform.LookAt(targetRobot);
        if ( Vector3.Distance(transform.position, coverPos.position) > 0.2f)
        {
            transform.position = Vector3.MoveTowards(transform.position, coverPos.position, speed * Time.fixedDeltaTime);
        }
        else
        {
            animator.SetBool("StaticShoot", true);
        }
    }

    void KillEnemy()
    {
        animator.SetBool("Die", true);
        alive = false;
        levelManager.EnemyKilled();
        Invoke("ResetEnemy", 2f);
        
    }    



}
