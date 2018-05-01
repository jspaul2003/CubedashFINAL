using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {
    //This is an object to use the Cube Dash Song infinitely, without being destroyed by the scene changes.
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
}
