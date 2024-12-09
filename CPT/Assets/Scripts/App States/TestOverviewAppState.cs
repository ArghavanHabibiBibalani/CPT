
using UnityEngine;

namespace StatePattern
{
    internal class TestOverviewAppState : AbstractAppState
    {

        private OverviewUIView _overviewUIView;

        public TestOverviewAppState(IAppStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public override void Enter()
        {
            _overviewUIView = Object.FindObjectOfType<OverviewUIView>();
            _overviewUIView.ScreenTapped += OnScreenTapped;
            _overviewUIView.ShowOverviewPanel();
        }

        public override void Exit()
        {
            _overviewUIView.HideOverviewPanel();
        }

        private void OnScreenTapped()
        {
            _stateMachine.TransitionTo(AppStateType.WARMUP);
        }
    }
}
