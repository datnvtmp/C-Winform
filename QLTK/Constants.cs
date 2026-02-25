namespace QLTK;

public static class Constants
{
	public static class Items
	{
		public const string CUONG_NO_NAME = "Cuồng Nộ";

		public const int CUONG_NO_ID = 381;

		public const int CUONG_NO_ICON = 2754;

		public const string BO_HUYET_NAME = "Bổ Huyết";

		public const int BO_HUYET_ID = 382;

		public const int BO_HUYET_ICON = 2755;

		public const string GIAP_XEN_NAME = "Giáp Xên";

		public const int GIAP_XEN_ID = 384;

		public const int GIAP_XEN_ICON = 2757;

		public const string KHAU_TRANG_NAME = "Khẩu Trang";

		public const int KHAU_TRANG_ID = 764;

		public const int KHAU_TRANG_ICON = 7149;

		public const string CAN_CO_NAME = "Cỏ may mắn";

		public const int CAN_CO_ID = 1635;

		public const int CAN_CO_ICON = 13618;
	}

	public const int CMD_LOGIN = 1;

	public const int CMD_AUTO_TRAIN_FULL = 2;

	public const int CMD_STOP_AUTO_TRAIN = 3;

	public const int CMD_UNKNOWN_4 = 4;

	public const int CMD_SET_MOB_TYPE = 5;

	public const int CMD_SET_MAP_ID = 6;

	public const int CMD_SET_ZONE_ID = 7;

	public const int CMD_RESET_ZONE_ID = 8;

	public const int CMD_AUTO_ITEM = 9;

	public const int CMD_STOP_AUTO_ITEM = 10;

	public const int CMD_HANDLE_SKILL = 11;

	public const int CMD_STOP_SKILL = 12;

	public const int CMD_AUTO_BOSS_NAPA = 13;

	public const int CMD_STOP_BOSS_NAPA = 14;

	public const int CMD_AUTO_GLT_START = 15;

	public const int CMD_AUTO_GLT_STOP = 16;

	public const int CMD_SET_MAX_HP = 17;

	public const int CMD_SET_MIN_HP = 18;

	public const int CMD_TRAIN_DONT_MOVE = 19;

	public const int CMD_LIST_USE_ITEM = 21;

	public const int CMD_LIST_TRASH_ITEM = 22;

	public const int CMD_AUTO_PORATA = 23;

	public const int CMD_AUTO_LOGIN = 24;

	public const int CMD_AUTO_USE_TDLT = 25;

	public const int CMD_AUTO_BUY_TDLT = 26;

	public const int CMD_SHOW_BAG = 27;

	public const int CMD_SHOW_BOX = 28;

	public const int CMD_LIST_MOD_ID = 29;

	public const int CMD_AUTO_SKH = 30;

	public const int CMD_AUTO_FLAG = 32;

	public const int CMD_AUTO_GOBACK = 35;

	public const int CMD_AUTO_OFF_KHI_DU_SO_LUONG = 37;

	public const int CMD_AUTO_UP_MAP_PRIVATE = 40;

	public const int CMD_ATTACK_FULL = 41;

	public static string BuildAutoTrainFull(int mapId, int mobType)
	{
		return $"{2}|{mapId}|{mobType}";
	}

	public static string BuildStopAutoTrain()
	{
		return 3.ToString();
	}

	public static string BuildSetZoneId(int zoneId)
	{
		return $"{7}|{zoneId}";
	}

	public static string BuildResetZoneId()
	{
		return 8.ToString();
	}

	public static string BuildAutoItem(string name, int id, int iconId)
	{
		return $"{9}|{name}|{id}|{iconId}";
	}

	public static string BuildStopAutoItem(int itemId)
	{
		return $"{10}|{itemId}";
	}

	public static string BuildHandleSkill(string skillsCommaSeparated)
	{
		if (string.IsNullOrWhiteSpace(skillsCommaSeparated))
		{
			return $"{11}";
		}
		string arg = string.Join("|", skillsCommaSeparated.Split(','));
		return $"{11}|{arg}";
	}

