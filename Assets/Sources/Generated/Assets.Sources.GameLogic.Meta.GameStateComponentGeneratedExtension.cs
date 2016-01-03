using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public Assets.Sources.GameLogic.Meta.GameStateComponent gameState { get { return (Assets.Sources.GameLogic.Meta.GameStateComponent)GetComponent(ComponentIds.GameState); } }

        public bool hasGameState { get { return HasComponent(ComponentIds.GameState); } }

        static readonly Stack<Assets.Sources.GameLogic.Meta.GameStateComponent> _gameStateComponentPool = new Stack<Assets.Sources.GameLogic.Meta.GameStateComponent>();

        public static void ClearGameStateComponentPool() {
            _gameStateComponentPool.Clear();
        }

        public Entity AddGameState(Assets.Sources.GameLogic.Meta.GameState newGameState) {
            var component = _gameStateComponentPool.Count > 0 ? _gameStateComponentPool.Pop() : new Assets.Sources.GameLogic.Meta.GameStateComponent();
            component.GameState = newGameState;
            return AddComponent(ComponentIds.GameState, component);
        }

        public Entity ReplaceGameState(Assets.Sources.GameLogic.Meta.GameState newGameState) {
            var previousComponent = hasGameState ? gameState : null;
            var component = _gameStateComponentPool.Count > 0 ? _gameStateComponentPool.Pop() : new Assets.Sources.GameLogic.Meta.GameStateComponent();
            component.GameState = newGameState;
            ReplaceComponent(ComponentIds.GameState, component);
            if (previousComponent != null) {
                _gameStateComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveGameState() {
            var component = gameState;
            RemoveComponent(ComponentIds.GameState);
            _gameStateComponentPool.Push(component);
            return this;
        }
    }

    public partial class Pool {
        public Entity gameStateEntity { get { return GetGroup(Matcher.GameState).GetSingleEntity(); } }

        public Assets.Sources.GameLogic.Meta.GameStateComponent gameState { get { return gameStateEntity.gameState; } }

        public bool hasGameState { get { return gameStateEntity != null; } }

        public Entity SetGameState(Assets.Sources.GameLogic.Meta.GameState newGameState) {
            if (hasGameState) {
                throw new SingleEntityException(Matcher.GameState);
            }
            var entity = CreateEntity();
            entity.AddGameState(newGameState);
            return entity;
        }

        public Entity ReplaceGameState(Assets.Sources.GameLogic.Meta.GameState newGameState) {
            var entity = gameStateEntity;
            if (entity == null) {
                entity = SetGameState(newGameState);
            } else {
                entity.ReplaceGameState(newGameState);
            }

            return entity;
        }

        public void RemoveGameState() {
            DestroyEntity(gameStateEntity);
        }
    }

    public partial class Matcher {
        static IMatcher _matcherGameState;

        public static IMatcher GameState {
            get {
                if (_matcherGameState == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.GameState);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherGameState = matcher;
                }

                return _matcherGameState;
            }
        }
    }
}
