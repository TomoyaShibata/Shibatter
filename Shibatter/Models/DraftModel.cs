using System;
using Newtonsoft.Json;

namespace Shibatter.Models
{
    class DraftModel
    {
        /// <summary>
        /// 作成日時
        /// </summary>
        public string CreatedAt { get; set; }
        /// <summary>
        /// ツイート文字列
        /// </summary>
        public string TweetText { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="tweetText"></param>
        public DraftModel(string tweetText)
        {
            this.CreatedAt = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            this.TweetText = tweetText;
        }

        [JsonConstructor]
        public DraftModel(object o)
        {

        }
    }
}
