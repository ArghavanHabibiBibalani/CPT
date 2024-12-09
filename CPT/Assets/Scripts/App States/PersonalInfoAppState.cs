
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Rendering.ShadowCascadeGUI;

namespace StatePattern
{
    internal class PersonalInfoAppState : AbstractAppState
    {
        private Button _saveButton;
        private Button _exitButton;
        private GameObject _inputCharacteristics;
        private SaveCharecteristicsData _dataSaver;
        public PersonalInfoAppState(IAppStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public override void Enter()
        {
            _inputCharacteristics = GameObject.FindGameObjectWithTag("Characteristics");
            if (_inputCharacteristics == null)
            {
                Debug.LogError("SInputCharecteristics instance not found!");
                return;
            }

            _inputCharacteristics.SetActive(true);

            _saveButton = GameObject.FindGameObjectWithTag("SaveButton")?.GetComponent<Button>();

            if (_saveButton)
            {
                _saveButton.onClick.AddListener(HandleSave);
            }
            else
            {
                Debug.LogError("Save Button missing.");
            }

            _exitButton = GameObject.FindGameObjectWithTag("ExitButton")?.GetComponent<Button>();

            if (_exitButton)
            {
                _exitButton.onClick.AddListener(HandleSave);//////////back to main state
            }
            else
            {
                Debug.LogError("Exit Button missing.");
            }
        }

        public override void Exit()
        {
            if (_saveButton)
            {
                _saveButton.onClick.RemoveListener(HandleSave);
            }
        }

        private void HandleSave()
        {
            if (_inputCharacteristics && _dataSaver)
            {
                string data = _inputCharacteristics.GetInputCharecteristicsData();
                _dataSaver.SavePlayerData(data);
            }


            //////////////////////////next state here
        }
    }
}
