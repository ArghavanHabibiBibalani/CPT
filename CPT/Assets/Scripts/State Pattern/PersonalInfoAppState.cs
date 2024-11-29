
using TMPro;
using UnityEngine;

namespace StatePattern
{
    internal class PersonalInfoAppState : AbstractAppState
    {
        public PersonalInfoAppState(IAppStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public override void Enter()
        {
            throw new System.NotImplementedException();
            // Make the PersonalInfoUIView do stuff
        }

        public override void Update()
        {
            throw new System.NotImplementedException();
            // Take PersonalInfoUIView's Input maybe?
        }

        public override void Exit()
        {
            throw new System.NotImplementedException();
            // Make the PersonalInfoUIView do stuff
        }

        public override void Reset()
        {
            throw new System.NotImplementedException();
            // Make the PersonalInfoUIView do stuff
        }
    }
}
