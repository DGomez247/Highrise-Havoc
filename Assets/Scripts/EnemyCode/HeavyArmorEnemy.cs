using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyArmorEnemy : MonoBehaviour
{
    private Rigidbody2D myRB;

    public float moveSpeed;

    public float waitTime;

    private float currentWait;
    private bool shot;

    public Transform firePellet1;
    public Transform firePellet2;
    public Transform firePellet3;
    public Transform firePellet4;
    public Transform firePellet5;


    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    public Transform[] patrolSpots;
    Transform currentPS;
    int currentIndex;
    private bool isPatrol;
    public Transform target;

    public float chaseRange;

    public player_movement thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        thePlayer = FindObjectOfType<player_movement>();
        currentIndex = 0;
        currentPS = patrolSpots[currentIndex];
        isPatrol = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (isPatrol)
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
            if (Vector3.Distance(transform.position, currentPS.position) < 0.1f)
            {
                if (currentIndex + 1 < patrolSpots.Length)
                {
                    currentIndex++;
                }
                else
                {
                    currentIndex = 0;
                }
                currentPS = patrolSpots[currentIndex];
            }
            Vector3 PSDirection = currentPS.position - transform.position;
            float angle = Mathf.Atan2(PSDirection.y, PSDirection.x) * Mathf.Rad2Deg - 0f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 90f);
        }

        float distToPlayer = Vector3.Distance(transform.position, target.position);
        // chase and fire at player
        if (distToPlayer < chaseRange)
        {
            isPatrol = false;
            Vector3 targetdir = target.position - transform.position;
            float angle = Mathf.Atan2(targetdir.y, targetdir.x) * Mathf.Rad2Deg - 0f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 90f);
            transform.position = Vector2.MoveTowards(transform.position, thePlayer.transform.position, moveSpeed * Time.deltaTime);

            //transform.LookAt(thePlayer.transform.position);


            transform.right = thePlayer.transform.position - transform.position;

            if (currentWait == 0)
            {
                Shoot();
            }

            if (shot && currentWait < waitTime)
            {
                currentWait += 1 * Time.deltaTime;
            }

            if (currentWait >= waitTime)
            {
                currentWait = 0;
            }

        }
    }

    private void FixedUpdate()
    {
        //myRB.velocity = (transform.forward * moveSpeed);
        //constantly move towards player without vision
        //transform.position = Vector2.MoveTowards(transform.position, thePlayer.transform.position, moveSpeed * Time.deltaTime);
        //transform.right = thePlayer.transform.position - transform.position;
    }

    public void Shoot()
    {
        shot = true;

        GameObject pellet1 = Instantiate(bulletPrefab, firePellet1.position, firePellet1.rotation);
        
        
        
        


        Rigidbody2D rb1 = pellet1.GetComponent<Rigidbody2D>();
        rb1.AddForce(firePellet1.right * bulletForce, ForceMode2D.Impulse);

        

        GameObject pellet2 = Instantiate(bulletPrefab, firePellet2.position, firePellet2.rotation);
        Rigidbody2D rb2 = pellet1.GetComponent<Rigidbody2D>();
        rb2.AddForce(firePellet2.right * bulletForce, ForceMode2D.Impulse);

        GameObject pellet3 = Instantiate(bulletPrefab, firePellet3.position, firePellet3.rotation);
        Rigidbody2D rb3 = pellet1.GetComponent<Rigidbody2D>();
        rb3.AddForce(firePellet3.right * bulletForce, ForceMode2D.Impulse);

        GameObject pellet4 = Instantiate(bulletPrefab, firePellet4.position, firePellet4.rotation);
        Rigidbody2D rb4 = pellet1.GetComponent<Rigidbody2D>();
        rb4.AddForce(firePellet4.right * bulletForce, ForceMode2D.Impulse);

        GameObject pellet5 = Instantiate(bulletPrefab, firePellet5.position, firePellet5.rotation);
        Rigidbody2D rb5 = pellet1.GetComponent<Rigidbody2D>();
        rb5.AddForce(firePellet5.right * bulletForce, ForceMode2D.Impulse);
    }
}
