using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data;
using GriffinReed.Models;
using GriffinReed.BusinessLayer;
using Common.DB;
//Add
namespace Business.Member {
	public sealed class BGRBMember : IBMember, IExistBusinessModel, IAddBusinessModel, IUpdateBusinessModel, IDeleteBusinessModel {

		#region private constructor

		/// <summary>
		/// 构造函数（私有）
		/// </summary>
		/// <param name="p_Entity">数据层的对象表实体</param>
		/// <param name="p_DBManagement">控制器</param>
		private BGRBMember(GR_Member p_Entity, IDBManagement p_DBManagement) {
			c_Entity = p_Entity;
			c_DBManagement = p_DBManagement;
			c_ObjectContext = p_DBManagement.CurrentDBContext;
			//c_MemberCollection = c_ObjectContext.CreateObjectSet<GR_Member>();
			//c_GroupRoleRelationCollection = c_ObjectContext.CreateObjectSet<GR_OrganizationRole>();
		}

		#endregion

		#region static entry to generate current entity object
		/// <summary>
		/// 获取对象
		/// </summary>
		/// <param name="p_MemberNo">会员编号</param>
		/// <returns></returns>
		public static BGRBMember GetMember(string p_MemberNo) {
			BGRBMember m_Instance = null;
			m_Instance = GetMember(p_MemberNo, null);
			return m_Instance;
		}

		/// <summary>
		/// 获取对象
		/// </summary>
		/// <param name="p_Code">会员编号</param>
		/// <param name="p_DBManagement">数据源控制器</param>
		/// <returns></returns>
		public static BGRBMember GetMember(string p_MemberNo, IDBManagement p_DBManagement) {
			BGRBMember m_Instance = null;
			if (p_DBManagement == null) {
				p_DBManagement = new ERPDBManagement();
			}
			ObjectSet<GR_Member> m_PermissionColleciton = p_DBManagement.CurrentDBContext.CreateObjectSet<GR_Member>();
			GR_Member m_Entity = m_PermissionColleciton.FirstOrDefault(m => m.MemberNo == p_MemberNo&&m.State=="Y");
			if (m_Entity != null) {
				m_Instance = GetMember(m_Entity, p_DBManagement);
			}
			return m_Instance;
		}
		/// <summary>
		/// 获取对象根据手机号
		/// </summary>
		/// <param name="p_Mobile">手机号</param>
		/// <param name="p_DBManagement"></param>
		/// <returns></returns>
		public static BGRBMember GetMemberByMobile(string p_Mobile, IDBManagement p_DBManagement) {
			BGRBMember m_Instance = null;
			if (p_DBManagement == null) {
				p_DBManagement = new ERPDBManagement();
			}
			ObjectSet<GR_Member> m_PermissionColleciton = p_DBManagement.CurrentDBContext.CreateObjectSet<GR_Member>();
			GR_Member m_Entity = m_PermissionColleciton.FirstOrDefault(m => m.Mobile == p_Mobile && m.State == "Y");
			if (m_Entity != null) {
				m_Instance = GetMember(m_Entity, p_DBManagement);
			}
			return m_Instance;
		}

		/// <summary>
		/// 获取对象
		/// </summary>
		/// <param name="p_Entity">会员对象</param>
		/// <param name="p_DBManagement">控制器</param>
		/// <returns></returns>
		public static BGRBMember GetMember(GR_Member p_Entity, IDBManagement p_DBManagement) {
			BGRBMember m_Instance = null;
			if (p_Entity != null && p_DBManagement != null) {
				m_Instance = new BGRBMember(p_Entity, p_DBManagement);
			}
			return m_Instance;
		}
		/// <summary>
		/// 获取对象
		/// </summary>
		/// <returns></returns>
		public static BGRBMember CreateMember() {
			BGRBMember m_Instance = null;
			m_Instance = CreateMember(null);
			return m_Instance;
		}

		/// <summary>
		/// 获取对象
		/// </summary>
		/// <param name="p_DBManagement">控制器</param>
		/// <returns></returns>
		public static BGRBMember CreateMember(IDBManagement p_DBManagement) {
			BGRBMember m_Instance = null;
			if (p_DBManagement == null) {
				p_DBManagement = new ERPDBManagement();
			}
			GR_Member m_Entity = new GR_Member();
			m_Instance = GetMember(m_Entity, p_DBManagement);
			return m_Instance;
		}

