using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if(other.collider.tag == "Player"){
            Score.instance.scoreUp(1);
            Debug.Log("Score: " + Score.instance.getScore());
            Destroy(gameObject);
        }  
    }
}
