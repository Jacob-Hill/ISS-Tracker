using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class WorldClock
{
    private readonly WebClient wb;

    public WorldClock()
    {
        wb = new WebClient();
    }

    private Dictionary<string, string> RequestTimeInfo()
    {
        string responseString = wb.DownloadString("http://worldtimeapi.org/api/timezone/Europe/London.txt");
        responseString = responseString.Replace(" ", "");
        string[] responseArray = responseString.Split('\n');
        Dictionary<string, string> responseDictionary = new Dictionary<string, string>();
        foreach(string line in responseArray)
        {
            string key = "";
            string data = "";
            bool pastColon = false;
            foreach(char character in line)
            {
                if (!pastColon)
                {
                    if (character == ':')
                    {
                        pastColon = true;
                    }
                    else
                    {
                        key += character;
                    }
                }
                else
                {
                    data += character;
                }
            }
            responseDictionary.Add(key, data);
        }
        return responseDictionary;
    }

    public Clock Clock()
    {
        Dictionary<string, string> TimeInfo = RequestTimeInfo();
        string UTCDateTime = TimeInfo["utc_datetime"];
        string[] split1 = UTCDateTime.Split('-');
        string[] split2 = split1[2].Split('T');
        List<string> DateTimeList = new List<string>();
        DateTimeList.Add(split1[0]);
        DateTimeList.Add(split1[1]);
        DateTimeList.Add(split2[0]);
        string segment = "";
        for(int i = 0; i<split2[1].Length; i++)
        {
            if(split2[1][i] == ':')
            {
                DateTimeList.Add(segment);
                segment = "";
            }
            else
            {
                if (split2[1][i] == '+')
                {
                    DateTimeList.Add(segment);
                    segment = "";
                }
                else
                {
                    segment += split2[1][i];
                }
            }
        }
        return new Clock(DateTimeList[0], DateTimeList[1], DateTimeList[2], DateTimeList[3], DateTimeList[4], DateTimeList[5]);

    }
}