		#endregion

		#region static entry to generate finder
		/// <summary>
		/// 创建一个会员查询对象
		/// </summary>
		/// <returns>会员业务查询对象</returns>
		public static BGRBMemberFinder CreateMemberFinder() {
			BGRBMemberFinder m_Selector = null;
			m_Selector = CreateMemberFinder(null);
			return m_Selector;
		}

		/// <summary>
		/// 根据相关的数据管理器创建一个会员对象
		/// </summary>
		/// <param name="p_DBManagement">数据管理器</param>
		/// <returns>会员对象</returns>
		public static BGRBMemberFinder CreateMemberFinder(IDBManagement p_DBManagement) {
			BGRBMemberFinder m_Selector = null;
			m_Selector = BGRBMemberFinder.GetInstance(p_DBManagement);
			return m_Selector;
		}

		#endregion

		#region field
		//会员集合对象
		//private ObjectSet<GR_Member> c_MemberCollection;
		//会员对象
		private GR_Member c_Entity;


		#endregion

		#region  property


		public override string MemberNo {
			get {
				return c_Entity.MemberNo;
			}

		}


		public override string Name {
			get {
				return c_Entity.Name;
			}
			set {
				c_Entity.Name = value;
			}
		}
		public override string CENo {
			get {
				return c_Entity.CENo;
			}
			set {
				c_Entity.CENo = value;
			}
		}

		public override string CardNo {
			get {
				return c_Entity.CardNo;
			}
			set {
				c_Entity.CardNo = value;
			}
		}


		public override string MemberType {
			get {
				return c_Entity.MemberType;
			}
			set {
				c_Entity.MemberType = value;
			}
		}

		public override string MemberTypeName {
			get {
				return c_Entity.MemberTypeName;
			}
			set {
				c_Entity.MemberTypeName = value;
			}
		}
		public override string Password {
			get {
				return c_Entity.Password;
			}
			set {
				c_Entity.Password = value;
			}
		}
		public override string Sex {
			get {
				return c_Entity.Sex;
			}
			set {
				c_Entity.Sex = value;
			}
		}

		public override string Birthday {
			get {
				return c_Entity.Birthday;
			}
			set {
				c_Entity.Birthday = value;
			}
		}
		public override string IDCard {
			get {
				return c_Entity.IDCard;
			}
			set {
				c_Entity.IDCard = value;
			}
		}
		public override string HighestEducation {
			get {
				return c_Entity.HighestEducation;
			}
			set {
				c_Entity.HighestEducation = value;
			}
		}
		public override string Profession {
			get {
				return c_Entity.Profession;
			}
			set {
				c_Entity.Profession = value;
			}
		}
		public override string Mobile {
			get {
				return c_Entity.Mobile;
			}
			set {
				c_Entity.Mobile = value;
			}
		}
		public override bool IsMobileValid {
			get {
				return c_Entity.IsMobileValid;
			}
			set {
				c_Entity.IsMobileValid = value;
			}
		}
		public override string Email {
			get {
				return c_Entity.Email;
			}
			set {
				c_Entity.Email = value;
			}
		}
		public override bool IsEmailValid {
			get {
				return c_Entity.IsEmailValid;
			}
			set {
				c_Entity.IsEmailValid = value;
			}
		}
		public override string Province {
			get {
				return c_Entity.Province;
			}
			set {
				c_Entity.Province = value;
			}
		}

		public override string City {
			get {
				return c_Entity.City;
			}
			set {
				c_Entity.City = value;
			}
		}
		public override string Area {
			get {
				return c_Entity.Area;
			}
			set {
				c_Entity.Area = value;
			}
		}

