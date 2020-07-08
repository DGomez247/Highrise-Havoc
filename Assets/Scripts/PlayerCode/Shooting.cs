using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public Transform casingPoint;
    public GameObject bulletPrefab;
    public GameObject bulletCasingPrefab;

    public float casingForce = 0.5f;
    public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if (PauseMenu.gameIsPaused == false)
            {
                Shoot();
                SoundManagerScript.PlaySound("firePistol");
            }
        }
    }

    void Shoot()
    {
       GameObject bullet =  Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        rbBullet.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);


        GameObject casing = Instantiate(bulletCasingPrefab, casingPoint.position, casingPoint.rotation);

        Rigidbody2D rbCasing = casing.GetComponent<Rigidbody2D>();
        rbCasing.AddForce(casingPoint.up * casingForce, ForceMode2D.Impulse);

        

        Destroy(bullet, 0.8f);
        Destroy(casing,5f);

    }


}
