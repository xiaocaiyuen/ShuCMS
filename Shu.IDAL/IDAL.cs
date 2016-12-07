 
using Shu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;

namespace Shu.IDAL
{
   
	
	public partial interface IMS_ADDal :IBaseDal<MS_AD>
    {
      
    }
	
	public partial interface IMS_ADClassDal :IBaseDal<MS_ADClass>
    {
      
    }
	
	public partial interface IMS_AdminDal :IBaseDal<MS_Admin>
    {
      
    }
	
	public partial interface IMS_AdminActionDal :IBaseDal<MS_AdminAction>
    {
      
    }
	
	public partial interface IMS_AdminModuleDal :IBaseDal<MS_AdminModule>
    {
      
    }
	
	public partial interface IMS_AdminRoleDal :IBaseDal<MS_AdminRole>
    {
      
    }
	
	public partial interface IMS_AdminRoleMenuDal :IBaseDal<MS_AdminRoleMenu>
    {
      
    }
	
	public partial interface IMS_AdminRoleModuleDal :IBaseDal<MS_AdminRoleModule>
    {
      
    }
	
	public partial interface IMS_AdminRoleTableDal :IBaseDal<MS_AdminRoleTable>
    {
      
    }
	
	public partial interface IMS_CandidatesDal :IBaseDal<MS_Candidates>
    {
      
    }
	
	public partial interface IMS_ConfigDal :IBaseDal<MS_Config>
    {
      
    }
	
	public partial interface IMS_DepartmentDal :IBaseDal<MS_Department>
    {
      
    }
	
	public partial interface IMS_DeptDal :IBaseDal<MS_Dept>
    {
      
    }
	
	public partial interface IMS_DownloadDal :IBaseDal<MS_Download>
    {
      
    }
	
	public partial interface IMS_DownloadClassDal :IBaseDal<MS_DownloadClass>
    {
      
    }
	
	public partial interface IMS_ExpressDal :IBaseDal<MS_Express>
    {
      
    }
	
	public partial interface IMS_FileUrlDal :IBaseDal<MS_FileUrl>
    {
      
    }
	
	public partial interface IMS_JobTitleDal :IBaseDal<MS_JobTitle>
    {
      
    }
	
	public partial interface IMS_LinkDal :IBaseDal<MS_Link>
    {
      
    }
	
	public partial interface IMS_LinkClassDal :IBaseDal<MS_LinkClass>
    {
      
    }
	
	public partial interface IMS_LogDal :IBaseDal<MS_Log>
    {
      
    }
	
	public partial interface IMS_LoginDal :IBaseDal<MS_Login>
    {
      
    }
	
	public partial interface IMS_MailTemplateDal :IBaseDal<MS_MailTemplate>
    {
      
    }
	
	public partial interface IMS_MenuDal :IBaseDal<MS_Menu>
    {
      
    }
	
	public partial interface IMS_MenuPageRelationDal :IBaseDal<MS_MenuPageRelation>
    {
      
    }
	
	public partial interface IMS_ModuleActionDal :IBaseDal<MS_ModuleAction>
    {
      
    }
	
	public partial interface IMS_NewsDal :IBaseDal<MS_News>
    {
      
    }
	
	public partial interface IMS_NewsClassDal :IBaseDal<MS_NewsClass>
    {
      
    }
	
	public partial interface IMS_OnlineDal :IBaseDal<MS_Online>
    {
      
    }
	
	public partial interface IMS_OnlineMessageDal :IBaseDal<MS_OnlineMessage>
    {
      
    }
	
	public partial interface IMS_OrderDal :IBaseDal<MS_Order>
    {
      
    }
	
	public partial interface IMS_OrderDetailDal :IBaseDal<MS_OrderDetail>
    {
      
    }
	
	public partial interface IMS_PaymentDal :IBaseDal<MS_Payment>
    {
      
    }
	
	public partial interface IMS_ProductDal :IBaseDal<MS_Product>
    {
      
    }
	
