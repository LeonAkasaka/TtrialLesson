using UnityEngine;

namespace Sample.SpaceInvaders
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private float _range; // ¶‰E‚ÌˆÚ“®”ÍˆÍ

        [SerializeField]
        private float _speed; // 1•bŠÔ‚ÌˆÚ“®‹——£

        private float _center; // ‰ŠúÀ•W
        private float _direction = 1; // •ûŒü

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