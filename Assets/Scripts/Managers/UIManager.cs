using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] PlayerStats stats;

    [Header("Bars")]
    [SerializeField] private Image HealthBar;
    [SerializeField] private Image MentalBar;
    [SerializeField] private Image HungerBar;
    [SerializeField] private Image StaminaBar;

    [SerializeField] private TextMeshProUGUI HealthTMP;
    [SerializeField] private TextMeshProUGUI MentalTMP;
    [SerializeField] private TextMeshProUGUI HungerTMP;
    [SerializeField] private TextMeshProUGUI StaminaTMP;
 
    private void Update()
    {
        UpdatePlayerUI();
    }
    private void UpdatePlayerUI()
    {
       
        HealthBar.fillAmount = Mathf.Lerp(HealthBar.fillAmount,
            stats.Health / stats.MaxHealth, 10f * Time.deltaTime);
        MentalBar.fillAmount = Mathf.Lerp(MentalBar.fillAmount,
            stats.Mental / stats.MaxMental, 10f * Time.deltaTime);
        HungerBar.fillAmount = Mathf.Lerp(HungerBar.fillAmount,
            stats.Hunger / stats.MaxHunger, 10f * Time.deltaTime);
        StaminaBar.fillAmount = Mathf.Lerp(StaminaBar.fillAmount,
            stats.Stamina / stats.MaxStamina, 10f * Time.deltaTime);

        HealthTMP.text = $"{stats.Health} / {stats.MaxHealth}";
        MentalTMP.text = $"{stats.Mental} / {stats.MaxMental}";
        HungerTMP.text = $"{stats.Hunger} / {stats.MaxHunger}";
        StaminaTMP.text = $"{Mathf.Round(stats.Stamina)} / {stats.MaxStamina}";
    }
}
