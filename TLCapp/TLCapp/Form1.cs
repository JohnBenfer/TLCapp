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
    public partial class TLC_form : Form
    {
        public TLC_form()
        {
            InitializeComponent();
            Scraper scraper = new Scraper(this);

        }




        string URL = "https://mytlc.bestbuy.com/";
        string TLC = "https://mytlc.bestbuy.com/etm/login.jsp";
        string Twitter = "https://twitter.com/login";
        string username;
        string password;
        string a = "a1280608";
        string p = "Jb654654";



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
        /// gets information regarding products from bestbuy.com
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ScrapeButton_Click(object sender, EventArgs e)
        {
            load("https://www.bestbuy.com/site/tvs/all-flat-screen-tvs/abcat0101001.c?id=abcat0101001");
            int c = 0;
            while (webbMain.IsBusy == false)
            {
                Application.DoEvents();
                debug_text.AppendText("waiting " + c++.ToString() + "\n");
            }

            while (webbMain.IsBusy == true)
            {
                Application.DoEvents();
                if (c % 4 == 0)
                {
                    Console.WriteLine(c--);
                }
                else
                {
                    c--;
                }

            }
            debug_text.AppendText("delay...\n");
            await Task.Delay(100);

            Dictionary<int, string> itemLine = new Dictionary<int, string>();

            var elements = webbMain.Document.All;
            Console.WriteLine("Count = " + elements.Count);
            foreach (HtmlElement i in elements)
            {
                if(i.GetAttribute("className") == "sku-value")
                {
                    Console.WriteLine(i.InnerText);
                }
                if (i.GetAttribute("className") == "sku-title" && !(i.InnerText.Equals("Model:")) && !(i.InnerText.Equals("SKU:")))
                {
                   
                    Console.WriteLine(i.InnerText + "\n");
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
        /// <summary>
        /// gets shifts when shifts button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                Console.WriteLine(kvp.Key + " " + kvp.Value.ToString());
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


        string month;

        private async void X_button_Click(object sender, EventArgs e)
        {
            debug_text.AppendText("Getting work shifts...\n");

            // goes to website and waits until loaded
            webbMain.Navigate(TLC);
            int c = 0;
            while (webbMain.IsBusy == false)
            {
                Application.DoEvents();
                debug_text.AppendText("waiting " + c++.ToString() + "\n");
            }

            while (webbMain.IsBusy == true)
            {
                Application.DoEvents();
                if(c%4 == 0)
                {
                    Console.WriteLine(c--);
                }
                else
                {
                    c--;
                }

            }
            debug_text.AppendText("delay...\n");
            await Task.Delay(100);
            // Logs user in
            var inputElements = webbMain.Document.GetElementsByTagName("input");
            Console.WriteLine("\n" + inputElements.Count + "\n");
            foreach (HtmlElement i in inputElements)
            {
                if (i.GetAttribute("name").Equals("login"))
                {
                    i.InnerText = a;
                }
                if (i.GetAttribute("name").Equals("password"))
                {
                    i.Focus();
                    i.InnerText = p;
                }
            } // closes foreach

            var buttonElements = webbMain.Document.GetElementsByTagName("button");
            foreach (HtmlElement i in buttonElements)
            {
                if (i.GetAttribute("id").Equals("loginButton"))
                {
                    i.InvokeMember("Click");
                    debug_text.AppendText("Button Click..\n");
                }
            }

            // waits to finish loading again
            while(webbMain.IsBusy == false)
            {
                Application.DoEvents();
                debug_text.AppendText("page is not busy..\n");
            }
            while (webbMain.IsBusy == true)
            {
                Application.DoEvents();
                debug_text.AppendText("page is busy..\n");

            }


            // extra delay to ensure webpage loaded
            debug_text.AppendText("delay..\n");
            await Task.Delay(100);

            // gets shifts and stores them
            var spanElements = webbMain.Document.All;
            Console.WriteLine(spanElements.Count);
            foreach (HtmlElement i in spanElements)
            {
                
                // gets current day
                if (i.GetAttribute("className").Equals("calendarDateCurrent"))
                {
                    days.Push(Convert.ToInt32(i.InnerText));
                }

                // gets day
                if (i.GetAttribute("className").Equals("calendarDateNormal"))
                {
                    days.Push(Convert.ToInt32(i.InnerText));
                }

                // gets shift
                if (i.GetAttribute("className").Equals("calendarTextShiftName"))
                {
                    time = i.InnerText;
                    shifts.Add(days.Pop(), time);
                }

                // gets current month
                if (i.GetAttribute("className").Equals("pageTitle"))
                {
                    month = i.InnerText;
                }

            }// close foreach

            debug_text.AppendText("Shifts Loaded\n");

            Dictionary<int, KeyValuePair<int, int>> all = getTimes(shifts);


            int m = getMonth(month);
            Output.Text += "Best Buy Shifts: \n";

            foreach (KeyValuePair<int, KeyValuePair<int, int>> kvp in all)
            {

                Output.AppendText(m + "/" + kvp.Key + " \t" + kvp.Value.Key + " - " + kvp.Value.Value + "\n");
                
            }
            if(shifts.Count != 0 )
            {
                if(Output.Text.Length > 10)
                {
                    debug_text.AppendText("Printed shifts");
                }
            } else
            {
                debug_text.AppendText("No shifts\n");
            }

        } // closes X button click


        private Dictionary<int, KeyValuePair<int, int>> getTimes(Dictionary<int, string> shifts)
        {
            string temp;
            string[] array;
            int one;
            int two;
            Dictionary<int, KeyValuePair<int, int>> times = new Dictionary<int, KeyValuePair<int, int>>();
            foreach (KeyValuePair<int, string> kvp in shifts)
            {
                temp = kvp.Value;
                temp = temp.Replace("\n", string.Empty);
                temp = temp.Replace("\r", string.Empty);
                array = temp.Split('-');
                array[0] = array[0].Replace(":", string.Empty);
                array[1] = array[1].Replace(":", string.Empty);

                one = Convert.ToInt32(array[0]);
                debug_text.AppendText(one.ToString() + "\n");
                two = Convert.ToInt32(array[1]);
                debug_text.AppendText(two.ToString() + "\n");

                if(one > 1259)
                {
                    one -= 1200;
                }

                if(two > 1259)
                {
                    two -= 1200;
                }
                debug_text.AppendText(one.ToString() + "\n");
                debug_text.AppendText(two.ToString() + "\n");
                times.Add(kvp.Key, new KeyValuePair<int, int>(one, two));
            }
            return times;
        }



        /// <summary>
        /// converts the month into a usable month
        /// </summary>
        /// <param name="month">month text from website</param>
        /// <returns>int month</returns>
        private int getMonth(string month)
        {
            if(month == null)
            {
                Console.WriteLine("Month was not found");
                return -1;
            }
            StringBuilder sb = new StringBuilder();
            char car;
            for(int i = 0; i < month.Length; i++)
            {
                car = month[i];
                if((car > 'a' && car < 'z') || (car > 'A' && car < 'Z'))
                {
                    sb.Append(month[i]);
                } else
                {
                    i = month.Length;
                }
            }

            string word = sb.ToString().ToUpper();
            
            switch (word)
            {
                case "JANUARY":
                    return 1;
                case "FEBUARY":
                    return 2;
                case "MARCH":
                    return 3;
                case "APRIL":
                    return 4;
                case "MAY":
                    return 5;
                case "JUNE":
                    return 6;
                case "JULY":
                    return 7;
                case "AUGUST":
                    return 8;
                case "SEPTEMBER":
                    return 9;
                case "OCTOBER":
                    return 10;
                case "NOVEMBER":
                    return 11;
                case "DECEMBER":
                    return 12;

                default:
                    return -1;
            }
        } // closes getMonth method

















        private void Refresh_button_Click(object sender, EventArgs e)
        {
            hop();
        }


        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }


    }
}









