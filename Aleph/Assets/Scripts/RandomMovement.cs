using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    private float waitTime;
    public float startWaitTime;
    public float speed;


    public Transform player;
    public float areaOfEffect;
    public Transform moveSpot;
    public float minX, maxX;
    public float minY, maxY;

    // Start is called before the first frame update
    void Start()
    {
       
        waitTime = startWaitTime;

        moveSpot.position = new Vector2(0, -9.3f);
    }
    
    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
        {
            if(waitTime <= 0)
            {
                moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                waitTime = startWaitTime;
            } else
            {
                waitTime -= Time.deltaTime;
            }
        }
      
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveSpot.position = new Vector2(0, -9.3f);
        }

        if (Vector2.Distance(transform.position, player.position) <= areaOfEffect)
        {
            moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            
            waitTime = startWaitTime;
        }

       
    }

 

   
}
