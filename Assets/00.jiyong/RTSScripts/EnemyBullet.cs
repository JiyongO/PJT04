using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //transform.position += transform.forward * Time.deltaTime * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PLAYER"))
        {
            Debug.Log("Bullet : Hit Player");
            other.SendMessage("OnDamage");
            Destroy(gameObject);
        }
        else if (other.CompareTag("TERRAIN"))
        {
            Destroy(gameObject);
        }
    }
}
