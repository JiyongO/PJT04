using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShell : MonoBehaviour
{
    public GameObject explosion;
    float expRadius = 0.3f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("PLAYER") || other.tag == "TERRAIN")
        {
            Instantiate(explosion, transform.position + (Vector3.up * 0.1f), Quaternion.identity);
            Debug.Log("60mm hit something");

            if (Physics.CheckSphere(transform.position, expRadius, 1 << LayerMask.NameToLayer("PLAYER")))
            {
                // Do Damage
                Debug.Log("60mm : Do Damage to Player");

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
