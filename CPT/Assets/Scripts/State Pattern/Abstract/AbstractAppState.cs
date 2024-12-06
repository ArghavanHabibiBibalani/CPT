
using UnityEngine;

namespace StatePattern
{
    internal abstract class AbstractAppState : IAppState
    {
        protected IAppStateMachine _stateMachine;

        public virtual void Enter() { }

        public virtual void Update() { }

        public virtual void Exit() { }

        public virtual void Reset() { }
    }
}
