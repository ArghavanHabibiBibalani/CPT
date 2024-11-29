
using UnityEngine;

namespace StatePattern
{
    internal class TestAppState : AbstractAppState
    {
        public TestAppState(IAppStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public override void Enter()
        {
            throw new System.NotImplementedException();
            // Make the WarmupViewUIView do stuff
            // Initialize the test?
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
            // Finalize the test?
        }

        public override void Reset()
        {
            throw new System.NotImplementedException();
            // Make the WarmupViewUIView do stuff
        }
    }
}
