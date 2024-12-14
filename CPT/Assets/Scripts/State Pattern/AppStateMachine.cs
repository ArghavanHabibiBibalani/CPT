
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StatePattern
{
    internal class AppStateMachine : PersistentSingletonMonoBehaviour<AppStateMachine>, IAppStateMachine
    {
        [SerializeField] private TestSettings _testSettings;

        private IAppState _activeState;
        private AppStatesManager _statesManager;

        public TestSettings testSettings { get => _testSettings; }

        protected override void Awake()
        {
            base.Awake();
            _statesManager = new AppStatesManager(this);
            Screen.SetResolution(1920, 1080, true);
        }

        private void Start()
        {
            SetInitialState();
        }

        private void Update()
        {
            _activeState?.Update();
        }

        private void SetInitialState()
        {
            _activeState = _statesManager.GetAppStateByType(AppStateType.PERSONAL_INFO);
            _activeState.Enter();
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
                _stateMachine = stateMachine;
                _states = new Dictionary<AppStateType, IAppState>();
                InitializeStates();
            }

            public IAppState GetAppStateByType(AppStateType type)
            {
                return _states.GetValueOrDefault(type);
            }

            private void InitializeStates()
            {
                _states.Add(AppStateType.PERSONAL_INFO, IAppState.CreatePersonalInfoAppState(_stateMachine));
                _states.Add(AppStateType.TEST_OVERVIEW, IAppState.CreateTestOverviewAppState(_stateMachine));
                _states.Add(AppStateType.TEST, IAppState.CreateTestAppState(_stateMachine));
            }
        }
    }
}
