using UnityEngine;

public class CheckSide : MonoBehaviour
{
    private static bool triggered = false;

    private void OnTriggerEnter(Collider col)
    {
        if (triggered) return;
        
        Debug.Log($"Triggered: {gameObject.name}, velocity: {Dice.diceVelocity.magnitude}");
        
        // if (Dice.diceVelocity.sqrMagnitude > 0.01f) return;
        if (col.name != "Plane") return;
        
        switch (gameObject.name)
        {
            case "1":
                Debug.Log(6);
                break;
            case "2": 
                Debug.Log(5);
                break;
            case "3":
                Debug.Log(4);
                break; 
            case "4":
                Debug.Log(3);
                break;
            case "5":
                Debug.Log(2);
                break;
            case "6":
                Debug.Log(1);
                break;
        }
        
        
        triggered = true;
    }

    public static void ResetTrigger()
    {
        triggered = false;
    }
}
