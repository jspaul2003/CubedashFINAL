using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detector : MonoBehaviour {
    //Exists as an invisible collider, so the player can stand on blocks.
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < -35)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(-BlockSpawner.speed * Time.deltaTime, 0, 0, Space.World); //continue to follow designated obstacle
        }
    }
}
