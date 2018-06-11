using System;
using System.Web;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using MyWeb.Data;
using MyWeb.Business;

namespace MyWeb.Common
{
	public class PageHelper : System.Web.UI.UserControl
	{
		private string[] Separator = new string[] { "," };
		public static Control FindControl(Control Root, string Id)
		{
			if (Root.ID == Id)
				return Root;
			foreach (Control Ctl in Root.Controls)
			{
				Control FoundCtl = FindControl(Ctl, Id);
				if (FoundCtl != null)
					return FoundCtl;
			}
			return null;
		}

		public static string ShowBannerCenter(string Position)
		{
			string Chuoi = "";
			List<Data.Advertise> list = Business.AdvertiseService.Advertise_GetByPosition(Position);
			if (list.Count > 0)
			{
				string path = "";
				path = list[0].Image;
				if (path.IndexOf(".swf") > 0)
				{
					Chuoi += "<script language='javascript'>playfile('" + path + "', '" + list[0].Width + "', '" + list[0].Height + "', true, '', '', 'link=" + list[0].Link + "');</script>";
				}
				else
				{
					Chuoi += "<div class=\"banner\"><img src='" + path + "' width='" + list[0].Width + "' height='" + list[0].Height + "' /></div>";
				}
			}
			list.Clear();
			list = null;
			return Chuoi;
		}

		public static string ShowActiveImage(string ActiveCode)
		{
			string strReturn = ActiveCode == "1" || ActiveCode == "True" ? "stop.png" : "start.png";
			return GlobalClass.GetUrlAdminImage() + strReturn;
		}

		public static string ShowCheckImage(object ActiveCode)
		{
			string strReturn;
			if (ActiveCode == null)
			{
				strReturn = "uncheck.gif";
			}
			else
			{
				strReturn = ActiveCode.ToString() == "1" || ActiveCode.ToString() == "True" ? "check.gif" : "uncheck.gif";
			}
			return GlobalClass.GetUrlAdminImage() + strReturn;
		}

		public static string ShowActiveToolTip(string ActiveCode)
		{
			return ActiveCode == "1" || ActiveCode == "True" ? "Ẩn" : "Hiển thị";
		}

		public static string ShowActiveStatus(string ActiveCode)
		{
			return ActiveCode == "1" || ActiveCode == "True" ? "Hiển thị" : "Ẩn";
		}

		public static void LoadDropDownList(DropDownList ddl, ArrayList array)
		{
			ddl.DataSource = array;
			ddl.DataBind();
		}

		public static void LoadDropDownList(DropDownList ddl, string[] StringArray)
		{
			LoadDropDownList(ddl, StringArray, false);
		}

		public static void LoadDropDownList(DropDownList ddl, string[] StringArray, bool ListItem)
		{
			if (ListItem)
			{
				ddl.DataSource = StringArray2ListItem(StringArray);
				ddl.DataTextField = "Text";
				ddl.DataValueField = "Value";

			}
			else
			{
				ddl.DataSource = StringArray2ArrayList(StringArray);
			}
			ddl.DataBind();
		}

		public static List<ListItem> StringArray2ListItem(string[] StringArray)
		{
			char[] splitter = { ',', ';' };
			List<ListItem> list = new List<ListItem>();
			for (int i = 0; i < StringArray.Length; i++)
			{
				string[] arr = StringArray[i].Split(splitter);
				if (arr.Length > 1)
				{
					list.Add(new ListItem(arr[1], arr[0]));
				}
				else
				{
					list.Add(new ListItem(arr[0], arr[0]));
				}
			}
			return list;
		}

		public static ArrayList StringArray2ArrayList(string[] StringArray)
		{
			ArrayList arrlist = new ArrayList();
			for (int i = 0; i < StringArray.Length; i++)
			{
				arrlist.Add(StringArray[i]);
			}
			return arrlist;
		}

		public static void LoadDropDownListTarget(DropDownList ddl)
		{
			string[] myArr = new string[] { "_self", "_blank" };
			ddl.DataSource = StringArray2ArrayList(myArr);
			ddl.DataBind();
		}

		public static void LoadDropDownListNumber(DropDownList ddl, int BeginNumber, int EndNumber)
		{
			for (int i = BeginNumber; i <= EndNumber; i++)
			{
				ddl.Items.Add(new ListItem(i.ToString(), i.ToString()));
			}
		}

		public static void LoadDropDownListPosition(DropDownList ddl)
		{
			string[] myArr = new string[] { "1,Logo", "2,Banner giữa", "3,Đối tác", "4,Quảng cáo trái" };
			LoadDropDownList(ddl, myArr, true);
		}

		public static void LoadDropDownListStatusCart(DropDownList ddl)
		{
			string[] myArr = new string[] { "0,Thêm vào giỏ hàng", "1,Đã đặt hàng", "2,Đã thanh toán", "3,Hủy đặt hàng" };
			LoadDropDownList(ddl, myArr, true);
		}

		public static string ShowAdvertiseStatusCart(string status)
		{
			string strString = "";
			string[] myArr = new string[] { "0,Thêm vào giỏ hàng", "1,Đã đặt hàng", "2,Đã thanh toán", "3,Hủy đặt hàng" };
			char[] splitter = { ',', ';' };
			for (int i = 0; i < myArr.Length; i++)
			{
				string[] arr = myArr[i].Split(splitter);
				if (arr[0].Equals(status))
				{
					strString = arr[1];
					break;
				}
			}
			return strString;
		}

