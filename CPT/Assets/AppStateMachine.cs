
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern
{
    internal class AppStateMachine : MonoBehaviour, IAppStateMachine
    {
        private IAppState _activeState;
        private AppStatesManager _statesManager;

        private void Awake()
        {
            _statesManager = new AppStatesManager(this);
        }

        private void Update()
        {
            _activeState?.Update();
        }

        public void TransitionTo(AppStateType targetStateType)
        {
            _activeState.Exit();
            _activeState = _statesManager.GetAppStateByType(targetStateType);
            _activeState.Enter();
        }

        private class AppStatesManager
        {
            private IAppStateMachine _stateMachine;
            private Dictionary<AppStateType ,IAppState> _states;


            public AppStatesManager(IAppStateMachine stateMachine)
            {
                InitializeStates();
            }

            public IAppState GetAppStateByType(AppStateType type)
            {
                return _states.GetValueOrDefault(type);
            }

            private void InitializeStates()
            {
                _states.Add(AppStateType.MAINMENU, IAppState.CreateMainMenuAppState(_stateMachine));
                _states.Add(AppStateType.PERSONAL_INFO, IAppState.CreatePersonalInfoAppState(_stateMachine));
                _states.Add(AppStateType.TEST_OVERVIEW, IAppState.CreateTestOverviewAppState(_stateMachine));
                _states.Add(AppStateType.WARMUP, IAppState.CreateWarmupAppState(_stateMachine));
                _states.Add(AppStateType.TEST, IAppState.CreateTestAppState(_stateMachine));
            }
        }
    }
}
