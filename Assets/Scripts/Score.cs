using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Text))]
public class Score : MonoBehaviour {
    //Score UI to show the score of player.
    //Will stay in top right corner of screen.
    //Gets score from Player object and then uses it to put it on screen
    public GameObject Player;
    private Text text;
    private int score;
    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Player != null)
        {
            score = Player.GetComponent<Player>().score;
        }
        text.text = "Score: " + score;
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            
        }
    }
}
