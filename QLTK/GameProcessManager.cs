#define DEBUG
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace QLTK;

public class GameProcessManager
{
	public struct RECT
	{
		public int Left;

		public int Top;

		public int Right;

		public int Bottom;
	}

	private readonly ConcurrentDictionary<string, Process> _runningProcesses = new ConcurrentDictionary<string, Process>();

	private const int SW_MINIMIZE = 6;

	private const int SW_RESTORE = 9;

	private const uint SWP_NOSIZE = 1u;

	private const uint SWP_NOZORDER = 4u;

	private static readonly IntPtr HWND_TOP = new IntPtr(0);

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

	[DllImport("user32.dll", SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	public static extern bool SetWindowText(IntPtr hWnd, string lpString);

	public void StartProcess(string accountID, ProcessStartInfo startInfo)
	{
		try
		{
			Process process = Process.Start(startInfo);
			if (_runningProcesses.TryRemove(accountID, out var value) && !value.HasExited)
			{
				value.Kill();
			}
			Thread.Sleep(1000);
			while (process.MainWindowHandle == IntPtr.Zero)
			{
				Thread.Sleep(1000);
			}
			SetWindowText(process.MainWindowHandle, accountID);
			_runningProcesses[accountID] = process;
		}
		catch (Exception ex)
		{
			Debug.WriteLine("Lỗi khi StartProcess cho " + accountID + ": " + ex.Message);
		}
	}

	public void KillProcess(string accountID)
	{
		if (!_runningProcesses.TryRemove(accountID, out var value))
		{
			return;
		}
		try
		{
			if (!value.HasExited)
			{
				value.Kill();
			}
		}
		catch (Exception ex)
		{
			Debug.WriteLine("Lỗi khi KillProcess " + accountID + ": " + ex.Message);
		}
	}

	public void KillAll()
	{
		List<string> list = _runningProcesses.Keys.ToList();
		foreach (string item in list)
		{
			KillProcess(item);
		}
	}

	public void MinimizeAll()
	{
		foreach (Process validWindowProcess in GetValidWindowProcesses())
		{
			ShowWindow(validWindowProcess.MainWindowHandle, 6);
		}
	}

	public void RestoreAll()
	{
		foreach (Process validWindowProcess in GetValidWindowProcesses())
		{
			ShowWindow(validWindowProcess.MainWindowHandle, 9);
		}
	}

	public void ArrangeAllWindows()
	{
		List<Process> validWindowProcesses = GetValidWindowProcesses();
		if (validWindowProcesses.Count == 0)
		{
			return;
		}
		int width = Screen.PrimaryScreen.WorkingArea.Width;
		int height = Screen.PrimaryScreen.WorkingArea.Height;
		int num = 5;
		int num2 = 0;
		int num3 = 0;
		foreach (Process item in validWindowProcesses)
		{
			IntPtr mainWindowHandle = item.MainWindowHandle;
			if (GetWindowRect(mainWindowHandle, out var lpRect))
			{
				int num4 = lpRect.Right - lpRect.Left;
				int num5 = lpRect.Bottom - lpRect.Top;
				if (num2 + num4 > width)
				{
					num2 = 0;
					num3 += num5 + num;
				}
				if (num3 + num5 > height)
				{
					num2 = 0;
					num3 = 0;
				}
				SetWindowPos(mainWindowHandle, HWND_TOP, num2, num3, 0, 0, 1u);
				num2 += num4 + num;
			}
		}
	}

	private List<Process> GetValidWindowProcesses()
	{
		List<Process> list = new List<Process>();
		foreach (KeyValuePair<string, Process> runningProcess in _runningProcesses)
		{
			Process value = runningProcess.Value;
			if (value == null || value.HasExited)
			{
				_runningProcesses.TryRemove(runningProcess.Key, out var _);
			}
			else if (value.MainWindowHandle != IntPtr.Zero)
			{
				list.Add(value);
			}
		}
		return list.OrderBy(delegate(Process p)
		{
			string windowTitle = GetWindowTitle(p.MainWindowHandle);
			int result;
			return int.TryParse(windowTitle, out result) ? result : int.MaxValue;
		}).ToList();
	}

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

	private string GetWindowTitle(IntPtr hWnd)
	{
		StringBuilder stringBuilder = new StringBuilder(256);
		GetWindowText(hWnd, stringBuilder, 256);
		return stringBuilder.ToString();
	}
}