	public partial interface IMS_ProductAttributeDal :IBaseDal<MS_ProductAttribute>
    {
      
    }
	
	public partial interface IMS_ProductAttributeClassDal :IBaseDal<MS_ProductAttributeClass>
    {
      
    }
	
	public partial interface IMS_ProductClassDal :IBaseDal<MS_ProductClass>
    {
      
    }
	
	public partial interface IMS_ProductGoodsDal :IBaseDal<MS_ProductGoods>
    {
      
    }
	
	public partial interface IMS_ProductSpecDal :IBaseDal<MS_ProductSpec>
    {
      
    }
	
	public partial interface IMS_RecommendPositionDal :IBaseDal<MS_RecommendPosition>
    {
      
    }
	
	public partial interface IMS_RecruitmentDal :IBaseDal<MS_Recruitment>
    {
      
    }
	
	public partial interface IMS_RelationAttributeTableDal :IBaseDal<MS_RelationAttributeTable>
    {
      
    }
	
	public partial interface IMS_ReWriteDal :IBaseDal<MS_ReWrite>
    {
      
    }
	
	public partial interface IMS_RSSDal :IBaseDal<MS_RSS>
    {
      
    }
	
	public partial interface IMS_SpecDal :IBaseDal<MS_Spec>
    {
      
    }
	
	public partial interface IMS_StatDal :IBaseDal<MS_Stat>
    {
      
    }
	
	public partial interface IMS_SurveyDal :IBaseDal<MS_Survey>
    {
      
    }
	
	public partial interface IMS_SurveyClassDal :IBaseDal<MS_SurveyClass>
    {
      
    }
	
	public partial interface IMS_SurveyItemDal :IBaseDal<MS_SurveyItem>
    {
      
    }
	
	public partial interface IMS_SurveyOptionDal :IBaseDal<MS_SurveyOption>
    {
      
    }
	
	public partial interface IMS_SurveyUserDal :IBaseDal<MS_SurveyUser>
    {
      
    }
	
	public partial interface IMS_SurveyUserOptionDal :IBaseDal<MS_SurveyUserOption>
    {
      
    }
	
	public partial interface IMS_TagsDal :IBaseDal<MS_Tags>
    {
      
    }
	
	public partial interface IMS_TopicDal :IBaseDal<MS_Topic>
    {
      
    }
	
	public partial interface IMS_TopicPartDal :IBaseDal<MS_TopicPart>
    {
      
    }
	
	public partial interface IMS_TopicPartContentDal :IBaseDal<MS_TopicPartContent>
    {
      
    }
	
	public partial interface IMS_UserDal :IBaseDal<MS_User>
    {
      
    }
	
	public partial interface IMS_User_OauthDal :IBaseDal<MS_User_Oauth>
    {
      
    }
	
	public partial interface IMS_User_Oauth_AppDal :IBaseDal<MS_User_Oauth_App>
    {
      
    }
	
	public partial interface IMS_UserAddressDal :IBaseDal<MS_UserAddress>
    {
      
    }
	
	public partial interface IMS_UserFavoriteDal :IBaseDal<MS_UserFavorite>
    {
      
    }
	
	public partial interface IMS_UserGroupDal :IBaseDal<MS_UserGroup>
    {
      
    }
	
	public partial interface IMS_UserSpreadDal :IBaseDal<MS_UserSpread>
    {
      
    }
	
	public partial interface IMS_UserSpreadEffectDal :IBaseDal<MS_UserSpreadEffect>
    {
      
    }
	
	public partial interface IMS_VideoDal :IBaseDal<MS_Video>
    {
      
    }
	
	public partial interface IMS_VideoClassDal :IBaseDal<MS_VideoClass>
    {
      
    }
	
	public partial interface ISequenceNumberDal :IBaseDal<SequenceNumber>
    {
      
    }
	
	public partial interface IView_MS_ADDal :IBaseExtendsDal<View_MS_AD>
    {
      
    }

	
}