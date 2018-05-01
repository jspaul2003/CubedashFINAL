using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour {
    public Renderer rend;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //from options for color
        if (graphics.cols[1] == 0)
        {
            rend.material.color = Color.white;
        }
        else if (graphics.cols[1] == 1)
        {
            rend.material.color = Color.cyan;
        }
        else if (graphics.cols[1] == 2)
        {
            rend.material.color = Color.green;
        }
    }
}
