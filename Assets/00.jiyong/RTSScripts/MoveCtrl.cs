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
    public bool isMoving;
    [SerializeField]
    bool isKeyA_Pressed;
    void Start()
    {
        nmAgent = GetComponent<NavMeshAgent>();
        selectableScript = GetComponent<SelectableUnitComponent>();
        layerMaskTerrain = LayerMask.NameToLayer("TERRAIN");
    }

    void Update()
    {
        if (selectableScript.selectionCircle != null)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                isKeyA_Pressed = true;
                Debug.Log("A pressed");
                return;
            }
            if (isKeyA_Pressed)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    Debug.Log("Soldier Attacking");
                    isKeyA_Pressed = false;
                    isMoving = false;
                    Move();
                }
                else if (Input.GetMouseButtonDown(0))
                {
                    isKeyA_Pressed = false;
                    Debug.Log("A released");
                }
            }
            else if (!isKeyA_Pressed && Input.GetMouseButtonDown(1))
            {
                Debug.Log("Soldier Move");
                isMoving = true;
                Move();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                isMoving = false;
                nmAgent.isStopped = true;
            }
        }
    }
    void Move()
    {
        nmAgent.isStopped = false;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, maxDist, 1 << layerMaskTerrain))
        {
            nmAgent.SetDestination(hit.point);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("P_Soldier : Enter Trigger " + other.name);
    }
}
