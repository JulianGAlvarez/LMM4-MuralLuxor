using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sol : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float stoppingDistance;
    [SerializeField] private float retreatDistance;

    private float waitTime;
    [SerializeField] private float startWaitTime;

    public Transform moveSpot;
    [SerializeField] private float minX1, maxX1, minY1, maxY1;
    [SerializeField] private float minX2, maxX2, minY2, maxY2;


    public Transform player;
  
    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
       
        moveSpot.position = new Vector2(Random.Range(minX1, maxX2), Random.Range(minY1, maxY2));
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        

    }

    // Update is called once per frame
    void Update()
    {
        

        EscapeFromPlayer();
    }

    //Handles Sun´s Idle Movement
    void Movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);


        if (Vector2.Distance(transform.position, moveSpot.position) < 0.5f)
        {
            if(waitTime <= 0)
            {

                moveSpot.position = new Vector2(Random.Range(minX1, maxX2), Random.Range(minY1, maxY2));
                waitTime = startWaitTime;
            } else
            {
                waitTime -= Time.deltaTime;
            }
        }

       
    }

    //Handles Sun´s Movement Running Away From Player
    void EscapeFromPlayer()
    {
        if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        } else
        {
            Movement();
        }
    }

    
}
