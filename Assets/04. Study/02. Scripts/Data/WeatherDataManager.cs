using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WeatherDataManager : MonoBehaviour
{
    public enum WeatherType { Sun, Cloud, Rain, Snow }
    public WeatherType weatherType;
    
    private string URL = "http://apis.data.go.kr/1360000/VilageFcstInfoService_2.0/getVilageFcst?";

    public string key;
    public string numOfRows;
    public string pageNo;
    public string dataType;
    public string base_date;
    public string base_time;
    public string nx;
    public string ny;

    public WeatherData.Root weatherData;
    private int currentPTY;
    private int currentSKY;

    IEnumerator Start()
    {
        URL += $"serviceKey={key}&numOfRows={numOfRows}&pageNo={pageNo}&dataType={dataType}" +
               $"&base_date={base_date}&base_time={base_time}&nx={nx}&ny={ny}";

        UnityWebRequest www = UnityWebRequest.Get(URL);
        Debug.Log(www.url);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Failed Data : " + www.error);
        }
        else
        {
            string data = www.downloadHandler.text;

            Debug.Log(data); // JSON 파일

            weatherData = JsonUtility.FromJson<WeatherData.Root>(data); // JSON 데이터 파싱

            foreach (var item in weatherData.response.body.items.item)
            {
                if (item.category == "PTY")
                {
                    currentPTY = int.Parse(item.fcstValue);
                }
                else if (item.category == "SKY")
                {
                    currentSKY = int.Parse(item.fcstValue);
                }
            }
            
            SetWeatherType();
        }
    }

    private void SetWeatherType()
    {
        if (currentSKY == 1 && currentPTY == 0)
        {
            weatherType = WeatherType.Sun;
        }
        else if (currentSKY == 3 || currentSKY == 4) 
        {
            weatherType = WeatherType.Cloud;
        } 
        else if (currentPTY == 1 || currentPTY == 2 || currentPTY == 4)
        {
            weatherType = WeatherType.Rain;
        }
        else if (currentPTY == 3)
        {
            weatherType = WeatherType.Snow;
        }

        Debug.Log($"현재 날씨는 {weatherType}입니다.");
    }
}