using System;
using System.Collections.Generic;
using System.Net;

public class Tracking
{

    private readonly WebClient wb;

    public Tracking()
    {
        wb = new WebClient();
    }

    private Dictionary<string, object> RequestISSInfo()
    {
        Uri uri = new Uri("http://api.open-notify.org/iss-now.json");
        string responseString = wb.DownloadString(uri);
        responseString = responseString.Replace(":", "");
        responseString = responseString.Replace(" ", "");
        responseString = responseString.Replace(",", "");
        responseString = responseString.Replace("{", "");
        responseString = responseString.Replace("}", "");
        Console.WriteLine(responseString);
        string[] responseArray = responseString.Split('"');
        List<string> responseList = new List<string>();
        foreach (string item in responseArray)
        {
            if (item != "")
            {
                responseList.Add(item);
            }
        }
        Dictionary<string, object> responseDictionary = new Dictionary<string, object>();
        Dictionary<string, string> issPosition = new Dictionary<string, string>();
        for (int i = 0; i<responseList.Count; i++)
        {
            if(responseList[i] == "message")
            {
                responseDictionary.Add(responseList[i], responseList[i + 1]);
            }
            else if (responseList[i] == "timestamp")
            {
                responseDictionary.Add(responseList[i], responseList[i + 1]);
            }
            else if (responseList[i] == "longitude")
            {
                issPosition.Add(responseList[i], responseList[i + 1]);
            }
            else if (responseList[i] == "latitude")
            {
                issPosition.Add(responseList[i], responseList[i + 1]);
            }
        }
        responseDictionary.Add("iss_position", issPosition);
        return responseDictionary;
    }

    public Position ISSPosition()
    {
        Dictionary<string, object> ISSInfo = RequestISSInfo();
        Dictionary<string, string> ISSPosition = (Dictionary<string, string>)ISSInfo["iss_position"];
        return new Position(ISSPosition["latitude"], ISSPosition["longitude"]);
    }
}


