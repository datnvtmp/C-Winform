using System.Linq;

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

    public const int CMD_AUTO_NE_CHAR = 31;

    public const int CMD_AUTO_GOBACK = 35;

	public const int CMD_AUTO_OFF_KHI_DU_SO_LUONG = 37;

	public const int CMD_AUTO_UP_MAP_PRIVATE = 40;

	public const int CMD_ATTACK_FULL = 41;

	public const int CMD_MOB_LOAI_TRU = 99;

	public const int CMD_SET_TIME_NEXT_MAP = 888;

	public const int CMD_CLOSE_ALL = 999;

	public static string BuildAutoTrainFull(int mapId, int mobType)
	{
		return $"{CMD_AUTO_TRAIN_FULL}|{mapId}|{mobType}";
	}

	public static string BuildStopAutoTrain()
	{
		return CMD_STOP_AUTO_TRAIN.ToString();
	}

	public static string BuildSetZoneId(int zoneId)
	{
		return $"{CMD_SET_ZONE_ID}|{zoneId}";
	}

	public static string BuildResetZoneId()
	{
		return CMD_RESET_ZONE_ID.ToString();
	}

	public static string BuildAutoItem(string name, int id, int iconId)
	{
		return $"{CMD_AUTO_ITEM}|{name}|{id}|{iconId}";
	}

	public static string BuildStopAutoItem(int itemId)
	{
		return $"{CMD_STOP_AUTO_ITEM}|{itemId}";
	}
	public static string BuildAutoNeChar(string characterNames)
	{
		if (string.IsNullOrWhiteSpace(characterNames))
			return $"{CMD_AUTO_NE_CHAR}";

		// Lọc và trim từng tên, loại bỏ empty entries (chấp nhận cả | và ,)
		var validNames = characterNames
			.Split(new[] { '|', ',' }, System.StringSplitOptions.RemoveEmptyEntries)
			.Select(name => name.Trim())
			.Where(name => !string.IsNullOrWhiteSpace(name))
			.ToList();

		// Nếu sau khi lọc không còn tên nào hợp lệ
		if (validNames.Count == 0)
			return $"{CMD_AUTO_NE_CHAR}";

		return $"{CMD_AUTO_NE_CHAR}|{string.Join("|", validNames)}";
	}
	public static string BuildHandleSkill(string skillsCommaSeparated)
	{
		if (string.IsNullOrWhiteSpace(skillsCommaSeparated))
		{
			return $"{CMD_HANDLE_SKILL}";
		}
		string arg = string.Join("|", skillsCommaSeparated.Split(','));
		return $"{CMD_HANDLE_SKILL}|{arg}";
	}

	public static string BuildHandleIDSL(string skillsCommaSeparated)
	{
		string arg = string.Join("|", skillsCommaSeparated.Split('-'));
		return $"{CMD_AUTO_OFF_KHI_DU_SO_LUONG}|{arg}";
	}

	public static string BuildStopSkill(int skillId)
	{
		return $"{CMD_STOP_SKILL}|{skillId}";
	}

	public static string BuildAutoBossNapa(int quantity, int farmLast)
	{
		return $"{CMD_AUTO_BOSS_NAPA}|{quantity}|{farmLast}";
	}

	public static string BuildStopBossNapa()
	{
		return CMD_STOP_BOSS_NAPA.ToString();
	}

	public static string BuildAutoGLTStart()
	{
		return CMD_AUTO_GLT_START.ToString();
	}

	public static string BuildAutoGLTStop()
	{
		return CMD_AUTO_GLT_STOP.ToString();
	}

	public static string BuildSetMaxHp(string maxHp)
	{
		if (string.IsNullOrWhiteSpace(maxHp))
		{
			maxHp = "0";
		}
		return $"{CMD_SET_MAX_HP}|{maxHp}";
	}

	public static string BuildSetMinHp(string minHp)
	{
		if (string.IsNullOrWhiteSpace(minHp))
		{
			minHp = long.MaxValue.ToString();
		}
		return $"{CMD_SET_MIN_HP}|{minHp}";
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
		return $"{CMD_LIST_USE_ITEM}|{listItems}";
	}

	public static string BuildTrashItemIds(string listItems)
	{
		return $"{CMD_LIST_TRASH_ITEM}|{listItems}";
	}

	public static string BuildListIDMob(string ListIDMob)
	{
		return $"{CMD_LIST_MOD_ID}|{ListIDMob}";
	}

	public static string BuildAutoPorata()
	{
		return $"{CMD_AUTO_PORATA}";
	}

	public static string BuildAutoUpMapPrivate()
	{
		return $"{CMD_AUTO_UP_MAP_PRIVATE}";
	}

	public static string BuildAutoSKH()
	{
		return $"{CMD_AUTO_SKH}";
	}

	public static string BuildAttackFull()
	{
		return $"{CMD_ATTACK_FULL}";
	}

	public static string BuildAutoGB()
	{
		return $"{CMD_AUTO_GOBACK}";
	}

	public static string BuildAutoFlag()
	{
		return $"{CMD_AUTO_FLAG}";
	}

	public static string BuildAutoLogin()
	{
		return $"{CMD_AUTO_LOGIN}";
	}

	public static string BuildAutoUseTDLT()
	{
		return $"{CMD_AUTO_USE_TDLT}";
	}

	public static string BuildAutoBuyTDLT()
	{
		return $"{CMD_AUTO_BUY_TDLT}";
	}

	public static string BuildTrainDontMove()
	{
		return $"{CMD_TRAIN_DONT_MOVE}";
	}

	public static string BuildMobLoaiTru(string mobType)
	{
		return $"{CMD_MOB_LOAI_TRU}|{mobType}";
	}

	public static string BuildSetTimeNextMap(int seconds)
	{
		return $"{CMD_SET_TIME_NEXT_MAP}|{seconds}";
	}

	public static string BuildCloseAll()
	{
		return CMD_CLOSE_ALL.ToString();
	}

	public static string GetCommandDescription(int commandCode)
	{
		if (1 == 0)
		{
		}
		string result = commandCode switch
		{
			CMD_LOGIN => "Login",
			CMD_AUTO_TRAIN_FULL => "Auto Train Full",
			CMD_STOP_AUTO_TRAIN => "Stop Auto Train",
			CMD_SET_MOB_TYPE => "Set Mob Type",
			CMD_SET_MAP_ID => "Set Map ID",
			CMD_SET_ZONE_ID => "Set Zone ID",
			CMD_RESET_ZONE_ID => "Reset Zone ID",
			CMD_AUTO_ITEM => "Auto Item",
			CMD_STOP_AUTO_ITEM => "Stop Auto Item",
			CMD_HANDLE_SKILL => "Handle Skill",
			CMD_STOP_SKILL => "Stop Skill",
			CMD_AUTO_BOSS_NAPA => "Auto Boss Napa",
			CMD_STOP_BOSS_NAPA => "Stop Boss Napa",
			CMD_AUTO_GLT_START => "Auto GLT Start",
			CMD_AUTO_GLT_STOP => "Auto GLT Stop",
			CMD_SET_MAX_HP => "Set Max HP",
			CMD_SET_MIN_HP => "Set Min HP",
			CMD_TRAIN_DONT_MOVE => "Train Don't Move",
			CMD_LIST_USE_ITEM => "List Use Item",
			CMD_LIST_TRASH_ITEM => "List Trash Item",
			CMD_AUTO_PORATA => "Auto Porata",
			CMD_AUTO_LOGIN => "Auto Login",
			CMD_AUTO_USE_TDLT => "Auto Use TDLT",
			CMD_AUTO_BUY_TDLT => "Auto Buy TDLT",
			CMD_SHOW_BAG => "Show Bag",
			CMD_SHOW_BOX => "Show Box",
			CMD_LIST_MOD_ID => "List Mob ID",
			CMD_AUTO_SKH => "Auto SKH",
			CMD_AUTO_NE_CHAR => "Auto Ne Character",
			CMD_AUTO_FLAG => "Auto Flag",
			CMD_AUTO_GOBACK => "Auto GoBack",
			CMD_AUTO_OFF_KHI_DU_SO_LUONG => "Auto Off When Enough",
			CMD_AUTO_UP_MAP_PRIVATE => "Auto Up Map Private",
			CMD_ATTACK_FULL => "Attack Full",
			CMD_MOB_LOAI_TRU => "Mob Loai Tru Filter",
			CMD_SET_TIME_NEXT_MAP => "Set Time Next Map",
			CMD_CLOSE_ALL => "Close All",
			_ => $"Unknown Command ({commandCode})",
		};
		if (1 == 0)
		{
		}
		return result;
	}
}
