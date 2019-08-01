using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OurPotan2 : MonoBehaviour
{
    public float xt;
    public float yt;
    public float zt;
    public float g = -9.8f;
    public float t = 0;
    public float timeAfter;

    public int potanDamage = 50;
    public GameObject explosion;

    public float expRadius = 0.3f;
    private EnemyHpUICannons enemyUI;

    public Vector3 startPos;
    public Vector3 endPos;
    // Start is called before the first frame update
    void Start()
    {
        enemyUI = GetComponent<EnemyHpUICannons>();
        startPos = this.transform.position;
        Debug.Log("startPos = " + startPos);
        endPos = GameObject.FindGameObjectWithTag("ENEMY").transform.position;
        Debug.Log("endPos = " + endPos);
    }

    // Update is called once per frame
    void Update()
    {
        TargetFire();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("ENEMY") || other.tag == "TERRAIN")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Debug.Log("60mm hit SomeThing");

            if (Physics.CheckSphere(transform.position, expRadius, 1 << LayerMask.NameToLayer("ENEMY")))
            {
                // Do Damage
                EnemyHpUICannons enemyUI = other.gameObject.GetComponent<EnemyHpUICannons>();
                if (enemyUI != null)
                {
                    enemyUI.TakeDamage(amount: potanDamage);
                    Debug.Log("60mm : Do Damage to Enemy");
                }

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

    public void TargetFire()
    {

        this.t += Time.deltaTime;

        xt = startPos.x + endPos.x * t;
        yt = startPos.y + endPos.y * t - 0.5f * g * t * t;
        zt = startPos.z + endPos.z * t;

        var potanFly = new Vector3(xt, yt, zt);

        //Debug.Log(potanFly);
        //Debug.Log(yt);
        this.transform.position = potanFly * Time.deltaTime * 1.0f;
    }
}

