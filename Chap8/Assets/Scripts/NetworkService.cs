using System.Collections;
using System;
using UnityEngine;

public class NetworkService
{
    private const string xmlApi = "http://api.openweathermap.org/data/2.5/weather?APPID=6940bacb2825a8c8a6b159196b80a9e9&zip=73013,us&mode=xml";

    private bool IsResponseValid(WWW www)
    {
        if (www.error != null)
        {
            Debug.Log(www.error.ToString() + ": Bad Connection");
            return false;
        }
        else if (string.IsNullOrEmpty(www.text))
        {
            Debug.Log("bad data");
            return false;
        }
        else
        {
            Debug.Log("all good");
            return true;
        }
    }

    private IEnumerator CallAPI(string url, Action<string> callback)
    {
        WWW www = new WWW(url);
        yield return www;

        if (!IsResponseValid(www))
        {
            yield break;
        }

        callback(www.text);
    }

    public IEnumerator GetWeatherXML(Action<string> callback)
    {
        return CallAPI(xmlApi, callback);
    }

}
