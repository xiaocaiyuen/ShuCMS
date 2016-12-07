 
using Shu.DAL;
using Shu.IDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shu.Factroy
{
	public partial class DBSession : IDBSession
    {
		private IMS_ADDal _MS_ADDal;
        public IMS_ADDal MS_ADDal
        {
            get
            {
                if(_MS_ADDal == null)
                {
                    _MS_ADDal = AbstractFactory.CreateMS_ADDal();
                }
                return _MS_ADDal;
            }
            set { _MS_ADDal = value; }
        }
		private IMS_ADClassDal _MS_ADClassDal;
        public IMS_ADClassDal MS_ADClassDal
        {
            get
            {
                if(_MS_ADClassDal == null)
                {
                    _MS_ADClassDal = AbstractFactory.CreateMS_ADClassDal();
                }
                return _MS_ADClassDal;
            }
            set { _MS_ADClassDal = value; }
        }
		private IMS_AdminDal _MS_AdminDal;
        public IMS_AdminDal MS_AdminDal
        {
            get
            {
                if(_MS_AdminDal == null)
                {
                    _MS_AdminDal = AbstractFactory.CreateMS_AdminDal();
                }
                return _MS_AdminDal;
            }
            set { _MS_AdminDal = value; }
        }
		private IMS_AdminActionDal _MS_AdminActionDal;
        public IMS_AdminActionDal MS_AdminActionDal
        {
            get
            {
                if(_MS_AdminActionDal == null)
                {
                    _MS_AdminActionDal = AbstractFactory.CreateMS_AdminActionDal();
                }
                return _MS_AdminActionDal;
            }
            set { _MS_AdminActionDal = value; }
        }
		private IMS_AdminModuleDal _MS_AdminModuleDal;
        public IMS_AdminModuleDal MS_AdminModuleDal
        {
            get
            {
                if(_MS_AdminModuleDal == null)
                {
                    _MS_AdminModuleDal = AbstractFactory.CreateMS_AdminModuleDal();
                }
                return _MS_AdminModuleDal;
            }
            set { _MS_AdminModuleDal = value; }
        }
		private IMS_AdminRoleDal _MS_AdminRoleDal;
        public IMS_AdminRoleDal MS_AdminRoleDal
        {
            get
            {
                if(_MS_AdminRoleDal == null)
                {
                    _MS_AdminRoleDal = AbstractFactory.CreateMS_AdminRoleDal();
                }
                return _MS_AdminRoleDal;
            }
            set { _MS_AdminRoleDal = value; }
        }
		private IMS_AdminRoleMenuDal _MS_AdminRoleMenuDal;
        public IMS_AdminRoleMenuDal MS_AdminRoleMenuDal
        {
            get
            {
                if(_MS_AdminRoleMenuDal == null)
                {
                    _MS_AdminRoleMenuDal = AbstractFactory.CreateMS_AdminRoleMenuDal();
                }
                return _MS_AdminRoleMenuDal;
            }
            set { _MS_AdminRoleMenuDal = value; }
        }
		private IMS_AdminRoleModuleDal _MS_AdminRoleModuleDal;
        public IMS_AdminRoleModuleDal MS_AdminRoleModuleDal
        {
            get
            {
                if(_MS_AdminRoleModuleDal == null)
                {
                    _MS_AdminRoleModuleDal = AbstractFactory.CreateMS_AdminRoleModuleDal();
                }
                return _MS_AdminRoleModuleDal;
            }
            set { _MS_AdminRoleModuleDal = value; }
        }
		private IMS_AdminRoleTableDal _MS_AdminRoleTableDal;
        public IMS_AdminRoleTableDal MS_AdminRoleTableDal
        {
            get
            {
                if(_MS_AdminRoleTableDal == null)
                {
                    _MS_AdminRoleTableDal = AbstractFactory.CreateMS_AdminRoleTableDal();
                }
                return _MS_AdminRoleTableDal;
            }
            set { _MS_AdminRoleTableDal = value; }
        }
		private IMS_CandidatesDal _MS_CandidatesDal;
        public IMS_CandidatesDal MS_CandidatesDal
        {
            get
            {
                if(_MS_CandidatesDal == null)
                {
                    _MS_CandidatesDal = AbstractFactory.CreateMS_CandidatesDal();
                }
                return _MS_CandidatesDal;
            }
            set { _MS_CandidatesDal = value; }
        }
		private IMS_ConfigDal _MS_ConfigDal;
        public IMS_ConfigDal MS_ConfigDal
        {
            get
            {
                if(_MS_ConfigDal == null)
                {
                    _MS_ConfigDal = AbstractFactory.CreateMS_ConfigDal();
                }
                return _MS_ConfigDal;
            }
            set { _MS_ConfigDal = value; }
        }
		private IMS_DepartmentDal _MS_DepartmentDal;
        public IMS_DepartmentDal MS_DepartmentDal
        {
            get
            {
                if(_MS_DepartmentDal == null)
                {
                    _MS_DepartmentDal = AbstractFactory.CreateMS_DepartmentDal();
                }
                return _MS_DepartmentDal;
            }
            set { _MS_DepartmentDal = value; }
        }
		private IMS_DeptDal _MS_DeptDal;
        public IMS_DeptDal MS_DeptDal
        {
            get
            {
                if(_MS_DeptDal == null)
                {
                    _MS_DeptDal = AbstractFactory.CreateMS_DeptDal();
                }
                return _MS_DeptDal;
            }
            set { _MS_DeptDal = value; }
        }
		private IMS_DownloadDal _MS_DownloadDal;
        public IMS_DownloadDal MS_DownloadDal
        {
            get
            {
                if(_MS_DownloadDal == null)
                {
                    _MS_DownloadDal = AbstractFactory.CreateMS_DownloadDal();
                }
                return _MS_DownloadDal;
            }
            set { _MS_DownloadDal = value; }
        }
		private IMS_DownloadClassDal _MS_DownloadClassDal;
        public IMS_DownloadClassDal MS_DownloadClassDal
        {
            get
            {
                if(_MS_DownloadClassDal == null)
                {
                    _MS_DownloadClassDal = AbstractFactory.CreateMS_DownloadClassDal();
                }
                return _MS_DownloadClassDal;
            }
            set { _MS_DownloadClassDal = value; }
        }
		private IMS_ExpressDal _MS_ExpressDal;
        public IMS_ExpressDal MS_ExpressDal
        {
            get
            {
                if(_MS_ExpressDal == null)
                {
                    _MS_ExpressDal = AbstractFactory.CreateMS_ExpressDal();
                }
                return _MS_ExpressDal;
            }
            set { _MS_ExpressDal = value; }
        }
		private IMS_FileUrlDal _MS_FileUrlDal;
        public IMS_FileUrlDal MS_FileUrlDal
        {
            get
            {
                if(_MS_FileUrlDal == null)
                {
                    _MS_FileUrlDal = AbstractFactory.CreateMS_FileUrlDal();
                }
                return _MS_FileUrlDal;
            }
            set { _MS_FileUrlDal = value; }
        }
		private IMS_JobTitleDal _MS_JobTitleDal;
        public IMS_JobTitleDal MS_JobTitleDal
        {
            get
            {
                if(_MS_JobTitleDal == null)
                {
                    _MS_JobTitleDal = AbstractFactory.CreateMS_JobTitleDal();
                }
                return _MS_JobTitleDal;
            }
            set { _MS_JobTitleDal = value; }
        }
		private IMS_LinkDal _MS_LinkDal;
        public IMS_LinkDal MS_LinkDal
        {
            get
            {
                if(_MS_LinkDal == null)
                {
                    _MS_LinkDal = AbstractFactory.CreateMS_LinkDal();
                }
                return _MS_LinkDal;
            }
            set { _MS_LinkDal = value; }
        }
		private IMS_LinkClassDal _MS_LinkClassDal;
        public IMS_LinkClassDal MS_LinkClassDal
        {
            get
            {
                if(_MS_LinkClassDal == null)
                {
                    _MS_LinkClassDal = AbstractFactory.CreateMS_LinkClassDal();
                }
                return _MS_LinkClassDal;
            }
            set { _MS_LinkClassDal = value; }
        }
		private IMS_LogDal _MS_LogDal;
        public IMS_LogDal MS_LogDal
        {
            get
            {
                if(_MS_LogDal == null)
                {
                    _MS_LogDal = AbstractFactory.CreateMS_LogDal();
                }
                return _MS_LogDal;
            }
            set { _MS_LogDal = value; }
        }
		private IMS_LoginDal _MS_LoginDal;
        public IMS_LoginDal MS_LoginDal
        {
            get
            {
                if(_MS_LoginDal == null)
                {
                    _MS_LoginDal = AbstractFactory.CreateMS_LoginDal();
                }
                return _MS_LoginDal;
            }
            set { _MS_LoginDal = value; }
        }
		private IMS_MailTemplateDal _MS_MailTemplateDal;
        public IMS_MailTemplateDal MS_MailTemplateDal
        {
            get
            {
                if(_MS_MailTemplateDal == null)
                {
                    _MS_MailTemplateDal = AbstractFactory.CreateMS_MailTemplateDal();
                }
                return _MS_MailTemplateDal;
            }
            set { _MS_MailTemplateDal = value; }
        }
		private IMS_MenuDal _MS_MenuDal;
        public IMS_MenuDal MS_MenuDal
        {
            get
            {
                if(_MS_MenuDal == null)
                {
                    _MS_MenuDal = AbstractFactory.CreateMS_MenuDal();
                }
                return _MS_MenuDal;
            }
            set { _MS_MenuDal = value; }
        }
		private IMS_MenuPageRelationDal _MS_MenuPageRelationDal;
        public IMS_MenuPageRelationDal MS_MenuPageRelationDal
        {
            get
            {
                if(_MS_MenuPageRelationDal == null)
                {
                    _MS_MenuPageRelationDal = AbstractFactory.CreateMS_MenuPageRelationDal();
                }
                return _MS_MenuPageRelationDal;
            }
            set { _MS_MenuPageRelationDal = value; }
        }
		private IMS_ModuleActionDal _MS_ModuleActionDal;
        public IMS_ModuleActionDal MS_ModuleActionDal
        {
            get
            {
                if(_MS_ModuleActionDal == null)
                {
                    _MS_ModuleActionDal = AbstractFactory.CreateMS_ModuleActionDal();
                }
                return _MS_ModuleActionDal;
            }
            set { _MS_ModuleActionDal = value; }
        }
		private IMS_NewsDal _MS_NewsDal;
        public IMS_NewsDal MS_NewsDal
        {
            get
            {
                if(_MS_NewsDal == null)
                {
                    _MS_NewsDal = AbstractFactory.CreateMS_NewsDal();
                }
                return _MS_NewsDal;
            }
            set { _MS_NewsDal = value; }
        }
		private IMS_NewsClassDal _MS_NewsClassDal;
        public IMS_NewsClassDal MS_NewsClassDal
        {
            get
            {
                if(_MS_NewsClassDal == null)
                {
                    _MS_NewsClassDal = AbstractFactory.CreateMS_NewsClassDal();
                }
                return _MS_NewsClassDal;
            }
            set { _MS_NewsClassDal = value; }
        }
		private IMS_OnlineDal _MS_OnlineDal;
        public IMS_OnlineDal MS_OnlineDal
        {
            get
            {
                if(_MS_OnlineDal == null)
                {
                    _MS_OnlineDal = AbstractFactory.CreateMS_OnlineDal();
                }
                return _MS_OnlineDal;
            }
            set { _MS_OnlineDal = value; }
        }
		private IMS_OnlineMessageDal _MS_OnlineMessageDal;
        public IMS_OnlineMessageDal MS_OnlineMessageDal
        {
            get
            {
                if(_MS_OnlineMessageDal == null)
                {
                    _MS_OnlineMessageDal = AbstractFactory.CreateMS_OnlineMessageDal();
                }
                return _MS_OnlineMessageDal;
            }
            set { _MS_OnlineMessageDal = value; }
        }
		private IMS_OrderDal _MS_OrderDal;
        public IMS_OrderDal MS_OrderDal
        {
            get
            {
                if(_MS_OrderDal == null)
                {
                    _MS_OrderDal = AbstractFactory.CreateMS_OrderDal();
                }
                return _MS_OrderDal;
            }
            set { _MS_OrderDal = value; }
        }
		private IMS_OrderDetailDal _MS_OrderDetailDal;
        public IMS_OrderDetailDal MS_OrderDetailDal
        {
            get
            {
                if(_MS_OrderDetailDal == null)
                {
                    _MS_OrderDetailDal = AbstractFactory.CreateMS_OrderDetailDal();
                }
                return _MS_OrderDetailDal;
            }
            set { _MS_OrderDetailDal = value; }
        }
		private IMS_PaymentDal _MS_PaymentDal;
        public IMS_PaymentDal MS_PaymentDal
        {
            get
            {
                if(_MS_PaymentDal == null)
                {
                    _MS_PaymentDal = AbstractFactory.CreateMS_PaymentDal();
                }
                return _MS_PaymentDal;
            }
            set { _MS_PaymentDal = value; }
        }
		private IMS_ProductDal _MS_ProductDal;
        public IMS_ProductDal MS_ProductDal
        {
            get
            {
                if(_MS_ProductDal == null)
                {
                    _MS_ProductDal = AbstractFactory.CreateMS_ProductDal();
                }
                return _MS_ProductDal;
            }
            set { _MS_ProductDal = value; }
        }
		private IMS_ProductAttributeDal _MS_ProductAttributeDal;
        public IMS_ProductAttributeDal MS_ProductAttributeDal
        {
            get
            {
                if(_MS_ProductAttributeDal == null)
                {
                    _MS_ProductAttributeDal = AbstractFactory.CreateMS_ProductAttributeDal();
                }
                return _MS_ProductAttributeDal;
            }
            set { _MS_ProductAttributeDal = value; }
        }
		private IMS_ProductAttributeClassDal _MS_ProductAttributeClassDal;
        public IMS_ProductAttributeClassDal MS_ProductAttributeClassDal
        {
            get
            {
                if(_MS_ProductAttributeClassDal == null)
                {
                    _MS_ProductAttributeClassDal = AbstractFactory.CreateMS_ProductAttributeClassDal();
                }
                return _MS_ProductAttributeClassDal;
            }
            set { _MS_ProductAttributeClassDal = value; }
        }
		private IMS_ProductClassDal _MS_ProductClassDal;
        public IMS_ProductClassDal MS_ProductClassDal
        {
            get
            {
                if(_MS_ProductClassDal == null)
                {
                    _MS_ProductClassDal = AbstractFactory.CreateMS_ProductClassDal();
                }
                return _MS_ProductClassDal;
            }
            set { _MS_ProductClassDal = value; }
        }
		private IMS_ProductGoodsDal _MS_ProductGoodsDal;
        public IMS_ProductGoodsDal MS_ProductGoodsDal
        {
            get
            {
                if(_MS_ProductGoodsDal == null)
                {
                    _MS_ProductGoodsDal = AbstractFactory.CreateMS_ProductGoodsDal();
                }
                return _MS_ProductGoodsDal;
            }
            set { _MS_ProductGoodsDal = value; }
        }
		private IMS_ProductSpecDal _MS_ProductSpecDal;
        public IMS_ProductSpecDal MS_ProductSpecDal
        {
            get
            {
                if(_MS_ProductSpecDal == null)
                {
                    _MS_ProductSpecDal = AbstractFactory.CreateMS_ProductSpecDal();
                }
                return _MS_ProductSpecDal;
            }
            set { _MS_ProductSpecDal = value; }
        }
		private IMS_RecommendPositionDal _MS_RecommendPositionDal;
        public IMS_RecommendPositionDal MS_RecommendPositionDal
        {
            get
            {
                if(_MS_RecommendPositionDal == null)
                {
                    _MS_RecommendPositionDal = AbstractFactory.CreateMS_RecommendPositionDal();
                }
                return _MS_RecommendPositionDal;
            }
            set { _MS_RecommendPositionDal = value; }
        }
		private IMS_RecruitmentDal _MS_RecruitmentDal;
        public IMS_RecruitmentDal MS_RecruitmentDal
        {
            get
            {
                if(_MS_RecruitmentDal == null)
                {
                    _MS_RecruitmentDal = AbstractFactory.CreateMS_RecruitmentDal();
                }
                return _MS_RecruitmentDal;
            }
            set { _MS_RecruitmentDal = value; }
        }
		private IMS_RelationAttributeTableDal _MS_RelationAttributeTableDal;
        public IMS_RelationAttributeTableDal MS_RelationAttributeTableDal
        {
            get
            {
                if(_MS_RelationAttributeTableDal == null)
                {
                    _MS_RelationAttributeTableDal = AbstractFactory.CreateMS_RelationAttributeTableDal();
                }
                return _MS_RelationAttributeTableDal;
            }
            set { _MS_RelationAttributeTableDal = value; }
        }
		private IMS_ReWriteDal _MS_ReWriteDal;
        public IMS_ReWriteDal MS_ReWriteDal
        {
            get
            {
                if(_MS_ReWriteDal == null)
                {
                    _MS_ReWriteDal = AbstractFactory.CreateMS_ReWriteDal();
                }
                return _MS_ReWriteDal;
            }
            set { _MS_ReWriteDal = value; }
        }
		private IMS_RSSDal _MS_RSSDal;
        public IMS_RSSDal MS_RSSDal
        {
            get
            {
                if(_MS_RSSDal == null)
                {
                    _MS_RSSDal = AbstractFactory.CreateMS_RSSDal();
                }
                return _MS_RSSDal;
            }
            set { _MS_RSSDal = value; }
        }
		private IMS_SpecDal _MS_SpecDal;
        public IMS_SpecDal MS_SpecDal
        {
            get
            {
                if(_MS_SpecDal == null)
                {
                    _MS_SpecDal = AbstractFactory.CreateMS_SpecDal();
                }
                return _MS_SpecDal;
            }
            set { _MS_SpecDal = value; }
        }
		private IMS_StatDal _MS_StatDal;
        public IMS_StatDal MS_StatDal
        {
            get
            {
                if(_MS_StatDal == null)
                {
                    _MS_StatDal = AbstractFactory.CreateMS_StatDal();
                }
                return _MS_StatDal;
            }
            set { _MS_StatDal = value; }
        }
		private IMS_SurveyDal _MS_SurveyDal;
        public IMS_SurveyDal MS_SurveyDal
        {
            get
            {
                if(_MS_SurveyDal == null)
                {
                    _MS_SurveyDal = AbstractFactory.CreateMS_SurveyDal();
                }
                return _MS_SurveyDal;
            }
            set { _MS_SurveyDal = value; }
        }
		private IMS_SurveyClassDal _MS_SurveyClassDal;
        public IMS_SurveyClassDal MS_SurveyClassDal
        {
            get
            {
                if(_MS_SurveyClassDal == null)
                {
                    _MS_SurveyClassDal = AbstractFactory.CreateMS_SurveyClassDal();
                }
                return _MS_SurveyClassDal;
            }
            set { _MS_SurveyClassDal = value; }
        }
		private IMS_SurveyItemDal _MS_SurveyItemDal;
        public IMS_SurveyItemDal MS_SurveyItemDal
        {
            get
            {
                if(_MS_SurveyItemDal == null)
                {
                    _MS_SurveyItemDal = AbstractFactory.CreateMS_SurveyItemDal();
                }
                return _MS_SurveyItemDal;
            }
            set { _MS_SurveyItemDal = value; }
        }
		private IMS_SurveyOptionDal _MS_SurveyOptionDal;
        public IMS_SurveyOptionDal MS_SurveyOptionDal
        {
            get
            {
                if(_MS_SurveyOptionDal == null)
                {
                    _MS_SurveyOptionDal = AbstractFactory.CreateMS_SurveyOptionDal();
                }
                return _MS_SurveyOptionDal;
            }
            set { _MS_SurveyOptionDal = value; }
        }
		private IMS_SurveyUserDal _MS_SurveyUserDal;
        public IMS_SurveyUserDal MS_SurveyUserDal
        {
            get
            {
                if(_MS_SurveyUserDal == null)
                {
                    _MS_SurveyUserDal = AbstractFactory.CreateMS_SurveyUserDal();
                }
                return _MS_SurveyUserDal;
            }
            set { _MS_SurveyUserDal = value; }
        }
		private IMS_SurveyUserOptionDal _MS_SurveyUserOptionDal;
        public IMS_SurveyUserOptionDal MS_SurveyUserOptionDal
        {
            get
            {
                if(_MS_SurveyUserOptionDal == null)
                {
                    _MS_SurveyUserOptionDal = AbstractFactory.CreateMS_SurveyUserOptionDal();
                }
                return _MS_SurveyUserOptionDal;
            }
            set { _MS_SurveyUserOptionDal = value; }
        }
		private IMS_TagsDal _MS_TagsDal;
        public IMS_TagsDal MS_TagsDal
        {
            get
            {
                if(_MS_TagsDal == null)
                {
                    _MS_TagsDal = AbstractFactory.CreateMS_TagsDal();
                }
                return _MS_TagsDal;
            }
            set { _MS_TagsDal = value; }
        }
		private IMS_TopicDal _MS_TopicDal;
        public IMS_TopicDal MS_TopicDal
        {
            get
            {
                if(_MS_TopicDal == null)
                {
                    _MS_TopicDal = AbstractFactory.CreateMS_TopicDal();
                }
                return _MS_TopicDal;
            }
            set { _MS_TopicDal = value; }
        }
		private IMS_TopicPartDal _MS_TopicPartDal;
        public IMS_TopicPartDal MS_TopicPartDal
        {
            get
            {
                if(_MS_TopicPartDal == null)
                {
                    _MS_TopicPartDal = AbstractFactory.CreateMS_TopicPartDal();
                }
                return _MS_TopicPartDal;
            }
            set { _MS_TopicPartDal = value; }
        }
		private IMS_TopicPartContentDal _MS_TopicPartContentDal;
        public IMS_TopicPartContentDal MS_TopicPartContentDal
        {
            get
            {
                if(_MS_TopicPartContentDal == null)
                {
                    _MS_TopicPartContentDal = AbstractFactory.CreateMS_TopicPartContentDal();
                }
                return _MS_TopicPartContentDal;
            }
            set { _MS_TopicPartContentDal = value; }
        }
		private IMS_UserDal _MS_UserDal;
        public IMS_UserDal MS_UserDal
        {
            get
            {
                if(_MS_UserDal == null)
                {
                    _MS_UserDal = AbstractFactory.CreateMS_UserDal();
                }
                return _MS_UserDal;
            }
            set { _MS_UserDal = value; }
        }
		private IMS_User_OauthDal _MS_User_OauthDal;
        public IMS_User_OauthDal MS_User_OauthDal
        {
            get
            {
                if(_MS_User_OauthDal == null)
                {
                    _MS_User_OauthDal = AbstractFactory.CreateMS_User_OauthDal();
                }
                return _MS_User_OauthDal;
            }
            set { _MS_User_OauthDal = value; }
        }
		private IMS_User_Oauth_AppDal _MS_User_Oauth_AppDal;
        public IMS_User_Oauth_AppDal MS_User_Oauth_AppDal
        {
            get
            {
                if(_MS_User_Oauth_AppDal == null)
                {
                    _MS_User_Oauth_AppDal = AbstractFactory.CreateMS_User_Oauth_AppDal();
                }
                return _MS_User_Oauth_AppDal;
            }
            set { _MS_User_Oauth_AppDal = value; }
        }
		private IMS_UserAddressDal _MS_UserAddressDal;
        public IMS_UserAddressDal MS_UserAddressDal
        {
            get
            {
                if(_MS_UserAddressDal == null)
                {
                    _MS_UserAddressDal = AbstractFactory.CreateMS_UserAddressDal();
                }
                return _MS_UserAddressDal;
            }
            set { _MS_UserAddressDal = value; }
        }
		private IMS_UserFavoriteDal _MS_UserFavoriteDal;
        public IMS_UserFavoriteDal MS_UserFavoriteDal
        {
            get
            {
                if(_MS_UserFavoriteDal == null)
                {
                    _MS_UserFavoriteDal = AbstractFactory.CreateMS_UserFavoriteDal();
                }
                return _MS_UserFavoriteDal;
            }
            set { _MS_UserFavoriteDal = value; }
        }
		private IMS_UserGroupDal _MS_UserGroupDal;
        public IMS_UserGroupDal MS_UserGroupDal
        {
            get
            {
                if(_MS_UserGroupDal == null)
                {
                    _MS_UserGroupDal = AbstractFactory.CreateMS_UserGroupDal();
                }
                return _MS_UserGroupDal;
            }
            set { _MS_UserGroupDal = value; }
        }
		private IMS_UserSpreadDal _MS_UserSpreadDal;
        public IMS_UserSpreadDal MS_UserSpreadDal
        {
            get
            {
                if(_MS_UserSpreadDal == null)
                {
                    _MS_UserSpreadDal = AbstractFactory.CreateMS_UserSpreadDal();
                }
                return _MS_UserSpreadDal;
            }
            set { _MS_UserSpreadDal = value; }
        }
		private IMS_UserSpreadEffectDal _MS_UserSpreadEffectDal;
        public IMS_UserSpreadEffectDal MS_UserSpreadEffectDal
        {
            get
            {
                if(_MS_UserSpreadEffectDal == null)
                {
                    _MS_UserSpreadEffectDal = AbstractFactory.CreateMS_UserSpreadEffectDal();
                }
                return _MS_UserSpreadEffectDal;
            }
            set { _MS_UserSpreadEffectDal = value; }
        }
		private IMS_VideoDal _MS_VideoDal;
        public IMS_VideoDal MS_VideoDal
        {
            get
            {
                if(_MS_VideoDal == null)
                {
                    _MS_VideoDal = AbstractFactory.CreateMS_VideoDal();
                }
                return _MS_VideoDal;
            }
            set { _MS_VideoDal = value; }
        }
		private IMS_VideoClassDal _MS_VideoClassDal;
        public IMS_VideoClassDal MS_VideoClassDal
        {
            get
            {
                if(_MS_VideoClassDal == null)
                {
                    _MS_VideoClassDal = AbstractFactory.CreateMS_VideoClassDal();
                }
                return _MS_VideoClassDal;
            }
            set { _MS_VideoClassDal = value; }
        }
		private ISequenceNumberDal _SequenceNumberDal;
        public ISequenceNumberDal SequenceNumberDal
        {
            get
            {
                if(_SequenceNumberDal == null)
                {
                    _SequenceNumberDal = AbstractFactory.CreateSequenceNumberDal();
                }
                return _SequenceNumberDal;
            }
            set { _SequenceNumberDal = value; }
        }
		private IView_MS_ADDal _View_MS_ADDal;
        public IView_MS_ADDal View_MS_ADDal
        {
            get
            {
                if(_View_MS_ADDal == null)
                {
                    _View_MS_ADDal = AbstractFactory.CreateView_MS_ADDal();
                }
                return _View_MS_ADDal;
            }
            set { _View_MS_ADDal = value; }
        }
	}	
}