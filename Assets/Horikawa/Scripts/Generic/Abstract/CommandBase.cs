using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CommandBase : MonoBehaviour
{
    // コンポーネント
    private Command command;

    private void Awake()
    {
        // コンポーネント取得
        command = GetComponent<Command>();

        // イベントに関数を追加
        command.onDecide.AddListener(OnDecide);
        command.onDecide.AddListener(PlayDecideSE);
        InputManager.Instance.decideEvent.AddListener(DecideInput);
    }

    // 決定時に呼び出される関数
    protected abstract void OnDecide();

    // 決定SE再生
    private void PlayDecideSE()
    {
        AudioManager.Instance.PlayOneShot(AudioManager.SE.CommandDecide);
    }

    // 決定入力時に呼び出される関数
    private void DecideInput()
    {
        if (command.isSelected)
        {
            command.onDecide.Invoke();
        }
    }
}
