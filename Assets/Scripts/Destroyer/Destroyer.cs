using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Bird" || other.gameObject.tag == "Pig" || other.gameObject.tag == "Brick"){
            print("detected");
            Destroy(other.gameObject);
        }
    }
}
