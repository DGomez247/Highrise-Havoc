using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D myRB;

    public float moveSpeed;

    public float waitTime;

    private float currentWait;
    private bool shot;

    public Transform firePoint;
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
        if(isPatrol)
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
            if(Vector3.Distance(transform.position, currentPS.position) < 0.1f)
            {
                if(currentIndex + 1 < patrolSpots.Length)
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
                SoundManagerScript.PlaySound("enemyFirePistol");
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

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }
}
