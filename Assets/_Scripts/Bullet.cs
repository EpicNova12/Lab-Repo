using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        Destroy(gameObject);

        if(other.collider.tag == "Player")
        {
            FindObjectOfType<PlayerHealth>().TakeDamage(1);
            if(FindObjectOfType<PlayerHealth>().getHealth() <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        } 
        else if(other.collider.tag == "Enemy")
        {
            FindObjectOfType<EnemyController>().TakeDamage(1);
            if(FindObjectOfType<EnemyController>().getEHealth()<=0)
            {
                Destroy(other.gameObject);
            }
        }
    }
   
}
