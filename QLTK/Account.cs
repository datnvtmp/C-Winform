using System.ComponentModel;
using Newtonsoft.Json;

namespace QLTK;

public class Account : INotifyPropertyChanged
{
	private string _charName;

	public int ID { get; set; }

	public string UserName { get; set; }

	public string Password { get; set; }

	public string Server { get; set; }

	[JsonIgnore]
	public string Status { get; set; }

	[JsonIgnore]
	public string DataInGame { get; set; }

	public string Proxy { get; set; }

	public string CharName
	{
		get
		{
			return _charName;
		}
		set
		{
			if (_charName != value)
			{
				_charName = value;
				OnPropertyChanged(_charName);
			}
		}
	}

	public AccountSettings Settings { get; set; } = new AccountSettings();

	public bool Auto { get; set; } = false;

	public event PropertyChangedEventHandler PropertyChanged;

	protected void OnPropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
