
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace StatePattern
{
    internal class TestAppState : AbstractAppState
    {
        private TestUIView _testUIView;
        private TestManager _testManager;
        private TestSettings _testSettings;

        private bool _isWarmup = true;

        public TestAppState(IAppStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _testSettings = AppStateMachine.Instance.testSettings;
        }

        public override void Enter()
        {
            _testUIView = Object.FindObjectOfType<TestUIView>();
            _testUIView.ScreenTapped += OnScreenTapped;
            _testUIView.ShowAllElements();

            _testManager = new TestManager(_testSettings, _testUIView);
            _testManager.WarmupFinished += OnWarmupFinished;
            _testManager.TestFinished += OnTestFinished;
            _testManager.BeginWarmup();
        }

        public override void Exit()
        {
            _testUIView.HideAllElements();
            Reset();
        }

        public override void Reset()
        {
            _isWarmup = true;
        }

        private void OnScreenTapped()
        {

        }

        private void OnWarmupFinished()
        {
            _testManager.BeginTest();
        }

        private void OnTestFinished()
        {

        }
    }
}
