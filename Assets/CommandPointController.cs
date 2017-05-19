using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandPointController : MonoBehaviour {
    
    /// <summary>
    /// The player number who controls this CP
    /// </summary>
    private int owner;

	// Use this for initialization
	void Start () {
        owner = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    internal void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.name == "Player_two")
        {
            this.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0, 0.3f);
            owner = 2;
        }
        else if (obj.gameObject.name == "Player_one")
        {
            this.GetComponent<SpriteRenderer>().color = new Color(0, 0, 255, 0.3f);
            owner = 1;
        }
    }
}
