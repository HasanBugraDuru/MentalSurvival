using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FSMState // AttackAction
{
    public string ID;
    public FSMAction[] Actions;  // MoveAtion |AttackAction|...
    public FSMTransition[] Transitions;


    public void UpdateState(EnemyBrain enemyBrain)
    {
        ExecuteActions();
        ExecuteTransition(enemyBrain);
    }
    private void ExecuteActions()
    {
        for (int i = 0; i < Actions.Length; i++)
        {
            Actions[i].Act();
        }
    }
    private void ExecuteTransition(EnemyBrain enemyBrain)
    {
        if (Transitions == null || Transitions.Length <= 0) return;
        for(int i = 0; i < Transitions.Length;i++)
        {
           bool value = Transitions[i].Decision.Decide();

            if(value)
            {
                enemyBrain.ChangeState(Transitions[i].TrueState);
            }
            else
            {
                enemyBrain.ChangeState(Transitions[i].FalseState);
            }
        }
    }
}
