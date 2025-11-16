using UnityEngine;
using UnityEngine.InputSystem;

namespace Sample.UnityChan
{
    public class TalkInitiator : MonoBehaviour
    {
        [SerializeField]
        private KeyCode _keyCode = KeyCode.Space;

        [SerializeField]
        private float _distance = 1;

        // Update is called once per frame
        void Update()
        {
            // デバッグ用の判定ライン表示
            var forward = transform.TransformDirection(Vector3.forward);
            var position = transform.position + new Vector3(0, 0.5F, 0);
            Debug.DrawLine(position, position + forward * _distance, Color.red);

            // アクションの判定
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                if (Physics.Raycast(position, forward, out var hit, _distance))
                {
                    var target = hit.collider.GetComponent<TalkResponder>();
                    if (target is not null)
                    {
                        target.Talk(transform);
                    }
                }
            }
        }
    }
}
