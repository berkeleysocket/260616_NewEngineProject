using UnityEngine;

namespace Runtime.Agents.FSM
{
    [CreateAssetMenu(fileName = "RandomTimeConditionSO", menuName = "SO/StateConditionSO/RandomTimeCondition")]
    public class RandomTimeConditionSO : StateConditionSO
    {
        [SerializeField] private float minTrueDuration = 1f;
        [SerializeField] private float maxTrueDuration = 3f;
        [SerializeField] private float minFalseDuration = 2f;
        [SerializeField] private float maxFalseDuration = 5f;

        private bool _currentState;
        private float _nextTargetTime;
        private float _timer;

        public override void Initialize(Agent agent)
        {
            _currentState = false;
            _timer = 0f;
            SetRandomTargetTime();
        }

        public override bool CheckCondition()
        {
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

        private void SetRandomTargetTime()
        {
            if (_currentState)
                _nextTargetTime = Random.Range(minTrueDuration, maxTrueDuration);
            else
                _nextTargetTime = Random.Range(minFalseDuration, maxFalseDuration);
        }
    }
}