using System.Collections;

[System.Serializable]
public class Checklist {
	public string title, text;
	public ChecklistItem[] items;
	public int index = 0;
}