		public override string Address {
			get {
				return c_Entity.Address;
			}
			set {
				c_Entity.Address = value;
			}
		}
		public override string PostCode {
			get {
				return c_Entity.PostCode;
			}
			set {
				c_Entity.PostCode = value;
			}
		}
		public override string Remark {
			get {
				return c_Entity.Remark;
			}
			set {
				c_Entity.Remark = value;
			}
		}
		public override decimal? SumInvestCapital {
			get {
				return c_Entity.SumInvestCapital;
			}
			set {
				c_Entity.SumInvestCapital = value;
			}
		}
		public override string Saleperson {
			get {
				return c_Entity.Saleperson;
			}
			set {
				c_Entity.Saleperson = value;
			}
		}
		public override string FinanceConsultant {
			get {
				return c_Entity.FinanceConsultant;
			}
			set {
				c_Entity.FinanceConsultant = value;
			}
		}
		public override string CustomService {
			get {
				return c_Entity.CustomService;
			}
			set {
				c_Entity.CustomService = value;
			}
		}
		public override int IntegralTotal {
			get {
				return c_Entity.IntegralTotal;
			}
			set {
				c_Entity.IntegralTotal = value;
			}
		}
		public override int IntegralCurrent {
			get {
				return c_Entity.IntegralCurrent;
			}
			set {
				c_Entity.IntegralCurrent = value;
			}
		}
		public override int IntegralConsume {
			get {
				return c_Entity.IntegralConsume;
			}
			set {
				c_Entity.IntegralConsume = value;
			}
		}
		public override int GrowthPoint {
			get {
				return c_Entity.GrowthPoint;
			}
			set {
				c_Entity.GrowthPoint = value;
			}
		}
		public override int LoginCount {
			get {
				return c_Entity.LoginCount;
			}
			set {
				c_Entity.LoginCount = value;
			}
		}
		public override DateTime LastLoginTime {
			get {
				return c_Entity.LastLoginTime;
			}
			set {
				c_Entity.LastLoginTime = value;
			}
		}
		public override string LastLoginIP {
			get {
				return c_Entity.LastLoginIP;
			}
			set {
				c_Entity.LastLoginIP = value;
			}
		}
		public override int ApplyUpgradeMemberCount {
			get {
				return c_Entity.ApplyUpgradeMemberCount;
			}
			set {
				c_Entity.ApplyUpgradeMemberCount = value;
			}
		}
		public override int FinanceBookingCount {
			get {
				return c_Entity.FinanceBookingCount;
			}
			set {
				c_Entity.FinanceBookingCount = value;
			}
		}
		public override int FinanceTransCount {
			get {
				return c_Entity.FinanceTransCount;
			}
			set {
				c_Entity.FinanceTransCount = value;
			}
		}
		public override string InfoSourceCode {
			get {
				return c_Entity.InfoSourceCode;
			}
			set {
				c_Entity.InfoSourceCode = value;
			}
		}
		public override string InfoSourceName {
			get {
				return c_Entity.InfoSourceName;
			}
			set {
				c_Entity.InfoSourceName = value;
			}
		}


		public override string RegisterSourceCode {
			get {
				return c_Entity.RegisterSourceCode;
			}
			set {
				c_Entity.RegisterSourceCode = value;
			}
		}
		public override string RegisterSourceName {
			get {
				return c_Entity.RegisterSourceName;
			}
			set {
				c_Entity.RegisterSourceName = value;
			}
		}
		public override DateTime RegisterTime {
			get {
				return c_Entity.RegisterTime;
			}
			set {
				c_Entity.RegisterTime = value;
			}
		}
		public override string RegisterType {
			get {
				return c_Entity.RegisterType;
			}
			set {
				c_Entity.RegisterType = value;
			}
		}
		public override string JionMode {
			get {
				return c_Entity.JionMode;
			}
			set {
				c_Entity.JionMode = value;
			}
		}
		public override string MemberTicktNo {
			get {
				return c_Entity.MemberTicketNo;
			}
			set {
				c_Entity.MemberTicketNo = value;
			}
		}
		#endregion

		#region implement  IBMember

		#region inner method

		protected override void FillCurrentProperty() {
            ObjectSet<GR_Member> c_MemberCollection = c_ObjectContext.CreateObjectSet<GR_Member>();
			if (c_Entity == null) {
				c_Entity = c_MemberCollection.CreateObject();
			}
		}
		protected override bool Save() {
			bool m_Result = true;
			c_ObjectContext.SaveChanges();
			return m_Result;
		}

