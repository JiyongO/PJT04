using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveCtrl : MonoBehaviour
{
    SelectableUnitComponent selectableScript;
    NavMeshAgent nmAgent;
    Ray ray;
    RaycastHit hit;
    float maxDist = 100f;
    LayerMask layerMaskTerrain;
    void Start()
    {
        nmAgent = GetComponent<NavMeshAgent>();
        selectableScript = GetComponent<SelectableUnitComponent>();
        layerMaskTerrain = LayerMask.NameToLayer("TERRAIN");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && selectableScript.selectionCircle != null)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, maxDist, 1 << layerMaskTerrain))
            {
                nmAgent.SetDestination(hit.point);
                Debug.Log("Move");
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("P : Enter Trigger "+other.name);
    }
}
