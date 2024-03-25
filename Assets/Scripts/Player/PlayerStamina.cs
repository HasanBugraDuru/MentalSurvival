using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    [Header("Stamina")]
    [SerializeField] private PlayerStats stats;
    [SerializeField] private float LostSpeed;

    public void GainStamina()
    {
       if(stats.Stamina>=stats.MaxStamina) return;
        if (stats.Stamina <= 0)
        {
            Invoke("GainStamina2", 3);
        }else 
        {
            GainStamina2(); 
        }

    }    
    private void GainStamina2()
    {
        stats.Stamina += LostSpeed * Time.deltaTime;
    }
    public void LostStamina() 
    {
        stats.Stamina-=LostSpeed*Time.deltaTime; 
    }
}
