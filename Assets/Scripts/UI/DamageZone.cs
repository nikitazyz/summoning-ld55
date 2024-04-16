using UnityEngine;

namespace UI
{
    public class DamageZone : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public void Run()
        {
            _animator.SetTrigger("Run");
        }
    }
}