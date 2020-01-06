using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public int totalAmmo = 30;
    public int loadedAmmo = 10;
    private int reloadAmount;

    public float bulletForce = 20f;
    public GameObject reloadText;
    public GameObject outOfAmmoText;

    void Update()
    {
        if (totalAmmo > 0)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Reload();
            }
        }

        if (loadedAmmo > 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                loadedAmmo--;
                Shoot();
            }
        }

        else if (totalAmmo <= 0)
        {
            outOfAmmoText.SetActive(true);
            
        }

        else if (loadedAmmo <= 0)
        {
            reloadText.SetActive(true);
        }

    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        FindObjectOfType<AudioManager>().Play("playerShoot");
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    void Reload()
    {
        reloadAmount = 10 - loadedAmmo;
        if(totalAmmo > reloadAmount)
        {
            totalAmmo -= reloadAmount;
            loadedAmmo += reloadAmount;
            reloadText.SetActive(false);
        }
        
        else if(totalAmmo <= reloadAmount && totalAmmo > 0)
        {
            loadedAmmo += totalAmmo;
            totalAmmo -= totalAmmo;
            reloadText.SetActive(false);
        }
    }
}
