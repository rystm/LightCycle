using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandPointController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    internal void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.name == "Player_two")
        {
            this.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0, 0.3f);
        }
        else if (obj.gameObject.name == "Player_one")
        {
            this.GetComponent<SpriteRenderer>().color = new Color(0, 0, 255, 0.3f);
        }
    }
}
