using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2 : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayLevel2()
    {
        SceneManager.LoadSceneAsync("Level 2"); 
    }
}
