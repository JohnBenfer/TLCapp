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
            Console.WriteLine(load(TLC));
        }

        /// <summary>
        /// navigates to the webpage
        /// </summary>
        /// <param name="URL"></param>
        /// <returns></returns>
        private bool load(string URL)
        {
            webbMain.Navigate(URL);
            Console.WriteLine(webbMain.ReadyState.ToString());
            return false;
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
                Console.WriteLine(i.TagName);

                Console.WriteLine("hereeee");
                i.InvokeMember("Click");
                
            }

        }




        private void shifts_button_Click(object sender, EventArgs e)
        {

            var dataElements = webbMain.Document.GetElementsByTagName("td");
            foreach(HtmlElement i in dataElements)
            {
                //Console.WriteLine(i.TagName);

                Console.WriteLine(i.GetAttribute("span"));



                if (i.GetAttribute("class").Equals("calendarCellRegularFuture"))
                {
                    Console.WriteLine("herrrreeeeee");
                }
            }



        }







       




         































        private void Refresh_button_Click(object sender, EventArgs e)
        {
            
        }


        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }


    }
}









