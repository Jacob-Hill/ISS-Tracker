using UnityEngine;
using UnityEngine.UI;

public class PositionPanel : MonoBehaviour
{
    private Text Longitude;
    private Text Latitude;
    private ISS ISS;
    private string longitude;
    private string latitude;

    // Start is called before the first frame update
    void Start()
    {
        Longitude = GameObject.Find("Longitude").GetComponent<Text>();
        Latitude = GameObject.Find("Latitude").GetComponent<Text>();
        ISS = (ISS)GameObject.Find("ISS").GetComponent(typeof(ISS));
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
        UpdatePanel();
    }

    void UpdatePosition()
    {
        Position position = ISS.Position;
        longitude = position.Long.ToString();
        latitude = position.Lat.ToString();
    }

    void UpdatePanel()
    {
        Longitude.text = longitude;
        Latitude.text = latitude;
    }
}
