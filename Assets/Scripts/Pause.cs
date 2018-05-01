using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Pause : MonoBehaviour {
    //THERE IS NO PAUSE BUTTON!
    private Text text;
    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < -35)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(-BlockSpawner.speed * Time.deltaTime, 0, 0, Space.World);
        }
    }
}
