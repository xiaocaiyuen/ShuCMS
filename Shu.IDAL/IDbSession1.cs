 

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shu.IDAL
{
	public partial interface IDBSession
    {
		IMS_ADDal MS_ADDal{get;set;}
		IMS_ADClassDal MS_ADClassDal{get;set;}
		IMS_AdminDal MS_AdminDal{get;set;}
		IMS_AdminActionDal MS_AdminActionDal{get;set;}
		IMS_AdminModuleDal MS_AdminModuleDal{get;set;}
		IMS_AdminRoleDal MS_AdminRoleDal{get;set;}
		IMS_AdminRoleMenuDal MS_AdminRoleMenuDal{get;set;}
		IMS_AdminRoleModuleDal MS_AdminRoleModuleDal{get;set;}
		IMS_AdminRoleTableDal MS_AdminRoleTableDal{get;set;}
		IMS_CandidatesDal MS_CandidatesDal{get;set;}
		IMS_ConfigDal MS_ConfigDal{get;set;}
		IMS_DepartmentDal MS_DepartmentDal{get;set;}
		IMS_DeptDal MS_DeptDal{get;set;}
		IMS_DownloadDal MS_DownloadDal{get;set;}
		IMS_DownloadClassDal MS_DownloadClassDal{get;set;}
		IMS_ExpressDal MS_ExpressDal{get;set;}
		IMS_FileUrlDal MS_FileUrlDal{get;set;}
		IMS_JobTitleDal MS_JobTitleDal{get;set;}
		IMS_LinkDal MS_LinkDal{get;set;}
		IMS_LinkClassDal MS_LinkClassDal{get;set;}
		IMS_LogDal MS_LogDal{get;set;}
		IMS_LoginDal MS_LoginDal{get;set;}
		IMS_MailTemplateDal MS_MailTemplateDal{get;set;}
		IMS_MenuDal MS_MenuDal{get;set;}
		IMS_MenuPageRelationDal MS_MenuPageRelationDal{get;set;}
		IMS_ModuleActionDal MS_ModuleActionDal{get;set;}
		IMS_NewsDal MS_NewsDal{get;set;}
		IMS_NewsClassDal MS_NewsClassDal{get;set;}
		IMS_OnlineDal MS_OnlineDal{get;set;}
		IMS_OnlineMessageDal MS_OnlineMessageDal{get;set;}
		IMS_OrderDal MS_OrderDal{get;set;}
		IMS_OrderDetailDal MS_OrderDetailDal{get;set;}
		IMS_PaymentDal MS_PaymentDal{get;set;}
		IMS_ProductDal MS_ProductDal{get;set;}
		IMS_ProductAttributeDal MS_ProductAttributeDal{get;set;}
		IMS_ProductAttributeClassDal MS_ProductAttributeClassDal{get;set;}
		IMS_ProductClassDal MS_ProductClassDal{get;set;}
		IMS_ProductGoodsDal MS_ProductGoodsDal{get;set;}
		IMS_ProductSpecDal MS_ProductSpecDal{get;set;}
		IMS_RecommendPositionDal MS_RecommendPositionDal{get;set;}
		IMS_RecruitmentDal MS_RecruitmentDal{get;set;}
		IMS_RelationAttributeTableDal MS_RelationAttributeTableDal{get;set;}
		IMS_ReWriteDal MS_ReWriteDal{get;set;}
		IMS_RSSDal MS_RSSDal{get;set;}
		IMS_SpecDal MS_SpecDal{get;set;}
		IMS_StatDal MS_StatDal{get;set;}
		IMS_SurveyDal MS_SurveyDal{get;set;}
		IMS_SurveyClassDal MS_SurveyClassDal{get;set;}
		IMS_SurveyItemDal MS_SurveyItemDal{get;set;}
		IMS_SurveyOptionDal MS_SurveyOptionDal{get;set;}
		IMS_SurveyUserDal MS_SurveyUserDal{get;set;}
		IMS_SurveyUserOptionDal MS_SurveyUserOptionDal{get;set;}
		IMS_TagsDal MS_TagsDal{get;set;}
		IMS_TopicDal MS_TopicDal{get;set;}
		IMS_TopicPartDal MS_TopicPartDal{get;set;}
		IMS_TopicPartContentDal MS_TopicPartContentDal{get;set;}
		IMS_UserDal MS_UserDal{get;set;}
		IMS_User_OauthDal MS_User_OauthDal{get;set;}
		IMS_User_Oauth_AppDal MS_User_Oauth_AppDal{get;set;}
		IMS_UserAddressDal MS_UserAddressDal{get;set;}
		IMS_UserFavoriteDal MS_UserFavoriteDal{get;set;}
		IMS_UserGroupDal MS_UserGroupDal{get;set;}
		IMS_UserSpreadDal MS_UserSpreadDal{get;set;}
		IMS_UserSpreadEffectDal MS_UserSpreadEffectDal{get;set;}
		IMS_VideoDal MS_VideoDal{get;set;}
		IMS_VideoClassDal MS_VideoClassDal{get;set;}
		ISequenceNumberDal SequenceNumberDal{get;set;}
		IView_MS_ADDal View_MS_ADDal{get;set;}
	}	
}