using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveManager : MonoBehaviour
{
    RaycastHit hit;
    public bool isSettingWayPoint;
    public GameObject wayPoint;
    LayerMask layerMaskTerrain;
    float maxDist = 100f;
    public static List<Vector3> wpList;
    public Canvas[] wpImage;
    int wpImageCount;

    NavMeshAgent[] navMeshAgents;
    // Start is called before the first frame update
    void Start()
    {
        wpList = new List<Vector3>();
        layerMaskTerrain = LayerMask.NameToLayer("TERRAIN");
    }

    // Update is called once per frame
    void Update()
    {
        if (isSettingWayPoint && Input.GetMouseButtonDown(0))
        {
            Debug.Log("clicked for wp");
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, maxDist, 1 << layerMaskTerrain))
            {
                Debug.Log("rayHit for wp");
                wpList.Add(hit.point);
                Instantiate(wayPoint, hit.point, Quaternion.identity);
                Instantiate(wpImage[wpImageCount], (hit.point + new Vector3(0, 0.8f, 0)), Quaternion.identity);
                wpImageCount++;
            }

        }
    }
    public void SetMakeWP()
    {
        isSettingWayPoint = !isSettingWayPoint;
    }
    public void StartSimulation()
    {
        navMeshAgents = FindObjectsOfType<NavMeshAgent>();
        foreach (var nmAgent in navMeshAgents)
        {
            nmAgent.SendMessage("MoveArmy");
        }
    }
}
