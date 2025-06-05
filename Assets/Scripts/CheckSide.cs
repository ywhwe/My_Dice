using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class CheckSide : MonoBehaviour
{
    [HideInInspector] public static bool triggered = false;

    private void OnTriggerEnter(Collider col)
    {
        if (triggered) return;

        if (Dice.instance.rolledTime<0.5f)
        {
            Debug.Log($"Triggered: {gameObject.name}, velocity: {Dice.diceVelocity.magnitude}");

            UniTask.WaitUntil(() => !Dice.instance.isTimerOn);

            switch (gameObject.name)
            {
                case "1": DiceResult.resultInstance.result = 6;
                    break;
                case "2": DiceResult.resultInstance.result = 5;
                    break;
                case "3": DiceResult.resultInstance.result = 4;
                    break;
                case "4": DiceResult.resultInstance.result = 3;
                    break;
                case "5": DiceResult.resultInstance.result = 2;
                    break;
                case "6": DiceResult.resultInstance.result = 1;
                    break;
            }
        }
        
        // if (Dice.diceVelocity.sqrMagnitude > 0.01f) return;
        // if (Dice.instance.dice.GetComponent<Transform>().position.y > 0.4566893f) return;
        // if (col.name != "Plane") return;
        
        triggered = true;
    }

    public static void ResetTrigger()
    {
        triggered = false;
    }
}
