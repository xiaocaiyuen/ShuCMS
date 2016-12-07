/*小图根路径*/
var uploadPath_X = "";

/*结果值*/
var list_result = "";
/*图片ID自增*/
var imgListID = 0;

/*文件控件对象ID*/
var text_clientID;
/*是否多选*/
var is_select_more = false;
/*图片控件对象ID*/
var img_clientID;

/*隐藏控件*/
var hid_imglist_id = "";
var hid_imgtxtlist_id = "";

/*调用入口*/
function selectFile(more, txt_ID, img_ID) {
    is_select_more = more; /*是否多选*/
    text_clientID = txt_ID; /*文件控件对象ID*/
    img_clientID = img_ID; /*图片控件对象ID*/

    browseFile();
}

/*弹出选择窗口*/
function browseFile() {
    var finder = new CKFinder();
    finder.basePath = '/upload/';
    finder.selectActionFunction = setValue;
    finder.popup();
}

/*回发设置值*/
function setValue(resultText) {
    /*存在对象与返回结果*/
    if (resultText) {
        if (is_select_more) {
            /*多选择*/
            setFieldMore(resultText);
        } else {
            /*单选择*/
            //clientObject.value = resultText;
            setField(resultText, text_clientID, img_clientID);
        }
    }
}




/*多选择设置*/
function setFieldMore(resultText) {
    list_result = resultText;
    loadImgList();
    /*关闭弹层*/
    //$.jBox.close();
}

/*加载多图*/
function loadImgList() {
    var obj = document.getElementById(hid_imglist);
    if (!obj) {
        return;
    }
    if (obj.value == "") {
        obj.value = list_result;
    } else {
        if (list_result != "") {
            obj.value += "|" + list_result;
        }
    }

    /*图片过滤||*/
    for (var k = 0; k < obj.value.split("||").length; k++) {
        var reg = new RegExp(/\|\|+/);
        obj.value = obj.value.replace(reg, "|");
    }
    if (obj.value.indexOf('|') == 0) {
        obj.value = obj.value.substring(obj.value.indexOf('|') + 1, obj.value.length);
    }
    createImg(obj.value);
}

/*创建图片列表*/
function createImg(objValue, txtValue) {
    var txtValue = document.getElementById(hid_imgtxtlist).value;
   
    if (objValue == "") {
        return;
    }
    imgdivlist.innerHTML = "";
    var strTemp = "";
    var urlAry = objValue.split("|");
    var txtAry = txtValue.split("|");
    var txtValue = "";
    for (var i = 0; i <= urlAry.length; i++) {
        if (!urlAry[i] || urlAry[i] == "" || urlAry[i] == "undefined") {
            continue;
        }
        txtValue = "";
        if (txtAry[i] && txtAry[i] != "") {
            txtValue = txtAry[i];
        }
        /*保存同一图片出现次数*/
        var imgSrc = urlAry[i];
        var alt = imgSrc.substring(imgSrc.lastIndexOf('/') + 1);
        strTemp += urlAry[i];
        $("<li id=\"img_list" + imgListID + "\"><table cellpadding='0' cellspacing='0' border='0'><tr><td><a id='a_imglist_" + i + "' href='" + uploadPath_X + imgSrc + "' target='_blank'><img alt=\"" + alt + "\" src=\"" + uploadPath_X + imgSrc + "\" onerror=\"this.src='../images/NoPic.jpg'\" width=\"100\" height=\"100\" style=\"border: 1px solid #ccc; padding: 2px;\" align=\"absmiddle\" /></a></td><td><textarea id='txt_list" + imgListID + "' name='img_txt' rows='7' cols='14' class='textareabox'>" + txtValue + "</textarea></td></tr><tr><td></td><td><div><span><a href=\"\"></a></span><span><a href='javascript:;' onclick=\"javascript:remove_list('img_list" + imgListID + "','" + urlAry[i] + "'," + (strTemp.split(urlAry[i]).length - 1) + ");\">删除</a></span></div></td></tr></table></li>").appendTo(imgdivlist);
        imgListID++;
    }
}

/*删除多附件其中一个*/
function remove_list(obj, imgurl, index) {
    var hobj = document.getElementById(hid_imglist);
    var txtObj = document.getElementById(hid_imgtxtlist);
    if (!hobj || hobj.value == "") {
        return;
    }

    /*更新图片列表*/
    var imgAry = hobj.value.split(imgurl);
    hobj.value = "";
    for (var i = 0; i < imgAry.length; i++) {
        if (imgAry[i] == "" && (i == (imgAry.length - 1))) {
            continue;
        }
        if ((index) == (i + 1)) {
            hobj.value += imgAry[i];
        } else {
            if ((i == (imgAry.length - 1))) {
                hobj.value += imgAry[i];
            } else {
                hobj.value += imgAry[i] + imgurl;
            }
        }
    }

    /*图片过滤||*/
    for (var k = 0; k < hobj.value.split("||").length; k++) {
        var reg = new RegExp(/\|\|+/);
        hobj.value = hobj.value.replace(reg, "|");
    }
    if (hobj.value.lastIndexOf('|') + 1 == hobj.value.length) {
        hobj.value = hobj.value.substring(hobj.value.lastIndexOf('|'), 0);
    }
    if (hobj.value.indexOf('|') == 0) {
        hobj.value = hobj.value.substring(hobj.value.indexOf('|') + 1, hobj.value.length);
    }

    $("#" + obj + "").remove();
    loadTxtList();
    createImg(hobj.value);
}

/*定时执行加载图片说明*/
function loadTxtList() {
    var txtObj = document.getElementById(hid_imgtxtlist);
    var txtAry = document.getElementsByName("img_txt");
    txtObj.value = "";
    for (var i = 0; i < txtAry.length; i++) {
        txtObj.value += txtAry[i].value + "|";
    }
}

