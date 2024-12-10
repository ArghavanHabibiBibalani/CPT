using StatePattern;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace StatePattern
{
    internal class MainMenuAppState : AbstractAppState
    {
        private Button _startButton;
        private GameObject _inputCharacteristics;

        public MainMenuAppState(IAppStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public override void Enter()
        {
            _startButton = GameObject.Find("StartButton")?.GetComponent<Button>();
            _inputCharacteristics = GameObject.FindGameObjectWithTag("Characteristics");

            //TO DO: Add if else for this
            _inputCharacteristics.SetActive(false);

            if (_startButton != null)
            {
                _startButton.onClick.AddListener(OnStartButtonClicked);
            }
            else
            {
                Debug.LogError("Start Button is missing from the scene!");
            }
        }

        public override void Exit()
        {
            if (_startButton != null)
            {
                _startButton.onClick.RemoveListener(OnStartButtonClicked);
                GameObject.Find("StartButton").SetActive(false);
                _inputCharacteristics.SetActive(true);
            }
        }

        private void OnStartButtonClicked()//////////////////////////////////////////////////////////////////////
        {
            Debug.Log("Transitioning to PersonalInfo State");

            _stateMachine.TransitionTo(AppStateType.PERSONAL_INFO);
            
        }
    }
}
