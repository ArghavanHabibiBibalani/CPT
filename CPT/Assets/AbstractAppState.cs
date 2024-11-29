
using UnityEngine;

namespace StatePattern
{
    internal abstract class AbstractAppState : IAppState
    {
        protected IAppStateMachine _stateMachine;

        public abstract void Enter();

        public abstract void Update();

        public abstract void Exit();

        public abstract void Reset();
    }
}
