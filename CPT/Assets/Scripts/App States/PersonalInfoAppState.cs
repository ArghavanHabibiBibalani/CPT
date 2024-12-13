
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Rendering.ShadowCascadeGUI;

namespace StatePattern
{
    internal class PersonalInfoAppState : AbstractAppState
    {
        private InformationUIView _informationUIView;
        private SaveInputManager _dataSaver;
        public PersonalInfoAppState(IAppStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _dataSaver = Object.FindObjectOfType<SaveInputManager>();
        }

        public override void Enter()
        {
            _informationUIView = Object.FindObjectOfType<InformationUIView>();
            _informationUIView.SaveClicked += OnSaveClicked;
            _informationUIView.ShowAllElements();
            _dataSaver.ResetRowBuffer();
            Debug.Log("Entered info state");
        }

        public override void Exit()
        {
            _informationUIView.HideAllElements();
            _informationUIView.ResetElements();
        }

        private void OnSaveClicked()
        {
            Save();
            _stateMachine.TransitionTo(AppStateType.TEST_OVERVIEW);
        } 

        private void Save()
        {
            string data = _informationUIView.InputManager.GetInputCharacteristicsData();
            _dataSaver.SavePlayerData(data);
        }
    }
}
