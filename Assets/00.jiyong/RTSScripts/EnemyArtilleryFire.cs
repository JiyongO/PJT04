using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArtilleryFire : MonoBehaviour
{
    public GameObject potan;
    public Transform FirePoint;
    public float force = 200f;
    float timeAfter;
    float delay = 3f;
    float radius = 2.2f;
    LayerMask layerMaskPlayer;
    Collider[] colliders;
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
        {
            colliders = Physics.OverlapSphere(transform.position, radius, 1 << layerMaskPlayer);
            Fire(colliders[0]);
            Debug.Log("E : Player In Sight");
        }
    }
    void Fire(Collider col)
    {
        if (timeAfter > delay)
        {
            transform.LookAt(col.transform);
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
    private void OnEnable()
    {
            GameMgr.enemyCannons.Add(gameObject);
    }
    private void OnDisable()
    {
            GameMgr.enemyCannons.Remove(gameObject);
    }
}
