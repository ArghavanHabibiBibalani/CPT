
using UnityEngine;

namespace StatePattern
{
    internal class WarmupAppState : AbstractAppState
    {
        public WarmupAppState(IAppStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public override void Enter()
        {
            throw new System.NotImplementedException();
            // Make the WarmupViewUIView do stuff
            // Initialize the warmup test?
        }

        public override void Update()
        {
            throw new System.NotImplementedException();
            // Take and handle tap inputs?
        }

        public override void Exit()
        {
            throw new System.NotImplementedException();
            // Make the WarmupViewUIView do stuff
            // Wrap up the warmup test?
        }

        public override void Reset()
        {
            throw new System.NotImplementedException();
            // Make the WarmupViewUIView do stuff
        }
    }
}
