using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceThrow : MonoBehaviour
{
    private GameObject player;
    private GameObject invisableObject1;
    private GameObject invisableObject2;
    private Transform itemToRotate;
    //private Vector3 playerHandLocation; //starting location unless boundToHand == true.
    //private Vector3 throwDestination;
    private bool boundToHand = false, movingFoward = false;
    private Vector3 endingLocation;
    //private float currentLocation, x = 0, endDistance;

    [Header("Throw Settings")]
    public string object_throwing = ""; //handName
    public string object_being_thrown_invis1 = ""; // name of the handle
    public string object_being_thrown_invis2 = ""; // name of the beam
    public float throw_Distance = 10;
    public float throwHeight = 1.5f;
    public float speed = 2;
    public float seconds_taken = 5;
    public float DPS = 360; //degrees-rotated per second
    public double destroy_distance = 2; //distance at which the clone is destroyed and the original re-appears

    /*private float currentTime;
    private float startTime;
    public float coolDown_Seconds = 3;
    private float coolDown_LastUsed = -5;*/

    void Start()
    {
        BoomerangStart();
    }

    void Update()
    {
        BoomerangThrow();
        /*if (Input.GetKeyDown(KeyCode.F)) //TODO bring back cooldown and change keybind
        {
            if (Time.time > (coolDown_Seconds + coolDown_LastUsed))
            {
                coolDown_LastUsed = Time.time; //reset cooldown.

                //Make things move.
                if (boundToHand == true)
                {
                    BoomerangThrow();
                }
                else
                {
                    BoomerangThrow(); //temp
                }
            }
            else Debug.Log("Not ready.  " + (coolDown_Seconds + coolDown_LastUsed - Time.time) + " seconds until cooldown ready.");
        }*/
    }

    private void BoomerangStart()
    {
        movingFoward = false;
        if (object_throwing.Equals("")) object_throwing = "Your_Mom"; //default.  TODO set to right hand, and can make another default to left if wanted.
        if (object_being_thrown_invis1.Equals("")) object_being_thrown_invis1 = "superDetailedHandle";
        if (object_being_thrown_invis2.Equals("")) object_being_thrown_invis2 = "deathBeam";

        player = GameObject.Find(object_throwing);
        invisableObject1 = GameObject.Find(object_being_thrown_invis1); //make these objects invisable later
        invisableObject2 = GameObject.Find(object_being_thrown_invis2);
        invisableObject1.GetComponent<MeshRenderer>().enabled = false; //make main item held invisable and throw duplicate.
        invisableObject2.GetComponent<MeshRenderer>().enabled = false;

        itemToRotate = gameObject.transform.GetChild(0); //Find The Weapon That Is The Child Of The Empty Object

        endingLocation = new Vector3((player.transform.position.x), (player.transform.position.y + throwHeight), (player.transform.position.z)) + (player.transform.forward * throw_Distance); //end-locaton moves with player.
        StartCoroutine(Boom());
    }
    private void BoomerangThrow() //from hand.
    {
        itemToRotate.transform.Rotate( 0, Time.deltaTime * DPS, 0 );

        if (movingFoward)
        {
            transform.position = Vector3.MoveTowards(transform.position, endingLocation, Time.deltaTime * 40); //Change The Position To The Location In Front Of The Player
            //if (itemToRotate.transform.Rotate(yAngle:) < 35) { } //give innitial rotation
        }
        if (!movingFoward)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y + throwHeight, player.transform.position.z), Time.deltaTime * speed); //Return To Player
        }
        if (!movingFoward && Vector3.Distance(player.transform.position, transform.position) < 2) //TODO set last int to a reasonable distance from hand to destroy clone.
        {
            //Once It Is Close To The Player, Make The Player's Normal Weapon Visible, and Destroy The Clone
            invisableObject1.GetComponent<MeshRenderer>().enabled = true;
            invisableObject2.GetComponent<MeshRenderer>().enabled = true;
            Destroy(this.gameObject);
        }
    }
    IEnumerator Boom()
    {
        movingFoward = true;
        yield return new WaitForSeconds(seconds_taken); //one direction
        movingFoward = false;
    }
}


/*
playerHandLocation = new Vector3(x: -2f, y: 1f, z: -2f); //TODO find hand.
throwDestination = new Vector3(x: 2f, y: 1f, z: 2f); //TODO find location player is pointing...  or fake it with firing at +x.

/*currentTime = Time.deltaTime;
startTime = Time.deltaTime;
while ((currentTime-throw_Time) < startTime)
{
    transform.position = Vector3.Lerp(playerHandLocation, throwDestination, (currentTime-startTime)/throw_Time);
    currentTime = Time.deltaTime;
} infinite loop no matter which way it's pointed.  */

//Vector3.Lerp.GetComponent(playerHandLocation, throwDestination, throw_Time);
//transform.position = Vector3.Lerp(playerHandLocation, throwDestination, throw_Time);
