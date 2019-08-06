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
    int soldierCount;
    int cannonCount;
    const int maxCount = 5;
    public Text soldierTxt;
    public Text cannonTxt;
    float makeSpeed;
    public AudioClip audioClip;

    public void MakeUnit(string unitName)
    {
        GetComponent<AudioSource>().PlayOneShot(audioClip);
        if (unitName == "Soldiers")
        {
            btn = soldierBtn;
            if (soldierCount >= maxCount)
                return;
            soldierCount++;
            soldierTxt.text = soldierCount.ToString();
        }

        else
        {
            btn = cannonBtn;
            if (cannonCount >= maxCount)
                return;
            cannonCount++;
            cannonTxt.text = cannonCount.ToString();
        }
        StartCoroutine(MakingUnit(btn, unitName));
    }
    public IEnumerator MakingUnit(Button btnName, string unitName)
    {
        while (btnName.image.fillAmount < 1)
        {
            if (unitName == "Soldiers")
                makeSpeed = 2f;
            btnName.image.fillAmount += Time.deltaTime*makeSpeed;
            yield return new WaitForSeconds(0.1f);
        }
        makeSpeed = 1f;
        btnName.image.fillAmount = 0;
        Debug.Log("makeUnit " + unitName);
        unit = Resources.Load<GameObject>(unitName);
        Instantiate(unit, startTr.position, Quaternion.identity);
        if (unitName == "Soldiers")
        {
            soldierCount--;
            soldierTxt.text = soldierCount.ToString();
        }
        else
        {
            cannonCount--;
            cannonTxt.text = cannonCount.ToString();
        }
    }
}
