using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject potan;
    public Transform FirePoint;
    public float force = 200f;
    float timeAfter;
    float delay = 2f;
    float radius = 2f;
    LayerMask layerMaskPlayer;
    // Start is called before the first frame update
    void Start()
    {
        layerMaskPlayer = LayerMask.NameToLayer("PLAYER");
    }

    // Update is called once per frame
    void Update()
    {
        timeAfter += Time.deltaTime;
        if (Physics.CheckSphere(transform.position, radius, 1 << layerMaskPlayer))
            Fire();
    }
    void Fire()
    {
        if (timeAfter > delay)
        {
            GameObject potanInstance;
            potanInstance = Instantiate(potan, FirePoint.position, FirePoint.rotation);
            potanInstance.GetComponent<Rigidbody>().AddForce(FirePoint.forward * force);
            timeAfter = 0f;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    private void OnTriggerStay(Collider other)
    {        
        if (other.CompareTag("PLAYER"))
        {
            Debug.Log("E : stay");
            transform.LookAt(other.transform);
        }
    }
}
