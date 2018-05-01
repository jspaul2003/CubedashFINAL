using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour {
    //This controls spawning of obstacles and their detectors
    public static float speed = 10f; //our speed
    public GameObject[] prefabs; //our prefabs
    private float preY =0; //the location of our previous block spawned on the Y axis to prevent impossible scenarios
    // Use this for initialization
    void Start() {
        StartCoroutine(SpawnBlocks()); //begin our IE numerator
    }

    // Update is called once per frame
    void Update() {

    }

    IEnumerator SpawnBlocks()
    {
        int[] choices = new int[] { -3, 2, 7 }; //Y locations
        //pattern generation list
        // we will have a stair case, a v, and and an n and downwards staircase
        int[,] pats = new int[,] { 
             { 0,1,2 },
             { 2,1,0 },
             { 1,0,1 },
             {2,1,2},
             {1,2,1 },
             {2,3,2 }
             };
        while (true)
        {
            float t = Random.Range(3, 8); //time until next spawned
            //random generation
            //50 50, pattern vs random
            if (Random.Range(0, 2) == 0)
            {
                // RANDOM GENERATION
                float x = transform.position.x;
                int y1 = Random.Range(0, 3); //to choose from array
                float y = choices[y1]; // get proper y value
                if(preY==1 && y1== 0) //impossible to win scenario: We cant have that! So we wait
                {
                    yield return new WaitForSeconds(Time.deltaTime * 10 * 100f / speed);
                }
                float z = transform.position.z;
                Instantiate(prefabs[0], new Vector3(x - 5, y - 5, z - 5), Quaternion.identity);
                Instantiate(prefabs[1], new Vector3(x, y, z), Quaternion.identity);
                preY = y1; //Set our previous Y to PreY
                
            }
            else
            {
                //PATTERN
                t = Random.Range(3, 4); //even here we want shifting times to make the gameplay more diverse
                int i = Random.Range(0, 6); //choose pattern randomly
                if (preY == 1 && i==0) //IMPOSSIBLE TO WIN SITUATION
                {
                    yield return new WaitForSeconds(Time.deltaTime * 10 * 100f/speed);
                }
                for (int k = 0; k < 1; k++) //SPAWN PATTERN
                {
                    preY = -1; //reset PreY
                    Instantiate(prefabs[0], new Vector3(transform.position.x - 5, choices[pats[i, k]] - 5, transform.position.z - 5), Quaternion.identity);
                    Instantiate(prefabs[1], new Vector3(transform.position.x, choices[pats[i,k]], transform.position.z), Quaternion.identity);
                    yield return new WaitForSeconds(Time.deltaTime * t * 100f / speed);
                }
                preY = pats[i, 2]; //Set our PreY to the last block
            }
            yield return new WaitForSeconds(Time.deltaTime * t * 100f / speed); // wait a bit
        }
    }
}
