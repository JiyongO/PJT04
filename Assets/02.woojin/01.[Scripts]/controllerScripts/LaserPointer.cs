﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class LaserPointer : MonoBehaviour
{
    private SteamVR_Behaviour_Pose pose;
    private SteamVR_Input_Sources hand;
    private LineRenderer line;

    public bool isSettingWayPoint;
    public GameObject wayPoint;

    public static List<Vector3> wpList;
    public Canvas[] wpImage;
    int wpImageCount;

    [Header("Controller Setup")]
    public SteamVR_Input_Sources rightHand = SteamVR_Input_Sources.RightHand;

    //트리거  버튼의 클릭 이벤트에 반응할 액션
    public SteamVR_Action_Boolean trigger = SteamVR_Actions.default_InteractUI;

    private int UnitsCount = 0;

    bool isCreate = false;

    //라인의 최대 유효 거리
    public float maxDistance = 30.0f;
    //라인의 색상
    public Color color = Color.blue;
    public Color clickedColor = Color.green;

    //레이캐스트를 위한 변수 선언
    private RaycastHit hit;
    private Ray ray = new Ray();
    //컨트롤러의 transform 컴포넌트를 저장할 변수
    private Transform tr;

    //이벤트를 전달할 객체의 저장변수
    public GameObject prevObject;
    public GameObject currObject;

    public GameObject SoldierText;

    //pointer  프리팹을 저장할 변수
    private GameObject pointer;
    private LayerMask Layer;
    int s = 0;
    int t = 0;


    public enum Units_TYPE
    {
        NONE = -1, DIC_UNITS = 0, CUR_UNITS = 1
    }
    public Units_TYPE currUnits = Units_TYPE.NONE;
    [SerializeField]
    GameObject[] units;

    NavMeshAgent[] navMeshAgents;


    // Start is called before the first frame update
    void Start()
    {
        ray.origin = this.transform.position;
        ray.direction = this.transform.forward;

        wpList = new List<Vector3>();

        //컨트롤러의 Transform 컴포넌트를 저장
        tr = GetComponent<Transform>();
        Layer = LayerMask.NameToLayer("TERRAIN");

        //컨트롤러의 정보를 검출하기 위한 SteamVr_behaviour_pose 컴포넌트 추출
        pose = GetComponent<SteamVR_Behaviour_Pose>();
        //입력 소스 추출
        hand = pose.inputSource;

        // lineRenderer 생성
        CreatedLineRenderer();




        //프리팹을 Resources 폴더에서 로드해 동적을 생성
        GameObject _pointer = Resources.Load<GameObject>("Pointer");
        pointer = Instantiate<GameObject>(_pointer);
        units = new GameObject[2];
        units[0] = Resources.Load<GameObject>("OurArmy_end");
        units[1] = Resources.Load<GameObject>("OurCannon_end");

    }

    void CreatedLineRenderer()
    {
        //LineRenderer 생성
        line = this.gameObject.AddComponent<LineRenderer>();

        line.useWorldSpace = false;
        line.receiveShadows = false;

        //시작점과 끝점의 위치 설정
        line.SetPosition(0, Vector3.zero);
        line.SetPosition(1, new Vector3(0, 0, maxDistance));

        //라인의 너비 설정
        line.startWidth = 0.01F;
        line.endWidth = 0.02f;

        line.material = new Material(Shader.Find("Unlit/Color"));
        line.material.color = this.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(tr.position, tr.forward, out hit, maxDistance))
        {
            //현재 레이저 포인터로 가리키는 객체를 저장
            currObject = hit.collider.gameObject;
            //    //라인의 끝점의 위치를 레이캐스팅한 지점의 좌표로 변경
            line.SetPosition(1, new Vector3(0, 0, hit.distance));

            //   //포인터의 위치와 각도를 설정
            pointer.transform.position = hit.point + hit.normal * 0.01f;
            pointer.transform.rotation = Quaternion.LookRotation(hit.normal);

        }
        Debug.DrawRay(tr.position, tr.forward * 30f, Color.green);
        if (trigger.GetStateDown(rightHand))
        {
            Debug.Log("DDDDDDD");
            if (Physics.Raycast(tr.position, tr.forward, out hit, maxDistance, 1 << 5))
            {
                
                Debug.Log(hit.collider.gameObject.name);
                switch (hit.collider.tag)
                {
                    case "DICUNITS":
                        currUnits = Units_TYPE.DIC_UNITS;
                        Debug.Log("구닌");

                        break;
                    case "CURUNITS":
                        currUnits = Units_TYPE.CUR_UNITS;
                        Debug.Log("땅크");
                        break;
                    case "wp":
                        isSettingWayPoint = !isSettingWayPoint;
                        Debug.Log(isSettingWayPoint);
                        break;
                    case "st":
                        Debug.Log("스타떠");
                        StartSimulation();
                        break;
                    case "im":
                        Debug.Log("생성");
                        setUi();
                        break;


                }

            }
            if (Physics.Raycast(tr.position, tr.forward, out hit, maxDistance, 1 << Layer)
                                                    && trigger.GetStateDown(rightHand))
            {
                Debug.Log("ray Hit Ground");
                if (isSettingWayPoint)
                {
                    Debug.Log("clicked for wp");

                    {
                        Debug.Log("rayHit for wp");
                        wpList.Add(hit.point);
                        Instantiate(wayPoint, hit.point, Quaternion.identity);
                        Instantiate(wpImage[wpImageCount], (hit.point + new Vector3(0, 0.8f, 0)), Quaternion.identity);
                        wpImageCount++;

                    }
                }


                else
                {
                    Debug.Log("rigtHand " + (int)currUnits);
                  
                    switch(currUnits)
                    {
                        case Units_TYPE.CUR_UNITS:
                            if(t < 10)
                            {
                                Instantiate(units[(int)currUnits], hit.point, Quaternion.identity);
                                t++;
                            }
                            break;
                        case Units_TYPE.DIC_UNITS:
                            if(s<10)
                            {
                                Instantiate(units[(int)currUnits], hit.point, Quaternion.identity);
                                s++;
                            }
                            break;
                            
                    }
                    
                    


                }
            }
            }
            }
            
          public  void StartSimulation()
            {
                navMeshAgents = FindObjectsOfType<NavMeshAgent>();
                foreach (var nmAgent in navMeshAgents)
                {
                    nmAgent.SendMessage("MoveArmy");
                }
            }
    void setUi()
    {
        SoldierText.SetActive(true);
    }


    }

        
   
    

