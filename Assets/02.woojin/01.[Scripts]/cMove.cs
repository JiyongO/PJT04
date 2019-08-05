using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cMove : MonoBehaviour
{
    
    Animator anim;

    bool Ischeering;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("im"))
        {
            anim.SetBool("Ischeering", true);
        }
    }
}
