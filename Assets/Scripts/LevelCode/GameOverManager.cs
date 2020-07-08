using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
   // public int currentHP;
    

    
    Animator anim;

    
    void Awake()
    {
        anim = GetComponent<Animator>();
        //currentHP = GetComponent<PlayerHealth>().currentHealth;
    }

     void Update()
    {   
        if( playerHealth.currentHealth <= 0)
        {
            
            anim.SetTrigger("GameOver");

            
            if (Input.GetKeyDown(KeyCode.R))
            {

                SceneManager.LoadScene(1);
            }
        }
    }
}
