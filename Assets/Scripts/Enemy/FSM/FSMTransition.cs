using System;

[Serializable]
public class FSMTransition
{
    public FSMDecision Decision; // PlayerInRageOfAttack(sald�r� ya��lmas�n�n karar�) -> True or False
    public string TrueState;    // CurrentState -> AttackState
    public string FalseState;   // CurrentState -> PatrolState
}
