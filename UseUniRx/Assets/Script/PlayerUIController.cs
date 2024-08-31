using UnityEngine;
using UniRx;

public class PlayerUIController : MonoBehaviour
{
    public ReactiveProperty<int> PlayerHp = new(100);
    [SerializeField] int DamagePoint = 10;

    private void OnEnable()
    {
        PlayerHp.Value = 100;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) PlayerHp.Value -= DamagePoint;
        if (PlayerHp.Value <= 0) OnEnable();
    }
}