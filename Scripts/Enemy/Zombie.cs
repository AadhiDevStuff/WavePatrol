using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy ,IDamagable
{
    public Transform shotPoint;
    public GameObject bullet;
    public float bulletSpeed = 20f;
   
    private float timeBtwShots;
    public float startTimeBtwShots;
    public int Health { get; set; }

    public override void Update()
    {
        base.Update();

        //checking if player is Alive
        if (player != null)
        {
            if (timeBtwShots <= 0)
            {
                Attack();
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }

        }
    }
    public override void Init()
    {
        base.Init();
        //health initialize
        Health = base.health;
    }
    public override void Damage(int damage)
    {
        base.Damage(damage);
    }
    public override void Attack()
    {
        base.Attack();
        Shoot();

    }

    void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, shotPoint.position, shotPoint.rotation);
        FindObjectOfType<AudioManager>().Play("enemyShoot");
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        rb.velocity = (transform.right * bulletSpeed);

        timeBtwShots = startTimeBtwShots;
    }

}
