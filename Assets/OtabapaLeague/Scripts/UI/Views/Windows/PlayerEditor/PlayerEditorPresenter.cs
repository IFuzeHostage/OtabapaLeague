using System;
using OtabapaLeague.Scripts.Domain.Systems.Players;
using Zenject;
using Player = OtabapaLeague.Data.Player.Player;

namespace OtabapaLeague.Application.UI.Windows
{
    public class PlayerEditorPresenter : ViewPresenter<PlayerEditorView>
    {
        private readonly string _targetTag;
        private readonly IPlayerManager _playerManager;
        private readonly Action<PlayerEditSubmitEventArgs> _editCallback;
        
        public PlayerEditorPresenter(string targetTag, Action<PlayerEditSubmitEventArgs> submitCallback, IPlayerManager playerManager)
        {
            _targetTag = targetTag;
            _playerManager = playerManager;
            _editCallback = submitCallback;
        }
        
        public override void OnViewReady()
        {
            View.OnSubmitButtonClicked += OnSubmitClicked;
            
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
        
        private bool IsEditingExistingPlayer()
        {
            return !string.IsNullOrEmpty(_targetTag);
        }

        private void LoadExistingPlayerEditor()
        {
            if (_playerManager.TryGetPlayer(_targetTag, out var player))
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
            View.SetSubmitButtonText("Create");
        }
        
    }
}