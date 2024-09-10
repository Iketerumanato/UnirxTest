using UnityEngine;
using UniRx;
using System;

public class PlayerUIController : MonoBehaviour
{
    public ReactiveProperty<int> PlayerHp = new(100);
    [SerializeField] int DamagePoint = 10;
    [SerializeField] int maxPlayerHP = 100;
    private IDisposable spaceKeySubscription;
    readonly double waitTime = 1; 

    private void OnEnable()
    {
        PlayerHp.Value = maxPlayerHP;
    }

    private void Start()
    {
        // KeyCode.Space�̘A�Ŗh�~����
        spaceKeySubscription = Observable.EveryUpdate()
            .Where(_ => Input.GetKeyDown(KeyCode.Space))
            .ThrottleFirst(TimeSpan.FromSeconds(waitTime))
            .Subscribe(_ => DecreaseHp());
    }

    private void OnDisable()
    {
        // �I�u�W�F�N�g�������ɂȂ����ۂɍw�ǂ�����
        spaceKeySubscription?.Dispose();
    }

    public void DecreaseHp()
    {
        PlayerHp.Value -= DamagePoint;
        if (PlayerHp.Value <= 0)
        {
            OnEnable(); // HP��0�ȉ��ɂȂ����珉����
        }
    }
}