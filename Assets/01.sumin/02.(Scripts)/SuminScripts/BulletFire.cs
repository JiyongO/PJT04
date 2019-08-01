using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    public GameObject Potan;
    public Transform bulletPoint;
    public float force = 200f;

    private Transform tr;
    private Transform enemyTr;
    private float timeAfter;
    private float delay = 2f;
    private float radius = 2f;
    private LayerMask layerMaskEnemy;

    private MoveControl moveCtrl;
    private OurPotan2 ourPotan;

    private Vector3 targetPos;


    void Start()
    {
        tr = GetComponent<Transform>();
        moveCtrl = GetComponent<MoveControl>();
        layerMaskEnemy = LayerMask.NameToLayer("ENEMY");
        //ourPotan = GetComponent<OurPotan2>();
    }

    void Update()
    {
        timeAfter += Time.deltaTime;
        if (Physics.CheckSphere(transform.position, radius, 1 << layerMaskEnemy))
        {
            enemyTr = GameObject.FindGameObjectWithTag("ENEMY").GetComponent<Transform>();

            targetPos = new Vector3(enemyTr.position.x, tr.position.y, enemyTr.position.z);
            tr.LookAt(targetPos);
            Debug.Log("적찾음");
            moveCtrl.nmAgent.speed = 0f;
            Fire();
        }
        else if (!Physics.CheckSphere(transform.position, radius, 1 << layerMaskEnemy))
        {
            moveCtrl.nmAgent.speed = 0.5f;
        }
    }

    void Fire()
    {
        if (timeAfter > delay)
        {
            GameObject potanInstance;
            potanInstance = Instantiate(Potan, bulletPoint.position, bulletPoint.rotation);
            Debug.Log("적군에 포격");
            

            timeAfter = 0f;

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
