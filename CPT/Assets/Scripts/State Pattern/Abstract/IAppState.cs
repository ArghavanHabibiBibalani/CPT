
using UnityEngine;

namespace StatePattern
{
    internal interface IAppState
    {
        public virtual void Enter() { }
        public virtual void Update() { }
        public virtual void Exit() { }
        public virtual void Reset() { }

        public static MainMenuAppState CreateMainMenuAppState(IAppStateMachine stateMachine)
        {
            return new MainMenuAppState(stateMachine);
        }

        public static PersonalInfoAppState CreatePersonalInfoAppState(IAppStateMachine stateMachine)
        {
            return new PersonalInfoAppState(stateMachine);
        }

        public static TestOverviewAppState CreateTestOverviewAppState(IAppStateMachine stateMachine)
        {
            return new TestOverviewAppState(stateMachine);
        }

        public static TestAppState CreateTestAppState(IAppStateMachine stateMachine)
        {
            return new TestAppState(stateMachine);
        }
    }
}
