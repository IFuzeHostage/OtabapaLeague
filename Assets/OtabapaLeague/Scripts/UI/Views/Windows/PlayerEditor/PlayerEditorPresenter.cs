using System;
using OtabapaLeague.Scripts.Domain.Systems.Players;
using Zenject;

namespace OtabapaLeague.Application.UI.Windows
{
    public class PlayerEditorPresenter : ViewPresenter<PlayerEditorView>
    {
        private readonly int _targetId;
        private readonly IPlayerManager _playerManager;
        private readonly Action<PlayerEditSubmitEventArgs> _editCallback;
        
        public PlayerEditorPresenter(int targetId, Action<PlayerEditSubmitEventArgs> submitCallback, IPlayerManager playerManager)
        {
            _targetId = targetId;
            _playerManager = playerManager;
            _editCallback = submitCallback;
        }
        
        public override void OnViewReady()
        {
            View.OnSubmitButtonClicked += OnSubmitClicked;
            View.OnCancelButtonClicked += OnCancelClicked;
            
            if (IsEditingExistingPlayer())
            {
                LoadExistingPlayerEditor();
            }
            else
            {
                LoadNewPlayerEditor();
            }
        }

        public override void OnViewDisabled()
        {
            
        }

        private void OnSubmitClicked()
        {
            var resultArgs = new PlayerEditSubmitEventArgs(View.GetNameText(), View.GetTagText(), 0);
            _editCallback?.Invoke(resultArgs);
            View.Close();
        }
        
        private void OnCancelClicked()
        {
            View.Close();
        }
        
        private bool IsEditingExistingPlayer()
        {
            return _targetId != -1;
        }

        private void LoadExistingPlayerEditor()
        {
            if (_playerManager.TryGetPlayer(_targetId, out var player))
            {
                View.SetNameText(player.Name);
                View.SetTagText(player.Tag);
                View.SetSubmitButtonText("Save");
            }
            else
            {
                View.Close();
            }
        }
        
        private void LoadNewPlayerEditor()
        {
            View.SetNameText(string.Empty);
            View.SetTagText(string.Empty);
            View.SetSubmitButtonText("Create");
        }
        
    }
}