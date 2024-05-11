using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionAttackEnd : FSMDecision
{
    public bool attackEnded;
    public override bool Decide()
    {
        return CheckAttack();
    }

    public bool CheckAttack()
    {
        if (attackEnded) return true;
        else return false;
    }
   

}
