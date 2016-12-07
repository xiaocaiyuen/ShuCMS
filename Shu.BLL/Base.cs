 
using Shu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shu.BLL
{
	public partial class MS_ADBLL :BaseBLL<MS_AD>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_ADDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_ADDal;
        }
    }   
	public partial class MS_ADClassBLL :BaseBLL<MS_ADClass>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_ADClassDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_ADClassDal;
        }
    }   
	public partial class MS_AdminBLL :BaseBLL<MS_Admin>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_AdminDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_AdminDal;
        }
    }   
	public partial class MS_AdminActionBLL :BaseBLL<MS_AdminAction>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_AdminActionDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_AdminActionDal;
        }
    }   
	public partial class MS_AdminModuleBLL :BaseBLL<MS_AdminModule>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_AdminModuleDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_AdminModuleDal;
        }
    }   
	public partial class MS_AdminRoleBLL :BaseBLL<MS_AdminRole>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_AdminRoleDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_AdminRoleDal;
        }
    }   
	public partial class MS_AdminRoleMenuBLL :BaseBLL<MS_AdminRoleMenu>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_AdminRoleMenuDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_AdminRoleMenuDal;
        }
    }   
	public partial class MS_AdminRoleModuleBLL :BaseBLL<MS_AdminRoleModule>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_AdminRoleModuleDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_AdminRoleModuleDal;
        }
    }   
	public partial class MS_AdminRoleTableBLL :BaseBLL<MS_AdminRoleTable>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_AdminRoleTableDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_AdminRoleTableDal;
        }
    }   
	public partial class MS_CandidatesBLL :BaseBLL<MS_Candidates>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_CandidatesDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_CandidatesDal;
        }
    }   
	public partial class MS_ConfigBLL :BaseBLL<MS_Config>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_ConfigDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_ConfigDal;
        }
    }   
	public partial class MS_DepartmentBLL :BaseBLL<MS_Department>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_DepartmentDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_DepartmentDal;
        }
    }   
	public partial class MS_DeptBLL :BaseBLL<MS_Dept>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_DeptDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_DeptDal;
        }
    }   
	public partial class MS_DownloadBLL :BaseBLL<MS_Download>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_DownloadDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_DownloadDal;
        }
    }   
	public partial class MS_DownloadClassBLL :BaseBLL<MS_DownloadClass>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_DownloadClassDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_DownloadClassDal;
        }
    }   
	public partial class MS_ExpressBLL :BaseBLL<MS_Express>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_ExpressDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_ExpressDal;
        }
    }   
	public partial class MS_FileUrlBLL :BaseBLL<MS_FileUrl>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_FileUrlDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_FileUrlDal;
        }
    }   
	public partial class MS_JobTitleBLL :BaseBLL<MS_JobTitle>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_JobTitleDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_JobTitleDal;
        }
    }   
	public partial class MS_LinkBLL :BaseBLL<MS_Link>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_LinkDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_LinkDal;
        }
    }   
	public partial class MS_LinkClassBLL :BaseBLL<MS_LinkClass>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_LinkClassDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_LinkClassDal;
        }
    }   
	public partial class MS_LogBLL :BaseBLL<MS_Log>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_LogDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_LogDal;
        }
    }   
	public partial class MS_LoginBLL :BaseBLL<MS_Login>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_LoginDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_LoginDal;
        }
    }   
	public partial class MS_MailTemplateBLL :BaseBLL<MS_MailTemplate>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_MailTemplateDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_MailTemplateDal;
        }
    }   
	public partial class MS_MenuBLL :BaseBLL<MS_Menu>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_MenuDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_MenuDal;
        }
    }   
	public partial class MS_MenuPageRelationBLL :BaseBLL<MS_MenuPageRelation>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_MenuPageRelationDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_MenuPageRelationDal;
        }
    }   
	public partial class MS_ModuleActionBLL :BaseBLL<MS_ModuleAction>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_ModuleActionDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_ModuleActionDal;
        }
    }   
	public partial class MS_NewsBLL :BaseBLL<MS_News>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_NewsDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_NewsDal;
        }
    }   
	public partial class MS_NewsClassBLL :BaseBLL<MS_NewsClass>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_NewsClassDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_NewsClassDal;
        }
    }   
	public partial class MS_OnlineBLL :BaseBLL<MS_Online>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_OnlineDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_OnlineDal;
        }
    }   
	public partial class MS_OnlineMessageBLL :BaseBLL<MS_OnlineMessage>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_OnlineMessageDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_OnlineMessageDal;
        }
    }   
	public partial class MS_OrderBLL :BaseBLL<MS_Order>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_OrderDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_OrderDal;
        }
    }   
	public partial class MS_OrderDetailBLL :BaseBLL<MS_OrderDetail>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_OrderDetailDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_OrderDetailDal;
        }
    }   
	public partial class MS_PaymentBLL :BaseBLL<MS_Payment>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_PaymentDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_PaymentDal;
        }
    }   
	public partial class MS_ProductBLL :BaseBLL<MS_Product>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_ProductDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_ProductDal;
        }
    }   
	public partial class MS_ProductAttributeBLL :BaseBLL<MS_ProductAttribute>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_ProductAttributeDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_ProductAttributeDal;
        }
    }   
	public partial class MS_ProductAttributeClassBLL :BaseBLL<MS_ProductAttributeClass>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_ProductAttributeClassDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_ProductAttributeClassDal;
        }
    }   
	public partial class MS_ProductClassBLL :BaseBLL<MS_ProductClass>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_ProductClassDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_ProductClassDal;
        }
    }   
	public partial class MS_ProductGoodsBLL :BaseBLL<MS_ProductGoods>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_ProductGoodsDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_ProductGoodsDal;
        }
    }   
	public partial class MS_ProductSpecBLL :BaseBLL<MS_ProductSpec>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_ProductSpecDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_ProductSpecDal;
        }
    }   
	public partial class MS_RecommendPositionBLL :BaseBLL<MS_RecommendPosition>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_RecommendPositionDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_RecommendPositionDal;
        }
    }   
	public partial class MS_RecruitmentBLL :BaseBLL<MS_Recruitment>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_RecruitmentDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_RecruitmentDal;
        }
    }   
	public partial class MS_RelationAttributeTableBLL :BaseBLL<MS_RelationAttributeTable>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_RelationAttributeTableDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_RelationAttributeTableDal;
        }
    }   
	public partial class MS_ReWriteBLL :BaseBLL<MS_ReWrite>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_ReWriteDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_ReWriteDal;
        }
    }   
	public partial class MS_RSSBLL :BaseBLL<MS_RSS>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_RSSDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_RSSDal;
        }
    }   
	public partial class MS_SpecBLL :BaseBLL<MS_Spec>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_SpecDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_SpecDal;
        }
    }   
	public partial class MS_StatBLL :BaseBLL<MS_Stat>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_StatDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_StatDal;
        }
    }   
	public partial class MS_SurveyBLL :BaseBLL<MS_Survey>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_SurveyDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_SurveyDal;
        }
    }   
	public partial class MS_SurveyClassBLL :BaseBLL<MS_SurveyClass>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_SurveyClassDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_SurveyClassDal;
        }
    }   
	public partial class MS_SurveyItemBLL :BaseBLL<MS_SurveyItem>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_SurveyItemDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_SurveyItemDal;
        }
    }   
	public partial class MS_SurveyOptionBLL :BaseBLL<MS_SurveyOption>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_SurveyOptionDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_SurveyOptionDal;
        }
    }   
	public partial class MS_SurveyUserBLL :BaseBLL<MS_SurveyUser>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_SurveyUserDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_SurveyUserDal;
        }
    }   
	public partial class MS_SurveyUserOptionBLL :BaseBLL<MS_SurveyUserOption>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_SurveyUserOptionDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_SurveyUserOptionDal;
        }
    }   
	public partial class MS_TagsBLL :BaseBLL<MS_Tags>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_TagsDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_TagsDal;
        }
    }   
	public partial class MS_TopicBLL :BaseBLL<MS_Topic>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_TopicDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_TopicDal;
        }
    }   
	public partial class MS_TopicPartBLL :BaseBLL<MS_TopicPart>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_TopicPartDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_TopicPartDal;
        }
    }   
	public partial class MS_TopicPartContentBLL :BaseBLL<MS_TopicPartContent>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_TopicPartContentDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_TopicPartContentDal;
        }
    }   
	public partial class MS_UserBLL :BaseBLL<MS_User>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_UserDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_UserDal;
        }
    }   
	public partial class MS_User_OauthBLL :BaseBLL<MS_User_Oauth>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_User_OauthDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_User_OauthDal;
        }
    }   
	public partial class MS_User_Oauth_AppBLL :BaseBLL<MS_User_Oauth_App>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_User_Oauth_AppDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_User_Oauth_AppDal;
        }
    }   
	public partial class MS_UserAddressBLL :BaseBLL<MS_UserAddress>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_UserAddressDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_UserAddressDal;
        }
    }   
	public partial class MS_UserFavoriteBLL :BaseBLL<MS_UserFavorite>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_UserFavoriteDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_UserFavoriteDal;
        }
    }   
	public partial class MS_UserGroupBLL :BaseBLL<MS_UserGroup>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_UserGroupDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_UserGroupDal;
        }
    }   
	public partial class MS_UserSpreadBLL :BaseBLL<MS_UserSpread>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_UserSpreadDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_UserSpreadDal;
        }
    }   
	public partial class MS_UserSpreadEffectBLL :BaseBLL<MS_UserSpreadEffect>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_UserSpreadEffectDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_UserSpreadEffectDal;
        }
    }   
	public partial class MS_VideoBLL :BaseBLL<MS_Video>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_VideoDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_VideoDal;
        }
    }   
	public partial class MS_VideoClassBLL :BaseBLL<MS_VideoClass>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.MS_VideoClassDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.MS_VideoClassDal;
        }
    }   
	public partial class SequenceNumberBLL :BaseBLL<SequenceNumber>
    {
		public override void SetCurrentDal()
        {
            Dal = this.DBSession.SequenceNumberDal;
        }
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.SequenceNumberDal;
        }
    }   
	public partial class View_MS_ADBLL :BaseExtendsBLL<View_MS_AD>
    {
	    public override void SetExtendsCurrentDal()
        {
            DalExtends = this.DBSession.View_MS_ADDal;
        }
    }   
	
}