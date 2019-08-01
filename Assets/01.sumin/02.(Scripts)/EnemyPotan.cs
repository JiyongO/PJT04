using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPotan : MonoBehaviour
{
    public int potanDamage = 50;
    public GameObject explosion;

    private float expRadius = 0.3f;
    private HpUICannon hpUICannon;
    private HpUISoldier hpUISoldier;
    // Start is called before the first frame update
    void Start()
    {
        hpUICannon = GetComponent<HpUICannon>();
        hpUISoldier = GetComponent<HpUISoldier>();

    }

    // Update is called once per frame
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
                // Do Damage
                HpUICannon hpUICannon = other.gameObject.GetComponent<HpUICannon>();
                HpUISoldier hpUISoldier = other.gameObject.GetComponent<HpUISoldier>();
                if (hpUICannon != null)
                {
                    hpUICannon.TakeDamage(amount: potanDamage);
                    Debug.Log("60mm : Do Damage to Player");

                }
                else if (hpUISoldier !=null);
                {
                    hpUISoldier.TakeDamage(amount: potanDamage);
                    Debug.Log("Laser : Do Damage to Player");
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
