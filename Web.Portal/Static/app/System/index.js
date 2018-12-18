/*
 *------------------------------------------------------------------
 模块描述说明：
 用户管理功能模块对于的js文件
 作者：张三
 时间：2016-4-29 11:33:54
 ----------------------------------------------------------------- */
var service = service || {};

(function () {
    var AdminService = function (serviceName) {
        this.name = serviceName || "UnnamedService";
        this.pageSzie = 10;
    };

    AdminService.prototype.dto = {
        // dto
        SysRoleDto: function () {
            this.Id = 0;
            this.Name = '';
            this.Mark = '';
            this.SysFuncs = [];
            this.SubSystems = [];
            this.Number = '';
        },
        // dto 
        SysRoleItemDto: function () {
            this.Id = 0;
            this.Name = '';
            this.Mark = '';
            this.SysFuncs = [];
            this.SubSystems = [];
            this.CreatorUserName = '';
            this.CreationTime = '';
            this.SysUsers = 0;
        }
    };

    AdminService.prototype.io = {
        // 获得所有权限集合 
        getSysRoles: function (page) {
            var _page = page || 1;

            return $.ajax({
                url: '/Admin/GetSysRoles',
                data: {
                    "page": _page,
                    "pageSzie": this.pageSzie
                },
                type: "GET",
                cache: false
            }).then(function (res) {
                return res;
            }, function () {
                return wikitec.EmtpyPagedResult;
            });
        },
        // 修改角色信息
        modifySysRole: function (model) {
            return $.ajax({
                url: '/Admin/ModifyRole',
                data: {
                    "sysRoleDto": model
                },
                type: "POST",
                cache: false
            });
        }
    };

    service.admin = service.admin || new AdminService("admin-service");
})();