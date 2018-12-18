/*
 *------------------------------------------------------------------
 模块描述说明：
 用户管理功能模块js文件
 作者：李天赐
 时间：2018-10-12 16:28:53
 ----------------------------------------------------------------- */
var service = service || {};

(function () {
    var SystemService = function (serviceName) {
        this.name = serviceName || "UnnamedService";
        this.pageSzie = 10;
    };

    SystemService.prototype.dto = {
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

    SystemService.prototype.io = {
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

    service.admin = service.admin || new SystemService("admin-service");
})();