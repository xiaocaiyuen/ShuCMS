<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Shu.Manage._default" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>FineUI（开源版）在线示例 - 基于 ExtJS 的开源 ASP.NET 控件库</title>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" />
    <meta name="Title" content="基于 ExtJS 的开源 ASP.NET 控件库(ExtJS based open source ASP.NET Controls)" />
    <meta name="Description" content="FineUI 的使命是创建 No JavaScript，No CSS，No UpdatePanel，No ViewState，No WebServices 的网站应用程序" />
    <meta name="Keywords" content="开源,ASP.NET,控件库,ExtJS,AJAX,Web2.0" />
    <link type="text/css" rel="stylesheet" href="~/res/css/default.css" />
</head>
<body>
    <form id="form1" runat="server">
        <ext:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server"></ext:PageManager>
        <ext:RegionPanel ID="RegionPanel1" ShowBorder="false" runat="server">
            <Regions>
                <ext:Region ID="Region1" ShowBorder="false" ShowHeader="false"
                    Position="Top" Layout="Fit" runat="server">
                    <Content>
                        <div id="header">
                            <table>
                                <tr>
                                    <td>
                                        <a class="homepage" href="http://fineui.com/" title="官网首页">
                                            <img src="./res/icon/house.png" alt="Home" />
                                        </a>
                                        <a class="logo" href="./default.aspx" title="在线示例首页">FineUI（开源版）在线示例
                                        </a>
                                    </td>
                                    <td style="text-align: right;">
                                        <ext:Button runat="server" CssClass="" Text="专业版示例" IconAlign="Top" Icon="ThumbUp"
                                            EnablePostBack="false" OnClientClick="window.location.href='http://fineui.com/demo_pro';">
                                        </ext:Button>
                                        <ext:Button runat="server" CssClass="" Text="加载动画" IconAlign="Top" Icon="Hourglass"
                                            EnablePostBack="false">
                                            <Listeners>
                                                <ext:Listener Event="click" Handler="onLoadingSelectClick" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button runat="server" CssClass="userpicaction" Text="三生石上" IconUrl="~/res/images/my_face_80.jpg" IconAlign="Left"
                                            EnablePostBack="false">
                                            <Menu runat="server">
                                                <ext:MenuButton Text="个人信息" Icon="User" EnablePostBack="false" runat="server">
                                                    <Listeners>
                                                        <ext:Listener Event="click" Handler="onUserProfileClick" />
                                                    </Listeners>
                                                </ext:MenuButton>
                                                <ext:MenuSeparator runat="server"></ext:MenuSeparator>
                                                <ext:MenuButton Text="安全退出" Icon="ZoomOut" EnablePostBack="false" runat="server">
                                                    <Listeners>
                                                        <ext:Listener Event="click" Handler="onSignOutClick" />
                                                    </Listeners>
                                                </ext:MenuButton>
                                            </Menu>
                                        </ext:Button>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </Content>
                </ext:Region>
                <ext:Region ID="leftPanel" RegionSplit="true" Width="220px" ShowHeader="true" ShowBorder="true" Title="全部示例"
                    EnableCollapse="true" Layout="Fit" Collapsed="false" RegionPosition="Left" runat="server">
                </ext:Region>
                <ext:Region ID="mainRegion" ShowHeader="false" Layout="Fit" ShowBorder="true" Position="Center"
                    runat="server">
                    <Items>
                        <ext:TabStrip ID="mainTabStrip" EnableTabCloseMenu="true" ShowBorder="false" runat="server">
                            <Tabs>
                                <ext:Tab Title="首页" Layout="Fit" Icon="House" CssClass="maincontent" runat="server">
                                    <Toolbars>
                                        <ext:Toolbar runat="server">
                                            <Items>
                                                <ext:ToolbarFill ID="ToolbarFill2" runat="server">
                                                </ext:ToolbarFill>
                                                <ext:Button ID="btnGotoOpenSourceSite" Icon="DiskDownload" Text="下载全部源码" OnClientClick="window.open('http://fineui.codeplex.com/', '_blank');"
                                                    EnablePostBack="false" runat="server">
                                                </ext:Button>
                                                <ext:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                                                </ext:ToolbarSeparator>
                                                <ext:Button ID="Button1" Icon="PageGo" Text="论坛交流" OnClientClick="window.open('http://fineui.com/bbs/', '_blank');"
                                                    EnablePostBack="false" runat="server">
                                                </ext:Button>
                                            </Items>
                                        </ext:Toolbar>
                                    </Toolbars>
                                    <Items>
                                        <ext:ContentPanel ShowBorder="false" BodyPadding="10px" ShowHeader="false" AutoScroll="true"
                                            runat="server">
                                            <h2>FineUI（开源版）</h2>
                                            基于 ExtJS 的开源 ASP.NET 控件库
                                        
                                            <br />
                                            <h2>FineUI的使命</h2>
                                            创建 No JavaScript，No CSS，No UpdatePanel，No ViewState，No WebServices 的网站应用程序
                                        
                                            <br />
                                            <h2>支持的浏览器</h2>
                                            Chrome、Firefox、Safari、IE 8.0+
                                        
                                            <br />
                                            <h2>授权协议</h2>
                                            Apache License v2.0（ExtJS 库在 <a target="_blank" href="http://www.sencha.com/license">GPL v3</a> 协议下发布）
                                            
                                            <br />
                                            <h2>相关链接</h2>
                                            首页：<a target="_blank" href="http://fineui.com/">http://fineui.com/</a>
                                            <br />
                                            论坛：<a target="_blank" href="http://fineui.com/bbs/">http://fineui.com/bbs/</a>
                                            <br />
                                            示例：<a target="_blank" href="http://fineui.com/demo/">http://fineui.com/demo/</a>
                                            <br />
                                            文档：<a target="_blank" href="http://fineui.com/doc/">http://fineui.com/doc/</a>
                                            <br />
                                            下载：<a target="_blank" href="http://fineui.codeplex.com/">http://fineui.codeplex.com/</a>
                                            <br />
                                            <br />
                                            <br />
                                            注：FineUI 不再内置 ExtJS 库，请手工添加 ExtJS 库：<a target="_blank" href="http://fineui.com/bbs/forum.php?mod=viewthread&tid=3218">http://fineui.com/bbs/forum.php?mod=viewthread&tid=3218</a>


                                            <div style="position: fixed; bottom: 30px; right: 10px; text-align: center; border: solid 1px #ddd; padding: 10px; background-color: #efefef;">
                                                <div style="margin-bottom: 5px;">
                                                    扫描二维码，关注 FineUI 微信公众号
                                                </div>
                                                <img src="http://fineui.com/images/weixin_fineui.jpg" style="width: 150px;" alert="关注 FineUI 微信公众号">
                                            </div>
                                        </ext:ContentPanel>
                                    </Items>
                                </ext:Tab>
                            </Tabs>
                        </ext:TabStrip>
                    </Items>
                </ext:Region>
                <ext:Region ID="bottomPanel" RegionPosition="Bottom" ShowBorder="false" ShowHeader="false" EnableCollapse="false" runat="server" Layout="Fit">
                    <Items>
                        <ext:ContentPanel runat="server" ShowBorder="false" ShowHeader="false">
                            <table class="bottomtable">
                                <tr>
                                    <td style="width: 300px;">&nbsp;版本：<a target="_blank" href="http://fineui.com/version">v<asp:Literal runat="server" ID="litVersion"></asp:Literal></a>
                                        &nbsp;&nbsp; <a target="_blank" href="http://wp.qq.com/wpa/qunwpa?idkey=5a98eb42b742a1edaf22826648d5f61bc16ed08e0253976bc8d30f97508c09c7">QQ公开群</a></td>
                                    <td style="text-align: center;">Copyright &copy; 2008-2016 合肥三生石上软件有限公司</td>
                                    <td style="width: 300px; text-align: right;">在线人数：<asp:Literal runat="server" ID="litOnlineUserCount"></asp:Literal>&nbsp;</td>
                                </tr>
                            </table>
                        </ext:ContentPanel>
                    </Items>
                </ext:Region>
            </Regions>
        </ext:RegionPanel>
        <ext:Window ID="windowSourceCode" Icon="PageWhiteCode" Title="源代码" Hidden="true" EnableIFrame="true"
            runat="server" IsModal="true" Width="950px" Height="550px" EnableClose="true"
            EnableMaximize="true" EnableResize="true">
        </ext:Window>
        <ext:Window ID="windowLoadingSelector" Title="加载动画" Hidden="true" EnableIFrame="true" IFrameUrl="./common/loading.aspx"
            runat="server" IsModal="true" Width="1000px" Height="625px" EnableClose="true"
            EnableMaximize="true" EnableResize="true">
        </ext:Window>
        <ext:Menu ID="menuSettings" runat="server">
            <ext:MenuButton ID="btnExpandAll" IconUrl="~/res/images/expand-all.gif" Text="展开菜单" EnablePostBack="false"
                runat="server">
            </ext:MenuButton>
            <ext:MenuButton ID="btnCollapseAll" IconUrl="~/res/images/collapse-all.gif" Text="折叠菜单"
                EnablePostBack="false" runat="server">
            </ext:MenuButton>
            <ext:MenuSeparator ID="MenuSeparator4" runat="server">
            </ext:MenuSeparator>
            <ext:MenuCheckBox runat="server" ID="cbxShowOnlyNew" Text="仅显示最新示例">
            </ext:MenuCheckBox>
            <ext:MenuSeparator ID="MenuSeparator1" runat="server">
            </ext:MenuSeparator>
            <ext:MenuButton ID="MenuTheme" EnablePostBack="false" Text="主题" runat="server">
                <Menu ID="Menu4" runat="server">
                    <ext:MenuCheckBox Text="海卫一（Triton）" ID="MenuThemeTriton" Checked="true" GroupName="MenuTheme" runat="server">
                    </ext:MenuCheckBox>
                    <ext:MenuCheckBox Text="小清新（Crisp）" ID="MenuThemeCrisp" GroupName="MenuTheme" runat="server">
                    </ext:MenuCheckBox>
                    <ext:MenuCheckBox Text="海王星（Neptune）" ID="MenuThemeNeptune" GroupName="MenuTheme" runat="server">
                    </ext:MenuCheckBox>
                    <ext:MenuCheckBox Text="蓝色（Blue）" ID="MenuThemeBlue" GroupName="MenuTheme" runat="server">
                    </ext:MenuCheckBox>
                    <ext:MenuCheckBox Text="灰色（Gray）" ID="MenuThemeGray" GroupName="MenuTheme" runat="server">
                    </ext:MenuCheckBox>
                </Menu>
            </ext:MenuButton>
            <ext:MenuButton EnablePostBack="false" Text="菜单样式" ID="MenuStyle" runat="server">
                <Menu runat="server">
                    <ext:MenuCheckBox Text="树菜单" ID="MenuStyleTree" Checked="true" GroupName="MenuStyle" runat="server">
                    </ext:MenuCheckBox>
                    <ext:MenuCheckBox Text="手风琴+树菜单" ID="MenuStyleAccordion" GroupName="MenuStyle" runat="server">
                    </ext:MenuCheckBox>
                </Menu>
            </ext:MenuButton>
            <ext:MenuButton EnablePostBack="false" Text="语言" ID="MenuLang" runat="server">
                <Menu ID="Menu2" runat="server">
                    <ext:MenuCheckBox Text="简体中文" ID="MenuLangZHCN" Checked="true" GroupName="MenuLang" runat="server">
                    </ext:MenuCheckBox>
                    <ext:MenuCheckBox Text="繁體中文" ID="MenuLangZHTW" GroupName="MenuLang" runat="server">
                    </ext:MenuCheckBox>
                    <ext:MenuCheckBox Text="English" ID="MenuLangEN" GroupName="MenuLang" runat="server">
                    </ext:MenuCheckBox>
                </Menu>
            </ext:MenuButton>
            <ext:MenuSeparator ID="MenuSeparator2" runat="server">
            </ext:MenuSeparator>
            <ext:MenuButton Text="FineUI（开源版）示例" runat="server">
                <Menu runat="server">
                    <ext:MenuHyperLink ID="MenuHyperLink4" runat="server" Text="v4.x 示例" NavigateUrl="http://fineui.com/demo_v4/" Target="_blank">
                    </ext:MenuHyperLink>
                    <ext:MenuHyperLink ID="MenuHyperLink2" runat="server" Text="v3.x 示例" NavigateUrl="http://fineui.com/demo_v3/" Target="_blank">
                    </ext:MenuHyperLink>
                    <ext:MenuHyperLink ID="MenuHyperLink1" runat="server" Text="v3.x 示例（英文）" NavigateUrl="http://fineui.com/demo_en/" Target="_blank">
                    </ext:MenuHyperLink>
                </Menu>
            </ext:MenuButton>
            <ext:MenuHyperLink ID="MenuHyperLink3" runat="server" Text="FineUI（专业版）示例" NavigateUrl="http://fineui.com/demo_pro/" Target="_blank">
            </ext:MenuHyperLink>
        </ext:Menu>
        <asp:XmlDataSource ID="XmlDataSource1" runat="server" EnableCaching="false" DataFile="~/common/menu.xml"></asp:XmlDataSource>
    </form>
    <script src="./res/js/jquery.min.js"></script>
    <script>

        var btnExpandAllClientID = '<%= btnExpandAll.ClientID %>';
        var btnCollapseAllClientID = '<%= btnCollapseAll.ClientID %>';
        var leftPanelClientID = '<%= leftPanel.ClientID %>';
        var mainTabStripClientID = '<%= mainTabStrip.ClientID %>';
        var windowSourceCodeClientID = '<%= windowSourceCode.ClientID %>';
        var menuSettingsClientID = '<%= menuSettings.ClientID %>';
        var cbxShowOnlyNewClientID = '<%= cbxShowOnlyNew.ClientID %>';
        var windowLoadingSelectorClientID = '<%= windowLoadingSelector.ClientID %>';

        var MenuStyleClientID = '<%= MenuStyle.ClientID %>';
        var MenuLangClientID = '<%= MenuLang.ClientID %>';
        var MenuThemeClientID = '<%= MenuTheme.ClientID %>';


        // 点击加载动画
        function onLoadingSelectClick(event) {
            var windowLoadingSelector = F(windowLoadingSelectorClientID);
            windowLoadingSelector.f_show();
        }


        function onSignOutClick() {
            F.alert('尚未实现');
        }

        function onUserProfileClick() {
            F.alert('尚未实现');
        }


        F.ready(function () {
            var btnExpandAll = F(btnExpandAllClientID);
            var btnCollapseAll = F(btnCollapseAllClientID);
            var leftPanel = F(leftPanelClientID);
            var mainTabStrip = F(mainTabStripClientID);
            var windowSourceCode = F(windowSourceCodeClientID);
            var menuSettings = F(menuSettingsClientID);
            var cbxShowOnlyNew = F(cbxShowOnlyNewClientID);

            var MenuStyle = F(MenuStyleClientID);
            var MenuLang = F(MenuLangClientID);
            var MenuTheme = F(MenuThemeClientID);

            var treeMenu = leftPanel.items.getAt(0);
            var menuType = 'accordion';
            if (treeMenu.isXType('treepanel')) {
                menuType = 'menu';
            }

            // 当前展开的手风琴面板
            function getExpandedPanel() {
                var panel = null;
                treeMenu.items.each(function (item) {
                    if (!item.getCollapsed()) {
                        panel = item;
                    }
                });
                return panel;
            }

            // 点击展开菜单
            btnExpandAll.on('click', function () {
                if (menuType == 'menu') {
                    // 左侧为树控件
                    treeMenu.expandAll();
                } else {
                    // 左侧为树控件+手风琴控件
                    var expandedPanel = getExpandedPanel();
                    if (expandedPanel) {
                        expandedPanel.items.getAt(0).expandAll();
                    }
                }
            });

            // 点击折叠菜单
            btnCollapseAll.on('click', function () {
                if (menuType == 'menu') {
                    // 左侧为树控件
                    treeMenu.collapseAll();
                } else {
                    // 左侧为树控件+手风琴控件
                    var expandedPanel = getExpandedPanel();
                    if (expandedPanel) {
                        expandedPanel.items.getAt(0).collapseAll();
                    }
                }
            });

            // 点击仅显示最新示例
            cbxShowOnlyNew.on('click', function () {
                var checked = this.checked;
                if (checked) {
                    F.cookie('ShowOnlyNew_v6', checked, {
                        expires: 100 // 单位：天
                    });
                } else {
                    F.removeCookie('ShowOnlyNew_v6');
                }
                top.window.location.reload();
            });

            // 点击菜单样式
            function MenuStyleItemCheckChange(cmp, checked) {
                if (checked) {
                    var menuStyle = 'accordion';
                    if (cmp.id.indexOf('MenuStyleTree') >= 0) {
                        menuStyle = 'tree';
                    }
                    F.cookie('MenuStyle_v6', menuStyle, {
                        expires: 100 // 单位：天
                    });
                    top.window.location.reload();
                }
            }
            MenuStyle.menu.items.each(function (item, index) {
                item.on('checkchange', MenuStyleItemCheckChange);
            });


            // 切换语言
            function MenuLangItemCheckChange(cmp, checked) {
                if (checked) {
                    var lang = 'en';
                    if (cmp.id.indexOf('MenuLangZHCN') >= 0) {
                        lang = 'zh_CN';
                    } else if (cmp.id.indexOf('MenuLangZHTW') >= 0) {
                        lang = 'zh_TW';
                    }

                    F.cookie('Language_v6', lang, {
                        expires: 100 // 单位：天
                    });
                    top.window.location.reload();
                }
            }
            MenuLang.menu.items.each(function (item, index) {
                item.on('checkchange', MenuLangItemCheckChange);
            });


            // 切换主题
            function MenuThemeItemCheckChange(cmp, checked) {
                if (checked) {
                    var lang = 'neptune';
                    if (cmp.id.indexOf('MenuThemeBlue') >= 0) {
                        lang = 'blue';
                    } else if (cmp.id.indexOf('MenuThemeGray') >= 0) {
                        lang = 'gray';
                    } else if (cmp.id.indexOf('MenuThemeCrisp') >= 0) {
                        lang = 'crisp';
                    } else if (cmp.id.indexOf('MenuThemeTriton') >= 0) {
                        lang = 'triton';
                    }

                    F.cookie('Theme_v6', lang, {
                        expires: 100 // 单位：天
                    });
                    top.window.location.reload();
                }
            }
            MenuTheme.menu.items.each(function (item, index) {
                item.on('checkchange', MenuThemeItemCheckChange);
            });


            function createToolbar(tabConfig) {

                // 由工具栏上按钮获得当前标签页中的iframe节点
                function getCurrentIFrameNode(btn) {
                    return $('#' + btn.id).parents('.f-tab').find('iframe');
                }

                var sourcecodeButton = new Ext.Button({
                    text: '源代码',
                    type: 'button',
                    icon: './res/icon/page_white_code.png',
                    listeners: {
                        click: function () {
                            var iframeNode = getCurrentIFrameNode(this);
                            var iframeWnd = iframeNode[0].contentWindow

                            var files = [iframeNode.attr('src')];
                            var sourcefilesNode = $(iframeWnd.document).find('head meta[name=sourcefiles]');
                            if (sourcefilesNode.length) {
                                $.merge(files, sourcefilesNode.attr('content').split(';'));
                            }
                            windowSourceCode.f_show('./common/source.aspx?files=' + encodeURIComponent(files.join(';')));
                        }
                    }
                });

                var openNewWindowButton = new Ext.Button({
                    text: '新标签页中打开',
                    type: 'button',
                    icon: './res/icon/tab_go.png',
                    listeners: {
                        click: function () {
                            var iframeNode = getCurrentIFrameNode(this);
                            window.open(iframeNode.attr('src'), '_blank');
                        }
                    }
                });

                var refreshButton = new Ext.Button({
                    text: '刷新',
                    type: 'button',
                    icon: './res/icon/reload.png',
                    listeners: {
                        click: function () {
                            var iframeNode = getCurrentIFrameNode(this);
                            iframeNode[0].contentWindow.location.reload();
                        }
                    }
                });

                var toolbar = new Ext.Toolbar({
                    items: ['->', sourcecodeButton, '-', refreshButton, '-', openNewWindowButton]
                });

                tabConfig['tbar'] = toolbar;
            }



            // 此函数源代码定义在：extjs_builder\js\F\F.util.js

            // 初始化主框架中的树(或者Accordion+Tree)和选项卡互动，以及地址栏的更新
            // treeMenu： 主框架中的树控件实例，或者内嵌树控件的手风琴控件实例
            // mainTabStrip： 选项卡实例
            // updateHash: 切换Tab时，是否更新地址栏Hash值（默认值：true）
            // refreshWhenExist： 添加选项卡时，如果选项卡已经存在，是否刷新内部IFrame（默认值：false）
            // refreshWhenTabChange: 切换选项卡时，是否刷新内部IFrame（默认值：false）
            // maxTabCount: 最大允许打开的选项卡数量
            // maxTabMessage: 超过最大允许打开选项卡数量时的提示信息
            F.initTreeTabStrip(treeMenu, mainTabStrip, {
                createToolbar: createToolbar,
                maxTabCount: 10,
                maxTabMessage: '请先关闭一些选项卡（最多允许打开 10 个）！'
            });


            // 添加示例标签页
            window.addExampleTab = function (id, iframeUrl, title, icon, refreshWhenExist) {
                // 动态添加一个标签页
                // mainTabStrip： 选项卡实例
                // id： 选项卡ID
                // iframeUrl: 选项卡IFrame地址 
                // title: 选项卡标题
                // icon： 选项卡图标
                // createToolbar： 创建选项卡前的回调函数（接受tabConfig参数）
                // refreshWhenExist： 添加选项卡时，如果选项卡已经存在，是否刷新内部IFrame
                F.addMainTab(mainTabStrip, {
                    id: id,
                    iframeUrl: iframeUrl,
                    title: title,
                    icon: icon,
                    refreshWhenExist: refreshWhenExist
                });
            };

            // 移除选中标签页
            window.removeActiveTab = function () {
                var activeTab = mainTabStrip.getActiveTab();
                mainTabStrip.removeTab(activeTab.id);
            };



            // 添加工具图标，并在点击时显示上下文菜单
            // 专业版提醒：请将 type:'gear' 改为 iconFont:'gear'
            leftPanel.addTool({
                type: 'gear',
                //tooltip: '系统设置',
                handler: function (event) {
                    menuSettings.showBy(this);
                }
            });

        });


    </script>
</body>
</html>
