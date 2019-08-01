using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyHpUICannons : MonoBehaviour
{
    public float cannonHp = 150.0f;
    public float currentHp;
    public float sinkSpeed = 2.5f;
    public Slider enemyHpSilder;

    private bool isDead;
    private bool isSinking;
    private bool damaged;
    private SphereCollider sphereCollider;
    private EnemyFire enemyFire;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = cannonHp;
        sphereCollider = GetComponent<SphereCollider>();
        enemyFire = GetComponent<EnemyFire>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        damaged = true;

        currentHp -= amount;

        enemyHpSilder.value = currentHp;

        if(currentHp <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        Debug.Log("dead");
        StartSinking();
        enemyFire.enabled = false; 

        
    }

    public void StartSinking()
    {
        GetComponent<NavMeshAgent>().enabled = false; 
        //GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;

        Destroy(gameObject, 0.5f);
    }
}
