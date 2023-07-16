using UnityEngine;

namespace Sample.SpaceInvaders
{
    public class MissileLauncher : MonoBehaviour
    {
        public const string EnemyMissileName = "EnemyMissile";

        [SerializeField]
        private float _interval = 5;

        [SerializeField]
        private Vector2 _velocity = new(0, -10);

        [SerializeField]
        private Vector2 _launchOffset = new(0, -1);

        private float _elapsed;

        private void Update()
        {
            _elapsed += Time.deltaTime;
            if (_elapsed > _interval)
            {
                _elapsed = 0;
                var missile = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                missile.transform.position = transform.position + (Vector3)_launchOffset;
                missile.transform.localScale = transform.localScale;
                missile.name = EnemyMissileName;

                var c = missile.GetComponent<Collider>();
                c.isTrigger = true;

                var r = missile.AddComponent<Rigidbody>();
                r.useGravity = false;
                r.velocity = _velocity;
                Destroy(missile, 3);
            }
        }
    }
}