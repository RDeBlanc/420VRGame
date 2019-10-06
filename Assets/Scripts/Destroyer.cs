using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float lifeTime = 10f;
    public float closeness = 0.5f;
    // Update is called once per frame
    void Update()
    {
        if(lifeTime > 0) {
            lifeTime -= Time.deltaTime;
            if(lifeTime <= 0) {
                Destroy(this.gameObject);
            }
        }
        
        if(this.transform.position.y <= -20) {
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Upon entering the collider on the LightSaber it will destroy itself.
    /// </summary>
    /// <param name="collision">This will be the collider on the LightSaber weapon part</param>
    private void OnCollisionEnter(Collision collision) {
        if( (collision.gameObject.name == "LightSaber") || (collision.gameObject.name == "beamPivot") ) { //added the childName of the new lightsaber.
            //Casts Animation of Destruction. Needs coding and animation. AnimateDestruction();
            Destruction(collision.contacts[0]);
        }
    }

    /// <summary>
    /// Destroys the this gameobject which means it will destroy whatever object this script is attatched to.
    /// </summary>
    void Destruction(ContactPoint cp) {
        //Making left and right.
        Vector3 left = cp.point - this.transform.position;
        left = Vector3.Cross(left, Vector3.up).normalized * closeness;
        Vector3 right = -left;

        //change left
        GameObject leftChild = GameObject.Instantiate(GetComponent<FruitThrow>().OrangeChild);
        leftChild.transform.position = transform.position + left;
        leftChild.GetComponent<FruitThrow>().isChild = true;
        leftChild.GetComponent<FruitThrow>().randomThrow = true;

        //Change right
        GameObject rightChild = GameObject.Instantiate(GetComponent<FruitThrow>().OrangeChild);
        rightChild.transform.position = transform.position + right;
        rightChild.GetComponent<FruitThrow>().isChild = true;
        rightChild.GetComponent<FruitThrow>().randomThrow = true;
        Destroy(this.gameObject);
    }
}
