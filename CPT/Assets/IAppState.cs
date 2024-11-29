
using UnityEngine;

namespace StatePattern
{
    internal interface IAppState
    {
        public abstract void Enter();
        public abstract void Update();
        public abstract void Exit();
        public abstract void Reset();

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

        public static WarmupAppState CreateWarmupAppState(IAppStateMachine stateMachine)
        {
            return new WarmupAppState(stateMachine);
        }

        public static TestAppState CreateTestAppState(IAppStateMachine stateMachine)
        {
            return new TestAppState(stateMachine);
        }
    }
}
