using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tagayasu7AspNetCoreApp1
{
    public class Event
    {
        // レスポンスフィールド
        public class ConnpassApiResponse
        {
            public List<EventItem> events { get; set; }
            public int Results_returned { get; set; }
            public int Results_start { get; set; }
            public int results_available { get; set; }
        }

        // レスポンスフィールド(検索結果のイベントリスト)
        public class EventItem
        {
            // connpass.com 上のURL
            [DataType(DataType.Url)]
            public string event_url { get; set; }
            // イベント参加タイプ
            public string event_type { get; set; }
            // 管理者のニックネーム
            public string owner_nickname { get; set; }
            // グループ
            public Series series { get; set; }
            // 更新日時 (ISO-8601形式)
            public DateTime updated_at { get; set; }
            // 開催会場の緯度
            public string lat { get; set; }
            // イベント開催日時 (ISO-8601形式)
            public DateTime started_at { get; set; }
            // Twitterのハッシュタグ
            public string hash_tag { get; set; }
            // タイトル
            public string title { get; set; }
            // イベントID
            public int event_id { get; set; }
            // 開催会場の経度
            public string lon { get; set; }
            // 補欠者数
            public int waiting { get; set; }
            // 定員
            public object limit { get; set; }
            // 管理者のID
            public int owner_id { get; set; }
            // 管理者の表示名
            public string owner_display_name { get; set; }
            // 概要(HTML形式)
            [DataType(DataType.Html)]
            public string description { get; set; }
            // 開催場所
            public string address { get; set; }
            // キャッチ
            public string _catch { get; set; }
            // 参加者数
            public int accepted { get; set; }
            // イベント終了日時 (ISO-8601形式)
            public DateTime ended_at { get; set; }
            // 開催会場
            public string place { get; set; }
        }

        // グループ
        public class Series
        {
            // グループのconnpass.com 上のURL
            public string url { get; set; }
            // グループID
            public int id { get; set; }
            // グループタイトル
            public string title { get; set; }
        }

        public static List<EventItem> GetEvents(string keyword)
        {
            string url = "https://connpass.com/api/v1/event/?keyword=" + keyword;

            WebClient webClient = new WebClient();
            webClient.Headers.Add("User-Agent: Other");
            string str = webClient.DownloadString(url);

            var data = JsonConvert.DeserializeObject<ConnpassApiResponse>(str);
            var list = new List<EventItem>();
            foreach (EventItem el in data.events)
            {
                list.Add(el);
            }

            list.Sort((x, y) => DateTime.Compare(y.started_at, x.started_at));

            return list;
        }

        public static List<EventItem> GetEvents(int? eventid)
        {
            string url = "https://connpass.com/api/v1/event/?event_id=" + eventid;

            WebClient webClient = new WebClient();
            webClient.Headers.Add("User-Agent: Other");
            string str = webClient.DownloadString(url);

            var data = JsonConvert.DeserializeObject<ConnpassApiResponse>(str);
            var list = new List<EventItem>();
            foreach (EventItem el in data.events)
            {
                list.Add(el);
            }

            list.Sort((x, y) => DateTime.Compare(y.started_at, x.started_at));

            return list;
        }
    }
}
