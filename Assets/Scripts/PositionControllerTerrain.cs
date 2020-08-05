using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;


public class PositionControllerTerrain : MonoBehaviour
{
    public GameObject theCube1;
    public GameObject theSphere1;
    public int thestringlength1;
    public float maxPos1 = 0f;
    public float minPos1 = 30f;


    private string createdRandomString1;
    private static int palindromeLength1;
    private Vector3 theNewPos1;

    /*
        SPAWNTERRAIN FUNCTION
        This function generate collectibles (cubes) at random positions in the maze and their corresponding text element with clamped through sphere object.
        The string of 9 characters generated having alphanumerics x, m and 8 and prenthesis ( and ) also, appeared in clamped text. 
     
     */

    public void spawnTerrain()
    {
        List<int> palindromeIndexes = new List<int>();              //  List of index values corresponds to palindrom strings
        int palindromeIndex;                                        //  palindron index variable

        Text randomString;                                          //  variable to store random strings generated 



        /* Algorithm to make random palindromic strings   */

        for (int i = 0; i < palindromeLength1; i++)
        {
            palindromeIndex = Random.Range(0, 37);                    // 38 strings to be generated as registration number is FA19-RCS-038
            if (!palindromeIndexes.Contains(palindromeIndex) || palindromeIndexes.Count == 0)
            {
                palindromeIndexes.Add(palindromeIndex);
            }
            else
            {
                palindromeLength1 = palindromeLength1 + 1;
            }
        }

        int cubeNumber = 0;
        while (cubeNumber < 38)                                                       //  for 38 cubes/collectibles
        {
            createdRandomString1 = "";
            float theXPosition = Random.Range(minPos1, maxPos1);                      //  To seek random positions on x-axis
            float theZPosition = Random.Range(minPos1, maxPos1);                      //  To seek random positions on z-axis
            theNewPos1 = new Vector3(theXPosition, 0.5f, theZPosition);               //  Store position in this variable. Notice y-axis will remain constant in 3D
            if (Physics.CheckSphere(theNewPos1, 0.36f))                               //  It at this location there is player then do nothing
            {
                continue;
            }
            else
            {                                                                        //  Otherwise
                GameObject sphere = Instantiate(theSphere1);                         //  generate an sphere game object that corresponds to clamp text for random string
                GameObject cube = Instantiate(theCube1);                             //  generate an cube game object which is collectible
                sphere.name = "Sphere" + cubeNumber;                                 //  append its index
                cube.name = "Cube" + cubeNumber;                                     //  append its index
                sphere.transform.position = new Vector3(theXPosition, 1.1f, theZPosition);    //  set label position
                cube.transform.position = theNewPos1;                                        //  set collectible cube position

                //  create random string of length 9-15 characters (, x, m, 8 and ) and display in the UI Text object

                randomString = GameObject.Find("Sphere" + cubeNumber + "/Canvas/Text").GetComponent<Text>();
                string[] characters = new string[] { "x", "m", "8" };
                string[] charactersAdditional = new string[] { "x", "m", "8", "(", ")" };
                thestringlength1 = Random.Range(9, 15);                          //  strings having random length between 9 to 15 characters 
                if (palindromeIndexes.Contains(cubeNumber))
                {
                    for (int j = 0; j < thestringlength1 / 2; j++)               //  to generate some palindromic strings
                    {
                        createdRandomString1 = createdRandomString1 + characters[Random.Range(0, characters.Length)];
                    }
                    createdRandomString1 = createdRandomString1 + new string(createdRandomString1.Reverse().ToArray());
                    createdRandomString1 = "(" + createdRandomString1 + ")";
                }
                else
                {
                    for (int j = 0; j < thestringlength1; j++)
                    {
                        createdRandomString1 = createdRandomString1 + charactersAdditional[Random.Range(0, charactersAdditional.Length)];
                    }
                }

                randomString.text = createdRandomString1;
                cubeNumber++;
            }
        }
    }

    public static int _totalPalindromes;
    public static int totalPalindromes
    {
        get
        {
            return _totalPalindromes;
        }
        set
        {
            _totalPalindromes = value;
        }

    }


    /*  START FUNCTION :  
        initially to generate 38 collectibles along with corresponding random strings, it is fixed that there should be minimum 1/3 (i.e 13) palindroms in the strings generated 
        by the spa*/

    void Start()
    {
        palindromeLength1 = Random.Range(13, 38);                 //  generate random palindrom length between 13 to 38
        PositionController.totalPalindromes = palindromeLength1; //  set the number of palindrom accroding to the length generated
        spawnTerrain();                                                //  call spawn function to generate cubes and corresponding strings clamped through sphere and text.
    }
}