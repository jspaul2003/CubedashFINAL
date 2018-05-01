using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DropDownController : MonoBehaviour {
    public Dropdown ground;
    public Dropdown background;
    public Dropdown player;
    public Dropdown obstacles;
    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        //We can control the color of main objects
        background.onValueChanged.AddListener(delegate {
            graphics.cols[1] = background.value;
        });
        ground.onValueChanged.AddListener(delegate {
            graphics.cols[0] = ground.value;
        });
        player.onValueChanged.AddListener(delegate {
            graphics.cols[2] = player.value;
        });
        obstacles.onValueChanged.AddListener(delegate {
            graphics.cols[3] = obstacles.value;
        });
        //also controls scene loading
        if (Input.GetKeyDown(KeyCode.Escape)) //if we want to return to title, we can by pressing esc
        {
            SceneManager.LoadScene("Title");
        }
    }
    

}
