using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

public class Socket_Server
{
	public class ClientInfo
	{
		public string AccountID { get; set; }

		public TcpClient Client { get; set; }

		public NetworkStream Stream { get; set; }
	}

	private TcpListener server;

	private Dictionary<string, ClientInfo> clients = new Dictionary<string, ClientInfo>();

	private const int PORT = 9999;

	private object lockObj = new object();

	public event Action<string, string> OnMessageReceived;

	public event Action<string> OnClientDisconnected;

	public void Start()
	{
		try
		{
			server = new TcpListener(IPAddress.Any, 9999);
			server.Start();
			server.BeginAcceptTcpClient(OnClientConnected, null);
		}
		catch (Exception)
		{
			MessageBox.Show("ERROR! Plese Tắt mở lại");
		}
	}

	private void OnClientConnected(IAsyncResult ar)
	{
		try
		{
			TcpClient tcpClient = server.EndAcceptTcpClient(ar);
			NetworkStream stream = tcpClient.GetStream();
			string tempKey = "UNKNOWN_" + Guid.NewGuid().ToString();
			lock (lockObj)
			{
				clients[tempKey] = new ClientInfo
				{
					AccountID = tempKey,
					Client = tcpClient,
					Stream = stream
				};
			}
			new Thread((ThreadStart)delegate
			{
				ReceiveLoop(tempKey);
			}).Start();
			server.BeginAcceptTcpClient(OnClientConnected, null);
		}
		catch (Exception ex)
		{
			Console.WriteLine("Error accepting client: " + ex.Message);
		}
	}

	private void ReceiveLoop(string accountID)
	{
		try
		{
			ClientInfo value;
			lock (lockObj)
			{
				if (!clients.TryGetValue(accountID, out value))
				{
					return;
				}
			}
			while (value.Client != null && value.Client.Connected)
			{
				string text = ReadUTF(value.Stream);
				if (text == null)
				{
					break;
				}
				this.OnMessageReceived?.Invoke(accountID, text);
				if (!text.StartsWith("REGISTER_USERNAME:"))
				{
					continue;
				}
				string text2 = text.Substring(18);
				lock (lockObj)
				{
					if (clients.ContainsKey(text2))
					{
						clients[text2].Client?.Close();
						clients.Remove(text2);
					}
					clients.Remove(accountID);
					clients[text2] = value;
					value.AccountID = text2;
				}
				accountID = text2;
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			lock (lockObj)
			{
				if (clients.ContainsKey(accountID))
				{
					clients[accountID].Client?.Close();
					clients.Remove(accountID);
				}
			}
			this.OnClientDisconnected?.Invoke(accountID);
		}
	}

	public void SendString(string accountID, string msg)
	{
		ClientInfo value;
		lock (lockObj)
		{
			if (!clients.TryGetValue(accountID, out value))
			{
				return;
			}
		}
		try
		{
			WriteUTF(value.Stream, msg);
		}
		catch (Exception)
		{
			lock (lockObj)
			{
				clients[accountID].Client?.Close();
				clients.Remove(accountID);
			}
		}
	}

	public void BroadcastString(string msg)
	{
		List<string> list = new List<string>();
		lock (lockObj)
		{
			foreach (KeyValuePair<string, ClientInfo> client in clients)
			{
				try
				{
					WriteUTF(client.Value.Stream, msg);
				}
				catch (Exception)
				{
					list.Add(client.Key);
				}
			}
			foreach (string item in list)
			{
				clients[item].Client?.Close();
				clients.Remove(item);
			}
		}
	}

	public List<string> GetConnectedClients()
	{
		lock (lockObj)
		{
			return clients.Keys.ToList();
		}
	}

	public bool IsConnected(string accountID)
	{
		lock (lockObj)
		{
			return clients.ContainsKey(accountID) && clients[accountID].Client.Connected;
		}
	}

	private void WriteUTF(NetworkStream stream, string str)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(str);
		int num = bytes.Length;
		stream.Write(new byte[2]
		{
			(byte)(num >> 8),
			(byte)(num & 0xFF)
		}, 0, 2);
		stream.Write(bytes, 0, bytes.Length);
		stream.Flush();
	}

	private string ReadUTF(NetworkStream stream)
	{
		byte[] array = new byte[2];
		int num = stream.Read(array, 0, 2);
		if (num < 2)
		{
			return null;
		}
		int num2 = (array[0] << 8) | array[1];
		byte[] array2 = new byte[num2];
		int num3;
		for (num = 0; num < num2; num += num3)
		{
			num3 = stream.Read(array2, num, num2 - num);
			if (num3 <= 0)
			{
				break;
			}
		}
		return Encoding.UTF8.GetString(array2);
	}

	public void Stop()
	{
		lock (lockObj)
		{
			foreach (ClientInfo value in clients.Values)
			{
				value.Stream?.Close();
				value.Client?.Close();
			}
			clients.Clear();
		}
		server?.Stop();
	}
}
