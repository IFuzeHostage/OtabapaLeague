using System;
using OtabapaLeague.Application.UI.Elements;
using UnityEngine;

namespace OtabapaLeague.Application.UI.Windows.GameEditor
{
    public class GameEditorView : View
    {
        public event Action OnSubmitButtonClicked;
        public event Action OnCancelButtonClicked;
        
        public int FirstPlayerIndex => _firstPlayerDropdown.CurrentIndex;
        public int SecondPlayerIndex => _secondPlayerDropdown.CurrentIndex;
        
        public int FirstPlayerScore => _firstPlayerScoreSelection.CurrentValue;
        public int SecondPlayerScore => _secondPlayerScoreSelection.CurrentValue;
        
        [SerializeField]
        private UISelectionDropdown _firstPlayerDropdown;
        [SerializeField]
        private UISelectionDropdown _secondPlayerDropdown;
        
        [SerializeField]
        private UINumberSelection _firstPlayerScoreSelection;
        [SerializeField]
        private UINumberSelection _secondPlayerScoreSelection;
        
        [SerializeField]
        private TextButton _submitButton;
        [SerializeField]
        private TextButton _cancelButton;
        
        public void SetPlayerOptions(string[] playerNames)
        {
            _firstPlayerDropdown.SetList(new System.Collections.Generic.List<string>(playerNames));
            _secondPlayerDropdown.SetList(new System.Collections.Generic.List<string>(playerNames));
        }
        
        public void ClearSelections()
        {
            _firstPlayerDropdown.SetIndex(0);
            _secondPlayerDropdown.SetIndex(0);
            _firstPlayerScoreSelection.SetNumber(0);
            _secondPlayerScoreSelection.SetNumber(0);
        }

        public int GetFirstPlayerIndex()
        {
            return _firstPlayerDropdown.CurrentIndex;   
        }

        public int GetSecondPlayerIndex()
        {
            return _secondPlayerDropdown.CurrentIndex;
        }

        public int GetFirstPlayerScore()
        {
            return _firstPlayerScoreSelection.CurrentValue;
        }
        
        public int GetSecondPlayerScore()
        {
            return _secondPlayerScoreSelection.CurrentValue;
        }
        
        protected override void InitComponents()
        {
            base.InitComponents();
            _submitButton.OnClick += OnSubmitButtonClickedHandler;
            _cancelButton.OnClick += OnCancelButtonClickedHandler;
        }
        
        private void OnSubmitButtonClickedHandler()
        {
            OnSubmitButtonClicked?.Invoke();
        }
        
        private void OnCancelButtonClickedHandler()
        {
            OnCancelButtonClicked?.Invoke();
        }
    }
}