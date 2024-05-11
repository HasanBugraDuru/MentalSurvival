using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionStun : FSMDecision
{
        public bool isStunned;




    public override bool Decide()
    {
        return DetectStun();
    }

    private bool DetectStun()
    {
        if (isStunned)
        {
            return true;
        }
        else return false;
    }
}

   
