using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject uiPrefab;
    public Transform target;
    Transform ui;
    Image healthSlider;
    private void Start()
    {
        ui = Instantiate(uiPrefab,target).transform;
        ui.SetParent(target);
        healthSlider = ui.GetChild(0).GetComponent<Image>();
    }
    void OnHealthChanged (int maxhealth, int currentHealth)
    {
        if (ui != null)
        {
            float healthPercentage = currentHealth / maxhealth;
            healthSlider.fillAmount=healthPercentage;

        }
    }
}
