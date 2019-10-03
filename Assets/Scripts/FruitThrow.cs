using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitThrow : MonoBehaviour
{
    [Header("Object RigidBody")]
    public Rigidbody rb;

    [Tooltip("If selected, Throw Positions don't do anything")]
    public bool randomThrow = false;
    public bool isChild = false;

    public GameObject OrangeChild;

    [Header("Throw Positions")]
    public int xThrow = 1;
    public int yThrow = 8;
    public int zThrow = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if(randomThrow == true) {
            if (!isChild) {
                rb.velocity = new Vector3(Random.Range(-4.0f, 4.0f), Random.Range(4.0f, 13.0f), Random.Range(-4f,4f));
            } else {
                rb.velocity = new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(2.0f, 5.0f), Random.Range(-1.0f,1.0f));
            }
            
        } else {
            rb.velocity = new Vector3(xThrow, yThrow, zThrow);
        }
    }
}
