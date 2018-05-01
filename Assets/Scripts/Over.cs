using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Over : MonoBehaviour {
    //GAME OVER SCREEN
    public GameObject Player;
    private int score;
    private Text text;

    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();

        // start text off as completely transparent black
        text.color = new Color(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            score = Player.GetComponent<Player>().score;
        }
        else
        {

            // reveal text only when player is null (destroyed)
            text.color = new Color(0, 0, 0, 1);
            text.text = "Oof!\nYour Score:\n" + score + "\nPress Space to Restart!"; //Show that player has lost but show score with him as well

            // jump is space bar by default
            if (Input.GetKey(KeyCode.Space)) //If we press space, restart game
            {
                BlockSpawner.speed = 10f; //reset speed
                                          // reload entire scene, starting music over again, refreshing score, etc.
                SceneManager.LoadScene("Main");
            }
        }
    }
}
