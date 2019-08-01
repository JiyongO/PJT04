//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PotanDist : MonoBehaviour
//{
//    private Transform tr;
//    private Transform enemyTr;

//    private MoveControl moveCtrl;
//    private OurPotan ourPotan;

//    private Vector3 startPos;
//    private Vector3 endPos;
//    private Vector3 targetPos;

//    public GameObject potan;
//    public Transform potanFire;
//    private LayerMask layerEnemy;

//    void Start()
//    {
//        tr = GetComponent<Transform>();
//        moveCtrl = GetComponent<MoveControl>();
//        layerEnemy = LayerMask.NameToLayer("ENEMY");
//    }

//    void Update()
//    {

//        timeAfter += Time.deltaTime;

//        if (Physics.CheckSphere(transform.position, 2f, 1 << layerEnemy))
//        {
//            enemyTr = GameObject.FindGameObjectWithTag("ENEMY").transform;
//            targetPos = new Vector3(enemyTr.position.x, tr.position.y, enemyTr.position.z);

//            tr.LookAt(targetPos);

//            Debug.Log("찾음");
//            moveCtrl.nmAgent.speed = 0f;

//            TargetFire();
//        }
//        if(!Physics.CheckSphere(transform.position, 2f, 1 << layerEnemy))
//        {
//            enemyTr = null;
//            moveCtrl.nmAgent.speed = 0.5f;
//        }
//    }

//    void TargetFire()
//    {
//        startPos = this.transform.position;
//        endPos = GameObject.FindGameObjectWithTag("ENEMY").transform.position;
//        this.t += Time.deltaTime;

//        xt = startPos.x + (endPos.x * t);
//        yt = startPos.y + (endPos.y * t) - (0.5f * g * t * t);
//        zt = startPos.z + (endPos.z);

//        var potanFly = new Vector3(xt, yt, zt);

//        Debug.Log(potanFly);

//        potanFly = potan.transform.position;

//    }
//}
