using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    //These are the obstacles sent towards the player to jump over
    public AudioSource explosion;
    public GameObject[] prefabs;
    public Renderer rend;
    // Use this for initialization
    void Start () {
       rend = GetComponent<Renderer>(); //get renderer component so settings for colors can work

    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < -35) //if beyond scope of view, we destroy the cube
        {
            Destroy(gameObject);
        }
        else
        {
            // ensure Blocks move at constant rate BlockSpawner
            transform.Translate(-BlockSpawner.speed * Time.deltaTime, 0, 0, Space.World);
        }
        //from options
        if (graphics.cols[3] == 0)
        {
            rend.material.color = Color.green;
        }
        else if(graphics.cols[3] == 1)
        {
            rend.material.color = Color.white;
        }
        else if (graphics.cols[3] == 2)
        {
            rend.material.color = Color.red;
        }


    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player") //If we collide into the player, blow him/her up and play an effect.
        {
            explosion.Play();

            // set explosion position to Block's and emit
            GetComponent<ParticleSystem>().transform.position = transform.position;
            GetComponent<ParticleSystem>().Play();
            Destroy(other.gameObject);
        }
    }
}
