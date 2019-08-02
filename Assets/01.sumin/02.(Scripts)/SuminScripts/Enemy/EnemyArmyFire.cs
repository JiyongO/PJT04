using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArmyFire : MonoBehaviour
{
    private Ray ray = new Ray ();
    private RaycastHit hit;

    private float maxDist = 10.0f;
    private float timeAfter;
    private float delay = 0.5f;
    private float radius = 1.0f;

    private Transform tr;
    private Transform enemyTr;
    private Collider[] coll;

    private LayerMask layerMaskEnemy;
    [SerializeField]

    public Transform shootPoint;
    public int damage = 30;
    private OurHpUISoldier ourHpSoldier;
    void Start()
    {
        tr = GetComponent<Transform>();
        layerMaskEnemy = LayerMask.NameToLayer("PLAYER");
    }
        

    void Update()
    {
        timeAfter += Time.deltaTime;
        if (Physics.CheckSphere(transform.position, 1f, 1 << layerMaskEnemy))
        {
            enemyTr = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<Transform>();
            coll = Physics.OverlapSphere(transform.position, radius, 1 << layerMaskEnemy);
            enemyTr = coll[0].transform;

            Debug.Log("Player : Enemy insight");
            tr.LookAt(enemyTr.position);

            Debug.DrawRay(ray.origin, ray.direction, Color.green);
            AttackStart();
            Debug.Log("적이 맞췄음");
            
        }
        else if(!Physics.CheckSphere(transform.position, 1f, 1 << layerMaskEnemy))
        {

        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 1f);
    }

    void AttackStart()
    {
        
        if (timeAfter > delay)
        {
            Debug.Log("적군이 쏨");
            
            timeAfter = 0f;
            //gunLight.enabled = true;

            ray.origin = shootPoint.position;
            ray.direction = shootPoint.forward;
            

            if (Physics.Raycast(ray, out hit, 1f, 1 << layerMaskEnemy))
            {
                ourHpSoldier = hit.collider.GetComponent<OurHpUISoldier>();
                Debug.DrawRay(ray.origin, ray.direction, Color.green);
                    Debug.Log("적군 레이저");
                
                if(ourHpSoldier != null)
                {
                    ourHpSoldier.TakeDamage2(amount: damage);
                }
                
            }
        }
    }
}
