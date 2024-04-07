using System;

[Serializable]
public class FSMTransition
{
    public FSMDecision Decision; // PlayerInRageOfAttack(saldýrý yaðýlmasýnýn kararý) -> True or False
    public string TrueState;    // CurrentState -> AttackState
    public string FalseState;   // CurrentState -> PatrolState
}
