using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorNew1 : MonoBehaviour
{
    public GameObject[] cube;
    public GameObject[] ball;
    Color[] ballcolor = new Color[3];// ball color for ramdomize
    Color[] cubecolor = new Color[10]; // cube color
    Color[] mainColors = new Color[] { Color.red, Color.green, Color.blue, Color.gray, Color.yellow, Color.magenta }; // store all color that want to ramdomize
    void Start()
    {
        for (int i = 0; i <= 2; i++) // random color for ball gameObject
        {
            ballcolor[i] = mainColors[Random.Range(0, mainColors.Length)];
            ball[i].GetComponent<Renderer>().material.color = ballcolor[i];
        }
        for(int i = 0; i <= cube.Length-1; i++) // random color for cube gameObject
        {
            cubecolor[i] = mainColors[Random.Range(0, mainColors.Length)];
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
                if (hit.transform != null && hit.transform.gameObject.CompareTag("Ball"))
                {
                    Color ballColor = hit.transform.gameObject.GetComponent<Renderer>().material.color;
                    for (int i = 0; i <= ball.Length - 1; i++)
                    {
                        if (hit.transform.gameObject == ball[i]) // check that if raycast hit any ball
                        {
                            foreach (GameObject cube in cube) // check each cube in cube array that has the same color as clicked ball

                            {
                                if (cube != null && cube.GetComponent<Renderer>().material.color == ballColor) //if cube is not null and have the same color as clicked ball
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
