using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SpinScript : MonoBehaviour
{

    [SerializeField] float RevolutionSpeed;
    [SerializeField] float OrbitSpeed;
    [SerializeField] Transform Planet;
    [SerializeField] Transform Root;

    [SerializeField] float PlanetSize;

    [SerializeField] bool RotatingCW = true;

    // Start is called before the first frame update
    void Start()
    {

        RevolutionSpeed = Random.Range(.0025f, 0.04f);
        OrbitSpeed = Random.Range(.0025f, 0.04f);

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector3 rootRotation = Root.eulerAngles;
        Vector3 planetRotation = Planet.eulerAngles;

        if (RotatingCW)
        {

            rootRotation.z -= RevolutionSpeed;
            planetRotation.z -= OrbitSpeed;

        }
        else {

            rootRotation.z += RevolutionSpeed;
            planetRotation.z += OrbitSpeed;

        }        

        Root.eulerAngles = rootRotation;
        Planet.eulerAngles = planetRotation;

        //Debug.Log("The global location of the planet is " + Planet.position + " and the mouse is located at " + mousePos);

        if (Input.GetMouseButtonDown(0))
        {

            Debug.Log("Click!");

            if (mousePos.x <= (Planet.position.x + (Planet.localScale.x)) && mousePos.x >= (Planet.position.x - (Planet.localScale.x)))
            {

                if (mousePos.y <= (Planet.position.y + (Planet.localScale.y)) && mousePos.y >= (Planet.position.y - (Planet.localScale.y)))
                {

                    RotatingCW = !RotatingCW;

                }

            }

        }

    }

}
