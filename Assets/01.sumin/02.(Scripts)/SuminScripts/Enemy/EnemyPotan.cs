using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPotan : MonoBehaviour
{
    public int potanDamage = 50;
    public GameObject explosion;

    private float expRadius = 0.5f;
    private OurHpUICannon hpUICannon;
    private OurHpUISoldier hpUISoldier;

    void Start()
    {

    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag==("PLAYER") || other.tag=="TERRAIN")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Debug.Log("60mm hit something");

            if (Physics.CheckSphere(transform.position, expRadius, 1 << LayerMask.NameToLayer("PLAYER")))
            {
                hpUICannon = other.gameObject.GetComponent<OurHpUICannon>();
                hpUISoldier = other.gameObject.GetComponent<OurHpUISoldier>();
                // Do Damage
                if (hpUICannon != null)
                {
                    hpUICannon.TakeDamage1(amount: potanDamage);
                    Debug.Log("60mm : Do Damage to Player");
                }
                if(hpUISoldier != null)
                {
                    hpUISoldier.TakeDamage2(amount: potanDamage);

                }
            }

            Destroy(gameObject, 2f);
        }
        Destroy(this.gameObject,3f);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, expRadius);
    }
}
