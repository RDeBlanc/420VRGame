using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LS_Cylinder : MonoBehaviour
{
    //LineRenderer line; // this is what makes the light saber just a light.  can change it to an object with physics.

    [Header("Beam size")]
    public float beam_Width;
    public float beam_Length;
    public float extendSpeed;

    //extending on button press varables.
    private bool isActivated = false;

    //Vector3 temp; //Vector3 is a 3D position.


    void Start()
    {
        //Debug.Log("Press Space to extend LightSaber. (LS_Cylinder.cs)");
        if (beam_Width == 0) beam_Width = 0.15f; //default settings
        if (beam_Length == 0) beam_Length = 2f;
        if (extendSpeed == 0) extendSpeed = 5;

    }
    void Update()
    {
        //temp = transform.localScale;
        //temp.y = 2f;

        if (Input.GetKeyDown(KeyCode.Space)) //extends/de-tends light on button press.          //TODO change later to work with VR controls instead of spacebar.
        {
            if (isActivated == true)
            {
                isActivated = false; //TODO optional play sound here.
            }
            else isActivated = true; //TODO optional play sound here.
        }
        if (isActivated == true)
        {
            //Lerp() moves between 2 different positions.
            transform.localScale = new Vector3(x: beam_Width, y: beam_Length, z: beam_Width);
            //endPosition.localPosition = Vector3.Lerp(endPosition.localPosition, extendedPosition, Time.deltaTime * (extendSpeed));
        }
        else transform.localScale = new Vector3(x: beam_Width, y: 0.01f, z: beam_Width);


        //line.SetPosition(0, startPosition.position); //these are the 2 inputs for start-position and end-positon in Unity.  This updates the light position.
        //line.SetPosition(1, endPosition.position);
    }
}
// TODO    deltatime && pivote