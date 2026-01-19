using UnityEngine;

namespace OtabapaLeague.Application.UI.Elements
{
    public class UINumberSelection : UIElement
    {
        public int CurrentValue => _currentNumber;
        
        [SerializeField]
		private UITextInput _numberText;
        [SerializeField] 
        private UIButton _increaseButton;
        [SerializeField] 
        private UIButton _decreaseButton;

        private int _currentNumber;
        
        public void SetNumber(int number)
        {
            _currentNumber = number;
            _numberText.Text = _currentNumber.ToString();
        }

        protected override void InitComponents()
        {
            base.InitComponents();
            _increaseButton.OnClick += OnIncreaseButtonClicked;
            _decreaseButton.OnClick += OnDecreaseButtonClicked;
        }
        
        private void OnDecreaseButtonClicked()
        {
            SetNumber(_currentNumber - 1);
        }

        private void OnIncreaseButtonClicked()
        {
            SetNumber(_currentNumber + 1);
        }
    }
}