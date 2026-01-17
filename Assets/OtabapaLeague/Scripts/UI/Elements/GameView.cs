using OtabapaLeague.Scripts.Data;
using UnityEngine;

namespace OtabapaLeague.Application.UI.Elements
{
    public class GameView : UIElement
    {
        [SerializeField]
        private GameViewPlayer _playerOneView;
        [SerializeField]
        private GameViewPlayer _playerTwoView;

        public void SetPlayerOne(string name, string tag)
        {
            _playerOneView.SetPlayer(name, tag);
        }
        
        public void SetPlayerOneScore(int score)
        {
            _playerOneView.SetPlayerScoreText(score);
        }
        
        public void SetPlayerTwo(string name, string tag)
        {
            _playerTwoView.SetPlayer(name, tag);
        }
        
        public void SetPlayerTwoScore(int score)
        {   
            _playerTwoView.SetPlayerScoreText(score);
        }
        
        public void SetWinner(GameResult gameResults)
        {
            switch (gameResults)
            {
                case GameResult.FirstPlayerWin:
                    _playerOneView.SetResultText("Winner");
                    _playerTwoView.SetResultText("Loser");
                    break;
                case GameResult.SecondPlayerWin:
                    _playerOneView.SetResultText("Loser");
                    _playerTwoView.SetResultText("Winner");
                    break;
            }
        }
    }
}