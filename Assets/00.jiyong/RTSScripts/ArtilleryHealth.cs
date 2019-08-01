using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtilleryHealth : MonoBehaviour
{
    public Image health;
    public Canvas healthCanvas;
    Quaternion startRot;
    private void Start()
    {
        startRot = healthCanvas.transform.rotation;

    }
    void Update()
    {
        healthCanvas.transform.rotation = startRot;
    }
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
