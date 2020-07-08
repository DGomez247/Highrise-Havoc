using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int health;
    private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            //Destroy(gameObject);
            this.gameObject.tag = "Dead";
            this.GetComponent<EnemyController>().moveSpeed = 0;
            //this.GetComponent<EnemyController>().firePoint = null;
            this.GetComponent<CircleCollider2D>().enabled = false;
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<EnemyController>().enabled = false;
        }
    }

    public void HurtEnemy(int damage)
    {
        currentHealth -= damage;
    }
}
