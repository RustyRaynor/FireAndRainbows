using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class PlayFabLeaderBoard : MonoBehaviour {

    [SerializeField] private GameManager gameManager;

 	[SerializeField] private GameObject scoreBordPannel;
    [SerializeField] private GameObject inputPannel;
    [SerializeField] private GameObject errorMessage;
    [SerializeField] private Text scoreText;
    // Transfission Data
    //[SerializeField] private string sendDataURL;
    //[SerializeField] private string reciveDataURL;
    // User Input submit
    [SerializeField] private InputField nameInField;
    [SerializeField] private InputField emailInField;

    [SerializeField] private GameObject LeaderBoardRaw;
    [SerializeField] private Transform LeaderBoardRawParent;

    private string[] scoreTextList;
    private bool inFieldShow = false;
    private float callTime;
	private string password = "FARBgame";
	public int lastScore;

    public void SubmitCredentials()
    {
        inputPannel.SetActive(false);
        PlayerPrefs.SetString("emailId", emailInField.text);
        PlayerPrefs.SetString("userName", nameInField.text);
        OnLoginGame();
    }


	public void OnLoginGame()
	{
        if(Application.internetReachability == NetworkReachability.NotReachable)
        {
            StartCoroutine(ShowError());
            return;
        }

        if(PlayerPrefs.HasKey("emailId"))
        {
            emailInField.text = PlayerPrefs.GetString("emailId");
            nameInField.text = PlayerPrefs.GetString("userName");
        }

        else
        {
            inputPannel.SetActive(true);
            return;
        }

		var request = new LoginWithEmailAddressRequest{Email = emailInField.text, Password = password};
		PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
	}

    IEnumerator ShowError()
    {
        errorMessage.SetActive(true);
        yield return new WaitForSeconds(3);
        errorMessage.SetActive(false);

    }

    public void OnCancel()
    {
        var request = new LoginWithCustomIDRequest { CustomId = "7B_noob", CreateAccount = true};
        PlayFabClientAPI.LoginWithCustomID(request, OnCancelLoginSuccess, OnCancelLoginFailure);
        
    }

    private void OnCancelLoginSuccess(LoginResult result)
    {
        Debug.Log("Logged In...");
       GetLeaderBoard();
    }

    private void OnCancelLoginFailure(PlayFabError error)
    {
        Debug.Log("Logged In Failed...");
        GetLeaderBoard();
    }
    

	private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Logged In...");
        gameManager.StartGame();
        GetScore();
    //    GetScoreAndMatch();
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("Unable To login...");
        Debug.LogError(error.GenerateErrorReport());
	
		var registerRequest = new RegisterPlayFabUserRequest{Email = emailInField.text, Password = password, Username = nameInField.text};
		PlayFabClientAPI.RegisterPlayFabUser(registerRequest, OnRegistrationSucces, OnRegistrationFailed);
    }

	private void OnRegistrationSucces(RegisterPlayFabUserResult result)
	{
		Debug.Log("Registered...");
		PlayFabClientAPI.UpdateUserTitleDisplayName(new UpdateUserTitleDisplayNameRequest{DisplayName = nameInField.text}, DisplayNameSetSucces, DisplayNameSetFailed);
        gameManager.StartGame();
        GetScore();
    }

	private void OnRegistrationFailed(PlayFabError error)
	{
        Debug.LogError(error.GenerateErrorReport());
        // no choice
    //    GetLeaderBoard();
	}

	void DisplayNameSetSucces(UpdateUserTitleDisplayNameResult result)
	{
	//	GetScoreAndMatch();
	}

	void DisplayNameSetFailed(PlayFabError error)
	{
        // no choice
    //    GetLeaderBoard();
	}


    public void StartCloudUpdatePlayerStats(int Score)
	{
        Invoke("GetLeaderBoard", 3);
        if(Score <= lastScore) return;
		PlayFabClientAPI.ExecuteCloudScript(new ExecuteCloudScriptRequest()
		{
			FunctionName = "UpdatePlayerStats",
			FunctionParameter = new {HighScore = Score},
			GeneratePlayStreamEvent = true,
		}, OnCloudUpdateSucces, OnCloudUpdateFailed);
	}

	void OnCloudUpdateSucces(ExecuteCloudScriptResult result)
	{
		Debug.Log("Cloud Updation Succeded : " + result.Logs);
   //     Invoke("GetLeaderBoard", 5);
	}

	void OnCloudUpdateFailed(PlayFabError error)
	{
		Debug.LogError("Cloud Updation Failed : " + error.GenerateErrorReport());
   //     Invoke("GetLeaderBoard", 5);
	}

    private string playerName;

    public void GetLeaderBoard()
	{
		var requestLeaderboard = new GetLeaderboardRequest{ StartPosition = 0, StatisticName = "HighScore", MaxResultsCount = 20 };
		PlayFabClientAPI.GetLeaderboard(requestLeaderboard, OnGetLeaderBoard, OnFailedLeaderBoard);
	}

	void OnGetLeaderBoard(GetLeaderboardResult result)
	{
        int i = 0;
        bool me = false;
		foreach (var playerData in result.Leaderboard)
		{
            if(playerData.DisplayName == nameInField.text) me = true;
            else me = false;
            LeaderboardRaw lbObj = Instantiate(LeaderBoardRaw, LeaderBoardRawParent).GetComponent<LeaderboardRaw>();
            lbObj.SetInfo(playerData.DisplayName, playerData.StatValue.ToString(), me);
            i++;
		}
	}

	void OnFailedLeaderBoard(PlayFabError error)
	{
		Debug.LogError(error.GenerateErrorReport());
	}

    /// picking the last score
    public void GetScore()
	{
		PlayFabClientAPI.GetPlayerStatistics(
			new GetPlayerStatisticsRequest(),
			GetScoreSucces,
			error => Debug.LogError(error.GenerateErrorReport())
		);  
	}

	void GetScoreSucces(GetPlayerStatisticsResult result)
	{
		foreach(var eachData in result.Statistics)
		{
			lastScore = eachData.Value;
		}
	}

}
