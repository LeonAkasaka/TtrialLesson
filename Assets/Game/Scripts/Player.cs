using Sample.MessageWindow;
using UnityEngine;

namespace Sample.UnityChan.Ref
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

            // �f�o�b�O�p�̔��胉�C���\��
            var forward = transform.TransformDirection(Vector3.forward);
            var position = transform.position + new Vector3(0, 0.5F, 0);
            Debug.DrawLine(position, position + forward, Color.red);

            // �A�N�V�����̔���
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("space"))
            {
                var distance = 1.0F;
                if (Physics.Raycast(position, forward, out var hit, distance))
                {
                    var target = hit.collider.GetComponent<TalkAction>();
                    if (target is not null)
                    {
                        target.Talk(transform);
                    }
                }
            }
        }
    }
}
