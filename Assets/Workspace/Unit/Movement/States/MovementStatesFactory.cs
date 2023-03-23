using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStatesFactory : StateFactory
{
    Unit _context;
    public MovementStatesFactory(Unit context) : base(context)
    {
        _context = context;
    }

    public IdleState Idle() { return new IdleState(_context, this); }
    public ReadyState Ready() { return new ReadyState(_context, this); }
    public MoveState Move() { return new MoveState(_context, this); }
}
