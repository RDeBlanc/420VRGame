using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSaberScript : MonoBehaviour
{
    LineRenderer line; // this is what makes the light saber just a light.  can change it to an object with physics.
    public Transform startPosition;
    public Transform endPosition;

    //extending on button press varables.
    private bool isActivated = false;
    private Vector3 extendedPosition; //Vector3 is a 3D position.
    private readonly float extendSpeed = 4.0f; //how fast the beam extends out.


    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>(); //makes lightbeam part
        extendedPosition = endPosition.localPosition;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //extends/de-tends light on button press.          //TODO change later to work with VR controls instead of spacebar.
        {
            if (isActivated == true)
            {
                isActivated = false;
            }
            else isActivated = true;
        }
        if (isActivated == true)
        {
            //Lerp() moves between 2 different positions.
            endPosition.localPosition = Vector3.Lerp(endPosition.localPosition, extendedPosition, Time.deltaTime * (extendSpeed));      //TODO add an invisable object that has collision that extends along with the light.
        }
        else endPosition.localPosition = Vector3.Lerp(endPosition.localPosition, startPosition.localPosition, Time.deltaTime * (extendSpeed));



        line.SetPosition(0, startPosition.position); //these are the 2 inputs for start-position and end-positon in Unity.  This updates the light position.
        line.SetPosition(1, endPosition.position);
    }
}

