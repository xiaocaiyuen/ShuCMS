 

using Shu.IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shu.Factroy
{
    public partial class AbstractFactory
    {
	    public static IMS_ADDal CreateMS_ADDal()
        {
		   string fullClassName = NameSpace + ".MS_ADDal";
           return CreateInstance(fullClassName) as IMS_ADDal;
        }
	    public static IMS_ADClassDal CreateMS_ADClassDal()
        {
		   string fullClassName = NameSpace + ".MS_ADClassDal";
           return CreateInstance(fullClassName) as IMS_ADClassDal;
        }
	    public static IMS_AdminDal CreateMS_AdminDal()
        {
		   string fullClassName = NameSpace + ".MS_AdminDal";
           return CreateInstance(fullClassName) as IMS_AdminDal;
        }
	    public static IMS_AdminActionDal CreateMS_AdminActionDal()
        {
		   string fullClassName = NameSpace + ".MS_AdminActionDal";
           return CreateInstance(fullClassName) as IMS_AdminActionDal;
        }
	    public static IMS_AdminModuleDal CreateMS_AdminModuleDal()
        {
		   string fullClassName = NameSpace + ".MS_AdminModuleDal";
           return CreateInstance(fullClassName) as IMS_AdminModuleDal;
        }
	    public static IMS_AdminRoleDal CreateMS_AdminRoleDal()
        {
		   string fullClassName = NameSpace + ".MS_AdminRoleDal";
           return CreateInstance(fullClassName) as IMS_AdminRoleDal;
        }
	    public static IMS_AdminRoleMenuDal CreateMS_AdminRoleMenuDal()
        {
		   string fullClassName = NameSpace + ".MS_AdminRoleMenuDal";
           return CreateInstance(fullClassName) as IMS_AdminRoleMenuDal;
        }
	    public static IMS_AdminRoleModuleDal CreateMS_AdminRoleModuleDal()
        {
		   string fullClassName = NameSpace + ".MS_AdminRoleModuleDal";
           return CreateInstance(fullClassName) as IMS_AdminRoleModuleDal;
        }
	    public static IMS_AdminRoleTableDal CreateMS_AdminRoleTableDal()
        {
		   string fullClassName = NameSpace + ".MS_AdminRoleTableDal";
           return CreateInstance(fullClassName) as IMS_AdminRoleTableDal;
        }
	    public static IMS_CandidatesDal CreateMS_CandidatesDal()
        {
		   string fullClassName = NameSpace + ".MS_CandidatesDal";
           return CreateInstance(fullClassName) as IMS_CandidatesDal;
        }
	    public static IMS_ConfigDal CreateMS_ConfigDal()
        {
		   string fullClassName = NameSpace + ".MS_ConfigDal";
           return CreateInstance(fullClassName) as IMS_ConfigDal;
        }
	    public static IMS_DepartmentDal CreateMS_DepartmentDal()
        {
		   string fullClassName = NameSpace + ".MS_DepartmentDal";
           return CreateInstance(fullClassName) as IMS_DepartmentDal;
        }
	    public static IMS_DeptDal CreateMS_DeptDal()
        {
		   string fullClassName = NameSpace + ".MS_DeptDal";
           return CreateInstance(fullClassName) as IMS_DeptDal;
        }
	    public static IMS_DownloadDal CreateMS_DownloadDal()
        {
		   string fullClassName = NameSpace + ".MS_DownloadDal";
           return CreateInstance(fullClassName) as IMS_DownloadDal;
        }
	    public static IMS_DownloadClassDal CreateMS_DownloadClassDal()
        {
		   string fullClassName = NameSpace + ".MS_DownloadClassDal";
           return CreateInstance(fullClassName) as IMS_DownloadClassDal;
        }
	    public static IMS_ExpressDal CreateMS_ExpressDal()
        {
		   string fullClassName = NameSpace + ".MS_ExpressDal";
           return CreateInstance(fullClassName) as IMS_ExpressDal;
        }
	    public static IMS_FileUrlDal CreateMS_FileUrlDal()
        {
		   string fullClassName = NameSpace + ".MS_FileUrlDal";
           return CreateInstance(fullClassName) as IMS_FileUrlDal;
        }
	    public static IMS_JobTitleDal CreateMS_JobTitleDal()
        {
		   string fullClassName = NameSpace + ".MS_JobTitleDal";
           return CreateInstance(fullClassName) as IMS_JobTitleDal;
        }
	    public static IMS_LinkDal CreateMS_LinkDal()
        {
		   string fullClassName = NameSpace + ".MS_LinkDal";
           return CreateInstance(fullClassName) as IMS_LinkDal;
        }
	    public static IMS_LinkClassDal CreateMS_LinkClassDal()
        {
		   string fullClassName = NameSpace + ".MS_LinkClassDal";
           return CreateInstance(fullClassName) as IMS_LinkClassDal;
        }
	    public static IMS_LogDal CreateMS_LogDal()
        {
		   string fullClassName = NameSpace + ".MS_LogDal";
           return CreateInstance(fullClassName) as IMS_LogDal;
        }
	    public static IMS_LoginDal CreateMS_LoginDal()
        {
		   string fullClassName = NameSpace + ".MS_LoginDal";
           return CreateInstance(fullClassName) as IMS_LoginDal;
        }
	    public static IMS_MailTemplateDal CreateMS_MailTemplateDal()
        {
		   string fullClassName = NameSpace + ".MS_MailTemplateDal";
           return CreateInstance(fullClassName) as IMS_MailTemplateDal;
        }
	    public static IMS_MenuDal CreateMS_MenuDal()
        {
		   string fullClassName = NameSpace + ".MS_MenuDal";
           return CreateInstance(fullClassName) as IMS_MenuDal;
        }
	    public static IMS_MenuPageRelationDal CreateMS_MenuPageRelationDal()
        {
		   string fullClassName = NameSpace + ".MS_MenuPageRelationDal";
           return CreateInstance(fullClassName) as IMS_MenuPageRelationDal;
        }
	    public static IMS_ModuleActionDal CreateMS_ModuleActionDal()
        {
		   string fullClassName = NameSpace + ".MS_ModuleActionDal";
           return CreateInstance(fullClassName) as IMS_ModuleActionDal;
        }
	    public static IMS_NewsDal CreateMS_NewsDal()
        {
		   string fullClassName = NameSpace + ".MS_NewsDal";
           return CreateInstance(fullClassName) as IMS_NewsDal;
        }
	    public static IMS_NewsClassDal CreateMS_NewsClassDal()
        {
		   string fullClassName = NameSpace + ".MS_NewsClassDal";
           return CreateInstance(fullClassName) as IMS_NewsClassDal;
        }
	    public static IMS_OnlineDal CreateMS_OnlineDal()
        {
		   string fullClassName = NameSpace + ".MS_OnlineDal";
           return CreateInstance(fullClassName) as IMS_OnlineDal;
        }
	    public static IMS_OnlineMessageDal CreateMS_OnlineMessageDal()
        {
		   string fullClassName = NameSpace + ".MS_OnlineMessageDal";
           return CreateInstance(fullClassName) as IMS_OnlineMessageDal;
        }
	    public static IMS_OrderDal CreateMS_OrderDal()
        {
		   string fullClassName = NameSpace + ".MS_OrderDal";
           return CreateInstance(fullClassName) as IMS_OrderDal;
        }
	    public static IMS_OrderDetailDal CreateMS_OrderDetailDal()
        {
		   string fullClassName = NameSpace + ".MS_OrderDetailDal";
           return CreateInstance(fullClassName) as IMS_OrderDetailDal;
        }
	    public static IMS_PaymentDal CreateMS_PaymentDal()
        {
		   string fullClassName = NameSpace + ".MS_PaymentDal";
           return CreateInstance(fullClassName) as IMS_PaymentDal;
        }
	    public static IMS_ProductDal CreateMS_ProductDal()
        {
		   string fullClassName = NameSpace + ".MS_ProductDal";
           return CreateInstance(fullClassName) as IMS_ProductDal;
        }
	    public static IMS_ProductAttributeDal CreateMS_ProductAttributeDal()
        {
		   string fullClassName = NameSpace + ".MS_ProductAttributeDal";
           return CreateInstance(fullClassName) as IMS_ProductAttributeDal;
        }
	    public static IMS_ProductAttributeClassDal CreateMS_ProductAttributeClassDal()
        {
		   string fullClassName = NameSpace + ".MS_ProductAttributeClassDal";
           return CreateInstance(fullClassName) as IMS_ProductAttributeClassDal;
        }
	    public static IMS_ProductClassDal CreateMS_ProductClassDal()
        {
		   string fullClassName = NameSpace + ".MS_ProductClassDal";
           return CreateInstance(fullClassName) as IMS_ProductClassDal;
        }
	    public static IMS_ProductGoodsDal CreateMS_ProductGoodsDal()
        {
		   string fullClassName = NameSpace + ".MS_ProductGoodsDal";
           return CreateInstance(fullClassName) as IMS_ProductGoodsDal;
        }
	    public static IMS_ProductSpecDal CreateMS_ProductSpecDal()
        {
		   string fullClassName = NameSpace + ".MS_ProductSpecDal";
           return CreateInstance(fullClassName) as IMS_ProductSpecDal;
        }
	    public static IMS_RecommendPositionDal CreateMS_RecommendPositionDal()
        {
		   string fullClassName = NameSpace + ".MS_RecommendPositionDal";
           return CreateInstance(fullClassName) as IMS_RecommendPositionDal;
        }
	    public static IMS_RecruitmentDal CreateMS_RecruitmentDal()
        {
		   string fullClassName = NameSpace + ".MS_RecruitmentDal";
           return CreateInstance(fullClassName) as IMS_RecruitmentDal;
        }
	    public static IMS_RelationAttributeTableDal CreateMS_RelationAttributeTableDal()
        {
		   string fullClassName = NameSpace + ".MS_RelationAttributeTableDal";
           return CreateInstance(fullClassName) as IMS_RelationAttributeTableDal;
        }
	    public static IMS_ReWriteDal CreateMS_ReWriteDal()
        {
		   string fullClassName = NameSpace + ".MS_ReWriteDal";
           return CreateInstance(fullClassName) as IMS_ReWriteDal;
        }
	    public static IMS_RSSDal CreateMS_RSSDal()
        {
		   string fullClassName = NameSpace + ".MS_RSSDal";
           return CreateInstance(fullClassName) as IMS_RSSDal;
        }
	    public static IMS_SpecDal CreateMS_SpecDal()
        {
		   string fullClassName = NameSpace + ".MS_SpecDal";
           return CreateInstance(fullClassName) as IMS_SpecDal;
        }
	    public static IMS_StatDal CreateMS_StatDal()
        {
		   string fullClassName = NameSpace + ".MS_StatDal";
           return CreateInstance(fullClassName) as IMS_StatDal;
        }
	    public static IMS_SurveyDal CreateMS_SurveyDal()
        {
		   string fullClassName = NameSpace + ".MS_SurveyDal";
           return CreateInstance(fullClassName) as IMS_SurveyDal;
        }
	    public static IMS_SurveyClassDal CreateMS_SurveyClassDal()
        {
		   string fullClassName = NameSpace + ".MS_SurveyClassDal";
           return CreateInstance(fullClassName) as IMS_SurveyClassDal;
        }
	    public static IMS_SurveyItemDal CreateMS_SurveyItemDal()
        {
		   string fullClassName = NameSpace + ".MS_SurveyItemDal";
           return CreateInstance(fullClassName) as IMS_SurveyItemDal;
        }
	    public static IMS_SurveyOptionDal CreateMS_SurveyOptionDal()
        {
		   string fullClassName = NameSpace + ".MS_SurveyOptionDal";
           return CreateInstance(fullClassName) as IMS_SurveyOptionDal;
        }
	    public static IMS_SurveyUserDal CreateMS_SurveyUserDal()
        {
		   string fullClassName = NameSpace + ".MS_SurveyUserDal";
           return CreateInstance(fullClassName) as IMS_SurveyUserDal;
        }
	    public static IMS_SurveyUserOptionDal CreateMS_SurveyUserOptionDal()
        {
		   string fullClassName = NameSpace + ".MS_SurveyUserOptionDal";
           return CreateInstance(fullClassName) as IMS_SurveyUserOptionDal;
        }
	    public static IMS_TagsDal CreateMS_TagsDal()
        {
		   string fullClassName = NameSpace + ".MS_TagsDal";
           return CreateInstance(fullClassName) as IMS_TagsDal;
        }
	    public static IMS_TopicDal CreateMS_TopicDal()
        {
		   string fullClassName = NameSpace + ".MS_TopicDal";
           return CreateInstance(fullClassName) as IMS_TopicDal;
        }
	    public static IMS_TopicPartDal CreateMS_TopicPartDal()
        {
		   string fullClassName = NameSpace + ".MS_TopicPartDal";
           return CreateInstance(fullClassName) as IMS_TopicPartDal;
        }
	    public static IMS_TopicPartContentDal CreateMS_TopicPartContentDal()
        {
		   string fullClassName = NameSpace + ".MS_TopicPartContentDal";
           return CreateInstance(fullClassName) as IMS_TopicPartContentDal;
        }
	    public static IMS_UserDal CreateMS_UserDal()
        {
		   string fullClassName = NameSpace + ".MS_UserDal";
           return CreateInstance(fullClassName) as IMS_UserDal;
        }
	    public static IMS_User_OauthDal CreateMS_User_OauthDal()
        {
		   string fullClassName = NameSpace + ".MS_User_OauthDal";
           return CreateInstance(fullClassName) as IMS_User_OauthDal;
        }
	    public static IMS_User_Oauth_AppDal CreateMS_User_Oauth_AppDal()
        {
		   string fullClassName = NameSpace + ".MS_User_Oauth_AppDal";
           return CreateInstance(fullClassName) as IMS_User_Oauth_AppDal;
        }
	    public static IMS_UserAddressDal CreateMS_UserAddressDal()
        {
		   string fullClassName = NameSpace + ".MS_UserAddressDal";
           return CreateInstance(fullClassName) as IMS_UserAddressDal;
        }
	    public static IMS_UserFavoriteDal CreateMS_UserFavoriteDal()
        {
		   string fullClassName = NameSpace + ".MS_UserFavoriteDal";
           return CreateInstance(fullClassName) as IMS_UserFavoriteDal;
        }
	    public static IMS_UserGroupDal CreateMS_UserGroupDal()
        {
		   string fullClassName = NameSpace + ".MS_UserGroupDal";
           return CreateInstance(fullClassName) as IMS_UserGroupDal;
        }
	    public static IMS_UserSpreadDal CreateMS_UserSpreadDal()
        {
		   string fullClassName = NameSpace + ".MS_UserSpreadDal";
           return CreateInstance(fullClassName) as IMS_UserSpreadDal;
        }
	    public static IMS_UserSpreadEffectDal CreateMS_UserSpreadEffectDal()
        {
		   string fullClassName = NameSpace + ".MS_UserSpreadEffectDal";
           return CreateInstance(fullClassName) as IMS_UserSpreadEffectDal;
        }
	    public static IMS_VideoDal CreateMS_VideoDal()
        {
		   string fullClassName = NameSpace + ".MS_VideoDal";
           return CreateInstance(fullClassName) as IMS_VideoDal;
        }
	    public static IMS_VideoClassDal CreateMS_VideoClassDal()
        {
		   string fullClassName = NameSpace + ".MS_VideoClassDal";
           return CreateInstance(fullClassName) as IMS_VideoClassDal;
        }
	    public static ISequenceNumberDal CreateSequenceNumberDal()
        {
		   string fullClassName = NameSpace + ".SequenceNumberDal";
           return CreateInstance(fullClassName) as ISequenceNumberDal;
        }
	    public static IView_MS_ADDal CreateView_MS_ADDal()
        {
		   string fullClassName = NameSpace + ".View_MS_ADDal";
           return CreateInstance(fullClassName) as IView_MS_ADDal;
        }
	}
	
}