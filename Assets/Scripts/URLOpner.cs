using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URLOpner : MonoBehaviour
{
    public string url;

    public void open()
    {

        Application.OpenURL(url);    
     }

}
