
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
        private Button _saveButton;
        //private Button _exitButton;
        //private InputManager _inputCharacteristics;
        private SaveInputManager _dataSaver;
        public PersonalInfoAppState(IAppStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _dataSaver = new SaveInputManager();
        }

        public override void Enter()
        {
            _informationUIView = Object.FindObjectOfType<InformationUIView>();
            _informationUIView.ScreenTapped += OnScreenTapped;
            _informationUIView.ShowAllElements();

            //_inputCharacteristics = GameObject.FindGameObjectWithTag("Characteristics")?.GetComponent<InputManager>();
            //if (_inputCharacteristics == null)
            //{
            //    Debug.LogError("SInputCharecteristics instance not found!");
            //    return;
            //}

            //GameObject.FindGameObjectWithTag("Characteristics").SetActive(true);

            _saveButton = GameObject.FindGameObjectWithTag("SaveButton")?.GetComponent<Button>();

            if (_saveButton)
            {
                _saveButton.onClick.AddListener(HandleSave);
            }
            else
            {
                Debug.LogError("Save Button missing.");
            }

            //_exitButton = GameObject.FindGameObjectWithTag("ExitButton")?.GetComponent<Button>();

            //if (_exitButton)
            //{
            //    //_exitButton.onClick.AddListener(HandleSave);//////////back to main state
            //}
            //else
            //{
            //    Debug.LogError("Exit Button missing.");
            //}
        }

        public override void Exit()
        {
            _informationUIView.HideAllElements();

            if (_saveButton)
            {
                _saveButton.onClick.RemoveListener(HandleSave);
            }
        }

        private void OnScreenTapped()
        {

        } 

        private void HandleSave()
        {
            string data = _informationUIView.InputManager.GetInputCharecteristicsData();
            _dataSaver.SavePlayerData(data);

            //if (_inputCharacteristics)
            //{
            //    string data = _inputCharacteristics.GetComponent<InputManager>().GetInputCharecteristicsData();
            //    _dataSaver.SavePlayerData(data);
            //}
            _stateMachine.TransitionTo(AppStateType.TEST);
        }
    }
}
