using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OurPotan2 : MonoBehaviour
{
    public int potanDamage = 50;
    public GameObject explosion;

    public float expRadius = 0.5f;

    private EnemyHpUICannons enemyHpCannon;
    private EnemyHpUISoldier enemyHpSoldier;

    void Start()
    {
        Destroy(this.gameObject, 3f);
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
                enemyHpCannon = other.gameObject.GetComponent<EnemyHpUICannons>();
                enemyHpSoldier = other.gameObject.GetComponent<EnemyHpUISoldier>();
                if (enemyHpCannon != null)
                {
                    enemyHpCannon.TakeDamage3(amount: potanDamage);
                    Debug.Log("60mm : Do Damage to Enemy");
                }
                else if(enemyHpSoldier != null)
                {
                    enemyHpSoldier.TakeDamage4(amount: potanDamage);
                }
                Destroy(gameObject, 2f);
            }
        }
        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, expRadius);
        }
    }
}

