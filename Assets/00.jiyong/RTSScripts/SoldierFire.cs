using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierFire : MonoBehaviour
{
    public GameObject bullet;
    float timeAfter;
    float delay = 1f;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timeAfter += Time.deltaTime;
        if (timeAfter > delay && animator.GetBool("Fire"))
        {
            timeAfter = 0f;
            FireBullet();
        }
    }
    void FireBullet()
    {
        Instantiate(bullet, transform.position + Vector3.up * 0.2f, transform.rotation);
    }
}
