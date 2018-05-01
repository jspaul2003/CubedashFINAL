using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public int a = 1;
    public GameObject Cam;
    public GameObject Canvas;
    private int k = 0;
    public Rigidbody Rb;
    public float jumpSpeed;
    private bool ground;
    public AudioSource jumpss;
    public int score;
    public Renderer rend;

    // Use this for initialization
    void Start () {
        //Color options
        ground = false;
        //from options
        if (graphics.cols[2] == 0)
        {
            rend.material.color = Color.red;
        }
        else if (graphics.cols[2] == 1)
        {
            rend.material.color = Color.blue;
        }
        else if (graphics.cols[2] == 2)
        {
            rend.material.color = Color.black;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //If we are below -0.1 (allow a little leeway for some areas), we are falling so we are not grounded
        if (Rb.velocity.y<-0.1 )
        {
            ground = false;
        }
        if(Rb.velocity.y == 0){ //touching
            ground = true;
        }
        //Speed augmenter: when jumping there is a chance of speed increasing
        int x = 0;
        if (Random.Range(0,4)==0)
        {
            x = 1;
        }
        //gravity must always be involved
        Vector3 nil = new Vector3(0f, 0f, 0f);
        Rb.velocity += nil;

        if (Input.GetKey(KeyCode.Space) && ground)
        {
            jumpss.Play(); //jump sound
            score += 1; //score increases each time we jump
            BlockSpawner.speed += x; //maybe speed increases?
            Vector3 jump = new Vector3(0f, jumpSpeed, 0f); //jump
            Rb.velocity += jump;
            ground = false; //no longer touching the ground
        }


        if (score % 10 == 0 && score > 1 && a==0) //IF we have increased our score by 10, We flip the screen around. This makes the gameplay more diverse.
        {
            if (k == 0)
            {
                Cam.transform.rotation = Quaternion.Euler(0, 0, 180); 
                Canvas.transform.rotation = Quaternion.Euler(0, 0, 180);
                Canvas.transform.position = new Vector3(3, (float)4, 5);
                k = 1;
            }
            else
            {
                Cam.transform.rotation = Quaternion.Euler(0, 0, 0);
                Canvas.transform.rotation = Quaternion.Euler(0, 0, 0);
                Canvas.transform.position = new Vector3(3, -3, 5);
                k = 0;
            }
            a = 1;
        }
        if (score % 10 == 1)
        {
            a = 0;
        }
    }
}
