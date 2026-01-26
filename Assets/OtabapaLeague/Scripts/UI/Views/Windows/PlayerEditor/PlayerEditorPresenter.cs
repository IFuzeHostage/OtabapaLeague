using System;
using OtabapaLeague.Scripts.Data.AvatarsRepository;
using OtabapaLeague.Scripts.Domain.Systems.Players;
using UnityEngine;
using Zenject;

namespace OtabapaLeague.Application.UI.Windows
{
    public class PlayerEditorPresenter : ViewPresenter<PlayerEditorView>
    {
        private readonly int _targetId;
        
        private readonly IPlayerManager _playerManager;
        private readonly IPlayerAvatarsRepository _playerAvatarsRepository;
        private readonly Action<PlayerEditSubmitEventArgs> _editCallback;
        
        private Sprite _loadedAvatar;
        
        public PlayerEditorPresenter(int targetId, Action<PlayerEditSubmitEventArgs> submitCallback, IPlayerManager playerManager,
            IPlayerAvatarsRepository playerAvatarsRepository)
        {
            _targetId = targetId;
            _playerManager = playerManager;
            _playerAvatarsRepository = playerAvatarsRepository;
            _editCallback = submitCallback;
        }
        
        public override void OnViewReady()
        {
            View.OnSubmitButtonClicked += OnSubmitClicked;
            View.OnCancelButtonClicked += OnCancelClicked;
            View.OnAvatarButtonClicked += OnAvatarClicked;
            
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
            View.OnSubmitButtonClicked -= OnSubmitClicked;
            View.OnCancelButtonClicked -= OnCancelClicked;
            View.OnAvatarButtonClicked -= OnAvatarClicked;
        }

        private void OnSubmitClicked()
        {
            var resultArgs = new PlayerEditSubmitEventArgs(View.GetNameText(), View.GetTagText(), _loadedAvatar);
            _editCallback?.Invoke(resultArgs);
            View.Close();
        }
        
        private void OnCancelClicked()
        {
            View.Close();
        }

        private void OnAvatarClicked()
        {
            _loadedAvatar = _playerAvatarsRepository.SelectAvatar();
            View.SetAvatar(_loadedAvatar);
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
                TryLoadAvatar();
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

        private void TryLoadAvatar()
        {
            var avatar = _playerAvatarsRepository.GetAvatar(_targetId);
            if (avatar != null)
            {
                View.SetAvatar(avatar);
            }
        }
    }
}