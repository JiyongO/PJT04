using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Billboard2 : MonoBehaviour
{

    void Update()
    {
        transform.LookAt(Camera.main.transform);
    }
}
