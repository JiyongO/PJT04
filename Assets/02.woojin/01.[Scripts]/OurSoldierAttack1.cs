using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OurSoldierAttack1 : MonoBehaviour
{
    private Ray ray = new Ray ();
    private RaycastHit hit;

    private float maxDist = 10.0f;
    private float timeAfter;
    private float delay = 0.5f;
    private float radius = 1f;

    private Transform tr;
    private Transform enemyTr;

    private LayerMask layerMaskEnemy;
    [SerializeField]
    private MoveControl1 moveCtrl1;
    private Collider[] coll;

    public Transform shootPoint;
    public int damage = 30;

    private EnemyHpUICannons enemyCannonHp;
    private EnemyHpUISoldier enemySoldierHp;

    void Start()
    {
        moveCtrl1 = GetComponent<MoveControl1>();
        
        tr = GetComponent<Transform>();
        layerMaskEnemy = LayerMask.NameToLayer("ENEMY");
    }

    void Update()
    {
        timeAfter += Time.deltaTime;
        if (Physics.CheckSphere(transform.position, 1f, 1 << layerMaskEnemy))
        {
            enemyTr = GameObject.FindGameObjectWithTag("ENEMY").GetComponent<Transform>();
            Debug.Log("Player : Enemy insight");
            coll = Physics.OverlapSphere(transform.position, radius, 1 << layerMaskEnemy);
            enemyTr = coll[0].transform;

            tr.LookAt(coll[0].transform.position);
            moveCtrl1.nmAgent.speed = 0f;

            Debug.DrawRay(ray.origin, ray.direction, Color.red);
            AttackStart();
            Debug.Log("아군이 맞췄음");
            
        }
        else if(!Physics.CheckSphere(transform.position, 1f, 1 << layerMaskEnemy))
        {
            enemyTr = null;
            moveCtrl1.nmAgent.speed = 0.5f;
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
            Debug.Log("아군이 쏨");
            
            timeAfter = 0f;

            ray.origin = shootPoint.position;
            ray.direction = shootPoint.forward;

            if (Physics.Raycast(ray, out hit, 1f, 1 << layerMaskEnemy))
            {
                enemyCannonHp = hit.collider.GetComponent<EnemyHpUICannons>();
                enemySoldierHp = hit.collider.GetComponent<EnemyHpUISoldier>();
                Debug.DrawRay(ray.origin, ray.direction, Color.red);
                    Debug.Log("아군 레이저");
                
                if(enemyCannonHp != null)
                {
                    enemyCannonHp.TakeDamage3(amount: damage);
                }
                else if(enemySoldierHp != null)
                {
                    enemySoldierHp.TakeDamage4(amount: damage);

                }
                
            }
        }
    }
    private void OnEnable()
    {
        GameMgr_.soldiers.Add(gameObject);
    }

    private void OnDisable()
    {
        GameMgr_.soldiers.Remove(gameObject);
    }
}
