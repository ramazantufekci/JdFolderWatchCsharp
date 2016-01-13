/*
 * Created by SharpDevelop.
 * User: Ramazan Tüfekçi
 * Web Site: www.ramazantufekci.com
 * Date: 1/13/2016
 * Time: 1:46 PM
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace JdFolderWatchCsharp
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		
		
		void Button1Click(object sender, EventArgs e)
		{
			webBrowser1.Navigate(textBox1.Text);
			webBrowser1.ScriptErrorsSuppressed = true;
			
		}
		//linkleri listelemek için arraylist tanımlıyoruz.
		ArrayList Liste = new ArrayList();
		
		Random rastgelesayi = new Random();
		
		void WebBrowser1DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			HtmlElementCollection links = webBrowser1.Document.GetElementsByTagName("h3");
			foreach (HtmlElement element in links) {
				if (element.OuterHtml.Contains("yt-lockup-title") ){
						HtmlElementCollection link2=element.GetElementsByTagName("a");
						foreach (HtmlElement element2 in link2) {
							if (!Liste.Contains(element2.GetAttribute("href"))) {
								Liste.Add(element2.GetAttribute("href"));
							}
						}
					}
			}
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			for (int i = 0; i < Liste.Count; i++) {
				StreamWriter SW = new StreamWriter("Jdownloader ın çalıştığı dizindeki folderwatch klasörü\\"+rastgelesayi.Next(1,100000)+".crawljob");
						     SW.WriteLine("text="+Liste[i].ToString());
						     //SW.WriteLine("autoStart=TRUE"); Linkler eklendiğinde otomatik indirme yapması için
						     SW.Close();
			}
			
		}
	}
}
