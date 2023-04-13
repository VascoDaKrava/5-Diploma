using UnityEngine;
using UnityEngine.AI;


namespace RTDef.Game.Animations
{
    public sealed class NavmeshVSAnimatorSynchronizator : MonoBehaviour
    {

        #region Fields

        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Animator _animator;
        private float _currentAngle;

        #endregion


        #region Mono

        private void Start()
        {
            _currentAngle = transform.eulerAngles.y;
        }

        void Update()
        {
            _animator.SetFloat(AnimationParams.VELOCITY_FORWARD, _agent.velocity.magnitude / _agent.speed);
            _animator.SetFloat(AnimationParams.ROTATION, ((_currentAngle - transform.eulerAngles.y) / Time.deltaTime) / _agent.angularSpeed);

            _currentAngle = transform.eulerAngles.y;
        }

        #endregion

    }
}