		/// <summary>
		/// 会员编号 规矩GR+yyyyMMdd+11位数字
		/// </summary>
		/// <returns></returns>
		private string GenerateMemberNo() {
            ObjectSet<GR_Member> c_MemberCollection = c_ObjectContext.CreateObjectSet<GR_Member>();
			string m_MemberNo = "GR";
			m_MemberNo += System.DateTime.Now.ToString("yyyyMMdd");
			int m_Count = c_MemberCollection.Count() + 1;
			m_MemberNo += m_Count.ToString("00000000");

			return m_MemberNo;
		}

		#endregion

		#region outer method

		public override BGRBUpgradeMemberTransDetail ApplyMemerUpgrade(string p_CurrentMemberType, string p_TargetMemberType, string p_RecommendMemberNo) {
			if (c_Entity == null) {
				return null;
			}
			BGRBMemberType m_MemberTypeBusiness = null;
			m_MemberTypeBusiness = BGRBMemberType.GetMemberType(p_TargetMemberType);
			if (m_MemberTypeBusiness == null) {
				return null;
			}
			BGRBUpgradeMemberTransDetail m_UpgradeMemberTransDetail = BGRBUpgradeMemberTransDetail.CreateUpgradeMemberTransDetail();
			BGRBUpgradeMemberTransDetail m_UpgradeTransDetail = m_UpgradeMemberTransDetail.GenerateUpgradeDetail(new BGRBMember(c_Entity, c_DBManagement), m_MemberTypeBusiness, null, null);

			return m_UpgradeTransDetail;
		}

		#endregion

		#endregion

		#region static business method

		#region member log in and log out

		#region log in

		/// <summary>
		/// 会员登录
		/// </summary>
		/// <param name="p_LoginCode">登录代码（会员卡号、会员编号、手机号）</param>
		/// <param name="p_Password">登录密码</param>
		/// <param name="p_MemberLoginType">登录方式</param>
		/// <returns>会员对象（成功返回实例，失败返回null）</returns>
		public static BGRBMember LoginMember(string p_LoginCode, string p_Password, MemberLoginType p_MemberLoginType) {
			BGRBMember m_MemberResult = null;
			m_MemberResult = GetMemberByLoginCodeAndPassword(p_LoginCode, p_Password, p_MemberLoginType);
			if (m_MemberResult != null) {
				m_MemberResult.LastLoginTime = DateTime.Now;
				m_MemberResult.LoginCount++;
				m_MemberResult.SaveData();
			}

			return m_MemberResult;
		}

		#endregion

		#region log out

		/// <summary>
		/// 会员退出
		/// </summary>
		public static void LogoutMember() {

		}

		#endregion

		#endregion

		#region member register

		public static BGRBMember BasicRegisterMember(string p_MemberName, string p_Mobile, string p_Email, string p_Sex, string p_Area, string p_RegisterType, ref string p_ResultMsg) {
			return BasicRegisterMember(p_MemberName, p_Mobile, p_Email, p_Sex, p_Area, p_RegisterType, false, ref p_ResultMsg);
		}

