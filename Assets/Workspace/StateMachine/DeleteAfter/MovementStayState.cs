using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStayState : MovementBaseState
{
    public MovementStayState(MovementStateMachine currentContext, MovementStateFactory movementStateFactory)
        : base(currentContext, movementStateFactory)
    {

    }
    public override void CheckSwitchStates()
    {
        if (Context.IsSelected)
        {
            SwitchState(Factory.Ready());
        }
    }

    public override void EnterState()
    {

    }

    public override void ExitState()
    {

    }

    public override void InitializeSubState()
    {

    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }
}
