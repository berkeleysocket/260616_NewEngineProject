using Scripts.Core.Utilities;

using UnityEngine;

namespace Scripts.Runtime.Agents.FSM.SO.Conditions
{
    [CreateAssetMenu(fileName = "RandomTimeCondition", menuName = "SO/StateCondition/RandomTimeCondition")]
    public class RandomTimeConditionSO : StateConditionSO
    {
        [SerializeField] private float minDuration = 1f;
        [SerializeField] private float maxDuration = 3f;

        private bool _currentState;
        private float _nextTargetTime;
        private float _timer;

        public override void Initialize(Agent agent)
        {
            _currentState = false;
            _nextTargetTime = 0f;
            _timer = 0f;
            SetRandomTargetTime();
        }

        public override bool CheckCondition()
        {
            DebugLogger.Log("CheckCondition");
            if (_currentState) _currentState = false;
            _timer += Time.deltaTime;

            if (_timer >= _nextTargetTime)
            {
                _timer = 0f;
                _currentState = true;

                SetRandomTargetTime();
            }

            return _currentState;
        }

        private void SetRandomTargetTime() => _nextTargetTime = Random.Range(minDuration, maxDuration);
    }
}