using System;
using UnityEngine;

public class RotateEarth : MonoBehaviour
{
    WorldClock WorldClock;
    Clock Clock;

    // Start is called before the first frame update
    void Start()
    {
        WorldClock = new WorldClock();
        Clock = WorldClock.Clock();
        int timeInSeconds;
        timeInSeconds = Convert.ToInt32(Clock.Second + Clock.Minute * 60 + Clock.Hour * 60 * 60);
        float angle = 360 * timeInSeconds / (24 * 60 * 60);
        transform.rotation = Quaternion.Euler(Vector3.up * angle);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * 360 * Time.deltaTime / (24 * 60 * 60));
    }
}
