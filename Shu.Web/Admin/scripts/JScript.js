function onReady() {

    var treeMenu = Ext.getCmp(DATA.treeMenu),
        regionPanel = Ext.getCmp(DATA.regionPanel),
        regionTop = Ext.getCmp(DATA.regionTop),
        //btnShowHideHeader = Ext.getCmp(DATA.btnShowHideHeader),
        mainTabStrip = Ext.getCmp(DATA.mainTabStrip),
        txtUser = Ext.getCmp(DATA.txtUser),
        txtOnlineUserCount = Ext.getCmp(DATA.txtOnlineUserCount),
        //txtCurrentTime = Ext.getCmp(DATA.txtCurrentTime),
        btnRefresh = Ext.getCmp(DATA.btnRefresh);

//    var btnExpandAll = Ext.getCmp(IDS.btnExpandAll);
//    var btnCollapseAll = Ext.getCmp(IDS.btnCollapseAll);

//    // 点击全部展开按钮
//    btnExpandAll.on('click', function () {
//        if (IDS.menuType == "menu") {
//            mainMenu.expandAll();
//        } else {
//            var expandedPanel = getExpandedPanel();
//            if (expandedPanel) {
//                expandedPanel.items.itemAt(0).expandAll();
//            }
//        }
//    });

//    // 点击全部折叠按钮
//    btnCollapseAll.on('click', function () {
//        if (IDS.menuType == "menu") {
//            mainMenu.collapseAll();
//        } else {
//            var expandedPanel = getExpandedPanel();
//            if (expandedPanel) {
//                expandedPanel.items.itemAt(0).collapseAll();
//            }
//        }
//    });




    // 欢迎信息
    txtUser.setText('欢迎您：<span class="highlight">' + DATA.userName + '</span>&nbsp;&nbsp; 登录IP：' + DATA.userIP);
    txtOnlineUserCount.setText('在线用户：' + DATA.onlineUserCount);
    // 点击刷新按钮
    btnRefresh.on('click', function () {
        //var iframeNode = getCurrentIFrameNode(this);
        //iframeNode[0].contentWindow.location.reload();
        alert(22);
        var iframe = Ext.DomQuery.selectNode('iframe', mainTabStrip.getActiveTab().body.dom);
        
        //iframe.src = iframe.src;
        iframe.contentWindow.location.reload();
    });
    X.util.initTreeTabStrip(treeMenu, mainTabStrip);
}