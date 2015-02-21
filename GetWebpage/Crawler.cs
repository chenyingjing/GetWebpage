using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;


namespace GetWebpage
{
    class Crawler
    {
        private int _currentLevelCount = 0;
        private int _maxLevelCout = 17;
        private string _startUrl = string.Empty;
        private List<string> _urlInCurrentLevel = new List<string>();
        private List<string> _visitedUrl = new List<string>();
        private string _keywords = string.Empty;
        private string _folder = string.Empty;
        public delegate void FinishCallHandler();
        public FinishCallHandler finishCall;

        public Crawler(int maxLevelCout, string urlString, string folder, string keywords)
        {
            _maxLevelCout = maxLevelCout;
            _startUrl = urlString;
            _folder = folder;
            _keywords = keywords;
        }


        public void CrawlFromUrl()
        {
            try
            {
                if (!Directory.Exists(_folder))
                {
                    Directory.CreateDirectory(_folder);
                }

                //GetDataFromUrl(urlString, fileFullPath, keywords, 1);
                _urlInCurrentLevel.Add(_startUrl);
                Crawl();
                if (finishCall != null)
                {
                    finishCall();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Crawl()
        {
            _currentLevelCount++;
            if (_currentLevelCount > _maxLevelCout || _urlInCurrentLevel.Count <= 0)
            {
                return;
            }
            List<string> urlToProcess = new List<string>(_urlInCurrentLevel);
            _urlInCurrentLevel.Clear();
            foreach (var url in urlToProcess)
            {
                HandleUrl(url);
            }
            Crawl();
        }

        private void HandleUrl(string urlString)
        {
            string fileName = GetFile(urlString);
            //fileName += ".html";
            string fileFullPath = Path.Combine(_folder, fileName);
            _visitedUrl.Add(urlString);
            GetDataFromUrl(urlString, fileFullPath, _keywords);
        }

        /*
          Remove
          /\:*?"<>|
         */
        private string GetFile(string urlString)
        {
            urlString = urlString.Replace("/", "");
            urlString = urlString.Replace("\\", "");
            urlString = urlString.Replace(":", "");
            urlString = urlString.Replace("*", "");
            urlString = urlString.Replace("?", "");
            urlString = urlString.Replace("\"", "");
            urlString = urlString.Replace("<", "");
            urlString = urlString.Replace(">", "");
            urlString = urlString.Replace("|", "");
            return urlString;
        }

        private void GetDataFromUrl(string urlString, string fileName, string keywords)
        {
            //DownloadUrl(urlString, fileFullPath, keywords);
            byte[] page = GetBinaryData(urlString);

            AnalyzePageByKeywords(page, keywords, fileName);

            AnalyzeUrlInPage(page);

        }

        private void AnalyzePageByKeywords(byte[] page, string keywords, string fileName)
        {
            if (page == null)
            {
                return;
            }
            bool match = CheckIfThePageMatchKeywords(page, keywords);
            if (match)
            {
                WriteBinaryDataToFile(page, fileName);
            }
        }

        private void AnalyzeUrlInPage(byte[] page)
        {
            if (page == null)
            {
                return;
            }
            string pageString = Encoding.UTF8.GetString(page);

            string regex = "href=[\\\"\\\'](http:\\/\\/|\\.\\/|\\/)?\\w+(\\.\\w+)*(\\/\\w+(\\.\\w+)?)*(\\/|\\?\\w*=\\w*(&\\w*=\\w*)*)?[\\\"\\\']";
            //string regex = "(http:\\/\\/|\\.\\/|\\/)?\\w+(\\.\\w+)*(\\/\\w+(\\.\\w+)?)*(\\/|\\?\\w*=\\w*(&\\w*=\\w*)*)?";
            Regex re = new Regex(regex);
            MatchCollection matches = re.Matches(pageString);
            foreach (Match item in matches)
            {
                string urlInThePage = GetUrlFromLink(item.Value);
                if (!_visitedUrl.Contains(urlInThePage))
                {
                    _urlInCurrentLevel.Add(urlInThePage);
                }
                //Console.Write(item.Value + Environment.NewLine);
            }

        }

        private string GetUrlFromLink(string linkString)
        {
            string rel = linkString.Replace("href=\"", "");
            rel = rel.Replace("href=\'", "");
            if (rel[rel.Length - 1] == '\'' || rel[rel.Length - 1] == '"')
            {
                rel = rel.Remove(rel.Length - 1);
            }
            int indexOfQuery = rel.IndexOf('?');
            if (indexOfQuery != -1)
            {
                rel = rel.Remove(indexOfQuery);
            }
            return rel;
        }
        

        //private void DownloadUrl(string urlString, string fileName, string keywords)
        //{
        //    try
        //    {
        //        byte[] page = GetBinaryData(urlString);

        //        bool match = CheckIfThePageMatchKeywords(page, keywords);
        //        if (match)
        //        {
        //            WriteBinaryDataToFile(page, fileName);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        private byte[] GetBinaryData(string urlString)
        {
            try
            {
                WebClient aWebClient = new WebClient();
                //TODO: if url is not availabel(http://www.google.com), it is necessary to handle it.
                byte[] page = aWebClient.DownloadData(urlString);
                return page;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Cant access {0}.", urlString);
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private void WriteBinaryDataToFile(byte[] page, string fileName)
        {
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(page);
                bw.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool CheckIfThePageMatchKeywords(byte[] page, string keywords)
        {
            //string pageString = Encoding.Default.GetString(page);
            string pageString = Encoding.UTF8.GetString(page);

            string[] keywordsArray = keywords.Split(new char[] { ' ' });

            foreach (var keyword in keywordsArray)
            {
                if (!pageString.Contains(keyword))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