		public static BGRBMember BasicRegisterMember(string p_MemberName, string p_Mobile, string p_Email, string p_Sex, string p_Area, string p_RegisterType, bool p_IsTransaction, ref string p_ResultMsg) {

			BGRBMemberFinder m_MemberFinder = null;
			IDBManagement m_DBManagement = new ERPDBManagement();

			#region 判断手机是否已经存在

			m_MemberFinder = BGRBMemberFinder.GetInstance(m_DBManagement);
			if (m_MemberFinder.ExistMemberMobile(p_Mobile)) {
				p_ResultMsg = "此手机用户已经存在!";
				return null;
			}

			#endregion

			#region 会员注册信息填充

			BGRBMemberType m_MemberType = BGRBMemberType.GetMemberType("V0", m_DBManagement);
			BGRBMember m_Member = BGRBMember.CreateMember(m_DBManagement);
			m_Member.Mobile = p_Mobile;
			m_Member.MemberType = m_MemberType.Code;
			m_Member.MemberTypeName = m_MemberType.Name;
			m_Member.Name = p_MemberName;
			m_Member.Email = p_Email;
			m_Member.Sex = p_Sex;
			m_Member.Area = p_Area;
			m_Member.Password = p_Mobile;
			m_Member.RegisterType = p_RegisterType;
			m_Member.InfoSourceCode = "01";
			m_Member.RegisterTime = DateTime.Now;
			m_Member.LastLoginTime = DateTime.Now;
			//c_TypeOrStatusFactory = ShowInfoSourceFactory.GetInstance();
			//c_Member.InfoSourceName = GetStateName(m_TempMember.InfoSourceCode);
			m_Member.RegisterSourceCode = "GRWEB";
			//c_TypeOrStatusFactory = ShowChannelSourceFactory.GetInstance();
			//c_Member.RegisterSourceName = GetStateName(m_TempMember.RegisterSourceCode);

			#endregion

			#region 数据源保存

			ReturnInfo m_MemberReturnInfo = null;
			if (p_IsTransaction) {
				m_MemberReturnInfo = m_Member.AddBusinessModel(false);
			}
			else {
				m_MemberReturnInfo = m_Member.AddBusinessModel(true);
			}

			#endregion

			return m_Member;
		}

		#endregion

		#region member password

		/// <summary>
		/// 重置用户的密码
		/// </summary>
		/// <param name="p_LoginCode">登录代码（会员卡号、会员编号、手机号）</param>
		/// <param name="p_OldPassword">旧密码</param>
		/// <param name="p_NewPassword">新密码</param>
		/// <param name="p_MemberLoginType">登录方式</param>
		/// <returns>是否重置成功</returns>
		public static bool ResetMemberPassword(string p_LoginCode, string p_OldPassword, string p_NewPassword, MemberLoginType p_MemberLoginType) {
			bool m_Result = true;
			BGRBMember m_Member = GetMemberByLoginCodeAndPassword(p_LoginCode, p_OldPassword, p_MemberLoginType);
			if (m_Member != null) {
				m_Member.Password = p_NewPassword;
				m_Member.SaveData();
			}
			else {
				m_Result = false;
			}

			return m_Result;
		}

		#endregion

		#region member mobile

		#region mobile valid

		/// <summary>
		/// 验证当前的登录会员的手机号码是否有效
		/// 通过则修改手机绑定状态
		/// </summary>
		/// <param name="p_LoginCode">登录代码（会员卡号、会员编号、手机号）</param>
		/// <param name="p_Password">登录密码</param>
		/// <param name="p_MemberLoginType">登录方式</param>
		/// <returns>验证是否通过（通过修改手机绑定状态）</returns>
		public static bool ValidMobile(string p_LoginCode, string p_Password, MemberLoginType p_MemberLoginType) {
			bool m_Result = false;
			BGRBMember m_Member = GetMemberByLoginCodeAndPassword(p_LoginCode, p_Password, p_MemberLoginType);
			if (m_Member != null) {
				m_Member.IsMobileValid = true;
				m_Result = m_Member.UpdateBusinessModel(true).IsSuccess;
			}
			return m_Result;
		}

		#endregion

		#endregion

		#region member email

		#region email valid

		/// <summary>
		/// 验证当前的登录会员的邮箱是否有效
		/// 通过则修改邮箱绑定状态
		/// </summary>
		/// <param name="p_LoginCode">登录代码（会员卡号、会员编号、手机号）</param>
		/// <param name="p_Password">登录密码</param>
		/// <param name="p_MemberLoginType">登录方式</param>
		/// <returns>验证是否通过（通过修改手机绑定状态）</returns>
		public static bool ValidEmail(string p_LoginCode, string p_Password, MemberLoginType p_MemberLoginType) {
			bool m_Result = false;
			BGRBMember m_Member = GetMemberByLoginCodeAndPassword(p_LoginCode, p_Password, p_MemberLoginType);


			if (m_Member != null) {
				m_Member.IsEmailValid = true;
				m_Result = m_Member.UpdateBusinessModel(true).IsSuccess;
			}
			return m_Result;
		}

		#endregion

		#endregion

		#region member common

