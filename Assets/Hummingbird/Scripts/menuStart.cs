using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuStart : MonoBehaviour
{
    // Start is called before the first frame update
    public void changemenuscene(string scenename)
    {
        SceneManager.LoadScene(scenename);

    }
    
   
}
