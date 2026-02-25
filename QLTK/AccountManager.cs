using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace QLTK;

public class AccountManager
{
	private string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "accounts.json");

	public BindingList<Account> Accounts { get; private set; }

	public AccountManager()
	{
		LoadAccounts();
	}

	public void LoadAccounts()
	{
		if (File.Exists(jsonPath))
		{
			string value = File.ReadAllText(jsonPath);
			List<Account> list = JsonConvert.DeserializeObject<List<Account>>(value) ?? new List<Account>();
			for (int i = 0; i < list.Count; i++)
			{
				list[i].ID = i + 1;
			}
			Accounts = new BindingList<Account>(list);
			SaveAccounts();
		}
		else
		{
			Accounts = new BindingList<Account>();
		}
	}

	public void SaveAccounts()
	{
		File.WriteAllText(jsonPath, JsonConvert.SerializeObject(Accounts, Formatting.Indented));
	}

	public Account GetAccount(string id)
	{
		return Accounts.FirstOrDefault((Account a) => a.ID.ToString() == id);
	}

	public Account GetAccount(int id)
	{
		return Accounts.FirstOrDefault((Account a) => a.ID == id);
	}

	public void AddAccount(Account acc)
	{
		acc.ID = ((Accounts.Count <= 0) ? 1 : (Accounts.Max((Account a) => a.ID) + 1));
		Accounts.Add(acc);
		SaveAccounts();
	}

	public void RemoveAccount(Account acc)
	{
		if (acc != null)
		{
			Accounts.Remove(acc);
			SaveAccounts();
		}
	}

	public void UpdateAccount(Account updateAccount)
	{
		Account account = GetAccount(updateAccount.ID);
		if (account != null)
		{
			int num = Accounts.IndexOf(account);
			if (num != -1)
			{
				Accounts[num] = updateAccount;
				SaveAccounts();
			}
		}
	}
}
