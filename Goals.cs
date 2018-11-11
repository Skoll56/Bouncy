using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goals : MonoBehaviour {

    private int count;
    public Text countText;

    void Start ()
    {

        count = 0;
        countText.text = "Count: " + count.ToString();
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

    }


    void OnColliderEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            count++;
            countText.text = "Count: " + count.ToString();
        }
    }
}
