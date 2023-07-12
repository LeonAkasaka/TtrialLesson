using UnityEngine;

namespace Sample.SpaceInvaders
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private float _range; // ���E�̈ړ��͈�

        [SerializeField]
        private float _speed; // 1�b�Ԃ̈ړ�����

        private float _center; // �������W
        private float _direction = 1; // ����

        private void Start()
        {
            _center = transform.position.x;
        }

        private void Update()
        {
            var pos = transform.position;
            var distance = Mathf.Abs(pos.x - _center);
            if (distance > _range)
            {
                pos.x = _center + _range * _direction;
                transform.position = pos;
                _direction = _direction * -1;
            }

            var v = _speed * Time.deltaTime * _direction;
            transform.Translate(v, 0, 0);
        }
    }
}