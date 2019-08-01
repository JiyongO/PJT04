using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUnit : MonoBehaviour
{
    private GameObject soldier;
    private GameObject cannon;

    private Ray ray;
    private RaycastHit hit;

    private float maxDist = 100.0f;

    private LayerMask layerMaskTerrain;

    // Start is called before the first frame update
    void Start()
    {
        layerMaskTerrain = LayerMask.NameToLayer("TERRAIN");
        soldier = Resources.Load("Soldier") as GameObject;
        cannon = Resources.Load("Cannon") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("x"))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, maxDist, 1 << layerMaskTerrain))
            {
                Instantiate(soldier, hit.point, Quaternion.identity);

            }
        }
        if (Input.GetKeyDown("z"))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, maxDist, 1 << layerMaskTerrain))
            {
                Instantiate(cannon, hit.point, Quaternion.identity);
            }
        }
    }
}
