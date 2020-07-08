using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public Sprite pistol, ar, shotgun;

    public SpriteRenderer spriteRenderer;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if(spriteRenderer == null)
        {
            spriteRenderer.sprite = pistol;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && Input.GetMouseButtonDown(1))
        {
            if(gameObject.tag == "AK")
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = ar;
            }

            if (gameObject.tag == "Pistol")
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = pistol;
            }
        }
    }
}
