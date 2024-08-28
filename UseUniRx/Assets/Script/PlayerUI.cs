using UnityEngine;
using TMPro;
using UniRx;
using System;
using UniRx.Triggers;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] TMP_Text HpText;
    [SerializeField] PlayerUIController _playerUicontroller;

    // Start is called before the first frame update
    void Start()
    {
        //˜A‘Å‚Ì–h~
        //TimeSpan PushTime = TimeSpan.FromSeconds(2);
        //this.UpdateAsObservable().
        //    Where(_ => Input.GetKeyDown(KeyCode.Space)).
        //    ThrottleFirst(PushTime).
        _playerUicontroller.PlayerHp.Subscribe(PlayerHp => UpDatePlayerHP(PlayerHp));//PlayerHp‚ğw“Ç
    }

    public void UpDatePlayerHP(int hp)
    {
        HpText.text = "HP:" + hp;
    }
}
