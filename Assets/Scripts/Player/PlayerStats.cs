using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerStats", menuName ="Player Stats")]
public class PlayerStats : ScriptableObject
{
    [Header("Config")]

    [Header("Health")]
    public float Health;
    public float MaxHealth;

    [Header("Mental")]
    public float Mental;
    public float MaxMental;

    [Header("Hunger")]
    public float Hunger;
    public float MaxHunger;

    [Header("Sleep")]
    public float Sleep;
    public float MaxSleep;

    [Header("Heat")]
    public float Heat;
    public float MaxHeat;

    [Header("Stamina")]
    public float Stamina;
    public float MaxStamina;



    public  void ResetPlayer()
    {
        Health = MaxHealth;
        Mental = MaxMental;
        Hunger = MaxHunger;
        Sleep = MaxSleep;
        Heat = MaxHeat;
        Stamina = MaxStamina;
    }
}
