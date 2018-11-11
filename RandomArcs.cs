using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomArcs : MonoBehaviour {

    public GameObject template;
    public GameObject[] wall = new GameObject[4];
    public Transform templateWall;
    private int level;
    public int layer;
    public float height;
    public int spawnNo;
	
	void Start ()
    {
        level = 0;
        layer = 1;
        height = transform.position.y;
	}
	
	
	void Update ()
    {
		if (transform.position.y >= level * 100)
        {
            for (int i = 0; i<spawnNo; i++) { ArcSpawn(); }
            level++;
        }

        if (transform.position.y >= layer * 3000)
        {
            for (int i = 0; i<4; i++)
            {
                wall[i].transform.position = new Vector3(wall[i].transform.position.x, wall[i].transform.position.y + 9000.0f, wall[i].transform.position.z);
                WallSpawn(wall[i], i);
            }
            layer++;
        }
	}



    void ArcSpawn()
    { 
        Instantiate(template, new Vector3(Random.Range(320.0f, 500.0f), transform.position.y + Random.Range(800.0f,1000.0f), Random.Range(88.0f, 270.0f)), Random.rotation);
    }

    void WallSpawn(GameObject wall, int i)
    {
        switch(i)
        {
            case 0:
                Instantiate(wall, new Vector3(301.7f, (2501.0f + (layer * 5000.0f)), 186.23f), wall.transform.rotation);
                break;
            case 1:
                Instantiate(wall, new Vector3(401.7f, (2501.0f + (layer * 5000.0f)), 286.23f), wall.transform.rotation);
                break;
            case 2:
                Instantiate(wall, new Vector3(501.7f, (2501.0f + (layer * 5000.0f)), 186.23f), wall.transform.rotation);
                break;
            case 3:
                Instantiate(wall, new Vector3(401.7f, (2501.0f + (layer * 5000.0f)), 86.23f), wall.transform.rotation);
                break;
        }
        
    }
}
