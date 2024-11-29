
using UnityEngine;

namespace StatePattern
{
    internal class TestOverviewAppState : AbstractAppState
    {
        public TestOverviewAppState(IAppStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public override void Enter()
        {
            throw new System.NotImplementedException();
            // Make the TestOverViewUIView do stuff
        }
        public override void Update()
        {
            throw new System.NotImplementedException();
            // Handle Skip or NextSlide events here maybe?
        }

        public override void Exit()
        {
            throw new System.NotImplementedException();
            // Make the TestOverViewUIView do stuff
        }

        public override void Reset()
        {
            throw new System.NotImplementedException();
            // Make the TestOverViewUIView do stuff
        }
    }
}
