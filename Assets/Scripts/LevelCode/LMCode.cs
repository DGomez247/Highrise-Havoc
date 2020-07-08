using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LMCode : MonoBehaviour
{
    public Transform destination;

    public GameObject[] enemies;

    public bool enemiesDead = false;
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player") && areAllEnemiesDead() == true )
        {
            Debug.Log("hit trigger");
            SceneManager.LoadScene(2);
            //collision.transform.position = destination.position;
        }



    }

    public bool areAllEnemiesDead()
    {
        for(int x = 0;x < enemies.Length; x++)
        {
            if(enemies [x].tag != "Dead")
            {
                   
                return false;
            }
        }
        enemiesDead = true;
        return true;
    }


}
