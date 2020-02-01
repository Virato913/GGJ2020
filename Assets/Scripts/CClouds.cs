using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CClouds : MonoBehaviour{

    //Set these variables to whatever you want the slowest and fastest speed for the clouds to be, through the inspector.
    public float minSpeed;
    public float maxSpeed;

    //Set these variables to the lowest and highest y values you want clouds to spawn at.
    public float minY;
    public float maxY;

    //Set this variable to how far off screen you want the cloud to spawn,
    //and how far off the screen you want the cloud to be for it to despawn. 
    public float buffer;

    float speed;
    float camWidth;

    // Start is called before the first frame update
    void Start(){

        //Set camWidth. Will be used later to check whether or not cloud is off screen.
        camWidth = Camera.main.orthographicSize * Camera.main.aspect;

        //Set Cloud Movement Speed, and Position to random values within range defined above
        speed = Random.Range(minSpeed, maxSpeed);
        transform.position = new Vector3(-camWidth - buffer, Random.Range(minY, maxY), transform.position.z);
    }

    // Update is called once per frame
    void Update(){

        //Translates the cloud to the right at the speed that is selected
        transform.Translate(speed * Time.deltaTime, 0, 0);

        //If cloud is off Screen, Destroy it.
        if (transform.position.x - buffer > camWidth){

            Destroy(gameObject);
        }
    }
}
