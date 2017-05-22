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
            if (owner != 2)
            {
                if (owner == 1) GameObject.Find("Player_one").GetComponent<PlayerControl>().UpdateScore(-1);
                this.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0, 0.3f);
                owner = 2;
                obj.gameObject.GetComponent<PlayerControl>().UpdateScore(1);
            }
        }
        else if (obj.gameObject.name == "Player_one")
        {
            if (owner != 1)
            {
                if (owner == 2) GameObject.Find("Player_two").GetComponent<PlayerControl>().UpdateScore(-1);
                this.GetComponent<SpriteRenderer>().color = new Color(0, 0, 255, 0.3f);
                owner = 1;
                obj.gameObject.GetComponent<PlayerControl>().UpdateScore(1);
            }
        }
    }
}
