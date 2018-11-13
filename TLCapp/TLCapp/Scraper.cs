/*
 * Scraper class created by John Benfer
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TLCapp
{
    public class Scraper
    {

        private TLC_form f;


        public Scraper(TLC_form f)
        {
            this.f = f;
            
        }
        
        
        public async Task Scrape(string url)
        {

            f.webbMain.Navigate(url);


            await WebWait();

            Dictionary<int, string> itemLine = new Dictionary<int, string>();
            string titleBuf;
            var elements = f.webbMain.Document.All;
            Console.WriteLine("Count = " + elements.Count);
            string className;
            int count = 0;
            foreach (HtmlElement i in elements)
            {

                className = i.GetAttribute("className");
                if (className.Equals("sku-value"))
                {
                    count++;
                    Console.WriteLine(i.InnerText);
                }
                if (i.GetAttribute("className") == "sku-title" && !(i.InnerText.Equals("Model:")) && !(i.InnerText.Equals("SKU:")))
                {
                    count++;
                    titleBuf = i.InnerText;

                    Console.WriteLine(titleBuf + "\n");
                }

            }





        } // closes scrape method

        /// <summary>
        /// waits for a webpage to be loaded
        /// </summary>
        /// <returns></returns>
        public async Task<bool> WebWait()
        {
            int c = 0;
            while (f.webbMain.IsBusy == false)
            {
                Application.DoEvents();
                f.debug_text.AppendText("waiting " + c++.ToString() + "\n");
            }

            while (f.webbMain.IsBusy == true)
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
            f.debug_text.AppendText("delay...\n");
            await Task.Delay(100);
            return true;
        }



    }
}
