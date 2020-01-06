using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int playerBulletDamageValue = 1;
    private int enemyBulletDamageValue = 1 ;
    private void Start()
    {
        Destroy(gameObject, 0.7f);
    }
  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Player>().Damage(enemyBulletDamageValue);
            Destroy(gameObject);
        }

        else if(other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().Damage(playerBulletDamageValue);
            Destroy(gameObject);
        }

        else if(other.CompareTag("Obstacles"))
        {
            Destroy(gameObject);
        }
       
    }
}
