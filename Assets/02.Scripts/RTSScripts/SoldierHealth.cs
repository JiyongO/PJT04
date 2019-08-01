using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoldierHealth : MonoBehaviour
{
    public Image health;
    void OnDamage()
    {
        if (health.fillAmount > 0)
        {
            health.fillAmount -= 0.1f;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
