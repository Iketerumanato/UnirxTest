using UnityEngine;
using UniRx;

public class PlayerUIController : MonoBehaviour
{
    public ReactiveProperty<int> PlayerHp = new(100);
    [SerializeField] int DamagePoint = 10;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) PlayerHp.Value -= DamagePoint;
    }
}