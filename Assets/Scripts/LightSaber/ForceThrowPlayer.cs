using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceThrowPlayer : MonoBehaviour //connect this to the object that's throwing the boomerang.
{
    public GameObject boomerang;
    public float throw_start_height = 1.5f;
    void Start() {Debug.Log("Press 'f' to throw. (ForceThrow.cs)");}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject clone;
            clone = Instantiate(boomerang, new Vector3(transform.position.x, transform.position.y + throw_start_height, transform.position.z), transform.rotation) as GameObject;
        }
        
    }
}
