using UnityEngine;

public class coin_handler : MonoBehaviour
{
    public float rotationSpeed = 90f;        // درجه در ثانیه
    public float floatAmplitude = 0.2f;      // شدت بالا پایین شدن
    public float floatFrequency = 1f;        // سرعت بالا پایین شدن

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        RotateCoin();
        FloatCoin();
    }

    void RotateCoin()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.Self);
    }

    void FloatCoin()
    {
        Vector3 newPos = startPos;
        newPos.y += Mathf.Sin(Time.time * Mathf.PI * floatFrequency) * floatAmplitude;
        transform.position = newPos;
    }
}
