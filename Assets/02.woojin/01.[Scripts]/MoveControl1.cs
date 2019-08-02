using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class MoveControl1 : MonoBehaviour
{
    SelectableUnitComponent selectableScript;
    public NavMeshAgent nmAgent;
    int wpCount = 0;
    MoveManager mm;
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
    // 시뮬레이션 시작 버튼에서 처음 실행 
    public void MoveArmy()
    {
        //if (nmAgent.isStopped)
        nmAgent.SetDestination(LaserPointer.wpList[wpCount]);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("P : Enter Trigger");
        if (other.CompareTag("WAYPOINT"))
        {
            Debug.Log("enter wp" + wpCount);
            if (wpCount < LaserPointer.wpList.Count - 1)
            {
                //Debug.LogFormat("??? {0} < {1}" , wpCount, MoveManager.wpList.Count-1);
                wpCount++;
                MoveArmy();
            }
        }
    }
}
