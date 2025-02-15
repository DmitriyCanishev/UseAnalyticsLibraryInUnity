using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace App.View
{
    public class ButtonEventSender : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _eventNameInput = null;
        [SerializeField] private TMP_InputField _eventParamNameInput = null;
        [SerializeField] private TMP_InputField _eventParamValueInput = null;

        private AppState.AppState _appState = null;

        private void OnEnable()
        {
            _appState = FindObjectOfType<AppState.AppState>();
        }

        public void SendEvent()
        {
            if (_eventParamNameInput.text.Length > 0 && _eventParamValueInput.text.Length > 0)
            {
                var eventParams = new Dictionary<string, object>
                {
                    {_eventParamNameInput.text, _eventParamValueInput.text}
                };
                _appState.SendEvent(_eventNameInput.text, eventParams);
                return;
            }

            _appState.SendEvent(_eventNameInput.text);
        }
    }
}