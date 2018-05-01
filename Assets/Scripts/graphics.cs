using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class graphics : MonoBehaviour {
    //Controls what colors get sent to the objects
    private static GameObject mp;
    void Awake()
    {
        if (!mp)
        {
            mp = transform.gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(transform.gameObject);
    }
    public static int[] cols = new int[] { 0, 0, 0, 0 };
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }
}
