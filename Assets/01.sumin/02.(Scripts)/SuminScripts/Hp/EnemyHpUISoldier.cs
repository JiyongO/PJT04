using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyHpUISoldier : MonoBehaviour
{
    public float SoldierHp = 100.0f;
    public float dicHp;
    public float skinSpeed = 2.5f;
    public Slider enemyHpsilder;

    private bool isDead;
    private bool isSinking;
    private bool damaged;
    private SphereCollider sphereCollider;
    private EnemyFire enemyFire;

    

    // Start is called before the first frame update
    void Start()
    {
        SoldierHp = dicHp;
        sphereCollider = GetComponent<SphereCollider>();
        enemyFire = GetComponent<EnemyFire>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TaakeDamage(int amount)
    {
        damaged = true;

        dicHp -= amount;

        enemyHpsilder.value = dicHp;

        if(dicHp <= 0 && !isDead)
        {
            Death();
        }


    }

 void Death()
    {
        isDead = true;
        Debug.Log("soldier Death");
        startSinking();
        enemyFire.enabled = false;
    }

    public void startSinking()
    {
        GetComponent<NavMeshAgent>().enabled = false;

        isSinking = true;

        Destroy(gameObject, 0.5f);
    }
}
