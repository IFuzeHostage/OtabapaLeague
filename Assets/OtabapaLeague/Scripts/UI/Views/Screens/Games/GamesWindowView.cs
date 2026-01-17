using System;
using System.Collections.Generic;
using OtabapaLeague.Application.UI.Elements;
using OtabapaLeague.Scripts.Data;
using UnityEngine;

namespace OtabapaLeague.Application.UI.Screens.Games
{
    public class GamesWindowView : View
    {
        public event Action OnAddGameButtonClickedEvent;
        
        [SerializeField]
        private RectTransform _gamesParent;
        [SerializeField]
        private GameView _gameViewPrefab;
        [SerializeField]
        private UIButton _addGameButton;

        private List<GameView> _games = new List<GameView>();
        
        public GameView AddGame(GameResultsPlayerData playerOneData, GameResultsPlayerData playerTwoData,
            GameResult result)
        {
            var gameView = CreateGameView();
            InitGameView(gameView, playerOneData, playerTwoData, result);
            _games.Add(gameView);
            return gameView;
        }

        protected override void InitComponents()
        {
            base.InitComponents();
            _addGameButton.OnClick += OnAddGameButtonClicked;
        }

        private GameView CreateGameView()
        {
            var gameView = Instantiate(_gameViewPrefab, _gamesParent);
            return gameView;
        }
        
        private void InitGameView(GameView gameView, GameResultsPlayerData playerOneData, GameResultsPlayerData playerTwoData,
            GameResult result)
        {
            gameView.SetPlayerOne(playerOneData.Name, playerOneData.Tag);
            gameView.SetPlayerOneScore(playerOneData.Score);
            gameView.SetPlayerTwo(playerTwoData.Name, playerTwoData.Tag);
            gameView.SetPlayerTwoScore(playerTwoData.Score);
            gameView.SetWinner(result);   
        }
        
        private void OnAddGameButtonClicked()
        {
            OnAddGameButtonClickedEvent?.Invoke();
        }
    }
}