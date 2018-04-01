using UnityEngine;
public class Utils {
	public static string formatNumber(float f, int decimals, bool commas = false){
		string str = Mathf.FloorToInt (f).ToString ();
		for (int i = 0; i < decimals; i++) {
			if (i == 0) {
				str += ".";
			}
			str += Mathf.RoundToInt ((f * Mathf.Pow (10, (float)(i + 1))) % 10).ToString ();
		}
		return str;
	}
}
