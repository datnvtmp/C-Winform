namespace QLTK;

public class AccountSettings
{
	public bool AutoTrainEnabled { get; set; } = false;

	public int MapId { get; set; } = 0;

	public int MobTypeIndex { get; set; } = 0;

	public bool AutoZoneEnabled { get; set; } = false;

	public int Zone { get; set; } = 0;

	public string SkillsText { get; set; } = "";

	public bool UseCuongNo { get; set; } = false;

	public bool UseGiapXen { get; set; } = false;

	public bool UseBoHuyet { get; set; } = false;

	public bool UseKhauTrang { get; set; } = false;

	public bool UseCanCo { get; set; } = false;

	public bool AutoBossNapa { get; set; } = false;

	public int QuantityGTS { get; set; } = 0;

	public bool FarmReverseGTS { get; set; } = false;

	public bool UseHpThreshold { get; set; } = false;

	public string HpThreshold { get; set; } = "0";

	public bool checkMinHp { get; set; } = false;

	public string minHp { get; set; } = "100000000";

	public bool AutoUseGiapLT { get; set; } = false;

	public bool AutoPorata { get; set; } = false;

	public bool AutoBuyTDLT { get; set; } = false;

	public bool AutoLogin { get; set; } = false;

	public bool TrainNotMove { get; set; } = false;

	public string ListIDItems { get; set; } = "";

	public string TrashItemIds { get; set; } = "";

	public string ListIDMob { get; set; } = "";

	public string IDSL { get; set; } = "";

	public string character { get; set; } = "";

	public bool nechar { get; set; } = false;

	public bool SKH { get; set; } = false;

	public bool AutoFlag { get; set; } = false;

	public bool AutoGB { get; set; } = false;

	public bool UpMapPrivate { get; set; } = false;

	public bool AttackFull { get; set; } = false;
}
