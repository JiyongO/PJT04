using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class HpUICannon : MonoBehaviour
{
    public float cannonHp = 150.0f;
    public float currentHp;
    public float sinkSpeed = 2.5f;
    public Slider OurCannonHpSlider;

    private bool isDead;
    private bool isSinking;
    private bool damaged;
    private SphereCollider sphereCollider;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = cannonHp;
        sphereCollider = GetComponent<SphereCollider>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        damaged = true;
        currentHp -= amount;
        OurCannonHpSlider.value = currentHp;
        if(currentHp <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        Debug.Log("ourCannon dead");
        StartDestroy();
    }

    public void StartDestroy()
    {
        GetComponent<NavMeshAgent>().enabled = false;
        isSinking = true;

        Destroy(gameObject, 0.5f);
    }
}
