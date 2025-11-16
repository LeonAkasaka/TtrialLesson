using Sample.UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sample.UnityChan
{
    [RequireComponent(typeof(Animator))]
    public class Player : MonoBehaviour
    {
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            // 前後移動の判定
            if (Keyboard.current.upArrowKey.isPressed) // 前進
            {
                if (Keyboard.current.leftShiftKey.isPressed)
                {
                    transform.Translate(0, 0, 2 * Time.deltaTime);
                    _animator.Play("Running@loop");
                }
                else
                {
                    transform.Translate(0, 0, 1 * Time.deltaTime);
                    _animator.Play("Walking@loop");
                }
                _animator.SetFloat("Speed", 1); // アニメーション順再生
            }
            else if (Keyboard.current.downArrowKey.isPressed) // 後退
            {
                transform.Translate(0, 0, -1 * Time.deltaTime);
                _animator.Play("Walking@loop");
                _animator.SetFloat("Speed", -1); // アニメーション逆再生
            }
            else // 待機
            {
                _animator.Play("Standing@loop");
            }

            // 左右の回転判定
            if (Keyboard.current.leftArrowKey.isPressed)
            {
                transform.Rotate(0, -120 * Time.deltaTime, 0);
            }
            else if (Keyboard.current.rightArrowKey.isPressed)
            {
                transform.Rotate(0, 120 * Time.deltaTime, 0);
            }

        }
    }
}
