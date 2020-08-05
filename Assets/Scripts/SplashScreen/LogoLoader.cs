using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//  After waiting 5 seconds next scene of scene index 1 will be loaded


public class LogoLoader : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("Countdown");
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(1);
    }
}