		/// <summary>
		/// 通过登录代码和登录密码获取会员
		/// </summary>
		/// <param name="p_LoginCode">登录代码（会员卡号、会员编号、手机号）</param>
		/// <param name="p_Password">登录密码</param>
		/// <param name="p_MemberLoginType">登录方式</param>
		/// <returns>会员对象（匹配成功返回实例，失败返回null）</returns>
		private static BGRBMember GetMemberByLoginCodeAndPassword(string p_LoginCode, string p_Password, MemberLoginType p_MemberLoginType) {
			BGRBMember m_MemberResult = null;
			IBMemberFinder<BGRBMember, GR_Member> m_MemberFinder = BGRBMember.CreateMemberFinder();
			switch (p_MemberLoginType) {
				case MemberLoginType.Card:
					m_MemberResult = m_MemberFinder.GetMemberByCardNoAndPassword(p_LoginCode, p_Password);
					break;
				case MemberLoginType.Mobile:
					m_MemberResult = m_MemberFinder.GetMemberByMobileAndPassword(p_LoginCode, p_Password);
					break;
				case MemberLoginType.MemberNo:
					m_MemberResult = m_MemberFinder.GetMemberByMemberNoAndPassword(p_LoginCode, p_Password);
					break;
				default:
					break;
			}

			return m_MemberResult;
		}

		#endregion

		#endregion

		#region  Update p_ExchangeGivingTransDetail

		/// <summary>
		/// 修改 会员 添加兑换礼品明细
		/// </summary>
		/// <param name="p_Member">会员</param>
		/// <param name="p_ExchangeGivingTransDetail">礼品明细</param>

		public void UpdateExchangeGivingGood(BGRBMember p_Member, BGRExchangeGivingTransDetail p_ExchangeGivingTransDetail, BGRExchangeGiving m_ExchangeGiving) {

			DefaultDBTransactionManagement m_TransactionManagement = new DefaultDBTransactionManagement();
			m_TransactionManagement.AddTransaction(m_ExchangeGiving);
			m_TransactionManagement.AddTransaction(p_Member);
			m_TransactionManagement.AddTransaction(p_ExchangeGivingTransDetail);
			m_TransactionManagement.TransactionSave();
		}


		#endregion
		#region implement  IAddBusinessModel

		/// <summary>
		/// 添加业务对象
		/// </summary>
		/// <param name="p_IsReallySave">是否立刻保存到数据源</param>
		public ReturnInfo AddBusinessModel(bool p_IsReallySave) {
			bool m_Result = true;
			ReturnInfo m_returnInfo = new ReturnInfo();
			if (c_Entity.EntityState != System.Data.EntityState.Detached) {
				m_returnInfo.IsSuccess = false;
				return m_returnInfo;
			}
			c_Entity.State = c_InUseState;
			c_IsSaveDB = p_IsReallySave;
			c_Entity.MemberNo = GenerateMemberNo();
			c_CurrentHandleCollection = new List<EntityObject>();
			c_CurrentHandleCollection.Add(c_Entity);
			m_Result = Add();
			m_returnInfo.IsSuccess = m_Result;
			return m_returnInfo;
		}

		#endregion



		#region  implement  IDeleteBusinessModel
		/// <summary>
		/// 删除业务对象
		/// </summary>
		/// <param name="p_IsReallySave">是否立刻保存到数据源</param>
		public ReturnInfo DeleteBusinessModel(bool p_IsReallySave) {
			bool m_Result = true;
			ReturnInfo m_returnInfo = new ReturnInfo();
			if (c_Entity.EntityState != EntityState.Modified && c_Entity.EntityState != EntityState.Unchanged) {
				m_returnInfo.IsSuccess = false;
				return m_returnInfo;
			}
			c_IsSaveDB = p_IsReallySave;
			c_Entity.State = c_NoUseState;
			c_CurrentHandleCollection = new List<EntityObject>();
			c_CurrentHandleCollection.Add(c_Entity);
			m_Result = Update();
			m_returnInfo.IsSuccess = m_Result;
			return m_returnInfo;
		}
		#endregion

		#region  implement  IExistBusinessModel
		/// <summary>
		/// 检测实例化代入参数的业务对象是否存在
		/// </summary>
		public ReturnInfo ExistStore() {
			bool m_Result = false;
			if (c_Entity.EntityState != EntityState.Detached) {
				m_Result = true;
			}
			ReturnInfo m_returnInfo = new ReturnInfo();
			m_returnInfo.IsSuccess = m_Result;
			return m_returnInfo;
		}
		#endregion

