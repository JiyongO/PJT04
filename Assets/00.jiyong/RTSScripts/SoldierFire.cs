using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierFire : MonoBehaviour
{
    public GameObject bullet;
    float timeAfter;
    float delay = 1f;
    Animator animator;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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
        audioSource.Play();
        Instantiate(bullet, transform.position + Vector3.up * 0.1f, transform.rotation);
    }
}
