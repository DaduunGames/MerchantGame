using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float time;
    public float FullDayLength;
    public float StartTime = 0.4f;
    private float timeRate;
    public Vector3 Noon;

    [Header("Sun")]
    public Light sun;
    public Gradient sunColour;
    public AnimationCurve sunIntensity;

    [Header("Moon")]
    public Light moon;
    public Gradient moonColour;
    public AnimationCurve moonIntensity;

    [Header("Other settings")]
    public AnimationCurve LightingIntesityMultiplyer;
    public AnimationCurve ReflectionsIntesityMultiplyer;

    private void Start()
    {
        timeRate = 1.0f / FullDayLength;
        time = StartTime;
    }

    private void Update()
    {
        //incriment time
        time += timeRate * Time.deltaTime;
        if (time >= 1.0f)
        {
            time = 0.0f;
        }

        // light rotation
        sun.transform.eulerAngles = (time - 0.25f) * Noon * 4.0f;
        moon.transform.eulerAngles = (time - 0.75f) * Noon * 4.0f;

        //light intensity

        sun.intensity = sunIntensity.Evaluate(time);
        moon.intensity = moonIntensity.Evaluate(time);

        //change colours
        sun.color = sunColour.Evaluate(time);
        moon.color = moonColour.Evaluate(time);

        #region enable/disable the sun/moon
        {//enable/disable the sun/moon
            //enable/disable the sun
            if (sun.intensity <= 0.3 && sun.gameObject.activeInHierarchy)
            {
                sun.gameObject.SetActive(false);
            }
            else if (sun.intensity > 0.3 && !sun.gameObject.activeInHierarchy)
            {
                sun.gameObject.SetActive(true);
            }

            //enable/disable the moon
            if (moon.intensity <= 0 && moon.gameObject.activeInHierarchy)
            {
                moon.gameObject.SetActive(false);
            }
            else if (moon.intensity > 0 && !moon.gameObject.activeInHierarchy)
            {
                moon.gameObject.SetActive(true);
            }
        }
        #endregion
    }
}





