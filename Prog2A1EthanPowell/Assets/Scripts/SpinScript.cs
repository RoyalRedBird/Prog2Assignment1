using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SpinScript : MonoBehaviour
{

    /*
    Note: The "planet" reffers to the planet itself, the "Root" reffers to the object the planet is attatched to. 

    The planet achieves orbit by way of being attatched to the root and making the root rotate. Kind of like attatching
    a ball to the end of a stick and swinging it around.
    */

    [SerializeField] float RevolutionSpeed; //The speed at which the planet rotates.
    [SerializeField] float OrbitSpeed; //The speed at which the planet orbits its root.
    [SerializeField] Transform Planet; //The transform for the planet.
    [SerializeField] Transform Root; //The transform for the root.

    [SerializeField] bool RotatingCW = true; //Checks if the planet is rotating and orbiting Clockwise or not.

    // Start is called before the first frame update
    void Start()
    {

        //Sets the Rotation and Orbit speed to a random number between .0025 and .04.
        RevolutionSpeed = Random.Range(.0025f, 0.04f);
        OrbitSpeed = Random.Range(.0025f, 0.04f);

    }

    // Update is called once per frame
    void Update()
    {

        //Grabs the location of the mouse in the world fro  the camera.
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        //Grabs the euler angles of both the root and the planet itself.
        Vector3 rootRotation = Root.eulerAngles;
        Vector3 planetRotation = Planet.eulerAngles;

        //If RotatingCW is true...
        if (RotatingCW)
        {

            //Rotate and orbit the planet clockwise.
            rootRotation.z -= RevolutionSpeed;
            planetRotation.z -= OrbitSpeed;

        }
        else {

            //Otherwise and orbit rotate the planet counterclockwise.
            rootRotation.z += RevolutionSpeed;
            planetRotation.z += OrbitSpeed;

        }        

        //Apply rotations to the root and the planet.
        Root.eulerAngles = rootRotation;
        Planet.eulerAngles = planetRotation;


        //If the mouse is clicked...
        if (Input.GetMouseButtonDown(0))
        {

            //And the global x coordinate of the mouse is between the left and right bounds of the planet's local scale...
            if (mousePos.x <= (Planet.position.x + (Planet.localScale.x)) && mousePos.x >= (Planet.position.x - (Planet.localScale.x)))
            {

                //And the global y coordinate of the mouse is between the top and bottom bounds of the planet's local scale...
                if (mousePos.y <= (Planet.position.y + (Planet.localScale.y)) && mousePos.y >= (Planet.position.y - (Planet.localScale.y)))
                {

                    //Rotate and orbit the planet the other way.
                    RotatingCW = !RotatingCW;

                }

            }

        }

    }

}
