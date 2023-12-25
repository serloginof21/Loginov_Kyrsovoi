using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3;
    public float chaseSpeed = 4;
    public float chaseDistance = 7f;
    private float waitTime;
    public float startWaitTime;
    public Transform[] moveSpots;
    public int randomSpot;
    public PlayerStats playerHealth;
    private Transform player;

    private bool isChasing = false;

    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= chaseDistance)
        {
            isChasing = true;
        }
        else if (distanceToPlayer > chaseDistance * 2)
        {
            isChasing = false;
        }

        if (isChasing)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
        }
        else{
                transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
                if(Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f){
                    if(waitTime <= 0){
                    randomSpot = Random.Range(0, moveSpots.Length);
                    waitTime = startWaitTime;
                }
                else{
                    waitTime -= Time.deltaTime;
                }
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            playerHealth.health -= 1;
        }
    }
}
