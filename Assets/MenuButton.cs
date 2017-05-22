using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour {

    public AudioClip select;
    public AudioSource source;
    GameObject audioPlayer;

    private void Start()
    {
        //audioPlayer = GameObject.Find("Audio Player");
        //source = audioPlayer.GetComponent<AudioSource>();
    }
    public void LoadLevel(int level)
	{
		string slevel = (level-1).ToString();
        //source.PlayOneShot(select, 1f);
        SceneManager.LoadScene(level);
        //MusicPlayer.PlayGameMusicA();
    }

	
	void OnGUI()
	{	
		GUIStyle textstyle = new GUIStyle();
		textstyle.fontSize = 40;
		
		Font myfont = (Font)Resources.Load("Fonts/BAUHS93", typeof(Font));
		textstyle.font = myfont;
    }
	
}
