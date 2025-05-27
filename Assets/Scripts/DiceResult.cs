using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

public class DiceResult : MonoBehaviour
{
    public TextMeshProUGUI texts;

    [HideInInspector] public int result;
    public static DiceResult resultInstance;
    
    private void Awake()
    {
        resultInstance = this;
        texts.text = "0";
        Result().Forget();
    }

    private async UniTask Result()
    {
        await UniTask.Yield();
        texts.text = result.ToString();
    }
}
