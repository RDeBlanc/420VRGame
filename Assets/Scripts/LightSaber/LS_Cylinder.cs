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
    public bool isActivated;

    //Vector3 temp; //Vector3 is a 3D position.

    void Start()
    {
        if (beam_Width == 0) beam_Width = 0.15f; //default settings
        if (beam_Length == 0) beam_Length = 2.5f;
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
                isActivated = false;
            }
            else isActivated = true;
        }
        if (isActivated == true)
        {
            Extend();
        }
        else Retract();
    }

    //Lerp() moves between 2 different positions.
    //endPosition.localPosition = Vector3.Lerp(endPosition.localPosition, extendedPosition, Time.deltaTime * (extendSpeed));
    public void Extend() {
        transform.localScale = new Vector3(x: beam_Width, y: beam_Length, z: beam_Width);
    }

    public void Retract() {
        transform.localScale = new Vector3(x: beam_Width, y: 0.01f, z: beam_Width);
    }
}