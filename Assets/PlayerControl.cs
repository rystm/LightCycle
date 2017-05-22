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

    // <summary>
    // The Player's score
    // </summary>
    private int score = 0;

    // <summary>
    // The Player's score display
    // </summary>
    private GUIText scoreDisp;

    // <summary>
    // The Player's score display
    // </summary>
    public GUIText winner;

    // <summary>
    // The Player's score display
    // </summary>
    public GUIText instructions;

    public GUIText status;

    //index of current level
    private int CurrLevel;

    //direction of travel
    public int dir = 5;
    private int NORTH = 0;
    private int EAST = 1;
    private int SOUTH = 2;
    private int WEST = 3;

    // <summary>
    // Whether or not the game has ended
    // </summary>
    public GameObject[] players;

    // <summary>
    // Current Scene
    // </summary>
    public Scene CurrentScene;

    void Start()
    {
        CurrentScene = SceneManager.GetActiveScene();
        myRigidBody = GetComponent<Rigidbody2D>();
        SpawnPlayer();
        CurrLevel = SceneManager.GetActiveScene().buildIndex;
        if (CurrentScene.name != "Battle")
        {
            if (this.gameObject.name.Equals("Player_one"))
            {
                scoreDisp = GameObject.Find("P1 Score").GetComponent<GUIText>();
            }
            else
            {
                scoreDisp = GameObject.Find("P2 Score").GetComponent<GUIText>();
            }
            DisplayScore();
        }
        winner = GameObject.Find("Winner").GetComponent<GUIText>();
        instructions = GameObject.Find("Instructions").GetComponent<GUIText>();
        winner.text = "";
        instructions.text = "";
        status = GameObject.Find("status").GetComponent<GUIText>();
    }

    void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length < 2)
        {
            instructions.text = "Press R to restart\n Press M to go to menu";
            players[0].GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene(CurrentScene.name);
            }
            else if (Input.GetKey(KeyCode.M))
            {
                SceneManager.LoadScene(SceneManager.GetSceneByName("Main Menu").name); //BROKEN *************************************
            }
        }
        else {
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
        if (obj.gameObject.tag != "Area")
        {
            if (CurrentScene.name.Equals("Command Posts"))
            {
                UpdateScore(-3);
            }
            else if (CurrentScene.name.Equals("Battle"))
            {
                this.score--;
            }

            if (GameObject.Find("Player_one").GetComponent<PlayerControl>().GetScore() > GameObject.Find("Player_two").GetComponent<PlayerControl>().GetScore())
            {
                winner.text = "Player 1 Wins";
                winner.color = new Color(0, 0, 255);
            }
            else if (GameObject.Find("Player_one").GetComponent<PlayerControl>().GetScore() < GameObject.Find("Player_two").GetComponent<PlayerControl>().GetScore())
            {
                winner.text = "Player 2 Wins";
                winner.color = new Color(0, 255, 0);
            }
            else
            {
                winner.text = "Tie Game";
                winner.color = new Color(255, 0, 0);
            }
            Destroy(this.gameObject);
        }
    }

    public void UpdateScore(int i)
    {
        score += i;
        DisplayScore();
    }

    public int GetScore()
    {
        return this.score;
    }

    void DisplayScore()
    {
        scoreDisp.text = score.ToString();
    }


    void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}
