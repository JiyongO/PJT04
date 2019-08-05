using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMgr : MonoBehaviour
{
    // 각 오브젝트에서 Add
    public static List<GameObject> soldiers = new List<GameObject>();
    public static List<GameObject> cannons = new List<GameObject>();
    static public List<GameObject> enemySoldiers = new List<GameObject>();
    public static List<GameObject> enemyCannons = new List<GameObject>();

    //에디터에서 할당
    public GameObject victory;
    public GameObject defeat;
    //GameObject[] go;

    // 에디터에서 할당
    public Text txtSoldiers;
    public Text txtCannons;
    public Text txtEnemySoldiers;
    public Text txtEnemyCannons;
    // Start is called before the first frame update
    void Start()
    {
        victory.SetActive(false);
        defeat.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        txtEnemySoldiers.text = string.Format("X {0}", enemySoldiers.Count);
        txtEnemyCannons.text = string.Format("X {0}", enemyCannons.Count);
        txtSoldiers.text = string.Format("X {0}", soldiers.Count);
        txtCannons.text = string.Format("X {0}", cannons.Count);

        Victory();
        Defeat();

    }

    

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    public void Victory()
    {
        if (victory.activeSelf == false && enemySoldiers.Count == 0 && enemyCannons.Count == 0 )
        {
            victory.SetActive(true);
        }
    }
    private void Defeat()
    {
        if (defeat.activeSelf == false && soldiers.Count == 0 && cannons.Count == 0)
        {
            defeat.SetActive(true);
        }
    }
}
