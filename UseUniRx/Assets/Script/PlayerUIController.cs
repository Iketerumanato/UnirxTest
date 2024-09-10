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
        // KeyCode.Spaceの連打防止処理
        spaceKeySubscription = Observable.EveryUpdate()
            .Where(_ => Input.GetKeyDown(KeyCode.Space))
            .ThrottleFirst(TimeSpan.FromSeconds(waitTime))
            .Subscribe(_ => DecreaseHp());
    }

    private void OnDisable()
    {
        // オブジェクトが無効になった際に購読を解除
        spaceKeySubscription?.Dispose();
    }

    public void DecreaseHp()
    {
        PlayerHp.Value -= DamagePoint;
        if (PlayerHp.Value <= 0)
        {
            OnEnable(); // HPが0以下になったら初期化
        }
    }
}