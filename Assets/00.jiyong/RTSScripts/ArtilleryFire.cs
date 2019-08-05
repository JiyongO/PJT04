using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtilleryFire : MonoBehaviour
{
    public GameObject potan;
    public Transform FirePoint;
    public float force = 200f;
    float timeAfter;
    float delay = 3f;
    float radius = 2.2f;
    LayerMask layerMaskPlayer;
    Collider[] colliders;
    public AudioClip deathAClip;
    // Start is called before the first frame update
    void Start()
    {
        layerMaskPlayer = LayerMask.NameToLayer("ENEMY");
    }

    // Update is called once per frame
    void Update()
    {
        timeAfter += Time.deltaTime;
        if (Physics.CheckSphere(transform.position, radius, 1 << layerMaskPlayer))
        {
            colliders = Physics.OverlapSphere(transform.position, radius, 1 << layerMaskPlayer);
            Fire(colliders[0]);
            Debug.Log("P : Enemy In Sight");
        }
    }
    void Fire(Collider col)
    {
        if (timeAfter > delay)
        {
            //old version
            //{
            //    transform.LookAt(col.transform);
            //    GameObject potanInstance;
            //    potanInstance = Instantiate(potan, FirePoint.position, FirePoint.rotation);
            //    potanInstance.GetComponent<Rigidbody>().AddForce(FirePoint.forward * force);
            //    timeAfter = 0f;
            //}
            transform.LookAt(col.transform);
            Instantiate(potan, col.transform.position + Vector3.up * 0.2f, Quaternion.identity);
            timeAfter = 0f;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    private void OnEnable()
    {
        GameMgr.cannons.Add(gameObject);
    }
    private void OnDisable()
    {
        GameMgr.cannons.Remove(gameObject);
        GetComponent<AudioSource>().PlayOneShot(deathAClip);
    }
}
