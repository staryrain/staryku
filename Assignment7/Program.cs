using System;
using System.Threading;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Security.Policy;
using System.Xml.Linq;


namespace ConsoleApp网络实验
{
    internal class Crawler
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;
        List<string> list = new List<string>();//限制爬行的页面必须在list中
        static void Main(string[] args)
        {
            
            Crawler myCrawler = new Crawler();
            string startUrl = "http://www.cnblogs.com/dstang2000";
            if(args.Length > 1) { startUrl = args[0]; }
            myCrawler.urls.Add(startUrl, false);
            new Thread(myCrawler.Crawl).Start();
        }
        
        private void Crawl()
        {
            Console.WriteLine("开始爬行");
            while(true)
            {
                string current = null;
                foreach(string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    foreach(string urllimit in list)
                        if (url == urllimit ) current = url;


                }
                if(current == null||count>10) {break;  }
                Console.WriteLine("爬行" + current + "页面!");
                string document = DownLoad(current);
                Regex ishtml = new Regex(@"^<!DOCTYPE html>"); //判断文档是否为HTML
                Regex ishtm = new Regex(@"^<!DOCTYPE htm>"); //判断文档是否为htm
                Regex isaspx = new Regex(@"^<!DOCTYPE aspx>"); //判断文档是否为aspx
                Regex isphp = new Regex(@"^<!DOCTYPE php>"); //判断文档是否为php
                Regex isjsp = new Regex(@"^<!DOCTYPE jsp>"); //判断文档是否为jsp
                urls[current] = true;       //
                count++;
                string temp = current;
                if (ishtml.IsMatch(document))
                {
                    Parse(document);//解析,并加入新的链接
                   
                }
                else if (ishtm.IsMatch(document))
                {
                    Parse(document);
                   
                }
                else if (isaspx.IsMatch(document))
                {
                    Parse(document);
                   
                }
                else if (isphp.IsMatch(document))
                {
                    Parse(document);
                    
                }
                else if (isjsp.IsMatch(document))
                {
                    Parse(document);
                    
                }//爬取的是htm/html……才解析
                
                urls[current] = true;
                count++;
               
            }
            Console.WriteLine("爬行结束");
            Console.ReadLine();
        }
        public string DownLoad(string url)
        {
            try
            {
                WebClient webclient = new WebClient();
                webclient.Encoding = Encoding.UTF8;
                string html = webclient.DownloadString(url);

                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }
        public void Parse(string html)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches=new Regex(strRef).Matches(html);
           
            foreach (Match match in matches)
            {
                if (match.Value.IndexOf(" / ") == 0) 
                    strRef= "http://www.cnblogs.com/dstang2000"+match.Value;//将相对地址转换为绝对地址
                else
                    strRef =match.Value.Substring(match.Value.IndexOf('=')+1).Trim('"');
                if (strRef.Length == 0) continue;

                if (urls[strRef] == null ) { urls[strRef] = false; }
                
            }
            
        }
    }
}
