using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinScript : MonoBehaviour
{

    [SerializeField] float RevolutionSpeed;
    [SerializeField] float OrbitSpeed;
    [SerializeField] Transform Planet;
    [SerializeField] Transform Root;

    // Start is called before the first frame update
    void Start()
    {

        RevolutionSpeed = Random.Range(1, 8);
        OrbitSpeed = Random.Range(1, 8);

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 rootRotation = Root.eulerAngles;
        Vector3 planetRotation = Planet.eulerAngles;

        rootRotation.z += RevolutionSpeed;
        planetRotation.z += OrbitSpeed;

        Root.eulerAngles = rootRotation;
        Planet.eulerAngles = planetRotation;

    }
}
