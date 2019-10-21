using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LS_Cylinder : MonoBehaviour
{
    //LineRenderer line; // this is what makes the light saber just a light.  can change it to an object with physics.

    [Header("Beam size")]
    public float beam_Width;
    public float beam_Length;
    public float extendSpeed;

    //extending on button press varables.
    public bool isOn;
    public bool isActivated;
    public bool testing = false;

    //public SteamVR_TrackedObject rightController = null;
    //public SteamVR_Controller.Device mDevice;

    //Vector3 temp; //Vector3 is a 3D position.

    void Start()
    {
        if (beam_Width == 0) beam_Width = 0.15f; //default settings
        if (beam_Length == 0) beam_Length = 2.5f;
        if (extendSpeed == 0) extendSpeed = 5;

    }


    void Update()
    {
        //Left: 14 triggers/ for extending lightsaber
        //Right: 15

        //Left: 11 grips while squeezed
        //Right: 12
        if (testing) {
            if (isOn == true && Input.GetButton("Submit")) {
                isActivated = false;
            }
            else if (Input.GetButton("Submit")) {
                isActivated = true;
            }









            if (isActivated) {
                isOn = true;
                transform.localScale = new Vector3(x: beam_Width, y: beam_Length, z: beam_Width);
            }

            if (!isActivated && isOn) {
                isOn = false;
                transform.localScale = new Vector3(x: beam_Width, y: 0.01f, z: beam_Width);
            }
        } else {
            //temp = transform.localScale;
            //temp.y = 2f;


            if (Input.GetKeyDown(KeyCode.Space)) //extends/de-tends light on button press.          //TODO change later to work with VR controls instead of spacebar.
            {
                if (isActivated == true) {
                    isActivated = false;
                } else isActivated = true;
            }
            if (isActivated == true) {
                Extend();
            } else Retract();
        }
    }

    //Lerp() moves between 2 different positions.
    //endPosition.localPosition = Vector3.Lerp(endPosition.localPosition, extendedPosition, Time.deltaTime * (extendSpeed));
    public void Extend() {
        isActivated = true;
    }

    public void Retract() {
        isActivated = false;
    }
}