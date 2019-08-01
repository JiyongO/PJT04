using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAttack : MonoBehaviour
{
    private Ray ray = new Ray ();
    private RaycastHit hit;

    private float maxDist = 10.0f;
    private float timeAfter;
    private float delay = 0.5f;

    private Transform tr;
    private Transform enemyTr;

    private LayerMask layerMaskEnemy;
    [SerializeField]
    private MoveControl moveCtrl;
    private Light gunLight;

    private EnemyHpUICannons enemyHpUI;

    public Transform shootPoint;
    public int damage = 30;

    void Start()
    {
        enemyHpUI = GetComponent<EnemyHpUICannons>();
        moveCtrl = GetComponent<MoveControl>();
        
        tr = GetComponent<Transform>();
        layerMaskEnemy = LayerMask.NameToLayer("ENEMY");

        gunLight = GetComponent<Light>();
    }

    void Update()
    {
        timeAfter += Time.deltaTime;
        if (Physics.CheckSphere(transform.position, 1f, 1 << layerMaskEnemy))
        {
            enemyTr = GameObject.FindGameObjectWithTag("ENEMY").GetComponent<Transform>();
            Debug.Log("Player : Enemy insight");
            tr.LookAt(enemyTr.position);
            moveCtrl.nmAgent.speed = 0f;
            Debug.DrawRay(ray.origin, ray.direction, Color.red);
            AttackStart();
            Debug.Log("hit");

        }
        else if(!Physics.CheckSphere(transform.position, 1f, 1 << layerMaskEnemy))
        {
            enemyTr = null;
            moveCtrl.nmAgent.speed = 0.5f;
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
            Debug.Log("skrksek");
            
            timeAfter = 0f;
            //gunLight.enabled = true;

            ray.origin = shootPoint.position;
            ray.direction = shootPoint.forward;

            if (Physics.Raycast(ray, out hit, 1f, 1 << layerMaskEnemy))
            {
                Debug.DrawRay(ray.origin, ray.direction, Color.red);
                    Debug.Log("ray");
                EnemyHpUICannons enemyHpUI = hit.collider.GetComponent<EnemyHpUICannons>();
                
                if(enemyHpUI != null)
                {
                    enemyHpUI.TakeDamage(amount: damage);
                }
                
            }
        }
    }
}
