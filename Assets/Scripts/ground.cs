using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground : MonoBehaviour {
    public Renderer rend;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        //from options for Colors
            if (graphics.cols[0] == 0)
            {
                rend.material.color = Color.blue;
            }
            else if (graphics.cols[0] == 1)
            {
                rend.material.color = Color.red;
            }
            else if (graphics.cols[0] == 2)
            {
                rend.material.color = Color.black;
            }
    }
}
