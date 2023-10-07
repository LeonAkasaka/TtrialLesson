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
            // �O��ړ��̔���
            if (Input.GetKey(KeyCode.UpArrow)) // �O�i
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
                _animator.SetFloat("Speed", 1); // �A�j���[�V�������Đ�
            }
            else if (Input.GetKey(KeyCode.DownArrow)) // ���
            {
                transform.Translate(0, 0, -1 * Time.deltaTime);
                _animator.Play("Walking@loop");
                _animator.SetFloat("Speed", -1); // �A�j���[�V�����t�Đ�
            }
            else // �ҋ@
            {
                _animator.Play("Standing@loop");
            }

            // ���E�̉�]����
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
