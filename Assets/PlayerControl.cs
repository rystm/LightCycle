using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class PlayerControl : MonoBehaviour
{

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

    //direction of travel
    public int dir = 5;
    private int NORTH = 0;
    private int EAST = 1;
    private int SOUTH = 2;
    private int WEST = 3;

    //coordinates for the edge of the map
    public float leftBox;
    public float rightBox;
    public float topBox;
    public float botBox;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        SpawnPlayer();
        CurrLevel = SceneManager.GetActiveScene().buildIndex;
        leftBox = GameObject.Find("West_Wall").transform.position.x;
        rightBox = GameObject.Find("East_Wall").transform.position.x;
        topBox = GameObject.Find("North_Wall").transform.position.y;
        botBox = GameObject.Find("South_Wall").transform.position.y;
        //transform.rotation = Quaternion.LookRotation(new Vector3(1, 0), new Vector3(0, 0, -1));
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.M))
        {
            SceneManager.LoadScene(0);
        }
        //Go east
        if (this.gameObject.name.Equals("Player_two") && Input.GetKey(KeyCode.D) && dir != WEST)
        {
            myRigidBody.velocity = new Vector2(Speed, 0f);
            dir = EAST;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
        }
        //Go west
        else if (this.gameObject.name.Equals("Player_two") && Input.GetKey(KeyCode.A) && dir != EAST)
        {
            myRigidBody.velocity = new Vector2(Speed * -1, 0f);
            dir = WEST;
            transform.rotation = Quaternion.LookRotation(Vector3.back, Vector3.up);
        }
        //Go north
        else if (this.gameObject.name.Equals("Player_two") && Input.GetKey(KeyCode.W) && dir != SOUTH)
        {
            myRigidBody.velocity = new Vector2(0f, Speed);
            dir = NORTH;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.left);
        }
        //Go south
        else if (this.gameObject.name.Equals("Player_two") && Input.GetKey(KeyCode.S) && dir != NORTH)
        {
            myRigidBody.velocity = new Vector2(0f, Speed * -1);
            dir = SOUTH;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.right);
        }

        //Player ONE
        //Go east
        if (this.gameObject.name.Equals("Player_one") && Input.GetKey(KeyCode.RightArrow) && dir != WEST)
        {
            myRigidBody.velocity = new Vector2(Speed, 0f);
            dir = EAST;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
        }
        //Go west
        else if (this.gameObject.name.Equals("Player_one") && Input.GetKey(KeyCode.LeftArrow) && dir != EAST)
        {
            myRigidBody.velocity = new Vector2(Speed * -1, 0f);
            dir = WEST;
            transform.rotation = Quaternion.LookRotation(Vector3.back, Vector3.up);
        }
        //Go north
        else if (this.gameObject.name.Equals("Player_one") && Input.GetKey(KeyCode.UpArrow) && dir != SOUTH)
        {
            myRigidBody.velocity = new Vector2(0f, Speed);
            dir = NORTH;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.left);
        }
        //Go south
        else if (this.gameObject.name.Equals("Player_one") && Input.GetKey(KeyCode.DownArrow) && dir != NORTH)
        {
            myRigidBody.velocity = new Vector2(0f, Speed * -1);
            dir = SOUTH;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.right);
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

    /*internal void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Player" || obj.gameObject.tag == "Trail" || obj.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(CurrLevel);
        }
    }*/


    internal void OnTriggerEnter2D(Collider2D obj)
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene(CurrLevel);
    }


    void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}
