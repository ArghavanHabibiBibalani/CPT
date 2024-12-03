
using UnityEngine;

namespace StatePattern
{
    internal class WarmupAppState : AbstractAppState
    {
        private TestUIView _testUIView;
        private TestManager _testManager;

        public WarmupAppState(IAppStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public override void Enter()
        {
            _testUIView = Object.FindObjectOfType<TestUIView>();
            _testManager = new TestManager(AppStateMachine.Instance.testSettings, _testUIView, true); // Fix the dependencies      
        }

        public override void Update() // May be unnecessary
        {
            // Take and handle tap inputs?
        }

        public override void Exit()
        {
            throw new System.NotImplementedException();
            // Make the WarmupUIView do stuff
            // Wrap up the warmup test?
        }

        public override void Reset() // May be unnecessary
        {
            throw new System.NotImplementedException();
            // Make the WarmupUIView do stuff
        }        
    }
}