		public static string ShowAdvertisePosition(string Position)
		{
			string strString = "";
			string[] myArr = new string[] { "1,Logo", "2,Banner giữa", "3,Đối tác", "4,Quảng cáo trái" };
			char[] splitter = { ',', ';' };
			for (int i = 0; i < myArr.Length; i++)
			{
				string[] arr = myArr[i].Split(splitter);
				if (arr[0].Equals(Position))
				{
					strString = arr[1];
					break;
				}
			}
			return strString;
		}
		public static void LoadDropDownListYesNo(DropDownList ddl)
		{
			string[] myArr = new string[] { "1,Yes", "0,No" };
			LoadDropDownList(ddl, myArr, true);
		}

		public static void LoadDropDownListCoKhong(DropDownList ddl)
		{
			string[] myArr = new string[] { "1,Có", "0,Không" };
			LoadDropDownList(ddl, myArr, true);
		}

		public static string ShowProPriority(string Priority)
		{
			string strString = "";
			string[] myArr = new string[] { "1,Bình thường", "2,Xuất hiện trang chủ", "3,Giao hàng" };
			char[] splitter = { ',', ';' };
			for (int i = 0; i < myArr.Length; i++)
			{
				string[] arr = myArr[i].Split(splitter);
				if (arr[0].Equals(Priority))
				{
					strString = arr[1];
					break;
				}
			}
			return strString;
		}

		public static void LoadDropProPriority(DropDownList ddl)
		{
			string[] myArr = new string[] { "1,Bình thường", "2,Xuất hiện trang chủ", "3,Giao hàng" };
			LoadDropDownList(ddl, myArr, true);
		}

		public static string ShowNewsPriority(string Priority)
		{
			string strString = "";
			string[] myArr = new string[] { "1,Bình thường", "2,Xuất hiện trang chủ", "3,Giao hàng" };
			char[] splitter = { ',', ';' };
			for (int i = 0; i < myArr.Length; i++)
			{
				string[] arr = myArr[i].Split(splitter);
				if (arr[0].Equals(Priority))
				{
					strString = arr[1];
					break;
				}
			}
			return strString;
		}

		public static void LoadDropNewsPriority(DropDownList ddl)
		{
			string[] myArr = new string[] { "1,Bình thường", "2,Xuất hiện trang chủ", "3,Giao hàng" };
			LoadDropDownList(ddl, myArr, true);
		}

		public static void LoadDropDownListFilterActive(DropDownList ddl)
		{
			string[] myArr = new string[] { ", -- Tất cả -- ", "1,Hiển thị", "0,Ẩn" };
			LoadDropDownList(ddl, myArr, true);
		}

		public static void LoadDropDownListActive(DropDownList ddl)
		{
			string[] myArr = new string[] { "1,Có", "0,Không" };
			LoadDropDownList(ddl, myArr, true);
		}

		public static void LoadDropDownListPagePosition(DropDownList ddl)
		{
			string[] myArr = new string[] { "2,Menu chính", "1,Menu trái", "3,Menu dưới" };
			LoadDropDownList(ddl, myArr, true);
		}

		public static string ShowPagePosition(string Position)
		{
			return Position == "1" ? "Menu trái" : Position == "2" ? "Menu chính" : "Menu dưới";
		}
		public static void LoadDropDownListPageType(DropDownList ddl)
		{
			string[] myArr = new string[] { "1,Trang liên kết", "2,Trang nội dung" };
			LoadDropDownList(ddl, myArr, true);
		}

		public static void LoadDropDownListAdvertiseType(DropDownList ddl)
		{
			string[] myArr = new string[] { "1,Hình ảnh", "2,Nội dung" };
			LoadDropDownList(ddl, myArr, true);
		}

		public static string ShowPageType(string ActiveCode)
		{
			return ActiveCode == "1" ? "Trang liên kết" : "Trang nội dung";
		}

		public static void LoadDropDownListSupportType(DropDownList ddl)
		{
			string[] myArr = new string[] { "1,Yahoo messenger", "2,Skype" };
			LoadDropDownList(ddl, myArr, true);
		}

		public static string ShowSupportType(string Type)
		{
			return Type == "1" ? "Yahoo messenger" : Type == "2" ? "Skype" : "Google talk";
		}
		public static string Format_Price(string Price, string unit)
		{
			Price = Price.Replace(".", "");
			Price = Price.Replace(",", "");
			string tmp = "";
			while (Price.Length > 3)
			{
				tmp = "." + Price.Substring(Price.Length - 3) + tmp;
				Price = Price.Substring(0, Price.Length - 3);
			}
			tmp = Price + tmp;
			return tmp + " " + unit;
		}

		public static string GetContent(string URL)
		{
			string str = string.Empty;
			HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(URL);
			myRequest.Method = "GET";
			WebResponse myResponse = myRequest.GetResponse();
			StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
			str = sr.ReadToEnd();
			sr.Close();
			myResponse.Close();
			return str;
		}

		public static string GetContent(string URL, string strStart, string strEnd)
		{
			string Content = GetContent(URL);
			int pStart = Content.IndexOf(strStart);
			int pEnd = Content.IndexOf(strEnd);
			string strReturn = Content.Substring(pStart, pEnd - pStart);
			return StripATag(strReturn);
		}
		public static string StripATag(string text)
		{
			return Regex.Replace(text, @"<a[^>]*?href\s*=\s*[""']?([^'"" >]+?)[ '""]?/?>|<.a*?>", string.Empty);
		}
		public static string GeneralDetailUrl(string prefix, string group_name, string id, string pro_name)
		{
			string strUrl = string.Empty;
			strUrl = "/" + prefix + "/" + StringClass.NameToTag(group_name) + "/" + id + "/" + StringClass.NameToTag(pro_name);
			return strUrl;
		}
		public static string GeneralGroupUrl(string prefix, string id, string group_name)
		{
			string strUrl = string.Empty;
			strUrl = "/" + prefix + "/" + id + "/" + StringClass.NameToTag(group_name);
			return strUrl;
		}
	}
}
