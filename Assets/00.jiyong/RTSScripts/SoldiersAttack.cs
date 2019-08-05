using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SoldiersAttack : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    float radidus=1f;
    Animator[] anim;
    Collider[] colliders;
    int layerPlayer;
    MoveCtrl moveCtrl;
    float speed = 0.5f;
    public AudioClip deathAClip;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponentsInChildren<Animator>();
        layerPlayer = LayerMask.GetMask("ENEMY");
        moveCtrl = GetComponent<MoveCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!moveCtrl.isMoving)
        {
            Attack(layerPlayer);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radidus);
    }
    void Attack(int layerMask)
    {
        if (Physics.CheckSphere(transform.position, radidus, layerMask))
        {
            colliders = Physics.OverlapSphere(transform.position, radidus, layerMask);
            if (colliders != null)
            {
                transform.LookAt(colliders[0].transform.position);
                navMeshAgent.isStopped = true;
                foreach (var animator in anim)
                {
                    animator.SetBool("Fire", true);
                }
            }

        }
        else
        {
            navMeshAgent.isStopped = false;
            foreach (var animator in anim)
            {
                animator.SetBool("Fire", false);
            }
        }
    }
    private void OnEnable()
    {
        GameMgr.soldiers.Add(gameObject);
    }
    private void OnDisable()
    {
        GameMgr.soldiers.Remove(gameObject);
        GetComponent<AudioSource>().PlayOneShot(deathAClip);
    }
}
