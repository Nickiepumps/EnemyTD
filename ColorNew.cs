using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorNew : MonoBehaviour
{
    public GameObject[] cube;
    public GameObject[] ball;
    Color[] ballcolor = new Color[3];// ball color for ramdomize
    Color[] cubecolor = new Color[10]; // cube color
    Color[] mainColors = new Color[] { Color.red, Color.green, Color.blue, Color.gray, Color.yellow, Color.magenta }; // store all color that want to ramdomize
    Color[] ballcolor2 = new Color[3]; // ball color for storing
    void Start()
    {
        for (int i = 0; i <= 2; i++) // random color for ball gameObject
        {
            ballcolor[i] = mainColors[Random.Range(0, mainColors.Length)];
            ballcolor2[i] = ballcolor[i];
            ball[i].GetComponent<Renderer>().material.color = ballcolor[i];
        }
        for(int i = 0; i <= cube.Length-1; i++) // random color for cube gameObject
        {
            cubecolor[i] = ballcolor2[(Random.Range(0, ballcolor.Length))];
            cube[i].GetComponent<Renderer>().material.color = cubecolor[i];
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {
                    for (int i = 0; i <= ball.Length-1; i++)
                    {
                        if (hit.transform.gameObject == ball[i]) // check that if raycast hit any ball
                        {
                           /*for(int j = 0; j <= cube.Length-1; j++) // loop through all the cube element and check each cube element has the same color as clicked ball
                            {
                                if(cube[j] != null && cube[j].GetComponent<Renderer>().material.color == ball[i].GetComponent<Renderer>().material.color) //if cube is not null and have the same color as clicked ball
                                {                                 
                                    Destroy(cube[j]);
                                }   
                            }*/
                           foreach(GameObject cube in cube) /* check each cube in cube array that has the same color as clicked ball
                                                               this method is also work and make most sense to me*/
                            {
                                if (cube != null && cube.GetComponent<Renderer>().material.color == ball[i].GetComponent<Renderer>().material.color) //if cube is not null and have the same color as clicked ball
                                {
                                    Destroy(cube);                                   
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
