using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPotanFire : MonoBehaviour
{
    public Transform bulletPrefab;
    public Transform bullet;

    private float tx;
    private float ty;
    private float tz;
    private float v;
    public float g = 9.8f;
    public float height = 3.0f;

    private float elapsed_time;
    private float t;

    private Transform start_Pos;
    private Transform end_Pos;

    private float dat;

    private Transform tr;
    private float timeAfter;
    private float delay = 3f;
    private float radius = 2f;
    private LayerMask layerMaskEnemy;

    private MoveControl1 moveCtrl;

    private Vector3 targetPos;
    private Collider[] coll;


    void Start()
    {
        tr = GetComponent<Transform>();
        moveCtrl = GetComponent<MoveControl1>();
        layerMaskEnemy = LayerMask.NameToLayer("PLAYER");
    }

    void Update()
    {
        timeAfter += Time.deltaTime;
        if (Physics.CheckSphere(transform.position, radius, 1 << layerMaskEnemy))
        {
            start_Pos = GetComponent<Transform>();
            coll = Physics.OverlapSphere(transform.position, radius, 1 << layerMaskEnemy);

            end_Pos = coll[0].transform;
            //end_Pos = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<Transform>();

            targetPos = new Vector3(end_Pos.position.x, tr.position.y, end_Pos.position.z);
            tr.LookAt(targetPos);

            //적을 LookAt 할 때 x축, z축을 고정시킴

            Shoot(height, coll[0]);

        }
        else if (!Physics.CheckSphere(transform.position, radius, 1 << layerMaskEnemy))
        {
            //isFire = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public void Shoot(float height, Collider coll)
    {
        //대포 쏠때 딜레이 시간
        if (timeAfter > delay)
        {
            timeAfter = 0f;

            this.height = height;

            bullet = Instantiate(bulletPrefab);
            bullet.position = start_Pos.position;

            Vector3 startPos = start_Pos.position;
            Vector3 endPos = end_Pos.position;

            //적군 y값 계산
            var dh = endPos.y - startPos.y;
            //현재 우리 대포의 y값 계산
            var mh = height - startPos.y;

            ty = Mathf.Sqrt(2 * this.g * mh);

            float a = this.g;
            float b = -2 * ty;
            float c = 2 * dh;

            dat = (-b + Mathf.Sqrt(b * b - 4 * a * c)) / (2 * a);

            tx = -(startPos.x - endPos.x) / dat;
            tz = -(startPos.z - endPos.z) / dat;
            //여기서 나온 tx, ty, tz 값은 아래 좌표 계산에 쓰임(참고)
            //나머지 수학적인 계산은 잘 모르겠음 ㅜㅜ
            this.elapsed_time = 0;
            StartCoroutine(ShootImpl());
            //isFire = true;
        }
    }

    //적군 위치값 계산
    IEnumerator ShootImpl()
    {
        //포탄 날아가는 시작점과 폭탄이 떨어지는 지점의 Vector 값
        Vector3 startPos = start_Pos.position;
        Vector3 endPos = end_Pos.position;

        while (true)
        {
            //폭탄이 최종적으로 떨어질 위치값 계산
            this.elapsed_time += Time.deltaTime;
            var tx = startPos.x + this.tx * elapsed_time;
            var ty = startPos.y + this.ty * elapsed_time - 0.5f * g * elapsed_time * elapsed_time;
            var tz = startPos.z + this.tz * elapsed_time;
            var tpos = new Vector3(tx, ty, tz);

            bullet.transform.LookAt(tpos);
            bullet.transform.position = tpos;

            if (this.elapsed_time >= this.dat)
                break;

            yield return null;
        }
    }
}
