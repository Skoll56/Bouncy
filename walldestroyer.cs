using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walldestroyer : MonoBehaviour {
    public Transform lava;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (this.gameObject.transform.position.y <= lava.transform.position.y - 5000)
        {
            Object.Destroy(this.gameObject);
        }
    }
}
