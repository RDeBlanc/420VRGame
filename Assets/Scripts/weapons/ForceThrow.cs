using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceThrow : MonoBehaviour
{
    private Vector3 playerHandLocation; //starting location unless boundToHand == true.
    private Vector3 throwDestination;
    private bool boundToHand = false;
    private Transform startingLocation; //TODO do I need this or Vector3?
    private Transform endingLocation; //

    [Header("Throw Settings")]
    public float throw_DistanceTODO = 10;
    public float throw_Time = 1;
    public float RPS = 1;
    public float coolDown_Seconds = 3;
    private float coolDown_LastUsed = -5;

    private float currentTime;
    private float startTime;

    void Start()
    {
        //Debug.Log("Press 'f' to throw. (ForceThrow.cs)");
        //bind to players hand TODO
        //startingLocation.position = new Vector3 (x: 0f, y: 5f, z: 0f); //TODO find hand.
        //startingLocation = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    { 
        //check if bound to hand 1st.

        if (Input.GetKeyDown(KeyCode.F) )
        {
            if (Time.time > (coolDown_Seconds + coolDown_LastUsed))
            {
                coolDown_LastUsed = Time.time; //reset cooldown.
                Debug.Log("Cooldown used.  ");

                //Make things move.
                if (boundToHand == true)
                {

                }
                else
                {
                    playerHandLocation = new Vector3(x: -2f, y: 1f, z: -2f); //TODO find hand.
                    throwDestination = new Vector3 (x: 2f, y: 1f, z: 2f); //TODO find location player is pointing...  or fake it with firing at +x.

                    /*currentTime = Time.deltaTime;
                    startTime = Time.deltaTime;
                    while ((currentTime-throw_Time) < startTime)
                    {
                        transform.position = Vector3.Lerp(playerHandLocation, throwDestination, (currentTime-startTime)/throw_Time);
                        currentTime = Time.deltaTime;
                    } infinite loop no matter which way it's pointed.  */ 

                    //Vector3.Lerp.GetComponent(playerHandLocation, throwDestination, throw_Time);
                    //transform.position = Vector3.Lerp(playerHandLocation, throwDestination, throw_Time);
                    

                }
            }
            else Debug.Log("Not ready.  " + (coolDown_Seconds + coolDown_LastUsed - Time.time) + "Seconds remaining.");
            
        }
    }
}