		#region implement  IUpdateBusinessModel
		/// <summary>
		/// 更新业务对象
		/// </summary>
		/// <param name="p_IsReallySave">是否立刻保存到数据源</param>
		public ReturnInfo UpdateBusinessModel(bool p_IsReallySave) {
			bool m_Result = true;
			ReturnInfo m_returnInfo = new ReturnInfo();
			if (c_Entity.EntityState != EntityState.Modified && c_Entity.EntityState != EntityState.Unchanged) {
				m_returnInfo.IsSuccess = false;
				return m_returnInfo;
			}
			c_IsSaveDB = p_IsReallySave;
			c_CurrentHandleCollection = new List<EntityObject>();
			c_CurrentHandleCollection.Add(c_Entity);
			m_Result = Update();
			m_returnInfo.IsSuccess = m_Result;
			return m_returnInfo;
		}
		#endregion

		#region member behavior

		#region member email

		/// <summary>
		/// 邮箱订阅
		/// </summary>
		/// <param name="p_Email">邮箱</param>
		/// <param name="p_MemberNo">会员编号</param>
		/// <returns></returns>
		public override bool SetEmailSubscription(string p_Email) {
			bool m_Result = true;
			BGREmailNewsSubscription m_EmailSubscription = null;
			BGREmailNewsSubscriptionFinder m_SubscriptionFinder = BGREmailNewsSubscription.CreateEmailNewsSubscriptionFinder(c_DBManagement);
			IQueryable<BGREmailNewsSubscription> m_Collection = m_SubscriptionFinder.GetEmailNewsSubscriptionByMemberNo(c_Entity.MemberNo, null);
			if (m_Collection != null && m_Collection.Count() > 0) {
				m_EmailSubscription = m_Collection.FirstOrDefault();
			}
			else {
				m_EmailSubscription = BGREmailNewsSubscription.CreateEmailNewsSubscription(c_DBManagement);
				m_EmailSubscription.MemberNo = c_Entity.MemberNo;
			}
			m_EmailSubscription.Email = p_Email;
			m_EmailSubscription.AddBusinessModel(m_Result);
			//m_EmailSubscription.SaveData();

			return m_Result;
		}

		#endregion

		#region card sale

		/// <summary>
		/// 销售会员卡（会员券方式）
		/// </summary>
		/// <param name="p_TicketNo">会员劵号</param>
		/// <param name="p_TicketPassword">会员劵密码</param>
		/// <returns></returns>
		public override bool SaleCardByMemberTicket(string p_TicketNo, string p_TicketPassword, ref string p_ResultMsg) {
			return BGRCard.SaleCardByTicket(c_Entity.MemberNo, p_TicketNo, p_TicketPassword, ref p_ResultMsg);
		}

		/// <summary>
		/// 销售会员卡（成长值方式）
		/// </summary>
		/// <param name="p_ResultMsg"></param>
		/// <returns></returns>
		public override bool SaleCardByGrowth(ref string p_ResultMsg,string p_JoinMode) {
			return BGRCard.SaleCardByGrowth(c_Entity.MemberNo, ref p_ResultMsg,p_JoinMode);
		}


		/// <summary>
		///  销售会员卡（付费方式）
		/// </summary>
		/// <param name="RecommendMemberNo">推荐会员编号</param>
		/// <param name="p_TagMemberType">目标等级</param>
		/// <param name="p_aleCardRewardType">奖励类型</param>
		/// <param name="p_ResultMsg"></param>
		/// <returns></returns>
        public override bool SaleCardByPayment(string RecommendMemberNo, string p_TagMemberType, SaleCardRewardType p_aleCardRewardType, ref string p_ResultMsg, string p_JoinMode) {
            return BGRCard.SaleCardByPayment(c_Entity.MemberNo, RecommendMemberNo, p_TagMemberType, p_aleCardRewardType, ref  p_ResultMsg, p_JoinMode);
		}

		#endregion

		#endregion


	}
}
