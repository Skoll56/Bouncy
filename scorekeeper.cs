using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scorekeeper : MonoBehaviour {

    public Text text;
    public Text curText, endText;
    private int topheight;
    public GameObject lose;

	void Start ()
    {
        topheight = 0;
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.y > topheight)
        {
            topheight = (int)transform.position.y;
            text.text = "Top Height: " + topheight.ToString() + "m";
        }

        curText.text = "Height: " + (int)transform.position.y + "m";
	}

    private void OnDestroy()
    {
        endText.text = text.text;
        lose.SetActive(true);
        Cursor.visible = true;
    }
}
