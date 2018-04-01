using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour {
	public Text title, text, number, number2;
	public Button button1, button2, plus, xplus, minus, xminus, back, plus2, xplus2, minus2, xminus2;
	public Button[] buttons;
	public GameObject enterNumber, enterNumber2;
	Text button1Text, button2Text;
	float setNum, setNum2, inc, inc2;
	int dec1, dec2;

	public void Init(ChecklistItem item, bool final){
		if (!Utils.CheckCondition (item.condition)) {
			Menu.instance.Next ();
			return;
		}
		inc = item.increment;
		inc2 = item.increment2;
		dec1 = item.dec1;
		dec2 = item.dec2;
		setNum = item.default1;
		setNum2 = item.default2;
		switch (item.type) {
		case "Number":
			enterNumber.SetActive (true);
			enterNumber2.SetActive (false);
			number.text = Utils.FormatNumber(setNum, dec1);
			break;
		case "2Number":
			enterNumber.SetActive (true);
			enterNumber2.SetActive (true);
			number.text = Utils.FormatNumber(setNum, dec1);
			number2.text = Utils.FormatNumber(setNum2, dec2);
			break;
		default:
			enterNumber.SetActive (false);
			enterNumber2.SetActive (false);
			break;
		}
		button1.onClick.RemoveAllListeners ();
		button1.onClick.AddListener (Menu.instance.Next);
		button2.onClick.RemoveAllListeners ();
		button2.onClick.AddListener (Menu.instance.Next);
		button1.transform.GetChild (0).GetComponent<Text> ().text = "Done";
		button2.transform.GetChild (0).GetComponent<Text> ().text = "Skip";
		title.text = item.title;
		text.text = item.text;
	}

	public void Init(string[] setButtons, string setTitle = ""){
		title.text = setTitle;
		for (int i = 0; i < buttons.Length; i++) {
			if (i < setButtons.Length) {
				buttons[i].gameObject.SetActive (true);
				buttons[i].transform.GetChild (0).GetComponent<Text> ().text = setButtons[i];
				buttons[i].onClick.RemoveAllListeners ();
			} else {
				buttons[i].gameObject.SetActive (false);
			}
		}
	}

	public void Change1(float f){
		setNum += inc * f;
		number.text = Utils.FormatNumber(setNum, dec1);
	}
	public void Change2(float f){
		setNum2 += inc2 * f;
		number2.text = Utils.FormatNumber(setNum2, dec2);
	}

	public void Buttons(int i){
		Menu.instance.Buttons (i);
	}

	public void Back(){
		Menu.instance.Back ();
	}
}
