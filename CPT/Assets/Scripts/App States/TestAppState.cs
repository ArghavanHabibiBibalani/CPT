
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace StatePattern
{
    internal class TestAppState : AbstractAppState
    {
        private TestUIView _testUIView;
        private TestManager _testManager;
        private TestRecorder _testRecorder;
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
            _testUIView.ShowAllElements();

            _testRecorder = Object.FindObjectOfType<TestRecorder>();

            _testManager = new TestManager(_testSettings, _testUIView, _testRecorder);
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

        private void OnWarmupFinished()
        {
            _testManager.BeginTest();
        }

        private void OnTestFinished()
        {
            // Write recorder's data
            Debug.Log(_testRecorder.RecordedData());
        }
    }
}
