using System;

[Serializable]
public class FSMTransition
{
   public FSMDecision decision; // PlayerInRageOfAttack(saldýrý yaðýlmasýnýn kararý) -> True or False
    public string TrueState;    // CurrentState -> AttackState
    public string FalseState;   // CurrentState -> PatrolState
}
