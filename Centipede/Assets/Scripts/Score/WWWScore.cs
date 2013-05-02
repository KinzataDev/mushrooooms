using UnityEngine;
using System.Collections;

public class WWWScore : MonoBehaviour {
	
	public static string getURL = "http://localhost:8080/Lab7WebApp/ScoreList";
	
	
	public void postHighScore(string playerName, int score, int bullets, int mushrooms, int pedes)
	{
		WWWForm form = new WWWForm();
		
		Debug.Log(getURL);
		
		form.AddField("command", "postHighScore");
		form.AddField("playerName", playerName);
		form.AddField("score", score);
		form.AddField("bullets", bullets);
		form.AddField("mushrooms", mushrooms);
		form.AddField("pedes", pedes);
		
		WWW www = new WWW(getURL, form);
		
		StartCoroutine(WaitForRequest(www));
		
		while( !www.isDone )
		{}
	}
	
	public int getPersonalScore(string playerName)
	{
		WWWForm form = new WWWForm();
		
		form.AddField("command", "getPersonalScore");
		form.AddField("playerName", playerName);
		
		WWW www = new WWW(getURL, form);
		
		int score = -1;
		
		StartCoroutine(GetPersonalScoreRequest(www, value => score = value) );
		
		while( !www.isDone )
		{}
		
		return score;
	}
		
	IEnumerator GetPersonalScoreRequest(WWW www, System.Action<int> result)
	{
		while (!www.isDone )
		{}
		
		if( string.IsNullOrEmpty(www.text) )
		{
			result(-1);
			yield break;
		}
		
		Debug.Log(www.text);
		
		result(int.Parse(www.text));
	}
	
	public ScoreData[] getTopTenHighScores()
	{
		WWWForm form = new WWWForm();
		
		form.AddField("command", "getTenScores");
		
		WWW www = new WWW(getURL, form);

		string data = "";
		
		StartCoroutine(GetTenScoresRequest(www, value => data = value) );
		
		while( !www.isDone )
		{}
		
		if( data != "" )
		{
			Debug.Log(data);
		}
		
		ScoreData[] dataArray = new ScoreData[10];
		for(int j =0; j< dataArray.Length; j++)
		{
			dataArray[j] = new ScoreData();
		}
		int i = 0;
		foreach( string s in data.Split('\n') )
		{
			string[] ss = s.Split(',');
			if( ss.Length == 2 )
			{
				ScoreData temp = new ScoreData();
				temp.Name = ss[0];
				temp.Score = int.Parse(ss[1]);
				dataArray[i++] = temp;
			}
		}
		
//		ArrayList dataArray = new ArrayList();
//		dataArray.Add(new ScoreData());
		
		return dataArray;
	}
	
	IEnumerator GetTenScoresRequest(WWW www, System.Action<string> result)
	{
		while (!www.isDone )
		{}
		
		if( string.IsNullOrEmpty(www.text) )
		{
			result("");
			yield break;
		}
		
		result(www.text);
	}
	
	public StatData getStatsByName(string playerName)
	{
		WWWForm form = new WWWForm();
		
		form.AddField("command", "getStatsByName");
		form.AddField("playerName", playerName);
		
		WWW www = new WWW(getURL, form);

		string data = "";
		
		StartCoroutine(getStatsByNameRequest(www, value => data = value) );
		
		while( !www.isDone )
		{}
		
		if( data != "" )
		{
			Debug.Log(data);
		}
		
		StatData stats = new StatData();
		
		foreach( string s in data.Split('\n') )
		{
			string[] ss = s.Split(',');
			if( ss.Length == 3 )
			{
				stats.bullets = long.Parse(ss[0]);
				stats.mushrooms = int.Parse(ss[1]);
				stats.pedes = int.Parse(ss[2 ]);
			}
		}
		
		return stats;
	}
	
	IEnumerator getStatsByNameRequest(WWW www, System.Action<string> result)
	{
		while (!www.isDone )
		{}
		
		if( string.IsNullOrEmpty(www.text) )
		{
			result("");
			yield break;
		}
		
		result(www.text);
	}
	
	public StatData getTotalStats()
	{
		getURL = "http://localhost:8080/Lab7WebApp/ScoreList";
		WWWForm form = new WWWForm();
		
		form.AddField("command", "getTotalStats");
		
		WWW www = new WWW(getURL, form);

		string data = "";
		
		StartCoroutine(getStatsByNameRequest(www, value => data = value) );
		
		while( !www.isDone )
		{}
		
		if( data != "" )
		{
			Debug.Log(data);
		}
		
		StatData stats = new StatData();
		
		foreach( string s in data.Split('\n') )
		{
			string[] ss = s.Split(',');
			if( ss.Length == 4 )
			{
				stats.games = int.Parse(ss[0]);
				stats.bullets = long.Parse(ss[1]);
				stats.mushrooms = int.Parse(ss[2]);
				stats.pedes = int.Parse(ss[3]);
			}
		}
		
		return stats;
	}
	
	IEnumerator WaitForRequest(WWW www)
    {
        yield return www;
		
        // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.text);
        } else {
            Debug.Log("WWW Error: "+ www.error);
        }    
    }
}
