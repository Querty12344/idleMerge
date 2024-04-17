using System;
using System.Collections.Generic;
using StateManagement.States;

namespace StateManagement
{
    public class StateHandler : IStateHandler
    {
        private readonly Dictionary<Type, IState> _states;

        public StateHandler(BootstrapState bootstrapState, CityState cityState, GameLoopState gameLoopState,
            LoadLevelState loadLevelState, MiningState miningState, ResourceLoadingState resourceLoadingState)
        {
            _states = new Dictionary<Type, IState>
            {
                [typeof(BootstrapState)] = bootstrapState,
                [typeof(CityState)] = cityState,
                [typeof(GameLoopState)] = gameLoopState,
                [typeof(LoadLevelState)] = loadLevelState,
                [typeof(MiningState)] = miningState,
                [typeof(ResourceLoadingState)] = resourceLoadingState
            };
        }


        public IState GetState<TState>() where TState : IState
        {
            var state = _states[typeof(TState)];
            return state;
        }
    }
}