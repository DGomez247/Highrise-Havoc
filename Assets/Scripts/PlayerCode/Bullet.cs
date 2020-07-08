using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject hitEffectWall;

    public GameObject hitEffectPerson;

    public Transform pellets;

    public int bulletDamage;
    private void OnCollisionEnter2D(Collision2D collision
        )
    {
        if(collision.gameObject.tag == "Pellets")
        {

            Physics2D.IgnoreLayerCollision(8, 8, true);
            
            
        }

        if(collision.gameObject.tag == "Wall")
        {
            GameObject effect = Instantiate(hitEffectWall, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            Destroy(gameObject);
        }
        

        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(bulletDamage);
            GameObject effect = Instantiate(hitEffectPerson, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().HurtEnemy(bulletDamage);
            GameObject effect = Instantiate(hitEffectPerson, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            Destroy(gameObject);
        }
    }

    


}
