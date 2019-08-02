using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Valve.VR;

public class MoveManager_ : MonoBehaviour
{

    [Header("Controller Setup")]
    public SteamVR_Input_Sources rightHand = SteamVR_Input_Sources.RightHand;

    //트리거  버튼의 클릭 이벤트에 반응할 액션
    public SteamVR_Action_Boolean trigger = SteamVR_Actions.default_InteractUI;

    private RaycastHit hit;
    private Ray ray = new Ray();
    //컨트롤러의 transform 컴포넌트를 저장할 변수
    private Transform tr;
    public static bool isSettingWayPoint;
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
        tr = GetComponent<Transform>();
        wpList = new List<Vector3>();
        layerMaskTerrain = LayerMask.NameToLayer("TERRAIN");
    }

    // Update is called once per frame
    void Update()
    {

        if (isSettingWayPoint)
        {
            Debug.Log("clicked for wp");
            if (Physics.Raycast(tr.position, tr.forward, out hit, maxDist, 1 << layerMaskTerrain)
                                                                && trigger.GetStateDown(rightHand))
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
