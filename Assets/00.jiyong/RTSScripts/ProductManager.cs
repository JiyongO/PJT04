using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductManager : MonoBehaviour
{
    public Transform startTr;
    GameObject unit;
    public Button soldierBtn;
    public Button cannonBtn;
    Button btn;
    float timeAfter;

    public void MakeUnit(string unitName)
    {
        if (unitName == "Soldiers")
            btn = soldierBtn;
        else
        {
            btn = cannonBtn;
        }
        StartCoroutine(MakingUnit(btn, unitName));
    }
    public IEnumerator MakingUnit(Button btnName, string unitName)
    {
        while (btnName.image.fillAmount < 1)
        {
            btnName.image.fillAmount += Time.deltaTime;
            yield return new WaitForSeconds(0.1f);
        }
        btnName.image.fillAmount = 0;
        Debug.Log("makeUnit " + unitName);
        unit = Resources.Load<GameObject>(unitName);
        Instantiate(unit, startTr.position, Quaternion.identity);
    }
}
