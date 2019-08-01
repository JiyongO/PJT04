using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour
{
    // 각 오브젝트에서 Add
    public static List<GameObject> soldiers = new List<GameObject>();
    public static List<GameObject> cannons = new List<GameObject>();
    static public List<GameObject> enemySoldiers = new List<GameObject>();
    public static List<GameObject> enemyCannons = new List<GameObject>();
    GameObject[] go;

    // 에디터에서 할당
    public Text txtSoldiers;
    public Text txtCannons;
    public Text txtEnemySoldiers;
    public Text txtEnemyCannons;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txtEnemySoldiers.text = string.Format("X {0}",enemySoldiers.Count);
        txtEnemyCannons.text = string.Format("X {0}", enemyCannons.Count);
        txtSoldiers.text = string.Format("X {0}", soldiers.Count);
        txtCannons.text = string.Format("X {0}", cannons.Count);
    }
}
