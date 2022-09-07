using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public float moveSpeed;
    Vector3 mousePosition;
    Vector2 position = new Vector2(0f, 0f);
    Vector2 contourPos;

    Vector2 playerPos = new Vector2(0f, 0f);
    private Detection detection;

    float lastY = 0;
    float lastX;
    [SerializeField] float windowWidth = 11.4885f;
    [SerializeField] float windowHeight = 10.4485f;
    [SerializeField] float OFFSET_X = 0.6008f;
    [SerializeField] float OFFSET_Y = -0.2066f;





    // Start is called before the first frame update
    void Start()
    {
        detection = (Detection)FindObjectOfType(typeof(Detection));

        playerRb = GetComponent<Rigidbody2D>();

        contourPos = new Vector2(FindObjectOfType<CountorFinder>().contourX, FindObjectOfType<CountorFinder>().contourY);
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
        // Handles Player´s Movement Direction

        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        Vector2 cameraPosition = GameObject.FindGameObjectWithTag("RawImage").GetComponent<CountorFinder>().getPosition();
        GameObject circle = GameObject.FindGameObjectWithTag("CirclePortalAbove");
        Debug.Log(circle.GetComponent<SpriteRenderer>().bounds.size.x);

        float x = cameraPosition.x * windowWidth + OFFSET_X;
        float y = cameraPosition.y * windowHeight + OFFSET_Y;

        position = Vector2.Lerp(transform.position, new Vector2(x, y), moveSpeed);
        playerPos = Vector2.Lerp(transform.position, contourPos, moveSpeed);
        

        /*

        float step = moveSpeed * Time.deltaTime;

        
         float normX = Mathf.Clamp(detection.faceX - lastX, 1, -1);
         float normY = Mathf.Clamp(detection.faceY - lastY, 1, -1);

         lastY = detection.faceY;
         lastX = detection.faceX;
         transform.position = Vector3.MoveTowards(new Vector3(transform.position.x + normX, transform.position.y +normY, transform.position.z), new Vector3(transform.position.x+ normX, transform.position.y+ normY, transform.position.z), step);
        
        */
    }

    private void FixedUpdate()
    {

       playerRb.MovePosition(position);

        

    }
}
