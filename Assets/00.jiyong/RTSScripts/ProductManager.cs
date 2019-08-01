using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductManager : MonoBehaviour
{
    public Transform startTr;
    GameObject unit;

    public void MakeUnit(string unitName)
    {
        Debug.Log("makeUnit "+ unitName);
        unit = Resources.Load<GameObject>(unitName);
        Instantiate(unit, startTr.position, Quaternion.identity);
    }
}
