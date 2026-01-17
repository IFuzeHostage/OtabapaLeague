using System;
using UnityEngine;

namespace OtabapaLeague.Application.UI.Elements
{
    public class PlayerView : UIElement
    {
        public event Action OnEditButton;
        public event Action OnDeleteButton;
        
        [SerializeField]
        private UIText _nameText;
        [SerializeField]
        private UIText _scoreText;
        [SerializeField] 
        private UIText _tagText;
        [SerializeField]
        private UIButton _editButton;
        [SerializeField]
        private UIButton _deleteButton;

        public void SetName(string name)
        {
            _nameText.Text = name;
        }

        public void SetTag(string tag)
        {
            _tagText.Text = tag;
        }
        
        public void SetScore(int score)
        {
            _scoreText.Text = score.ToString();
        }

        protected override void InitComponents()
        {
            _editButton.OnClick += OnEditClicked;
            _deleteButton.OnClick += OnDeleteClicked;
            
            base.InitComponents();
        }

        private void OnEditClicked()
        {
            OnEditButton?.Invoke();
        }
        
        private void OnDeleteClicked()
        {
            OnDeleteButton?.Invoke();
        }
    }
}