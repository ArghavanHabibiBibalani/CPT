using StatePattern;

namespace StatePattern
{
    internal class MainMenuAppState : AbstractAppState
    {
        public MainMenuAppState(IAppStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public override void Enter()
        {
            throw new System.NotImplementedException();
            // Make the MainMenuUIView do stuff
        }

        public override void Update()
        {
            throw new System.NotImplementedException();
        }

        public override void Exit()
        {
            throw new System.NotImplementedException();
            // Make the MainMenuUIView do stuff
        }

        public override void Reset()
        {
            throw new System.NotImplementedException();
            // Make the MainMenuUIView do stuff
        }
    }
}
