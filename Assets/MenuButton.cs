using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour {

    public void LoadLevel(int level)
	{
        SceneManager.LoadScene(level);
    }
}
