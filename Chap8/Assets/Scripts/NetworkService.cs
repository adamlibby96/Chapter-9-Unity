using System.Collections;
using System;
using UnityEngine;

public class NetworkService
{
    private const string xmlApi = "http://api.openweathermap.org/data/2.5/weather?APPID=a625a203bcef480ec4d39621e568ac2a&zip=73013,us&mode=xml";
    private const string webImage = "http://upload.wikimedia.org/wikipedia/commons/c/c5/Moraine_Lake_17092005.jpg";


    private bool IsResponseValid(WWW www)
    {
        if (www.error != null)
        {
            Debug.Log("bad connection");
            return false;
        }
        else if (string.IsNullOrEmpty(www.text))
        {
            Debug.Log("bad data");
            return false;
        }
        else
        { // all good
            return true;
        }
    }
    private IEnumerator CallAPI(string url, Action<string> callback)
    {
        WWW www = new WWW(url);
        yield return www;

        if (!IsResponseValid(www))
            yield break;

        callback(www.text);
    }
    public IEnumerator GetWeatherXML(Action<string> callback)
    {
        return CallAPI(xmlApi, callback);
    }

    public IEnumerator DownloadImage(Action<Texture2D> callback)
    {
        WWW www = new WWW(webImage);
        yield return www;
        callback(www.texture);
    }
}