using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.IO;

public class NewBehaviourScript : MonoBehaviour
{
    public Button Button;
    public Text Text;

    void Start()
    {
        Button btn = Button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
		string str = RequestWeatherData ();
		Text.text = str;
		Debug.Log (str);
	}

	public static string RequestWeatherData () 
	{
		const string url = "http://api.geonames.org/weatherJSON?north=44.1&south=-9.9&east=-22.4&west=55.2&username=demo";
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create (url);
		request.Method = "GET";
		var webResponse = request.GetResponse ();
		var webStream = webResponse.GetResponseStream ();
		var responseReader = new StreamReader (webStream);
		var response = responseReader.ReadToEnd ();
		return response;
	}
}