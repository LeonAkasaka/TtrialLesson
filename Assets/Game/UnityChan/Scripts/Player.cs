using Sample.UI;
using UnityEngine;

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
            if (Input.GetKey(KeyCode.UpArrow)) // 前進
            {
                if (Input.GetKey(KeyCode.LeftShift))
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
            else if (Input.GetKey(KeyCode.DownArrow)) // 後退
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
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(0, -120 * Time.deltaTime, 0);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(0, 120 * Time.deltaTime, 0);
            }

        }
    }
}
