using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

	public static Menu instance;

	public Config config;
	public GameObject panel, buttonPannel, button;
	Panel currentPanel;

	Checklist currentChecklist;
	MenuItem currentMenu;

	void Start () {
		instance = this;
		config = JsonUtility.FromJson<Config>(Resources.Load ("config").ToString());

		OpenMainMenu ();
	}

	public void OpenMainMenu(){
		currentMenu = config.main;
		SetMenu ();
	}
	public void Back(){
		currentMenu = currentMenu.parent;
		SetMenu ();
	}
	public void OpenMenu(int menu){
		currentMenu = currentMenu.items[menu];
		SetMenu ();
	}
	public void SetMenu(){
		foreach (MenuItem item in currentMenu.items) {
			item.parent = currentMenu;
		}
		if (currentPanel != null) {
			Destroy (currentPanel.gameObject);
		}
		currentPanel = GameObject.Instantiate (buttonPannel, transform).GetComponent<Panel> ();
		string[] strs = new string[currentMenu.items.Length];
		for (int i = 0; i < currentMenu.items.Length; i++) {
			strs [i] = currentMenu.items [i].title;
		}
		currentPanel.Init (strs, currentMenu.title);
		currentPanel.back.gameObject.SetActive (currentMenu.parent != null);
	}

	public void Buttons(int i){
		switch (currentMenu.items [i].type) {
		case "menu":
			OpenMenu (i);
			break;
		case "checklist":
			StartChecklist (i);
			break;
		default:
			break;
		}
	}

	public void StartChecklist(int checklistNum){
		currentMenu = currentMenu.items[checklistNum];
		currentChecklist = currentMenu.checklist;
		if (currentPanel != null) {
			Destroy (currentPanel.gameObject);
		}
		currentPanel = GameObject.Instantiate (panel, transform).GetComponent<Panel> ();
		currentPanel.Init(currentChecklist.items [currentChecklist.index], false);
	}
	public void Next(){
		currentChecklist.index++;
		if (currentChecklist.index >= currentChecklist.items.Length) {
			OpenMainMenu();
			currentChecklist.index = 0;
			return;
		}
		currentPanel.Init(currentChecklist.items [currentChecklist.index], false);
	}
}
