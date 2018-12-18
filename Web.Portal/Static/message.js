/*!
 * 网络学院工具类文档注释
 *Include
 *jquery 、layer
 * waterfall - v1.0.0 (2013-03-15T14:55:51+0800)
 * http://jraiser.org/ | Released under MIT license
 */

var stluciabj = window.stluciabj || {};

/*响应操作消息相关功能
@info：操作的详细描述
@title：标题描述
 */
stluciabj.Msg = new function () {

    var self = this;
    toastr.options = {
        "closeButton": true,
        "debug": true,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "showDuration": "400",
        "hideDuration": "1000",
        "timeOut": "3000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }

    //操作成功的提示
    self.showSuccess = function (info, title) {
        toastr.success(info || "您的操作已经成功完成", title || "操作成功！");
    };

    //操作成功的提示
    self.showError = function (info, title) {
        toastr.error(info || "抱歉，您的操作失败！", title || "操作失败！");
    };

    //操作成功的提示
    self.showInfo = function (info, title) {
        toastr.info(info || "显示信息详细信息！", title || "信息标题！");
    };

    //操作成功的提示
    self.showWarning = function (info, title) {
        toastr.warning(info || "显示信息详细信息！", title || "信息标题！");
    };
};


/*
  其他工具辅助类
 */
stluciabj.Toolkit = new function () {

    var self = this;

    /**
   * 验证手机号码
   * @method
   * @param {str}待验证字符串
   * @return {bool} 是否验证成功
   */
    self.validatePhone = function validatePhone(str) {
        if (!(/^1[34578]\d{9}$/.test(str))) {
            return false;
        } else {
            return true;
        }
    }


    /**
     * 动态的新增url参数，在支持h5属性的浏览器下不刷新当前页面
     * @method
     * @param {name} 参数名称
     * @param {value}参数值
     * @return {Element} 指定元素
     */
    self.addUrlPara = function (name, value) {
        var newUrl = '';
        var currentUrl = window.location.href.split('#')[0];
        if (/\?/g.test(currentUrl)) {
            if (/name=[-\w]{4,25}/g.test(currentUrl)) {
                currentUrl = currentUrl.replace(/name=[-\w]{4,25}/g, name + "=" + value);
            } else {
                currentUrl += "&" + name + "=" + value;
            }
        } else {
            currentUrl += "?" + name + "=" + value;
        }

        if (window.location.href.split('#')[1]) {
            newUrl = currentUrl + '#' + window.location.href.split('#')[1];
        } else {
            newUrl = currentUrl;
        }
        if (window.history.pushState) {
            window.history.pushState(null, null, newUrl);
        } else {
            window.location = newUrl;
        }
    }

};

stluciabj.Validator = new function () {
    var self = this;
    // 表单是否符合验证规则
    self.isValid = function (fromId) {
        $(fromId).data('bootstrapValidator').validate();
        return $(fromId).data('bootstrapValidator').isValid();
    }

}