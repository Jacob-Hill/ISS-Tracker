using UnityEngine;

public class ISS : MonoBehaviour
{
    private Tracking Tracking;
    private int TimeTillNextRequest = 1;
    public Position Position;
    public int altitude = 419;

    void Start()
    {
        Tracking = new Tracking();
    }

    void Update()
    {
        if (Time.time >= TimeTillNextRequest)
        {
            TimeTillNextRequest++;
            Position = Tracking.ISSPosition();
        }
        MoveISS(Position);
    }

    void MoveISS(Position position)
    {
        float latitude = (float)position.Lat;
        float longitude = (float)position.Long;
        float radius = 20.17f / 6371 * altitude + 20.17f;
        Vector3 target = Quaternion.AngleAxis(longitude, -Vector3.up) * Quaternion.AngleAxis(latitude, -Vector3.right) * new Vector3(0, 0, radius);
        transform.localPosition += (target-transform.localPosition)*Time.deltaTime;
    }
}
