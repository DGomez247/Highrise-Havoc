using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip playerFire,enemyFire;
    static AudioSource audiosrc;

    void Start()
    {
        playerFire = Resources.Load<AudioClip>("firePistol");

        enemyFire = Resources.Load<AudioClip>("enemyFirePistol");

        audiosrc = GetComponent<AudioSource>();
    }

    private void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip){
            case "firePistol":
                audiosrc.PlayOneShot(playerFire);
                break;

            case "enemyFirePistol":
                audiosrc.PlayOneShot(enemyFire);
                break;
        }
    }
}
