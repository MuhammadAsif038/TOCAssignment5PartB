using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    public static int sceneNum;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ToSplashOne());
    }

    IEnumerator ToSplashOne()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(1);
    }
}