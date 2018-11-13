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

        private System.Windows.Forms.WebBrowser webMain;
        private TLC_form f;


        public Scraper(TLC_form f)
        {
            this.f = f;
            
        }
        
        
        public async Task Scrape(string url)
        {

            f.webbMain.Navigate(url);


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

            Dictionary<int, string> itemLine = new Dictionary<int, string>();

            var elements = f.webbMain.Document.All;
            Console.WriteLine("Count = " + elements.Count);
            foreach (HtmlElement i in elements)
            {
                if (i.GetAttribute("className") == "sku-value")
                {
                    Console.WriteLine(i.InnerText);
                }
                if (i.GetAttribute("className") == "sku-title" && !(i.InnerText.Equals("Model:")) && !(i.InnerText.Equals("SKU:")))
                {

                    Console.WriteLine(i.InnerText + "\n");
                }

            }





        }



    }
}