	public static string BuildHandleIDSL(string skillsCommaSeparated)
	{
		string arg = string.Join("|", skillsCommaSeparated.Split('-'));
		return $"{37}|{arg}";
	}

	public static string BuildStopSkill(int skillId)
	{
		return $"{12}|{skillId}";
	}

	public static string BuildAutoBossNapa(int quantity, int farmLast)
	{
		return $"{13}|{quantity}|{farmLast}";
	}

	public static string BuildStopBossNapa()
	{
		return 14.ToString();
	}

	public static string BuildAutoGLTStart()
	{
		return 15.ToString();
	}

	public static string BuildAutoGLTStop()
	{
		return 16.ToString();
	}

	public static string BuildSetMaxHp(string maxHp)
	{
		if (string.IsNullOrWhiteSpace(maxHp))
		{
			maxHp = "0";
		}
		return $"{17}|{maxHp}";
	}

	public static string BuildSetMinHp(string minHp)
	{
		if (string.IsNullOrWhiteSpace(minHp))
		{
			minHp = long.MaxValue.ToString();
		}
		return $"{18}|{minHp}";
	}

	public static string BuildCuongNoCommand()
	{
		return BuildAutoItem("Cuồng Nộ", 381, 2754);
	}

	public static string BuildBoHuyetCommand()
	{
		return BuildAutoItem("Bổ Huyết", 382, 2755);
	}

	public static string BuildGiapXenCommand()
	{
		return BuildAutoItem("Giáp Xên", 384, 2757);
	}

	public static string BuildKhauTrangCommand()
	{
		return BuildAutoItem("Khẩu Trang", 764, 7149);
	}

	public static string BuildCanCoCommand()
	{
		return BuildAutoItem("Cỏ may mắn", 1635, 13618);
	}

	public static string BuildListIDItems(string listItems)
	{
		return $"{21}|{listItems}";
	}

	public static string BuildTrashItemIds(string listItems)
	{
		return $"{22}|{listItems}";
	}

	public static string BuildListIDMob(string ListIDMob)
	{
		return $"{29}|{ListIDMob}";
	}

	public static string BuildAutoPorata()
	{
		return $"{23}";
	}

	public static string BuildAutoUpMapPrivate()
	{
		return $"{40}";
	}

	public static string BuildAutoSKH()
	{
		return $"{30}";
	}

	public static string BuildAttackFull()
	{
		return $"{41}";
	}

	public static string BuildAutoGB()
	{
		return $"{35}";
	}

	public static string BuildAutoFlag()
	{
		return $"{32}";
	}

	public static string BuildAutoLogin()
	{
		return $"{24}";
	}

	public static string BuildAutoUseTDLT()
	{
		return $"{25}";
	}

	public static string BuildAutoBuyTDLT()
	{
		return $"{26}";
	}

	public static string BuildTrainDontMove()
	{
		return $"{19}";
	}

	public static string GetCommandDescription(int commandCode)
	{
		if (1 == 0)
		{
		}
		string result = commandCode switch
		{
			1 => "Login", 
			2 => "Auto Train Full", 
			3 => "Stop Auto Train", 
			5 => "Set Mob Type", 
			6 => "Set Map ID", 
			7 => "Set Zone ID", 
			8 => "Reset Zone ID", 
			9 => "Auto Item", 
			10 => "Stop Auto Item", 
			11 => "Handle Skill", 
			12 => "Stop Skill", 
			13 => "Auto Boss Napa", 
			14 => "Stop Boss Napa", 
			15 => "Auto GLT Start", 
			16 => "Auto GLT Stop", 
			17 => "Set Max HP", 
			18 => "Set Min HP", 
			_ => $"Unknown Command ({commandCode})", 
		};
		if (1 == 0)
		{
		}
		return result;
	}
}
