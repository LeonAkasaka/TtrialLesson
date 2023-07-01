using UnityEngine;

namespace Sample.UnityChan
{
    [RequireComponent(typeof(Animator))]
    public class FacialHandler : MonoBehaviour
    {
        private Animator _animator;
        private int _faceLayer;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _faceLayer = _animator.GetLayerIndex("face");
        }

        private void Update()
        {
            var info = _animator.GetCurrentAnimatorStateInfo(0);
            if (info.IsName("Standing@loop"))
            {
                _animator.Play("default", _faceLayer);
            }
        }

        void OnCallChangeFace(string stateName)
        {
            // �A�j���[�V�����ɐݒ肳��Ă���\��X�V�C�x���g�𔽉f
            _animator.SetLayerWeight(_faceLayer, 1);
            _animator.Play(stateName, _faceLayer);
        }
    }
}
