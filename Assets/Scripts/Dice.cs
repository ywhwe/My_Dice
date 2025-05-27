using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

public class Dice : MonoBehaviour
{
    static Rigidbody rb;
    public static Vector3 diceVelocity;
    
    [HideInInspector] public float rolledTime = 0f;
    [HideInInspector] public bool isTimerOn = false;

    private int[] angles = { 0, 90, 180, 270, 360 };

    public Object dice;
    public static Dice instance;

    private void Awake()
    {
        instance = this;
    }

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
        rolledTime = 0;
        if (!isTimerOn) StartCoroutine(RollTime());
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

    private IEnumerator RollTime()
    {
        isTimerOn = true;
        yield return null;
        
        rolledTime += Time.deltaTime;
        Debug.Log("rolledTime: " + rolledTime);
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
