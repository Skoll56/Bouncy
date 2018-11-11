using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class destroyer : MonoBehaviour {

    public Transform lava;
	

	void Start () {
		
	}
	
	
	void Update ()
    {
        if (this.gameObject.transform.position.y <= lava.transform.position.y + 50)
        {
            Object.Destroy(this.gameObject);
        }
	}

}
