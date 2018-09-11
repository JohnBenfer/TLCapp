/*
 * App created by John Benfer
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Net;

// input tag for username
// <input type="text" autocomplete="off" placeholder="User ID" class="inforTextbox" name="login" id="loginField">

// input tag for password
// <input type="password" autocomplete="off" class="inforTextbox" placeholder="Password" name="password" id="passwordField">

namespace TLCapp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string URL = "https://mytlc.bestbuy.com/";
        string TLC = "https://mytlc.bestbuy.com/etm/login.jsp";
        string Twitter = "https://twitter.com/login";
        string username;
        string password;
        string a = "a1280608";
        string p = "Jb321321";


        /// <summary>
        /// login button click
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            username = text_id.Text;
            password = text_password.Text;

            var inputElements = webbMain.Document.GetElementsByTagName("input");
            foreach (HtmlElement i in inputElements)
            {
                if (i.GetAttribute("name").Equals("login"))
                {
                    //i.InnerText = username;
                    i.InnerText = a;
                }
                if (i.GetAttribute("name").Equals("password"))
                {
                    i.Focus();
                    //i.InnerText = password;
                    i.InnerText = p;
                }
            }
        }



        /// <summary>
        /// opens webpage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Load_button_Click(object sender, EventArgs e)
        {
            load(TLC);
            
        }

        /// <summary>
        /// navigates to the webpage
        /// </summary>
        /// <param name="URL"></param>
        /// <returns></returns>
        private void load(string URL)
        {
            webbMain.Navigate(URL);
            //Console.WriteLine(webbMain.ReadyState.ToString());
            
        }

        /// <summary>
        /// clicks the enter button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Enter_button_Click(object sender, EventArgs e)
        {
            var inputElements = webbMain.Document.GetElementsByTagName("button");
            foreach (HtmlElement i in inputElements)
            {
                i.InvokeMember("Click");
                
            }

        }


        Dictionary<int, string> shifts = new Dictionary<int, string>();
        Stack<int> days = new Stack<int>();

        int day;
        string time;
        private void shifts_button_Click(object sender, EventArgs e)
        {

            

            var spanElements = webbMain.Document.All;
            foreach(HtmlElement i in spanElements)
            {

                //Console.WriteLine(i.GetAttribute("className"));
                //Console.Write(" " + i.GetAttribute("data"));
                //Console.WriteLine(i.TagName);

                // gets current day
                if (i.GetAttribute("className").Equals("calendarDateCurrent"))
                {
                    //Console.WriteLine("Current day " + i.InnerText);
                    days.Push(Convert.ToInt32(i.InnerText));
                }

                // gets day
                if (i.GetAttribute("className").Equals("calendarDateNormal"))
                {
                    //Console.WriteLine(i.InnerText);
                    days.Push(Convert.ToInt32(i.InnerText));
                }
                
                // gets shift
                if (i.GetAttribute("className").Equals("calendarTextShiftName"))
                {
                    //Console.WriteLine(i.InnerText);
                    time = i.InnerText;
                    
                    shifts.Add(days.Pop(), time);
                }

            }// close foreach

            

            foreach(KeyValuePair<int, string> kvp in shifts)
            {
                Console.WriteLine(kvp.Key.ToString() + " " + kvp.Value.ToString());
                //Console.WriteLine(" " + kvp.Value.ToString());
            }

        }


        private void hop()
        {
            
            WebClient webClient = new WebClient();
            string page = webClient.DownloadString(webbMain.Url);

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(page);
            //Console.WriteLine(page);

            List<List<string>> table = doc.DocumentNode.SelectSingleNode("//table[@class='mydata']")
                        .Descendants("tr")
                        .Skip(1)
                        .Where(tr => tr.Elements("td").Count() > 1)
                        .Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim()).ToList())
                        .ToList();


            Console.WriteLine(table[0][0].ToString());
        }







       




         































        private void Refresh_button_Click(object sender, EventArgs e)
        {
            hop();
        }


        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }


    }
}









