using System;
using System.Diagnostics;
using Engine.Models;

namespace Engine
{
    public class Game
    {
        public GameState GameState { get; set; }
        public GameState NextStep(PlayerAction[] player1Actions, PlayerAction[] player2Actions, double secondsDelta)
        {
            var newGameState = GameState;

            // Пересчет состояния игрока 1
            var ps1 = CalculeteNextPlayerState(newGameState.Player1.State, player1Actions, GameState, secondsDelta);
            var p1 = newGameState.Player1;
            p1.State = ps1;
            newGameState.Player1 = p1;

            // Пересчет состояния игрока 2
            var ps2 = CalculeteNextPlayerState(newGameState.Player2.State, player1Actions, GameState, secondsDelta);
            var p2 = newGameState.Player2;
            p2.State = ps2;
            newGameState.Player2 = p2;

            // Пересчет состояния мяча

            // Пересчет состояния игры
        }

        private static BallState CalculateNextBallState(BallState ballState, GameState gameState, GameRules gameRules, double secondsDelta)
        {
            var movingDelta = secondsDelta * ballState.Speed + gameRules.BallSpeedup * Math.Pow(secondsDelta, 2);

        }

        private static PlayerState CalculeteNextPlayerState(PlayerState playerState, PlayerAction[] actions, GameState gameState, double secondsDelta)
        {
            var movingDelta = secondsDelta * playerState.Speed;
            var newState = playerState;

            if (playerState.MovingBottom)
                newState.PositionY = playerState.PositionY + movingDelta;
            if (playerState.MovingTop)
                newState.PositionY = playerState.PositionY + movingDelta;

            var rocketTopPoint = newState.PositionY - newState.RocketSize / 2;
            var rocketBottomPoint = newState.PositionY + newState.RocketSize / 2;

            if (rocketBottomPoint > gameState.Map.Height)
                newState.PositionY -= rocketBottomPoint - gameState.Map.Height;
            else if (rocketTopPoint < 0)
                newState.PositionY -= rocketTopPoint;

            foreach(var action in actions)
            {
                switch (action)
                {
                    case PlayerAction.StartMovingTop:
                        newState.MovingTop = true;
                        break;
                    case PlayerAction.CancelMovingTop:
                        newState.MovingTop = false;
                        break;
                    case PlayerAction.StartMovingBottom:
                        newState.MovingBottom = true;
                        break;
                    case PlayerAction.CancelMovingBottom:
                        newState.MovingBottom = false;
                        break;
                    case PlayerAction.Nothing:
                    default:
                        break;
                }
            }

            return newState;
        }
    }
}
