using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OurPotan2 : MonoBehaviour
{
    public int potanDamage = 50;
    public GameObject explosion;

    public float expRadius = 0.3f;
    private EnemyHpUICannons enemyUI;



    void Start()
    {
        enemyUI = GetComponent<EnemyHpUICannons>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("ENEMY") || other.tag == "TERRAIN")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Debug.Log("60mm hit SomeThing");

            if (Physics.CheckSphere(transform.position, expRadius, 1 << LayerMask.NameToLayer("ENEMY")))
            {
                // Do Damage
                EnemyHpUICannons enemyUI = other.gameObject.GetComponent<EnemyHpUICannons>();
                if (enemyUI != null)
                {
                    enemyUI.TakeDamage(amount: potanDamage);
                    Debug.Log("60mm : Do Damage to Enemy");
                }

            }

            Destroy(gameObject, 2f);
        }
        Destroy(this.gameObject, 3f);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, expRadius);
    }
}

