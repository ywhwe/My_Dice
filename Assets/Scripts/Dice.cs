using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

public class Dice : MonoBehaviour
{
    static Rigidbody rb;
    public static Vector3 diceVelocity;

    private int[] angles = { 0, 90, 180, 270, 360 };

    [SerializeField] private Object dice;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(CheckButton());
    }

    private IEnumerator CheckButton()
    {
        while (UnityEditor.EditorApplication.isPlaying)
        {
            yield return null;
            
            diceVelocity = rb.velocity;
        } 
    }

    public void DiceRoll()
    {
        CheckSide.ResetTrigger();
        
        float dirX = Random.Range(0, 3000);
        float dirY = Random.Range(0, 3000);
        float dirZ = Random.Range(0, 3000);
        
        Quaternion currentRotation = transform.localRotation;
        float randomIndex_x = Random.Range(0, angles.Length);
        float randomIndex_z = Random.Range(0, angles.Length);

        transform.localPosition = dice.GetComponent<Transform>().position;
        
        transform.localRotation = Quaternion.Euler(angles[(int) randomIndex_x],
            currentRotation.eulerAngles.y, angles[(int) randomIndex_z]);
        
        float forceRand = Random.Range(200, 300);
        rb.AddForce(Vector3.up * forceRand);
        rb.AddTorque(new Vector3(dirX, dirY, dirZ), ForceMode.VelocityChange);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
