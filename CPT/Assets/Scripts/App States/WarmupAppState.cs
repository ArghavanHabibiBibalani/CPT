
using UnityEngine;

namespace StatePattern
{
    internal class WarmupAppState : AbstractAppState
    {
        [SerializeField] private CountdownSettings _countdownSettings;

        private TestManager _testManager;

        public WarmupAppState(IAppStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public override void Enter()
        {
            _testManager = new TestManager(_countdownSettings);
            
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
