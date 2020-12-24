using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Player))]
    public class PlayerAnimation : MonoBehaviour
    {
        private Animator _animator;
        private Player _player;
    
        private void Start()
        {
            _animator = GetComponent<Animator>();
            _player = GetComponent<Player>();
        }

        private void Update()
        {
        }
    }
}
