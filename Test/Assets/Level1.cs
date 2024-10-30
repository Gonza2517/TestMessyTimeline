using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayLevel1()
    {
        SceneManager.LoadSceneAsync("SampleScene");
        
    }
}
