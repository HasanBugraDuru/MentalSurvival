using System;

[Serializable]
public class FSMTransition
{
   public FSMDecision decision; // PlayerInRageOfAttack(sald�r� ya��lmas�n�n karar�) -> True or False
    public string TrueState;    // CurrentState -> AttackState
    public string FalseState;   // CurrentState -> PatrolState
}
