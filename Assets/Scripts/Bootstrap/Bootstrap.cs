using StateManagement;
using StateManagement.States;
using UnityEngine;
using Zenject;

namespace Bootstrap
{
    public class Bootstrap : MonoBehaviour, ICoroutineRunner
    {
        private static Bootstrap instance;
        private IStateMachine _stateMachine;

        public void Start()
        {
            Debug.Log("Starting");
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
                _stateMachine.Enter<BootstrapState>();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        [Inject]
        private void Construct(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
    }
}