using System;
using System.Collections.Generic;
using System.Linq;
using OtabapaLeague.Data.Player;
using OtabapaLeague.Scripts.Domain.Systems.Games;
using OtabapaLeague.Scripts.Domain.Systems.Players;
using Zenject.SpaceFighter;

namespace OtabapaLeague.Application.UI.Windows.GameEditor
{
    public class GameEditorPresenter : ViewPresenter<GameEditorView>
    {
        private Action<GameEditorSubmitArgs> _onSubmit;
        private IGamesManager _gamesManager;
        private IPlayerManager _playerManager;
        
        private IEnumerable<PlayerModel> _players;
        
        public GameEditorPresenter(Action<GameEditorSubmitArgs> onSubmit, IPlayerManager playerManager)
        {
            _onSubmit = onSubmit;
            _playerManager = playerManager;
        }
        
        public override void OnViewReady()
        {
            View.OnSubmitButtonClicked += OnViewSubmitButtonClicked;
            View.OnCancelButtonClicked += OnViewCancelButtonClicked;

            InitPlayers();
        }

        public override void OnViewDisabled()
        {
            View.OnSubmitButtonClicked -= OnViewSubmitButtonClicked;
            View.OnCancelButtonClicked -= OnViewCancelButtonClicked;
        }

        private void InitPlayers()
        {
            _players = _playerManager.AllPlayers;
            var playerNames = _players.Select(p => p.Name).ToArray();
            View.SetPlayerOptions(playerNames);
        }

        private void OnViewSubmitButtonClicked()
        {
            var firstPlayer = _players.ElementAt(View.GetFirstPlayerIndex()).Id;
            var secondPlayer = _players.ElementAt(View.GetSecondPlayerIndex()).Id;
            var firstPlayerScore = View.GetFirstPlayerScore();
            var secondPlayerScore = View.GetSecondPlayerScore();

            var submitArgs = new GameEditorSubmitArgs(firstPlayer, secondPlayer, firstPlayerScore, secondPlayerScore);
            _onSubmit?.Invoke(submitArgs);
            View.Close();
        }
        
        private void OnViewCancelButtonClicked()
        {
            View.Close();
        }
    }
}