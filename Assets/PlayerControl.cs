using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class PlayerControl : MonoBehaviour {

    /// <summary>
    /// Speed character at which moves
    /// </summary>
    public float Speed = 1f;
    /// <summary>
    /// player's Rigidbody2D
    /// </summary>
    public Rigidbody2D myRigidBody;
	/// <summary>
    /// Called when the character finished level
    /// </summary>
    //public event System.Action CompletedLevel = delegate { };
	/// <summary>
    /// Called when the player is spawned
    /// </summary>
    public event System.Action SpawnPlayer = delegate { };
	
	//index of current level
	private int CurrLevel;

    //coordinates for the edge of the map
    public float leftBox;
    public float rightBox;
    public float topBox;
    public float botBox;
	
    void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
		SpawnPlayer();
		CurrLevel = SceneManager.GetActiveScene().buildIndex;
        leftBox = GameObject.Find("West_Wall").transform.position.x;
        rightBox = GameObject.Find("East_Wall").transform.position.x;
        topBox = GameObject.Find("North_Wall").transform.position.y;
        botBox = GameObject.Find("South_Wall").transform.position.y;
    }

    void Update()
    {
	
		if(Input.GetKey(KeyCode.M))
		{
			SceneManager.LoadScene(0);
		}
        //Go east
        if(this.gameObject.name.Equals("Player_two") && Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            myRigidBody.velocity = new Vector2(Speed, 0f);
        }
        //Go west
        else if (this.gameObject.name.Equals("Player_two") && Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            myRigidBody.velocity = new Vector2(Speed * -1, 0f);
        }
        //Go north
        else if (this.gameObject.name.Equals("Player_two") && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            myRigidBody.velocity = new Vector2(0f, Speed);
        }
        //Go south
        else if (this.gameObject.name.Equals("Player_two") && Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
        {
            myRigidBody.velocity = new Vector2(0f, Speed * -1);
        }

        //Player ONE
        //Go east
        if (this.gameObject.name.Equals("Player_one") && Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidBody.velocity = new Vector2(Speed, 0f);
        }
        //Go west
        else if (this.gameObject.name.Equals("Player_one") && Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            myRigidBody.velocity = new Vector2(Speed * -1, 0f);
        }
        //Go north
        else if (this.gameObject.name.Equals("Player_one") && Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
        {
            myRigidBody.velocity = new Vector2(0f, Speed);
        }
        //Go south
        else if (this.gameObject.name.Equals("Player_one") && Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow))
        {
            myRigidBody.velocity = new Vector2(0f, Speed * -1);
        }
    }

	
	
	void OnGUI()
	{
	
		/*GUIStyle textstyle = new GUIStyle();
		textstyle.fontSize = 40;
		
		Font myfont = (Font)Resources.Load("Fonts/BAUHS93", typeof(Font));
		textstyle.font = myfont;
		
		string scoins = coinCounter.ToString();
		string splatforms = (MaxPlatforms - NumberOfPlatforms).ToString();
		GUI.Label(new Rect(0, 0, 500, 500), "My Coins: " + scoins, textstyle);
		GUI.Label(new Rect(0, 50, 500, 500), "Remaining Platforms: " + splatforms, textstyle);*/
	}


    //****************************************** HERE*********************************************************************************************

    internal void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Player" || obj.gameObject.tag == "Trail" || obj.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(CurrLevel);
        }
    }

  
    internal void OnTriggerEnter2D(Collider2D obj)
    {

    }


    void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}
