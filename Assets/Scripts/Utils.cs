using UnityEngine;
using System;
public class Utils {
	public static string FormatNumber(float f, int decimals, bool commas = false){
		string str = Mathf.FloorToInt (f).ToString ();
		for (int i = 0; i < decimals; i++) {
			if (i == 0) {
				str += ".";
			}
			str += Mathf.RoundToInt ((f * Mathf.Pow (10, (float)(i + 1))) % 10).ToString ();
		}
		return str;
	}
	public static bool CheckCondition(Condition con){
		if (DateTime.Now.DayOfWeek.ToString () != con.day && con.day != "") {
			return false;
		}
		if (DateTime.Now.Date != con.date && con.date != new DateTime (2000, 1, 1)) {
			return false;
		}
		if (DateTime.Now.Day != con.dayOfMonth && con.dayOfMonth > 0) {
			return false;
		}
		return true;
	}
}
