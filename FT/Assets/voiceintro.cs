using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVoiceOnCollision : MonoBehaviour
{
    public GameObject targetObject;  // 用于拖拽目标物体
    private AudioSource targetAudioSource;  // AudioSource组件

    void Start()
    {
        // 确保目标物体有AudioSource组件
        if (targetObject != null)
        {
            targetAudioSource = targetObject.GetComponent<AudioSource>();
            if (targetAudioSource == null)
            {
                UnityEngine.Debug.LogError(targetObject.name + "没有找到AudioSource组件！");
            }
        }
        else
        {
            UnityEngine.Debug.LogError("请在脚本中拖拽目标物体！");
        }
    }

    // 如果使用的是碰撞器
    void OnCollisionEnter(Collision collision)
    {
        UnityEngine.Debug.Log("检测到碰撞发生！");

        if (collision.gameObject == targetObject)  // 直接比较目标物体
        {
            UnityEngine.Debug.Log("与目标物体发生碰撞！");
            PlayAudio();
        }
    }

    // 如果使用触发器
    void OnTriggerEnter(Collider other)
    {
        UnityEngine.Debug.Log("触发器检测到物体接触！");

        if (other.gameObject == targetObject)  // 直接比较目标物体
        {
            UnityEngine.Debug.Log("与目标物体发生触发！");
            PlayAudio();
        }
    }

    // 播放音频的公共方法
    void PlayAudio()
    {
        if (targetAudioSource != null && !targetAudioSource.isPlaying)
        {
            targetAudioSource.Play();
            UnityEngine.Debug.Log("音频开始播放！");
        }
    }
}
