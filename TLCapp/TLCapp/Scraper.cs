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
            f.webbMain.ScriptErrorsSuppressed = true;

            f.webbMain.Navigate(url);


            await WebWait();
            f.debug_text.Text = "";

            Dictionary<int, string> itemLine = new Dictionary<int, string>();
            Dictionary<int, double> itemLine2 = new Dictionary<int, double>();
            Stack<int> skus = new Stack<int>();

            string titleBuf = "";

            var elements = f.webbMain.Document.All;
            Console.WriteLine("Count = " + elements.Count);

            string className;
            int count = 0;
            string temp = "";
            foreach (HtmlElement i in elements)
            {

                className = i.GetAttribute("className");
                if (className.Equals("sku-value"))
                {
                    count++;
                    Console.WriteLine(i.InnerText);
                    Console.WriteLine(count%3);
                    if(count%3 == 0)
                    {
                        itemLine.Add(Convert.ToInt32(i.InnerText), titleBuf);
                        skus.Push(Convert.ToInt32(i.InnerText));
                        Console.WriteLine();
                    }
                }
                if (className == "sku-title" && !(i.InnerText.Equals("Model:")) && !(i.InnerText.Equals("SKU:")))
                {
                    count++;
                    titleBuf = i.InnerText;

                    Console.WriteLine(titleBuf);
                    Console.WriteLine(count%3);

                }
                if(className.Equals("priceView-hero-price priceView-purchase-price"))
                {
                    Console.WriteLine(i.InnerText);
                    temp = i.InnerText;
                    temp = temp.Substring(1);
                    itemLine2.Add(skus.Peek(), Convert.ToDouble(temp));
                }

            }
            Console.WriteLine(count);
            foreach (KeyValuePair<int, string> item in itemLine)
            {
                f.Output.AppendText(item.Key.ToString() + " - " + itemLine2[item.Key] + " - " + item.Value + "\n");
            }



        } // closes scrape method


        /// <summary>
        /// waits for a webpage to be loaded
        /// </summary>
        /// <returns></returns>
        public async Task<bool> WebWait()
        {
            int c = 0;
            while (f.webbMain.IsBusy == false && c < 1000)
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
