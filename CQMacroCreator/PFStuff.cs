using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayFab;
using PlayFab.ClientModels;
using System.Threading;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CQMacroCreator
{

    class PFStuff
    {
        static public bool logres;
        static public bool DQResult;
        static public string DQlvl;
        static bool _running = true;
        string token;
        string kongID;
        public static int questID;
        public static List<int[]> getResult;
        public static int followers;
        public static int[] lineup;
        public static List<int> questList;
        public static int CSamount;
        public PFStuff(string t, string kid)
        {
            token = t;
            kongID = kid;
        }

        public void LoginKong()
        {
            PlayFabSettings.TitleId = "E3FA";
            var request = new LoginWithKongregateRequest
            {
                AuthTicket = token,
                CreateAccount = false,
                KongregateId = kongID,
            };
            var loginTask = PlayFabClientAPI.LoginWithKongregateAsync(request);
            while (_running)
            {
                if (loginTask.IsCompleted)
                {
                    var apiError = loginTask.Result.Error;
                    var apiResult = loginTask.Result.Result;

                    if (apiError != null)
                    {
                        logres = false;
                        return;
                    }
                    else if (apiResult != null)
                    {
                        logres = true;
                        return;
                    }
                    _running = true;
                }
                Thread.Sleep(1);
            }
            logres = false;
            return;
        }

        public void GetGameData()
        {
            questList = new List<int>();
            getResult = new List<int[]>();
            var request = new ExecuteCloudScriptRequest()
            {
                RevisionSelection = CloudScriptRevisionOption.Live,
                FunctionName = "status",
                FunctionParameter = new { token = token, kid = kongID }
            };
            var statusTask = PlayFabClientAPI.ExecuteCloudScriptAsync(request);
            bool _running = true;
            while (_running)
            {
                if (statusTask.IsCompleted)
                {
                    var apiError = statusTask.Result.Error;
                    var apiResult = statusTask.Result.Result;

                    if (apiError != null)
                    {
                        return;
                    }
                    else if (apiResult.FunctionResult != null)
                    {
                        JObject json = JObject.Parse(apiResult.FunctionResult.ToString());
                        string el = json["data"]["city"]["daily"]["setup"].ToString();
                        string elvl = json["data"]["city"]["daily"]["hero"].ToString();
                        string levels = json["data"]["city"]["hero"].ToString();
                        string quests = json["data"]["city"]["quests"].ToString();
                        DQlvl = json["data"]["city"]["daily"]["lvl"].ToString();
                        quests = quests.Substring(1, quests.Length - 2);
                        questList = quests.Split(',').Select(Int32.Parse).ToList();
                        followers = Convert.ToInt32(json["data"]["followers"].ToString());
                        int[] heroLevels = getArray(levels);
                        int[] enemyLineup = getArray(el);
                        int[] enemyLevels = getArray(elvl);
                        getResult.Add(heroLevels);
                        getResult.Add(enemyLineup);
                        getResult.Add(enemyLevels);
                        return;
                    }
                    _running = false;
                }
                Thread.Sleep(1);
            }
            return;
        }

        public void sendDQSolution()
        {
            var request = new ExecuteCloudScriptRequest()
            {
                RevisionSelection = CloudScriptRevisionOption.Live,
                FunctionName = "pved",
                FunctionParameter = new { setup = lineup, kid = kongID, max = true }
            };
            var statusTask = PlayFabClientAPI.ExecuteCloudScriptAsync(request);
            bool _running = true;
            while (_running)
            {
                if (statusTask.IsCompleted)
                {
                    var apiError = statusTask.Result.Error;
                    var apiResult = statusTask.Result.Result;

                    if (apiError != null)
                    {
                        DQResult = false;
                        return;
                    }
                    else if (apiResult.FunctionResult != null)
                    {
                        getResult = new List<int[]>();

                        JObject json = JObject.Parse(apiResult.FunctionResult.ToString());
                        string el = json["data"]["city"]["daily"]["setup"].ToString();
                        string elvl = json["data"]["city"]["daily"]["hero"].ToString();
                        string levels = json["data"]["city"]["hero"].ToString();
                        DQlvl = json["data"]["city"]["daily"]["lvl"].ToString();
                        int[] heroLevels = getArray(levels);
                        int[] enemyLineup = getArray(el);
                        int[] enemyLevels = getArray(elvl);
                        getResult.Add(heroLevels);
                        getResult.Add(enemyLineup);
                        getResult.Add(enemyLevels);

                        DQResult = true;
                        return;
                    }
                    _running = false;
                }
                Thread.Sleep(1);
            }
            DQResult = false;
            return;
        }     


        public void sendQuestSolution()
        {
            var request = new ExecuteCloudScriptRequest()
            {
                RevisionSelection = CloudScriptRevisionOption.Live,
                FunctionName = "pve",
                FunctionParameter = new { setup = lineup, id = questID }
            };
            var statusTask = PlayFabClientAPI.ExecuteCloudScriptAsync(request);
            bool _running = true;
            while (_running)
            {
                if (statusTask.IsCompleted)
                {
                    var apiError = statusTask.Result.Error;
                    var apiResult = statusTask.Result.Result;

                    if (apiError != null)
                    {
                        DQResult = false;
                        return;
                    }
                    else if (apiResult != null)
                    {
                        DQResult = true;
                        return;
                    }
                    _running = false;
                }
                Thread.Sleep(1);
            }
            DQResult = false;
            return;
        }

        private int[] getArray(string s)
        {
            s = Regex.Replace(s, @"\s+", "");
            s = s.Substring(1, s.Length - 2);
            int[] result = s.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
            return result;
        }
    }
}
