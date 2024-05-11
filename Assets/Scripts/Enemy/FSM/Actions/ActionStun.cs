using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionStun : FSMAction
{

        DecisionStun stun;
    [SerializeField] private float stunTimer;
    [SerializeField] private float stunReq;
    public override void Act()
    {
        GetStunned();
    }

    private void Awake()
    {
        stun = GetComponent<DecisionStun>();
    }
    private void GetStunned()
    {
        if (stunTimer < stunReq)
        {
            stunTimer += Time.deltaTime;

        }
        else
        {
            stun.isStunned = false;
            stunTimer = 0;
        }
    }
}
