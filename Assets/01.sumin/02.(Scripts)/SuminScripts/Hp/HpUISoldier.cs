using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpUISoldier : MonoBehaviour
{
    public float soldierHp = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
//<<<<<<< HEAD:Assets/02.Scripts/SuminScripts/Hp/HpUISoldier.cs

//=======
        transform.LookAt(Camera.main.transform);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0f, 0f);
//>>>>>>> 0a357a9214e5f3c7e0d8e5260be95330f12459a4:Assets/02.Scripts/SuminScripts/HealthUI.cs
    }
}
