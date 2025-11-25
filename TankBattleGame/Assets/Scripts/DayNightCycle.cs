using UnityEngine;

[RequireComponent(typeof(Light))]
public class DayNightCycle : MonoBehaviour
{
    private Light directionalLight;         // Automatically get Light from this GameObject

    [Header("Light Settings")]
    public float dayIntensity = 1.2f;
    public float nightIntensity = 0.1f;
    public Gradient lightColor;             // Optional color change

    [Header("Cycle Settings")]
    public float secondsPerFullDay = 60f;   // 1 minute = full day
    [Range(0, 1)] public float currentTimeOfDay = 0;
    public float timeMultiplier = 1f;

    private void Awake()
    {
        // Automatically get the Light component from the same GameObject
        directionalLight = GetComponent<Light>();
    }

    void Update()
    {
        // Time progression
        currentTimeOfDay += (Time.deltaTime / secondsPerFullDay) * timeMultiplier;
        if (currentTimeOfDay >= 1) currentTimeOfDay = 0;

        // Rotate the light (simulate the sun path)
        float sunAngle = currentTimeOfDay * 360f - 90f;
        transform.rotation = Quaternion.Euler(sunAngle, 170f, 0);

        // Adjust light intensity based on the sun's position
        float intensityMultiplier = 1f;
        if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f)
        {
            intensityMultiplier = 0f; // Night
        }
        else if (currentTimeOfDay <= 0.25f)
        {
            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * 50f);
        }
        else if (currentTimeOfDay >= 0.73f)
        {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * 50f));
        }

        directionalLight.intensity = Mathf.Lerp(nightIntensity, dayIntensity, intensityMultiplier);

        // Optional: smoothly change color
        if (lightColor != null)
        {
            directionalLight.color = lightColor.Evaluate(intensityMultiplier);
        }
    }
}
