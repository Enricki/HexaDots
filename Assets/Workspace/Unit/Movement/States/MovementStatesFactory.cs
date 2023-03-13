using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStatesFactory : StateFactory
{
    MovementController _context;
    public MovementStatesFactory(MovementController context) : base(context)
    {
        _context = context;
    }

    public IdleState Idle() { return new IdleState(_context, this); }
    public ReadyState Ready() { return new ReadyState(_context, this); }
    public MoveState Move() { return new MoveState(_context, this); }
}
