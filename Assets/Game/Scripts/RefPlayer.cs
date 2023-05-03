using UnityEngine;

public class RefPlayer : MonoBehaviour
{
    private Animator _animator;
    private int _faceLayer;
    private TalkAction _target;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _faceLayer = _animator.GetLayerIndex("face");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("space"))
        {
            _target?.Talk();
        }

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
            _animator.Play("default", _faceLayer);
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

    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent(out _target);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<TalkAction>(out var target) && target == _target)
        {
            _target = null;
        }
    }

    void OnCallChangeFace(string stateName)
    {
        // �A�j���[�V�����ɐݒ肳��Ă���\��X�V�C�x���g�𔽉f
        _animator.SetLayerWeight(_faceLayer, 1);
        _animator.Play(stateName, _faceLayer);
    }
}
