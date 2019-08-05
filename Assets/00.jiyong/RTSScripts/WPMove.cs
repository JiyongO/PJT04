using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPMove : MonoBehaviour
{
    public GameObject[] wp;
    int count = 0;
    float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, wp[count].transform.position, Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WAYPOINT")
        {
            Debug.Log("waypoint " + count);
            if(count == wp.Length - 1)
            {
                count = 0;
            }
            else
            {
            }
                count++;
        }
    }
}
