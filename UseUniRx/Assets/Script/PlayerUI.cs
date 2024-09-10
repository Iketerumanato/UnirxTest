using UnityEngine;
using TMPro;
using UniRx;
using System;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] TMP_Text HpText;
    [SerializeField] PlayerUIController _playerUicontroller;

    // Start is called before the first frame update
    void Start()
    {
        _playerUicontroller.PlayerHp.Subscribe(PlayerHp => UpDatePlayerHP(PlayerHp));//PlayerHp‚ğw“Ç
    }

    public void UpDatePlayerHP(int hp)
    {
        HpText.text = "HP:" + hp;
    }
}