using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVoiceOnCollision : MonoBehaviour
{
    public GameObject targetObject;  // ������קĿ������
    private AudioSource targetAudioSource;  // AudioSource���

    void Start()
    {
        // ȷ��Ŀ��������AudioSource���
        if (targetObject != null)
        {
            targetAudioSource = targetObject.GetComponent<AudioSource>();
            if (targetAudioSource == null)
            {
                UnityEngine.Debug.LogError(targetObject.name + "û���ҵ�AudioSource�����");
            }
        }
        else
        {
            UnityEngine.Debug.LogError("���ڽű�����קĿ�����壡");
        }
    }

    // ���ʹ�õ�����ײ��
    void OnCollisionEnter(Collision collision)
    {
        UnityEngine.Debug.Log("��⵽��ײ������");

        if (collision.gameObject == targetObject)  // ֱ�ӱȽ�Ŀ������
        {
            UnityEngine.Debug.Log("��Ŀ�����巢����ײ��");
            PlayAudio();
        }
    }

    // ���ʹ�ô�����
    void OnTriggerEnter(Collider other)
    {
        UnityEngine.Debug.Log("��������⵽����Ӵ���");

        if (other.gameObject == targetObject)  // ֱ�ӱȽ�Ŀ������
        {
            UnityEngine.Debug.Log("��Ŀ�����巢��������");
            PlayAudio();
        }
    }

    // ������Ƶ�Ĺ�������
    void PlayAudio()
    {
        if (targetAudioSource != null && !targetAudioSource.isPlaying)
        {
            targetAudioSource.Play();
            UnityEngine.Debug.Log("��Ƶ��ʼ���ţ�");
        }
    }
}
