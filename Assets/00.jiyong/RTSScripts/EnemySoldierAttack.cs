using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoldierAttack : MonoBehaviour
{
    float radidus = 1f;
    Animator[] anim;
    Collider[] colliders;

    int layerPlayer;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentsInChildren<Animator>();
        layerPlayer = LayerMask.GetMask("PLAYER");
    }

    // Update is called once per frame
    void Update()
    {
        Attack(layerPlayer);
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
                foreach (var animator in anim)
                {
                    animator.SetBool("Fire", true);
                }
            }

        }
        else
        {
            foreach (var animator in anim)
            {
                animator.SetBool("Fire", false);
            }
        }
    }
    private void OnEnable()
    {
        GameMgr.enemySoldiers.Add(this.gameObject);
    }
    private void OnDisable()
    {
        GameMgr.enemySoldiers.Remove(gameObject);
        GetComponent<AudioSource>().Play();
    }
}
