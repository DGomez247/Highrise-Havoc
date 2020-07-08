using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitArrow : MonoBehaviour
{
    public LMCode arrow;

    Animator anim;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(arrow.areAllEnemiesDead() == true)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            anim.SetTrigger("AllEnemiesDead");
        }
    }
}
